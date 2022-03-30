using System;
using System.Windows.Forms;
using CompGraphLab3.Engine;
using SharpGL;
using SharpGL.Enumerations;

namespace CompGraphLab3
{
    public partial class Form1 : Form
    {
        Point3D[] points;
        BeziePatch bezie;
        BezieCalc bezieCalc;
        OpenGL gl;
        private int axis = -1;
        private float angle = 0;

        private float angleDebug = 0;

        public Form1()
        {
            InitializeComponent();

            bezieCalc = new BezieCalc();
            points = new Point3D[9];
            bezie = new BeziePatch(3);
            //row 1
            points[0] = new Point3D(50, 50, 0);
            points[1] = new Point3D(150, 10, 0);
            points[2] = new Point3D(250, 50, 0);

            //row 2
            points[3] = new Point3D(50, 150, 0);
            points[4] = new Point3D(150, 150, 0);
            points[5] = new Point3D(450, 150, 0);

            //row3
            points[6] = new Point3D(10, 300, 0);
            points[7] = new Point3D(150, 250, 0);
            points[8] = new Point3D(250, 350, 0);


            ////micro square
            //points = new Point3D[4];
            //bezie = new BeziePatch(2);
            //points[0] = new Point3D(50, 50, 0);
            //points[1] = new Point3D(150, 50, 0);

            //points[2] = new Point3D(70, 70, 20);
            //points[3] = new Point3D(170, 70, 20);


            //small square
            ////row 1
            //points[0] = new Point3D(50, 50, 0);
            //points[1] = new Point3D(100, 50, 0);
            //points[2] = new Point3D(150, 50, 0);

            ////row 2
            //points[3] = new Point3D(50, 100, 0);
            //points[4] = new Point3D(100, 100, 0);
            //points[5] = new Point3D(150, 100, 0);

            ////row3
            //points[6] = new Point3D(50, 150, 0);
            //points[7] = new Point3D(100, 150, 0);
            //points[8] = new Point3D(150, 150, 0);


            ////big square
            ////row 1
            //points[0] = new Point3D(50, 50, 0);
            //points[1] = new Point3D(150, 50, 0);
            //points[2] = new Point3D(250, 50, 0);

            ////row 2
            //points[3] = new Point3D(50, 150, 0);
            //points[4] = new Point3D(150, 150, 0);
            //points[5] = new Point3D(250, 150, 0);

            ////row3
            //points[6] = new Point3D(50, 250, 0);
            //points[7] = new Point3D(150, 250, 0);
            //points[8] = new Point3D(250, 250, 0);

            bezie.SetAnchors(points);
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            Point3D temp,temp2;
            int count = 0;
            gl = this.openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);


            //drawing x axis
            gl.Color(0, 1, 0);
            gl.PointSize(5.0f);
            gl.Begin(BeginMode.Lines);
            gl.Vertex(0.0f,0.0f,0.0f);
            gl.Vertex(200.0f,0.0f,0.0f);
            gl.End();

            //drawing y axis
            gl.Color(1,0,0);
            gl.Begin(BeginMode.Lines);
            gl.Vertex(0.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 200.0f, 0.0f);
            gl.End();

            //drawing z axis
            gl.Color(0, 0, 1);
            gl.Begin(BeginMode.Lines);
            gl.Vertex(0.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 200.0f);
            gl.End();

            gl.Color(1.0f, 1.0f, 1.0f);
            //drawing points
            gl.PointSize(5);
            gl.Begin(BeginMode.Points);
            //gl.Vertex(0.0f,0.0f,0.0f);
            for (int i = 0; i < points.Length; i++)
            {
                gl.Vertex(points[i].GetX(), points[i].GetY(), points[i].GetZ());
            }
            gl.End();
            
