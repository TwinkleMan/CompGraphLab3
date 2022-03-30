using System;

namespace CompGraphLab3.Engine
{
    class BezieCalc
    {

        int Factorial(int n)
        {
            int f = n;

            if (f == 0)
                return 1;

            for (int i = 1; i < n; i++)
            {
                f *= i;
            }
            return f;
        }

        Point3D Derivative(Point3D[] points, float t)
        {
            Point3D curve = new Point3D(0, 0, 0);
            for (int i = 0; i < points.Length; i++)
            {
                Point3D c = points[i] * Factorial(points.Length - 1) / (Factorial(i) * Factorial(points.Length - 1 - i));
                if (i > 1)
                {
                    curve += c * i * (float)Math.Pow(t, i - 1) * (float)Math.Pow(1 - t, points.Length - 1 - i);
                }
                if (points.Length - 1 - i > 1)
                {
                    curve -= c * (float)Math.Pow(t, i) * (points.Length - 1 - i) * (float)Math.Pow(1 - t, points.Length - 2 - i);
                }
            }
            return curve;
        }

        private float GetBezieStik(float u, int i, int size)
        {
            float result = 0.0f;
            float temp = (float)Math.Pow(u, i);
            float temp2 = (float)Math.Pow(1 - u, size - i);
            float bottom = (Factorial(i) * Factorial(size - i)) * (float)Math.Pow(u, i) * (float)Math.Pow(1 - u, size - i);

            result = Factorial(size-1) / (Factorial(i) * Factorial(size-1 - i)) * (float)Math.Pow(u, i) * (float)Math.Pow(1 - u, size-1 - i);

            return result;
        }

        public Point3D CurveBezie(Point3D[] points, float u)
        {
            Point3D curve = new Point3D(0, 0, 0);
            float filtered_u = 0.0f;

            if ((u > 1.0f) && (u - 1.0f < 0.005))
            {
                filtered_u = 1.0f;
            }
            else filtered_u = u;

            for (int i = 0; i < points.Length; i++)
            {
                //Factorial(points.Length - 1) / (Factorial(i) * Factorial(points.Length - 1 - i)) * (float)Math.Pow(u, i) * (float)Math.Pow(1 - u, points.Length - 1 - i);
                curve += points[i] * GetBezieStik(filtered_u, i, points.Length);
            }
            return curve;
        }

        public Point3D GetPatchPoint(Point3D[,] points, float u, float v)
        {
            Point3D patch = new Point3D(0, 0, 0);
            float filtered_v;
            float filtered_u;
            

            if ((u > 1.0f) && (u - 1.0f < 0.005))
            {
                filtered_u = 1.0f;
            }
            else filtered_u = u;
            if ((v > 1.0f) && (v - 1.0f < 0.005))
            {
                filtered_v = 1.0f;
            }
            else filtered_v = v;


            for (int i = 0; i < points.GetLength(0); i++)
            {
                for (int j = 0; j < points.GetLength(0); j++)
                {
                    patch += points[i,j] * GetBezieStik(filtered_u, i, points.GetLength(0)) * GetBezieStik(filtered_v, j, points.GetLength(0));
                }
                
            }

            return patch;
        }


        public float TimeBezier(Point3D[] points, float x, float e = 0.0001f)
        {
            float u = 0.5f;
            float h = (CurveBezie(points, u).GetX() - x) / (Derivative(points, u).GetX() - 1);
            while (Math.Abs(h) >= e)
            {
                h = (CurveBezie(points, u).GetX() - x) / (Derivative(points, u).GetX() - 1);
                u -= h;
            }
            return u;
        }


        public Point3D[,] MatrixMultiply(Point3D[] coordLine, float[,] transformMatrix)
        {

            //M == matrix.GetLength(0), N = matrix.GetLength(1)

            Point3D[,] result = new Point3D[coordLine.GetLength(0), coordLine.GetLength(0)];
            float[] input1, input2;
            float[] temp = new float[coordLine.GetLength(0)*3];
            float tempCalc = 0;


            //convert input to line array
            input1 = new float[coordLine.GetLength(0) * 3];
            for (int i = 0; i < coordLine.GetLength(0); ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    input1[i * 3 + j] = GetXYZ(j,coordLine[i]);
                }
            }


            input2 = new float[9];
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    input2[i * 3 + j] = transformMatrix[i, j];
                }
            }


            //matrix multiplication
            for (int i = 0; i < coordLine.GetLength(0); ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        float temp1 = input1[i * 3 + k];
                        float temp2 = input2[k * 3 + j];
                        float temp3 = input1[i * 3 + k] * input2[k * 3 + j];
                        tempCalc += input1[i * 3 + k] * input2[k * 3 + j];
                    }
                    temp[i * 3 + j] = tempCalc;
                    tempCalc = 0.0f;

                }
            }


            //assemblying the output
            result = BuildPointArray(temp, Convert.ToInt32(Math.Sqrt(coordLine.GetLength(0))));

            return result;
        }

        private float GetXYZ(int count, Point3D point)
        {
            if (count == 0) return point.GetX();
            if (count == 1) return point.GetY();
            if (count == 2) return point.GetZ();

            else return 0;
        }

        private Point3D[,] BuildPointArray(float[] array, int size)
        {
            Point3D[,] result = new Point3D[size,size];

            for (int i = 0, k = 0; i < size; ++i)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (l == 0)
                        {
                            result[i, j].SetX(array[k++]);
                        }
                        else if (l == 1)
                        {
                            result[i, j].SetY(array[k++]);
                        }
                        else
                        {
                            result[i, j].SetZ(array[k++]);
                        }
                    }
                }
            }

            return result;
        }

        public Point3D[,] Rotate(BeziePatch patch, float angle, int axis)
        {
            float minNumber = 0.0001f;
            double angelRadians = angle * Math.PI / 180;
            Point3D[] matrix = patch.GetAnchorsRow();
            float cosphi = (float)Math.Cos(angelRadians);
            float sinphi = (float)Math.Sin(angelRadians);
            float[,] transform = null;
            Point3D[,] result;

            if (Math.Abs(cosphi) < minNumber) cosphi = 0;
            if (Math.Abs(sinphi) < minNumber) sinphi = 0;

            if (axis == 0)
            {
                transform = new float[,] { { 1, 0, 0 }, { 0, cosphi, sinphi }, { 0, -sinphi, cosphi }};
            }
            if (axis == 1)
            {
                transform = new float[,] { { cosphi, 0, -sinphi }, { 0, 1, 0 }, { sinphi, 0, cosphi }};
            }
            
            result = MatrixMultiply(matrix, transform);
            return result;
        }

        public void MoveObject(BeziePatch patch, float moveX, float moveY, float moveZ)
        {
            Point3D[,] pointMatrix = patch.GetAnchors();
            int size = pointMatrix.GetLength(0);

            for (int i = 0, k = 0; i < size; ++i)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (l == 0)
                        {
                            pointMatrix[i, j].SetX(pointMatrix[i, j].GetX() + moveX);
                        }
                        else if (l == 1)
                        {
                            pointMatrix[i, j].SetY(pointMatrix[i, j].GetY() + moveY);
                        }
                        else
                        {
                            pointMatrix[i, j].SetZ(pointMatrix[i, j].GetZ() + moveZ);
                        }
                    }
                }
            }

        }

    }
}
