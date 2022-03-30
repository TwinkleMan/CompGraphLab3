using System;

namespace CompGraphLab3.Engine
{
    public struct BeziePatch
    {
        private float minNumber;
        private int rows;

        private Point3D[,] anchors;

        public BeziePatch(int size)
        {
            anchors = new Point3D[size, size];
            rows = size;
            minNumber = 0.0001f;
        }

        public void SetAnchors(Point3D[,] newAnchors)
        {
            minNumber = 0.0001f;
            if (newAnchors == null)
            {
                anchors = newAnchors;
            }
            rows = newAnchors.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (Math.Abs(newAnchors[i, j].GetX()) < minNumber) newAnchors[i, j].SetX(0);
                    if (Math.Abs(newAnchors[i, j].GetY()) < minNumber) newAnchors[i, j].SetY(0);
                    if (Math.Abs(newAnchors[i, j].GetZ()) < minNumber) newAnchors[i, j].SetZ(0);
                    anchors[i,j] = newAnchors[i, j];
                }
            }
        }
        public Point3D[,] GetAnchors()
        {
            return anchors;
        }
        public Point3D[] GetAnchorsRow(int rowNum)
        {
            Point3D[] row = new Point3D[rows];

            for (int i = 0; i < rows; i++)
            {
                row[i] = anchors[rowNum,i];
            }

            return row;
        }
        public Point3D[] GetAnchorsRow()
        {
            Point3D[] result = new Point3D[rows*rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i*rows+j] = anchors[i, j];
                }
            }

            return result;
        }
        public int GetSize()
        {
            return rows;
        }

        public void SetAnchors(params Point3D[] points)
        {
            minNumber = 0.0001f;
            int count = 0;
            rows = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(points.GetLength(0))));

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    anchors[i, j] = points[count++];
                }
            }
        }
        public void SetAnchor(int number, Point3D point)
        {
            minNumber = 0.0001f;
            int row = number / rows;
            int col = number % rows;

            anchors[row, col] = point;
            rows = anchors.GetLength(0);
        }
    }
}
