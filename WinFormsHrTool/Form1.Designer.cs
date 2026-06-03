namespace WinFormsHrTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtDepartment = new TextBox();
            txtSalary = new TextBox();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 36);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(243, 36);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 1;
            label2.Text = "Department:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(530, 36);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 2;
            label3.Text = "Salary:";
            label3.Click += label3_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(77, 33);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 3;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(356, 33);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(150, 31);
            txtDepartment.TabIndex = 4;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(595, 33);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(150, 31);
            txtSalary.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(778, 31);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(139, 34);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "add Employee";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(900, 513);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 668);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(txtSalary);
            Controls.Add(txtDepartment);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtDepartment;
        private TextBox txtSalary;
        private Button btnAdd;
        private DataGridView dataGridView1;
    }
}
