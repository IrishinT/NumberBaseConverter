namespace NumberBaseConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            convertButton = new Button();
            inputTextBox = new TextBox();
            resultTextBox = new TextBox();
            fromComboBox = new ComboBox();
            toComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // convertButton
            // 
            convertButton.Font = new Font("Segoe UI", 12F);
            convertButton.Location = new Point(41, 259);
            convertButton.Margin = new Padding(3, 2, 3, 2);
            convertButton.Name = "convertButton";
            convertButton.Size = new Size(133, 46);
            convertButton.TabIndex = 0;
            convertButton.Text = "Перевести";
            convertButton.UseVisualStyleBackColor = true;
            convertButton.Click += convertButton_Click;
            // 
            // inputTextBox
            // 
            inputTextBox.Font = new Font("Segoe UI", 12F);
            inputTextBox.Location = new Point(42, 59);
            inputTextBox.Margin = new Padding(3, 2, 3, 2);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(133, 29);
            inputTextBox.TabIndex = 1;
            inputTextBox.TextChanged += textBox1_TextChanged;
            // 
            // resultTextBox
            // 
            resultTextBox.Font = new Font("Segoe UI", 12F);
            resultTextBox.Location = new Point(41, 358);
            resultTextBox.Margin = new Padding(3, 2, 3, 2);
            resultTextBox.Name = "resultTextBox";
            resultTextBox.ReadOnly = true;
            resultTextBox.Size = new Size(134, 29);
            resultTextBox.TabIndex = 2;
            resultTextBox.TextChanged += textBox2_TextChanged;
            // 
            // fromComboBox
            // 
            fromComboBox.Font = new Font("Segoe UI", 12F);
            fromComboBox.FormattingEnabled = true;
            fromComboBox.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" });
            fromComboBox.Location = new Point(42, 128);
            fromComboBox.Margin = new Padding(3, 2, 3, 2);
            fromComboBox.Name = "fromComboBox";
            fromComboBox.Size = new Size(133, 29);
            fromComboBox.TabIndex = 3;
            // 
            // toComboBox
            // 
            toComboBox.Font = new Font("Segoe UI", 12F);
            toComboBox.FormattingEnabled = true;
            toComboBox.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" });
            toComboBox.Location = new Point(42, 208);
            toComboBox.Margin = new Padding(3, 2, 3, 2);
            toComboBox.Name = "toComboBox";
            toComboBox.Size = new Size(133, 29);
            toComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(42, 33);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 5;
            label1.Text = "Введите число";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(42, 101);
            label2.Name = "label2";
            label2.Size = new Size(171, 21);
            label2.TabIndex = 6;
            label2.Text = "Из системы счисления";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(42, 180);
            label3.Name = "label3";
            label3.Size = new Size(158, 21);
            label3.TabIndex = 7;
            label3.Text = "В систему счисления";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(41, 334);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 8;
            label4.Text = "Результат";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(691, 394);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(toComboBox);
            Controls.Add(fromComboBox);
            Controls.Add(resultTextBox);
            Controls.Add(inputTextBox);
            Controls.Add(convertButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = " Конвертер систем счисления";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button convertButton;
        private TextBox inputTextBox;
        private TextBox resultTextBox;
        private ComboBox fromComboBox;
        private ComboBox toComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
