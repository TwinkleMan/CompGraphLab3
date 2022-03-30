using System;
using System.Windows.Forms;
using CompGraphLab3.Engine;

namespace CompGraphLab3
{
    public partial class SkeletonCreation : Form
    {
        private int rows;

        public SkeletonCreation()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            btn_create.Visible = false;
        }

        private void btn_countRows_Click(object sender, EventArgs e)
        {
            try
            {
                rows = int.Parse(txtbox_rowsCount.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input format!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataGridView1.Visible = true;
            btn_create.Visible = true;
            CreateGridSkeleton();
        }

        #region Grid Building

        private void CreateGridSkeleton()
        {
            dataGridView1.ColumnCount = rows;
            dataGridView1.Rows.Add(rows);

            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Columns[i].Name = (i + 1).ToString();
            }

            Debug.Text = $"Number of rows = {dataGridView1.RowCount}";
        }

        private Point3D[] ReadGrid()
        {
            Point3D[] points = new Point3D[rows*rows];
            Point3D buildingPoint = new Point3D();
            string temp;
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    temp = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                    buildingPoint.SetX((float)Convert.ToDouble(temp.Split(',')[0]));
                    buildingPoint.SetY((float)Convert.ToDouble(temp.Split(',')[1]));
                    buildingPoint.SetZ((float)Convert.ToDouble(temp.Split(',')[2]));

                    points[count++] = buildingPoint;
                }
            }

            
            return points;
        }

        #endregion

        private void SkeletonCreation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                ((Form1)Owner).SetNewSkeleton(ReadGrid());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong when creating new skeleton!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Skeleton set succesfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
