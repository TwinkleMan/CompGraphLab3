using CompGraphLab3.Engine;

namespace CompGraphLab3.Engine
{
    public struct Point3D
    {

        /*
         * 
         * Bezie 3rd  -  t^3 + 3*t^2*(1-t) + 3*t*(1-t)^2 + (1-t)^3 = 1
         * 
         * point on curve  -  P1*t^3 + P2*3*t^2*(1-t) + P3*3*t*(1-t)^2 + P4*(1-t)^3 = Pnew
         * 
         */

        private float x, y, z;

        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Point3D operator +(Point3D a, Point3D b) => new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Point3D operator -(Point3D a, float d) => new Point3D(a.x - d, a.y - d, a.z - d);
        public static Point3D operator -(Point3D a, Point3D b) => new Point3D(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Point3D operator *(float d, Point3D a) => new Point3D(a.x * d, a.y * d, a.z * d);
        public static Point3D operator *(Point3D a, float d) => new Point3D(a.x * d, a.y * d, a.z * d);
        public static Point3D operator *(Point3D a, Point3D b) => new Point3D(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Point3D operator /(Point3D a, float d) => new Point3D(a.x / d, a.y / d, a.z / d);
        public static Point3D operator /(Point3D a, Point3D b) => new Point3D(a.x / b.x, a.y / b.y, a.z / b.z);

        //returns basic coords
        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }
        public float GetZ()
        {
            return z;
        }

        public void SetX(float x)
        {
            this.x = x;
        }
        public void SetY(float y)
        {
            this.y = y;
        }
        public void SetZ(float z)
        {
            this.z = z;
        }

        //point addition (+)
        public static Point3D PointAdd(Point3D pointOne, Point3D pointTwo)
        {
            return new Point3D(pointOne.x + pointTwo.x, pointOne.y + pointTwo.y, pointOne.z + pointTwo.z);
        }
        //multiply to a constant
        public static Point3D PointTimes(Point3D point, float constant)
        {
            return new Point3D(point.x * constant, point.y * constant, point.z * constant);
        }

    }
}
