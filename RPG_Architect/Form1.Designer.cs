namespace RPG_Architect
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
            buttonAddCharacter = new Button();
            textBoxName = new TextBox();
            listBoxCharacters = new ListBox();
            numericUpDownAge = new NumericUpDown();
            numericUpDownStrength = new NumericUpDown();
            numericUpDownHealth = new NumericUpDown();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            button1 = new Button();
            buttonDelete = new Button();
            richTextBoxDetails = new RichTextBox();
            richTextBox5 = new RichTextBox();
            richTextBoxLore = new RichTextBox();
            buttonExport = new Button();
            buttonImport = new Button();
            richTextBox6 = new RichTextBox();
            comboBoxAdditionalAttributes = new ComboBox();
            buttonAddAttribute = new Button();
            textBoxAttributeValue = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHealth).BeginInit();
            SuspendLayout();
            // 
            // buttonAddCharacter
            // 
            buttonAddCharacter.ForeColor = SystemColors.ControlText;
            buttonAddCharacter.Location = new Point(381, 7);
            buttonAddCharacter.Name = "buttonAddCharacter";
            buttonAddCharacter.Size = new Size(148, 37);
            buttonAddCharacter.TabIndex = 0;
            buttonAddCharacter.Text = "Přidat postavu";
            buttonAddCharacter.UseVisualStyleBackColor = true;
            buttonAddCharacter.Click += button1_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(149, 74);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(207, 27);
            textBoxName.TabIndex = 1;
            textBoxName.TextChanged += textBox1_TextChanged_1;
            // 
            // listBoxCharacters
            // 
            listBoxCharacters.FormattingEnabled = true;
            listBoxCharacters.Location = new Point(926, 42);
            listBoxCharacters.Name = "listBoxCharacters";
            listBoxCharacters.Size = new Size(228, 644);
            listBoxCharacters.TabIndex = 2;
            listBoxCharacters.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // numericUpDownAge
            // 
            numericUpDownAge.Location = new Point(58, 41);
            numericUpDownAge.Name = "numericUpDownAge";
            numericUpDownAge.Size = new Size(64, 27);
            numericUpDownAge.TabIndex = 3;
            // 
            // numericUpDownStrength
            // 
            numericUpDownStrength.Location = new Point(58, 74);
            numericUpDownStrength.Name = "numericUpDownStrength";
            numericUpDownStrength.Size = new Size(64, 27);
            numericUpDownStrength.TabIndex = 4;
            // 
            // numericUpDownHealth
            // 
            numericUpDownHealth.Location = new Point(58, 107);
            numericUpDownHealth.Name = "numericUpDownHealth";
            numericUpDownHealth.Size = new Size(64, 27);
            numericUpDownHealth.TabIndex = 5;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(-1, 40);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(53, 27);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "Věk";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(-1, 73);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(53, 27);
            richTextBox2.TabIndex = 7;
            richTextBox2.Text = "Síla";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(-1, 106);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(53, 27);
            richTextBox3.TabIndex = 8;
            richTextBox3.Text = "Zdraví";
            richTextBox3.TextChanged += richTextBox3_TextChanged;
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(149, 41);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(69, 27);
            richTextBox4.TabIndex = 9;
            richTextBox4.Text = "Jméno";
            // 
            // button1
            // 
            button1.Location = new Point(402, 50);
            button1.Name = "button1";
            button1.Size = new Size(127, 29);
            button1.TabIndex = 10;
            button1.Text = "Uložit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(402, 85);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(127, 29);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Smazat";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // richTextBoxDetails
            // 
            richTextBoxDetails.Enabled = false;
            richTextBoxDetails.Location = new Point(9, 159);
            richTextBoxDetails.Name = "richTextBoxDetails";
            richTextBoxDetails.ReadOnly = true;
            richTextBoxDetails.Size = new Size(413, 515);
            richTextBoxDetails.TabIndex = 12;
            richTextBoxDetails.Text = "";
            richTextBoxDetails.TextChanged += richTextBoxDetails_TextChanged;
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(428, 137);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(53, 27);
            richTextBox5.TabIndex = 13;
            richTextBox5.Text = "Příběh";
            // 
            // richTextBoxLore
            // 
            richTextBoxLore.Location = new Point(428, 159);
            richTextBoxLore.Name = "richTextBoxLore";
            richTextBoxLore.Size = new Size(492, 515);
            richTextBoxLore.TabIndex = 14;
            richTextBoxLore.Text = "";
            richTextBoxLore.TextChanged += richTextBoxLore_TextChanged;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(-5, -4);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(127, 29);
            buttonExport.TabIndex = 15;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(128, -4);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(127, 29);
            buttonImport.TabIndex = 16;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // richTextBox6
            // 
            richTextBox6.Location = new Point(926, 12);
            richTextBox6.Name = "richTextBox6";
            richTextBox6.Size = new Size(85, 27);
            richTextBox6.TabIndex = 17;
            richTextBox6.Text = "Postavy";
            richTextBox6.TextChanged += richTextBox6_TextChanged;
            // 
            // comboBoxAdditionalAttributes
            // 
            comboBoxAdditionalAttributes.FormattingEnabled = true;
            comboBoxAdditionalAttributes.Location = new Point(562, 51);
            comboBoxAdditionalAttributes.Name = "comboBoxAdditionalAttributes";
            comboBoxAdditionalAttributes.Size = new Size(151, 28);
            comboBoxAdditionalAttributes.TabIndex = 18;
            comboBoxAdditionalAttributes.SelectedIndexChanged += comboBoxAdditionalAttributes_SelectedIndexChanged;
            // 
            // buttonAddAttribute
            // 
            buttonAddAttribute.Location = new Point(733, 51);
            buttonAddAttribute.Name = "buttonAddAttribute";
            buttonAddAttribute.Size = new Size(118, 29);
            buttonAddAttribute.TabIndex = 19;
            buttonAddAttribute.Text = "Přidat atribut";
            buttonAddAttribute.UseVisualStyleBackColor = true;
            buttonAddAttribute.Click += buttonAddAttribute_Click;
            // 
            // textBoxAttributeValue
            // 
            textBoxAttributeValue.Location = new Point(562, 87);
            textBoxAttributeValue.Name = "textBoxAttributeValue";
            textBoxAttributeValue.Size = new Size(151, 27);
            textBoxAttributeValue.TabIndex = 20;
            textBoxAttributeValue.TextChanged += textBoxAttributeValue_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1151, 686);
            Controls.Add(textBoxAttributeValue);
            Controls.Add(buttonAddAttribute);
            Controls.Add(comboBoxAdditionalAttributes);
            Controls.Add(richTextBox6);
            Controls.Add(buttonImport);
            Controls.Add(buttonExport);
            Controls.Add(richTextBoxLore);
            Controls.Add(richTextBox5);
            Controls.Add(richTextBoxDetails);
            Controls.Add(buttonDelete);
            Controls.Add(button1);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(numericUpDownHealth);
            Controls.Add(numericUpDownStrength);
            Controls.Add(numericUpDownAge);
            Controls.Add(listBoxCharacters);
            Controls.Add(textBoxName);
            Controls.Add(buttonAddCharacter);
            Name = "Form1";
            Text = "RPG Architect";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)numericUpDownAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHealth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddCharacter;
        private TextBox textBoxName;
        private ListBox listBoxCharacters;
        private NumericUpDown numericUpDownAge;
        private NumericUpDown numericUpDownStrength;
        private NumericUpDown numericUpDownHealth;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private Button button1;
        private Button buttonDelete;
        private RichTextBox richTextBoxDetails;
        private RichTextBox richTextBox5;
        private RichTextBox richTextBoxLore;
        private Button buttonExport;
        private Button buttonImport;
        private RichTextBox richTextBox6;
        private ComboBox comboBoxAdditionalAttributes;
        private Button buttonAddAttribute;
        private TextBox textBoxAttributeValue;
    }
}