            //drawing dashed lines
            for (int i = 0; i < bezie.GetSize(); i++)
            {
                gl.LineStipple(1, 0x000F);
                gl.Enable(OpenGL.GL_LINE_STIPPLE);
                gl.Begin(BeginMode.LineStrip);
                for (int j = 0; j < bezie.GetSize(); j++)
                {
                    Point3D tempPoint = bezie.GetAnchors()[i, j];
                    gl.Vertex(tempPoint.GetX(), tempPoint.GetY(), tempPoint.GetZ());
                }
                gl.End();


                gl.LineStipple(1, 0x00FF);
                gl.Begin(BeginMode.Lines);
                if (i != bezie.GetSize() - 1)
                {
                    for (int j = 0; j < bezie.GetSize(); j++)
                    {
                        Point3D tempPoint = bezie.GetAnchors()[i, j];
                        gl.Vertex(tempPoint.GetX(), tempPoint.GetY(), tempPoint.GetZ());

                        tempPoint = bezie.GetAnchors()[i + 1, j];
                        gl.Vertex(tempPoint.GetX(), tempPoint.GetY(), tempPoint.GetZ());
                    }
                }

                gl.End();
            }

            //drawing bezie patch
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Disable(OpenGL.GL_LINE_STIPPLE);
            int arrSize = Convert.ToInt32(1.03f / 0.05f);
            Point3D[,] pointArr = new Point3D[2,arrSize];
            int lineCount = 0;

            for (float u = 0.0f; u < 1.03f; u += 0.05f)
            {
                gl.Begin(BeginMode.LineStrip);
                for (float v = 0.0f; v < 1.03f; v += 0.05f)
                {
                    temp2 = bezieCalc.GetPatchPoint(bezie.GetAnchors(),u,v);
                    gl.Vertex(temp2.GetX(), temp2.GetY(), temp2.GetZ());
                    pointArr[lineCount,count] = temp2;
                    //Console.WriteLine($"Point {count}: X = {temp.GetX()}, Y = {temp.GetY()}, Z = {temp.GetZ()}");
                    count++;
                }
                //Console.WriteLine("segment done!");
                gl.End();

                count = 0;
                lineCount++;
                if (lineCount == 2)
                {
                    lineCount = 1;

                    //Console.WriteLine($"GetLength(0) = {pointArr.GetLength(0)}, GetLength(1) = {pointArr.GetLength(1)}");
                    gl.Begin(BeginMode.Lines);
                    for (int i = 0; i < pointArr.GetLength(1); i++)
                    {
                        for (int j = 0; j < pointArr.GetLength(0); j++)
                        {
                            gl.Vertex(pointArr[j,i].GetX(), pointArr[j,i].GetY(), pointArr[j,i].GetZ());
                        }
                    }
                    gl.End();

                    pointArr = DeleteLine(pointArr);
                }

            }
            gl.Flush();
        }

        Point3D[,] DeleteLine(Point3D[,] array)
        {
            Point3D[,] result = new Point3D[array.GetLength(0),array.GetLength(1)];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                result[0,i] = array[1,i];
            }

