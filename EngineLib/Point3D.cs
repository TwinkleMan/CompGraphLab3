namespace EngineLib
{
    public struct Point3D
    {

        private double x;
        private double y;
        private double z;

        public void CreatePoint3D(double x, double y, double z)
        {
            this.x = x; 
            this.y = y; 
            this.z = z;
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public double GetZ()
        {
            return z;
        }

    }
}
