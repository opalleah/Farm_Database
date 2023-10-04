namespace Farm_Database
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
            txtID = new TextBox();
            btn_QueryId = new Button();
            lblAnimalType = new Label();
            lblAnimalInfo = new Label();
            txtAnimalInfo = new RichTextBox();
            lblMessage = new Label();
            label2 = new Label();
            txtColour = new TextBox();
            btn_QueryColour = new Button();
            label3 = new Label();
            txtType = new TextBox();
            btn_QueryType = new Button();
            label4 = new Label();
            txtWeight = new TextBox();
            btn_QueryWeight = new Button();
            label5 = new Label();
            txtDeleteID = new TextBox();
            btn_Delete = new Button();
            radioConfirmDeletion = new RadioButton();
            btn_Insert = new Button();
            txtAWater = new TextBox();
            txtAWeight = new TextBox();
            txtAColour = new TextBox();
            txtACost = new TextBox();
            AnimalCombo = new ComboBox();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btn_Update = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            InsertCombo = new ComboBox();
            txtACharacteristic = new TextBox();
            label13 = new Label();
            Output = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 84);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 0;
            label1.Text = "Enter an ID:";
            // 
            // txtID
            // 
            txtID.Location = new Point(181, 84);
            txtID.Name = "txtID";
            txtID.Size = new Size(150, 31);
            txtID.TabIndex = 1;
            // 
            // btn_QueryId
            // 
            btn_QueryId.Location = new Point(359, 84);
            btn_QueryId.Name = "btn_QueryId";
            btn_QueryId.Size = new Size(112, 34);
            btn_QueryId.TabIndex = 2;
            btn_QueryId.Text = "Search";
            btn_QueryId.UseVisualStyleBackColor = true;
            btn_QueryId.Click += btn_QueryId_Click;
            // 
            // lblAnimalType
            // 
            lblAnimalType.AutoSize = true;
            lblAnimalType.Location = new Point(593, 79);
            lblAnimalType.Name = "lblAnimalType";
            lblAnimalType.Size = new Size(0, 25);
            lblAnimalType.TabIndex = 3;
            // 
            // lblAnimalInfo
            // 
            lblAnimalInfo.AutoSize = true;
            lblAnimalInfo.Location = new Point(593, 104);
            lblAnimalInfo.Name = "lblAnimalInfo";
            lblAnimalInfo.Size = new Size(104, 25);
            lblAnimalInfo.TabIndex = 4;
            lblAnimalInfo.Text = "Animal Info";
            // 
            // txtAnimalInfo
            // 
            txtAnimalInfo.Location = new Point(593, 132);
            txtAnimalInfo.Name = "txtAnimalInfo";
            txtAnimalInfo.Size = new Size(695, 328);
            txtAnimalInfo.TabIndex = 6;
            txtAnimalInfo.Text = "";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(594, 489);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(82, 25);
            lblMessage.TabIndex = 7;
            lblMessage.Text = "Message";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 123);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 8;
            label2.Text = "Enter a Colour:";
            // 
            // txtColour
            // 
            txtColour.Location = new Point(181, 123);
            txtColour.Name = "txtColour";
            txtColour.Size = new Size(150, 31);
            txtColour.TabIndex = 9;
            // 
            // btn_QueryColour
            // 
            btn_QueryColour.Location = new Point(359, 124);
            btn_QueryColour.Name = "btn_QueryColour";
            btn_QueryColour.Size = new Size(112, 34);
            btn_QueryColour.TabIndex = 10;
            btn_QueryColour.Text = "Search";
            btn_QueryColour.UseVisualStyleBackColor = true;
            btn_QueryColour.Click += btn_QueryColour_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 162);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 11;
            label3.Text = "Enter a Type:";
            // 
            // txtType
            // 
            txtType.Location = new Point(181, 162);
            txtType.Name = "txtType";
            txtType.Size = new Size(150, 31);
            txtType.TabIndex = 12;
            // 
            // btn_QueryType
            // 
            btn_QueryType.Location = new Point(359, 164);
            btn_QueryType.Name = "btn_QueryType";
            btn_QueryType.Size = new Size(112, 34);
            btn_QueryType.TabIndex = 13;
            btn_QueryType.Text = "Search";
            btn_QueryType.UseVisualStyleBackColor = true;
            btn_QueryType.Click += btn_QueryType_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 201);
            label4.Name = "label4";
            label4.Size = new Size(131, 25);
            label4.TabIndex = 14;
            label4.Text = "Enter a Weight:";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(181, 201);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(150, 31);
            txtWeight.TabIndex = 15;
            // 
            // btn_QueryWeight
            // 
            btn_QueryWeight.Location = new Point(359, 204);
            btn_QueryWeight.Name = "btn_QueryWeight";
            btn_QueryWeight.Size = new Size(112, 34);
            btn_QueryWeight.TabIndex = 16;
            btn_QueryWeight.Text = "Search";
            btn_QueryWeight.UseVisualStyleBackColor = true;
            btn_QueryWeight.Click += btn_QueryWeight_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 396);
            label5.Name = "label5";
            label5.Size = new Size(114, 25);
            label5.TabIndex = 17;
            label5.Text = "Delete by ID:";
            // 
            // txtDeleteID
            // 
            txtDeleteID.Location = new Point(181, 396);
            txtDeleteID.Name = "txtDeleteID";
            txtDeleteID.Size = new Size(150, 31);
            txtDeleteID.TabIndex = 18;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(181, 506);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(112, 34);
            btn_Delete.TabIndex = 19;
            btn_Delete.Text = "Delete";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // radioConfirmDeletion
            // 
            radioConfirmDeletion.AutoSize = true;
            radioConfirmDeletion.Location = new Point(181, 455);
            radioConfirmDeletion.Name = "radioConfirmDeletion";
            radioConfirmDeletion.Size = new Size(145, 29);
            radioConfirmDeletion.TabIndex = 20;
            radioConfirmDeletion.TabStop = true;
            radioConfirmDeletion.Text = "Are you sure?";
            radioConfirmDeletion.UseVisualStyleBackColor = true;
            // 
            // btn_Insert
            // 
            btn_Insert.Location = new Point(181, 986);
            btn_Insert.Name = "btn_Insert";
            btn_Insert.Size = new Size(112, 34);
            btn_Insert.TabIndex = 21;
            btn_Insert.Text = "Insert";
            btn_Insert.UseVisualStyleBackColor = true;
            btn_Insert.Click += btn_Insert_Click;
            // 
            // txtAWater
            // 
            txtAWater.Location = new Point(143, 894);
            txtAWater.Name = "txtAWater";
            txtAWater.Size = new Size(150, 31);
            txtAWater.TabIndex = 22;
            // 
            // txtAWeight
            // 
            txtAWeight.Location = new Point(143, 848);
            txtAWeight.Name = "txtAWeight";
            txtAWeight.Size = new Size(150, 31);
            txtAWeight.TabIndex = 23;
            // 
            // txtAColour
            // 
            txtAColour.Location = new Point(143, 802);
            txtAColour.Name = "txtAColour";
            txtAColour.Size = new Size(150, 31);
            txtAColour.TabIndex = 24;
            // 
            // txtACost
            // 
            txtACost.Location = new Point(143, 756);
            txtACost.Name = "txtACost";
            txtACost.Size = new Size(150, 31);
            txtACost.TabIndex = 25;
            // 
            // AnimalCombo
            // 
            AnimalCombo.FormattingEnabled = true;
            AnimalCombo.Items.AddRange(new object[] { "Cow", "Goat", "Sheep" });
            AnimalCombo.Location = new Point(143, 708);
            AnimalCombo.Name = "AnimalCombo";
            AnimalCombo.Size = new Size(150, 33);
            AnimalCombo.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonShadow;
            label6.Location = new Point(35, 95);
            label6.Name = "label6";
            label6.Size = new Size(103, 25);
            label6.TabIndex = 27;
            label6.Text = "Enter an ID:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 95);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 28;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(750, 778);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 29;
            // 
            // btn_Update
            // 
            btn_Update.Location = new Point(250, 202);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(112, 34);
            btn_Update.TabIndex = 32;
            btn_Update.Text = "Insert";
            btn_Update.UseVisualStyleBackColor = true;
            btn_Update.Click += btn_Update_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 708);
            label7.Name = "label7";
            label7.Size = new Size(56, 25);
            label7.TabIndex = 33;
            label7.Text = "Table:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 896);
            label8.Name = "label8";
            label8.Size = new Size(62, 25);
            label8.TabIndex = 34;
            label8.Text = "Water:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(29, 849);
            label9.Name = "label9";
            label9.Size = new Size(72, 25);
            label9.TabIndex = 35;
            label9.Text = "Weight:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 802);
            label10.Name = "label10";
            label10.Size = new Size(69, 25);
            label10.TabIndex = 36;
            label10.Text = "Colour:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 755);
            label11.Name = "label11";
            label11.Size = new Size(52, 25);
            label11.TabIndex = 37;
            label11.Text = "Cost:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(717, 272);
            label12.Name = "label12";
            label12.Size = new Size(0, 25);
            label12.TabIndex = 41;
            // 
            // InsertCombo
            // 
            InsertCombo.FormattingEnabled = true;
            InsertCombo.Items.AddRange(new object[] { "Water", "Weight", "Colour", "Cost", "Produce" });
            InsertCombo.Location = new Point(553, 776);
            InsertCombo.Name = "InsertCombo";
            InsertCombo.Size = new Size(182, 33);
            InsertCombo.TabIndex = 42;
            // 
            // txtACharacteristic
            // 
            txtACharacteristic.Location = new Point(143, 940);
            txtACharacteristic.Name = "txtACharacteristic";
            txtACharacteristic.Size = new Size(150, 31);
            txtACharacteristic.TabIndex = 44;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(29, 943);
            label13.Name = "label13";
            label13.Size = new Size(81, 25);
            label13.TabIndex = 45;
            label13.Text = "Produce:";
            // 
            // Output
            // 
            Output.AutoSize = true;
            Output.BackColor = SystemColors.Control;
            Output.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Output.Location = new Point(720, 31);
            Output.Name = "Output";
            Output.Size = new Size(90, 32);
            Output.TabIndex = 46;
            Output.Text = "Output";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = SystemColors.Control;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(29, 649);
            label14.Name = "label14";
            label14.Size = new Size(208, 32);
            label14.TabIndex = 47;
            label14.Text = "Insert New Record";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = SystemColors.Control;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(35, 30);
            label15.Name = "label15";
            label15.Size = new Size(259, 32);
            label15.TabIndex = 48;
            label15.Text = "Update Existing Record";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = SystemColors.Control;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(29, 327);
            label16.Name = "label16";
            label16.Size = new Size(164, 32);
            label16.TabIndex = 49;
            label16.Text = "Delete Record";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = SystemColors.Control;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(29, 12);
            label17.Name = "label17";
            label17.Size = new Size(175, 32);
            label17.TabIndex = 50;
            label17.Text = "Search Records";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtACharacteristic);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btn_QueryWeight);
            panel1.Controls.Add(btn_Delete);
            panel1.Controls.Add(btn_QueryType);
            panel1.Controls.Add(txtWeight);
            panel1.Controls.Add(btn_QueryColour);
            panel1.Controls.Add(radioConfirmDeletion);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtType);
            panel1.Controls.Add(txtDeleteID);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btn_QueryId);
            panel1.Controls.Add(txtColour);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(AnimalCombo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtACost);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(btn_Insert);
            panel1.Controls.Add(txtAColour);
            panel1.Controls.Add(txtAWater);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtAWeight);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(529, 1062);
            panel1.TabIndex = 51;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(btn_Update);
            panel2.Location = new Point(538, 631);
            panel2.Name = "panel2";
            panel2.Size = new Size(775, 443);
            panel2.TabIndex = 52;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1325, 1086);
            Controls.Add(Output);
            Controls.Add(InsertCombo);
            Controls.Add(label12);
            Controls.Add(textBox2);
            Controls.Add(lblMessage);
            Controls.Add(txtAnimalInfo);
            Controls.Add(lblAnimalInfo);
            Controls.Add(lblAnimalType);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtID;
        private Button btn_QueryId;
        private Label lblAnimalType;
        private Label lblAnimalInfo;
        private RichTextBox txtAnimalInfo;
        private Label lblMessage;
        private Label label2;
        private TextBox txtColour;
        private Button btn_QueryColour;
        private Label label3;
        private TextBox txtType;
        private Button btn_QueryType;
        private Label label4;
        private TextBox txtWeight;
        private Button btn_QueryWeight;
        private Label label5;
        private TextBox txtDeleteID;
        private Button btn_Delete;
        private RadioButton radioConfirmDeletion;
        private Button btn_Insert;
        private TextBox txtAWater;
        private TextBox txtAWeight;
        private TextBox txtAColour;
        private TextBox txtACost;
        private ComboBox AnimalCombo;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btn_Update;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private ComboBox InsertCombo;
        private TextBox txtACharacteristic;
        private Label label13;
        private Label Output;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Panel panel1;
        private Panel panel2;
    }
}