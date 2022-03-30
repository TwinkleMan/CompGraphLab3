namespace CompGraphLab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.angle_textbox = new System.Windows.Forms.TextBox();
            this.angle_lbl = new System.Windows.Forms.Label();
            this.angleDecreaseBtn = new System.Windows.Forms.Button();
            this.angleIncreaseBtn = new System.Windows.Forms.Button();
            this.axis_lbl = new System.Windows.Forms.Label();
            this.y_btn = new System.Windows.Forms.Button();
            this.x_btn = new System.Windows.Forms.Button();
            this.axisLbl = new System.Windows.Forms.Label();
            this.axisName_lbl = new System.Windows.Forms.Label();
            this.lbl_angleDebug = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_set = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 10;
            this.openGLControl1.Location = new System.Drawing.Point(12, 12);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControl1.Size = new System.Drawing.Size(770, 440);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.Resized += new System.EventHandler(this.openGLControl1_Resized);
            // 
            // angle_textbox
            // 
            this.angle_textbox.Location = new System.Drawing.Point(183, 473);
            this.angle_textbox.Name = "angle_textbox";
            this.angle_textbox.Size = new System.Drawing.Size(148, 20);
            this.angle_textbox.TabIndex = 2;
            // 
            // angle_lbl
            // 
            this.angle_lbl.AutoSize = true;
            this.angle_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angle_lbl.Location = new System.Drawing.Point(12, 469);
            this.angle_lbl.Name = "angle_lbl";
            this.angle_lbl.Size = new System.Drawing.Size(57, 24);
            this.angle_lbl.TabIndex = 4;
            this.angle_lbl.Text = " Угол";
            // 
            // angleDecreaseBtn
            // 
            this.angleDecreaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.angleDecreaseBtn.Location = new System.Drawing.Point(626, 473);
            this.angleDecreaseBtn.Name = "angleDecreaseBtn";
            this.angleDecreaseBtn.Size = new System.Drawing.Size(75, 56);
            this.angleDecreaseBtn.TabIndex = 5;
            this.angleDecreaseBtn.Text = "-";
            this.angleDecreaseBtn.UseVisualStyleBackColor = true;
            this.angleDecreaseBtn.Click += new System.EventHandler(this.angleDecreaseBtn_Click);
            // 
            // angleIncreaseBtn
            // 
            this.angleIncreaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.angleIncreaseBtn.Location = new System.Drawing.Point(707, 473);
            this.angleIncreaseBtn.Name = "angleIncreaseBtn";
            this.angleIncreaseBtn.Size = new System.Drawing.Size(75, 56);
            this.angleIncreaseBtn.TabIndex = 6;
            this.angleIncreaseBtn.Text = "+";
            this.angleIncreaseBtn.UseVisualStyleBackColor = true;
            this.angleIncreaseBtn.Click += new System.EventHandler(this.angleIncreaseBtn_Click);
            // 
            // axis_lbl
            // 
            this.axis_lbl.AutoSize = true;
            this.axis_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axis_lbl.Location = new System.Drawing.Point(13, 505);
            this.axis_lbl.Name = "axis_lbl";
            this.axis_lbl.Size = new System.Drawing.Size(137, 24);
            this.axis_lbl.TabIndex = 9;
            this.axis_lbl.Text = "Ось поворота";
            // 
            // y_btn
            // 
            this.y_btn.Location = new System.Drawing.Point(260, 509);
            this.y_btn.Name = "y_btn";
            this.y_btn.Size = new System.Drawing.Size(71, 20);
            this.y_btn.TabIndex = 8;
            this.y_btn.Text = "Y";
            this.y_btn.UseVisualStyleBackColor = true;
            this.y_btn.Click += new System.EventHandler(this.y_btn_Click);
            // 
            // x_btn
            // 
            this.x_btn.Location = new System.Drawing.Point(183, 509);
            this.x_btn.Name = "x_btn";
            this.x_btn.Size = new System.Drawing.Size(71, 20);
            this.x_btn.TabIndex = 7;
            this.x_btn.Text = "X";
            this.x_btn.UseVisualStyleBackColor = true;
            this.x_btn.Click += new System.EventHandler(this.x_btn_Click);
            // 
            // axisLbl
            // 
            this.axisLbl.AutoSize = true;
            this.axisLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.axisLbl.Location = new System.Drawing.Point(541, 493);
            this.axisLbl.Name = "axisLbl";
            this.axisLbl.Size = new System.Drawing.Size(20, 24);
            this.axisLbl.TabIndex = 12;
            this.axisLbl.Text = "0";
            // 
            // axisName_lbl
            // 
            this.axisName_lbl.AutoSize = true;
            this.axisName_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.axisName_lbl.Location = new System.Drawing.Point(409, 493);
            this.axisName_lbl.Name = "axisName_lbl";
            this.axisName_lbl.Size = new System.Drawing.Size(126, 24);
            this.axisName_lbl.TabIndex = 11;
            this.axisName_lbl.Text = "Текущая ось:";
            // 
            // lbl_angleDebug
            // 
            this.lbl_angleDebug.AutoSize = true;
            this.lbl_angleDebug.Location = new System.Drawing.Point(464, 473);
            this.lbl_angleDebug.Name = "lbl_angleDebug";
            this.lbl_angleDebug.Size = new System.Drawing.Size(35, 13);
            this.lbl_angleDebug.TabIndex = 13;
            this.lbl_angleDebug.Text = "label1";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(12, 555);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(380, 50);
            this.btn_reset.TabIndex = 14;
            this.btn_reset.Text = "Сброс фигуры";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(402, 555);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(380, 50);
            this.btn_set.TabIndex = 15;
            this.btn_set.Text = "Создать задающий многоугольник";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Сдвиг";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(348, 534);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(454, 534);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 18;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(560, 534);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 617);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lbl_angleDebug);
            this.Controls.Add(this.axisLbl);
            this.Controls.Add(this.axisName_lbl);
            this.Controls.Add(this.axis_lbl);
            this.Controls.Add(this.y_btn);
            this.Controls.Add(this.x_btn);
            this.Controls.Add(this.angleIncreaseBtn);
            this.Controls.Add(this.angleDecreaseBtn);
            this.Controls.Add(this.angle_lbl);
            this.Controls.Add(this.angle_textbox);
            this.Controls.Add(this.openGLControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.TextBox angle_textbox;
        private System.Windows.Forms.Label angle_lbl;
        private System.Windows.Forms.Button angleDecreaseBtn;
        private System.Windows.Forms.Button angleIncreaseBtn;
        private System.Windows.Forms.Label axis_lbl;
        private System.Windows.Forms.Button y_btn;
        private System.Windows.Forms.Button x_btn;
        private System.Windows.Forms.Label axisLbl;
        private System.Windows.Forms.Label axisName_lbl;
        private System.Windows.Forms.Label lbl_angleDebug;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

