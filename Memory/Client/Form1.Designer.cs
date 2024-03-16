namespace Client
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            button3 = new Button();
            richTextBox1 = new RichTextBox();
            listBox1 = new ListBox();
            textBox2 = new TextBox();
            listBox2 = new ListBox();
            button4 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(6, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 23);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(238, 22);
            button1.Name = "button1";
            button1.Size = new Size(43, 23);
            button1.TabIndex = 1;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ControlLight;
            button2.Location = new Point(6, 55);
            button2.Name = "button2";
            button2.Size = new Size(226, 23);
            button2.TabIndex = 2;
            button2.Text = "LOAD";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(287, 172);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Project";
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Tempus Sans ITC", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.Brown;
            button3.Location = new Point(238, 55);
            button3.Name = "button3";
            button3.Size = new Size(43, 23);
            button3.TabIndex = 7;
            button3.Text = "Res";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.ForeColor = SystemColors.Window;
            richTextBox1.Location = new Point(6, 91);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(275, 75);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "Enter your prompt here and press ENTER after it.. 'Predicted Category' and the 'Possible Categories' will appear on the bottom side. After it, the Data will be shown on right side..";
            richTextBox1.Click += richTextBox1_Click;
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            richTextBox1.KeyDown += richTextBox1_KeyDown;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Black;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.ForeColor = SystemColors.Window;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 260);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(287, 17);
            listBox1.TabIndex = 5;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(15, 15, 15);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Dock = DockStyle.Right;
            textBox2.ForeColor = SystemColors.Info;
            textBox2.Location = new Point(317, 0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Both;
            textBox2.Size = new Size(397, 286);
            textBox2.TabIndex = 6;
            textBox2.WordWrap = false;
            // 
            // listBox2
            // 
            listBox2.BackColor = SystemColors.InactiveCaptionText;
            listBox2.BorderStyle = BorderStyle.FixedSingle;
            listBox2.ForeColor = SystemColors.InactiveCaption;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(12, 192);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(287, 62);
            listBox2.TabIndex = 7;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.Brown;
            button4.Location = new Point(693, 263);
            button4.Name = "button4";
            button4.Size = new Size(21, 23);
            button4.TabIndex = 8;
            button4.Text = "!";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(714, 286);
            Controls.Add(button4);
            Controls.Add(listBox2);
            Controls.Add(textBox2);
            Controls.Add(listBox1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "(Client) Memory";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private RichTextBox richTextBox1;
        private Button button3;
        private ListBox listBox1;
        private TextBox textBox2;
        private ListBox listBox2;
        private Button button4;
    }
}