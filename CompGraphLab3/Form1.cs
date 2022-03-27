using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompGraphLab3.Engine;
using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph;

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
            //gl.LoadIdentity();
            //gl.Translate(-1.5f, 10.0f, -4.0f);
            gl.PointSize(5.0f);
            gl.Color(1.0f, 1.0f, 1.0f);

            //drawing points
            gl.PointSize(5);
            gl.Begin(BeginMode.Points);
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
            gl.Translate(-1.5f, 10.0f, -4.0f);

            //  Create an orthographic projection.
            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Ortho(0, this.openGLControl1.Width, this.openGLControl1.Height, 0, -10, 10);

            //  Back to the modelview.
            gl.MatrixMode(MatrixMode.Modelview);

            Console.WriteLine($"Height = {this.openGLControl1.Height}, width = {this.openGLControl1.Width}");
        }

        private void x_btn_Click(object sender, EventArgs e)
        {
            axis = 0;
            axisLbl.Text = "X";
        }

        private void y_btn_Click(object sender, EventArgs e)
        {
            axis = 1;
            axisLbl.Text = "Y";
        }

        private void angleDecreaseBtn_Click(object sender, EventArgs e)
        {
            Rotate();
            openGLControl1.DoRender();
        }

        private void angleIncreaseBtn_Click(object sender, EventArgs e)
        {
            Rotate();
            openGLControl1.DoRender();
        }

        private void Rotate()
        {
            if (axis == -1)
            {
                MessageBox.Show("Rotation axis is not selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                angle = float.Parse(angle_textbox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input format!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bezie.SetAnchors(bezieCalc.Rotate(bezie,angle,axis));
            points = bezie.GetAnchorsRow();
        }


    }
}
