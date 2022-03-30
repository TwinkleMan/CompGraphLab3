namespace CompGraphLab3
{
    partial class SkeletonCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_rowsCount = new System.Windows.Forms.TextBox();
            this.btn_countRows = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_create = new System.Windows.Forms.Button();
            this.Debug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(183, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество точек в ряду матрицы";
            // 
            // txtbox_rowsCount
            // 
            this.txtbox_rowsCount.Location = new System.Drawing.Point(509, 14);
            this.txtbox_rowsCount.Name = "txtbox_rowsCount";
            this.txtbox_rowsCount.Size = new System.Drawing.Size(100, 20);
            this.txtbox_rowsCount.TabIndex = 1;
            // 
            // btn_countRows
            // 
            this.btn_countRows.Location = new System.Drawing.Point(615, 14);
            this.btn_countRows.Name = "btn_countRows";
            this.btn_countRows.Size = new System.Drawing.Size(75, 20);
            this.btn_countRows.TabIndex = 2;
            this.btn_countRows.Text = "Вперед";
            this.btn_countRows.UseVisualStyleBackColor = true;
            this.btn_countRows.Click += new System.EventHandler(this.btn_countRows_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 357);
            this.dataGridView1.TabIndex = 3;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(713, 418);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 25);
            this.btn_create.TabIndex = 4;
            this.btn_create.Text = "Создать";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // Debug
            // 
            this.Debug.AutoSize = true;
            this.Debug.Location = new System.Drawing.Point(131, 424);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(35, 13);
            this.Debug.TabIndex = 5;
            this.Debug.Text = "label2";
            // 
            // SkeletonCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_countRows);
            this.Controls.Add(this.txtbox_rowsCount);
            this.Controls.Add(this.label1);
            this.Name = "SkeletonCreation";
            this.Text = "SkeletonCreation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SkeletonCreation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_rowsCount;
        private System.Windows.Forms.Button btn_countRows;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label Debug;
    }
}