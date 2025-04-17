namespace 定时关闭进程
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
            listBox_closeProcess = new ListBox();
            label1 = new Label();
            label2 = new Label();
            listBox_process = new ListBox();
            button_toRight = new Button();
            button_refresh = new Button();
            button_delete = new Button();
            textBox_searchStr = new TextBox();
            button_closeProcess = new Button();
            dateTimePicker1 = new DateTimePicker();
            checkBox_autoCloseProcess = new CheckBox();
            SuspendLayout();
            // 
            // listBox_closeProcess
            // 
            listBox_closeProcess.FormattingEnabled = true;
            listBox_closeProcess.ItemHeight = 17;
            listBox_closeProcess.Location = new Point(242, 54);
            listBox_closeProcess.Name = "listBox_closeProcess";
            listBox_closeProcess.Size = new Size(156, 157);
            listBox_closeProcess.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(242, 34);
            label1.Name = "label1";
            label1.Size = new Size(104, 17);
            label1.TabIndex = 1;
            label1.Text = "待关闭进程列表：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 34);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 3;
            label2.Text = "当前进程列表：";
            // 
            // listBox_process
            // 
            listBox_process.FormattingEnabled = true;
            listBox_process.ItemHeight = 17;
            listBox_process.Location = new Point(29, 88);
            listBox_process.Name = "listBox_process";
            listBox_process.Size = new Size(156, 123);
            listBox_process.TabIndex = 2;
            // 
            // button_toRight
            // 
            button_toRight.Location = new Point(191, 109);
            button_toRight.Name = "button_toRight";
            button_toRight.Size = new Size(45, 23);
            button_toRight.TabIndex = 4;
            button_toRight.Text = ">>";
            button_toRight.UseVisualStyleBackColor = true;
            button_toRight.Click += button_toRight_Click;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(29, 217);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(75, 23);
            button_refresh.TabIndex = 5;
            button_refresh.Text = "刷新";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // button_delete
            // 
            button_delete.Location = new Point(283, 217);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(75, 23);
            button_delete.TabIndex = 6;
            button_delete.Text = "删除";
            button_delete.UseVisualStyleBackColor = true;
            button_delete.Click += button_delete_Click;
            // 
            // textBox_searchStr
            // 
            textBox_searchStr.Location = new Point(29, 54);
            textBox_searchStr.Name = "textBox_searchStr";
            textBox_searchStr.Size = new Size(156, 23);
            textBox_searchStr.TabIndex = 7;
            textBox_searchStr.TextChanged += textBox_searchStr_TextChanged;
            textBox_searchStr.KeyUp += textBox_searchStr_KeyUp;
            // 
            // button_closeProcess
            // 
            button_closeProcess.Location = new Point(110, 217);
            button_closeProcess.Name = "button_closeProcess";
            button_closeProcess.Size = new Size(75, 23);
            button_closeProcess.TabIndex = 8;
            button_closeProcess.Text = "结束进程";
            button_closeProcess.UseVisualStyleBackColor = true;
            button_closeProcess.Click += button_closeProcess_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Location = new Point(229, 273);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(79, 23);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // checkBox_autoCloseProcess
            // 
            checkBox_autoCloseProcess.AutoSize = true;
            checkBox_autoCloseProcess.Location = new Point(101, 274);
            checkBox_autoCloseProcess.Name = "checkBox_autoCloseProcess";
            checkBox_autoCloseProcess.Size = new Size(135, 21);
            checkBox_autoCloseProcess.TabIndex = 11;
            checkBox_autoCloseProcess.Text = "自动结束进程时间：";
            checkBox_autoCloseProcess.UseVisualStyleBackColor = true;
            checkBox_autoCloseProcess.CheckedChanged += checkBox_autoCloseProcess_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 320);
            Controls.Add(dateTimePicker1);
            Controls.Add(checkBox_autoCloseProcess);
            Controls.Add(button_closeProcess);
            Controls.Add(textBox_searchStr);
            Controls.Add(button_delete);
            Controls.Add(button_refresh);
            Controls.Add(button_toRight);
            Controls.Add(label2);
            Controls.Add(listBox_process);
            Controls.Add(label1);
            Controls.Add(listBox_closeProcess);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "定时关闭指定进程";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox_closeProcess;
        private Label label1;
        private Label label2;
        private ListBox listBox_process;
        private Button button_toRight;
        private Button button_refresh;
        private Button button_delete;
        private TextBox textBox_searchStr;
        private Button button_closeProcess;
        private DateTimePicker dateTimePicker1;
        private CheckBox checkBox_autoCloseProcess;
    }
}