            return result;
        }

        void Reshape()
        {
            //gl.Viewport(0, 0, 800, 450);
            //gl.MatrixMode(OpenGL.GL_PROJECTION);
            //gl.LoadIdentity();
            //gl.Ortho2D(0, 800, 0, 450);
            
            gl.Rotate(1.0f, 0, 0);
        }

        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL instance.
            var gl = this.openGLControl1.OpenGL;
            //gl.Translate(-1.5f, 10.0f, -4.0f);
            //gl.Translate(220.0f, 30.0f, 0.0f);

            //  Create an orthographic projection.
            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Ortho(0, this.openGLControl1.Width, this.openGLControl1.Height, 0, -450.0f, 450.0f);

            //  Back to the modelview.
            gl.MatrixMode(MatrixMode.Modelview);
            //gl.Perspective(45.0f, (double)Width / (double)Height, -450, 1000.0);
            //gl.Viewport(55, -50, openGLControl1.Width, openGLControl1.Height);
            gl.LookAt(0, 0, 5.0, 0, 0, 0, 0, 1.0, 0);
            gl.LoadIdentity();
            

            Console.WriteLine($"Height = {this.openGLControl1.Height}, width = {this.openGLControl1.Width}");
        }


        //private void openGLControl1_Resized(object sender, EventArgs e)
        //{
        //    //  Get the OpenGL instance.
        //    var gl = this.openGLControl1.OpenGL;


        //    float cX = 220, cY = 170, cZ = 20;
        //    float diam = 220.0f;
        //    float zNear = 1.0f, zFar = zNear + diam;
        //    float left = cX - diam, right = cX + diam;
        //    float bottom = cY - diam, top = cY + diam;

        //    float aspect = (float)openGLControl1.Width / openGLControl1.Height;
        //    if (aspect < 1.0)
        //    {
        //        //window taller than wide
        //        bottom /= aspect;
        //        top /= aspect;
        //    } else
        //    {
        //        left *= aspect;
        //        right *= aspect;
        //    }

        //    gl.MatrixMode(MatrixMode.Projection);
        //    gl.LoadIdentity();
        //    gl.Ortho(left,right,bottom,top,zNear,zFar);
        //    gl.MatrixMode(MatrixMode.Modelview);
        //    gl.LoadIdentity();
        //    //gl.LookAt(0.0, 0.0, -20.0f, cX, cY, cZ, 1.0, 1.0, 1.0);

        //    Console.WriteLine($"Height = {this.openGLControl1.Height}, width = {this.openGLControl1.Width}");
        //}

        private void x_btn_Click(object sender, EventArgs e)
        {
            axis = 0;
            axisLbl.Text = "X";
            angleDebug = 0;
        }

        private void y_btn_Click(object sender, EventArgs e)
        {
            axis = 1;
            axisLbl.Text = "Y";
            angleDebug = 0;
        }

        private void angleDecreaseBtn_Click(object sender, EventArgs e)
        {
            GetAngle();
            angle = -angle;
            angleDebug += angle;

            lbl_angleDebug.Text = Convert.ToString(angleDebug);
            Rotate();
            angle = -angle;
            openGLControl1.DoRender();
        }

        private void angleIncreaseBtn_Click(object sender, EventArgs e)
        {
            GetAngle();
            angleDebug += angle;

            lbl_angleDebug.Text = Convert.ToString(angleDebug);
            Rotate();
            angle = Math.Abs(angle);
            openGLControl1.DoRender();
        }

        private void GetAngle()
        {
            try
            {
                angle = float.Parse(angle_textbox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input format!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Rotate()
        {
            if (axis == -1)
            {
                MessageBox.Show("Rotation axis is not selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bezie.SetAnchors(bezieCalc.Rotate(bezie,angle,axis));
            points = bezie.GetAnchorsRow();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            points = new Point3D[9];
            bezie = new BeziePatch((int)Math.Sqrt(points.Length));

            points[0] = new Point3D(50, 50, 0);
            points[1] = new Point3D(150, 10, 0);
            points[2] = new Point3D(250, 50, 0);

            //row 2
            points[3] = new Point3D(50, 150, 0);
            points[4] = new Point3D(150, 150, 0);
            points[5] = new Point3D(450, 150, 0);

            //row3
            points[6] = new Point3D(10, 300, 0);
            points[7] = new Point3D(150, 250, 0);
            points[8] = new Point3D(250, 350, 0);

            bezie.SetAnchors(points);
            openGLControl1.DoRender();
            axis = -1;
            axisLbl.Text = Convert.ToString(0);
            angle_textbox.Text = Convert.ToString(0);

        }

        public void SetNewSkeleton(Point3D[] newSkeleton)
        {
            points = newSkeleton;
            bezie = new BeziePatch((int)Math.Sqrt(points.Length));
            bezie.SetAnchors(points);
            openGLControl1.DoRender();
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SkeletonCreation skeletonCreation = new SkeletonCreation();
            skeletonCreation.Show(this);
        }





        private void MovePointOfView(float x, float y, float z)
        {
            var gl = this.openGLControl1.OpenGL;

            gl.MatrixMode(MatrixMode.Modelview);
            gl.LoadIdentity();

            double midX,midY, midZ;
            midX = points[4].GetX();
            midY = points[4].GetY();
            midZ = points[4].GetZ();

            gl.LookAt(x, y, z, 0, 0, 0, 0, 1, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bezieCalc.MoveObject(bezie,(float)Convert.ToDouble(textBox1.Text), (float)Convert.ToDouble(textBox2.Text), (float)Convert.ToDouble(textBox3.Text));
            points = bezie.GetAnchorsRow();
            openGLControl1.DoRender();
        }
    }
}
