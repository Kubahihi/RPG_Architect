using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Newtonsoft.Json;



namespace RPG_Architect
{
    public partial class Form1 : Form
    {
        private string savingFile;

        private List<Character> characters = new List<Character>();
        public Form1()
        {
            InitializeComponent();

            LoadSettings();

            

        comboBoxAdditionalAttributes.Items.Clear();
            comboBoxAdditionalAttributes.Items.AddRange(new string[]
            {
        "M�sto narozen�",
        "Datum narozen�",
        "Otec",
        "Matka",
        "Zbra�",
        "Zvl�tn� schopnost",
        "Povol�n� v minulosti",
        "Osudov� nep��tel"
            });
            if (checkBoxAutoLoad.Checked)
            {
                if (savingFile != null)
                {
                    string jsonString = File.ReadAllText(savingFile);

                    var importedCharacters = JsonConvert.DeserializeObject<List<Character>>(jsonString);

                    if (importedCharacters != null)
                    {
                        characters.AddRange(importedCharacters);
                        UpdateCharacterListBox();
                        // MessageBox.Show("Postavy byly �sp�n� importov�ny.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {
                    checkBoxAutoLoad.Checked = false;
                    SaveSettings();
                }
            }
        }
        public class AppSettings
        {
            public bool AutoLoadEnabled { get; set; }
            public string savingFilePath { get; set; }
        }

        private void LoadSettings()
        {
            if (File.Exists("setup.json"))
            {
                string json = File.ReadAllText("setup.json");
                var settings = JsonConvert.DeserializeObject<AppSettings>(json);

                if (settings != null)
                {
                    checkBoxAutoLoad.Checked = settings.AutoLoadEnabled;
                    savingFile = settings.savingFilePath;
                }
            }
        }

        private void SaveSettings()
        {
            var settings = new AppSettings
            {
                AutoLoadEnabled = checkBoxAutoLoad.Checked,
                savingFilePath = savingFile
            };

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText("setup.json", json);
        }
        public class Character
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Strength { get; set; }
            public int Health { get; set; }
            public string Lore { get; set; }



            public Dictionary<string, string> AdditionalAttributes { get; set; } = new Dictionary<string, string>();



            // Konstruktor 
            public Character(string name, int age, int strength, int health, string lore)
            {
                Name = name;
                Age = age;
                Strength = strength;
                Health = health;
                Lore = lore;

                AdditionalAttributes = new Dictionary<string, string>();
            }

            // Postava v seznamu
            public override string ToString()
            {
                string shownChar = Name;
                return shownChar;
            }


        }
        private void UpdateCharacterListBox()
        {
            // Vymaz�n� aktu�ln�ch polo�ek v ListBoxu
            listBoxCharacters.Items.Clear();

            // P�id�n� postav do ListBoxu
            foreach (var character in characters)
            {
                listBoxCharacters.Items.Add(character);  // P�id� cel� objekt postavy
            }

            // Nastaven�, co se bude zobrazovat v ListBoxu (zobraz� pouze jm�no postavy)
            listBoxCharacters.DisplayMember = "Name";
        }
        private void ExportCharactersToJson(string filePath)
        {


            string jsonString = JsonConvert.SerializeObject(characters, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        private void ImportCharactersFromJson(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);

                // Pou��v�me System.Text.Json pro deserializaci
                var importedCharacters = JsonConvert.DeserializeObject<List<Character>>(jsonString);

                if (importedCharacters != null)
                {
                    characters.AddRange(importedCharacters);
                    UpdateCharacterListBox();
                    MessageBox.Show("Postavy byly �sp�n� importov�ny.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Soubor neobsahuje ��dn� data.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba p�i na��t�n�: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // p�id�n� postavy
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            int age = (int)numericUpDownAge.Value;
            int strength = (int)numericUpDownStrength.Value;
            int health = (int)numericUpDownHealth.Value;
            string lore = richTextBoxLore.Text;

            // Vytvo�en� postavy
            Character newCharacter = new Character(name, age, strength, health, lore);

            // P�id�n� postavy do seznamu
            characters.Add(newCharacter);

            // P�id�n� postavy do ListBoxu
            listBoxCharacters.Items.Add(newCharacter);

            // Vymaz�n� TextBox� po p�id�n� postavy
            textBoxName.Clear();
            numericUpDownAge.Value = 0;
            numericUpDownStrength.Value = 0;
            numericUpDownHealth.Value = 0;
            richTextBoxDetails.Clear();
            richTextBoxLore.Clear();
        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxCharacters.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < characters.Count)
            {
                Character selectedChar = characters[selectedIndex];

                // Zobrazit info v edita�n�ch pol�ch
                textBoxName.Text = selectedChar.Name;
                numericUpDownAge.Value = selectedChar.Age;
                numericUpDownStrength.Value = selectedChar.Strength;
                numericUpDownHealth.Value = selectedChar.Health;
                richTextBoxDetails.Text = selectedChar.Lore;
                richTextBoxLore.Text = selectedChar.Lore;

                // Zobrazit tak� v textov�m poli
                richTextBoxDetails.Text = $"Jm�no: {selectedChar.Name}\n" +
                                                   $"V�k: {selectedChar.Age}\n" +
                                                   $"S�la: {selectedChar.Strength}\n" +
                                                   $"Zdrav�: {selectedChar.Health}\n" +
                                                   $"P��b�h: {selectedChar.Lore}";
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string currentVersion = "0.2";
            this.Text = "RPG Architect v" + currentVersion;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            int selectedIndex = listBoxCharacters.SelectedIndex;
            if (selectedIndex >= 0)
            {
                string selectedName = listBoxCharacters.SelectedItem.ToString();

                // Zobraz�me potvrzovac� okno
                DialogResult result = MessageBox.Show(
                    $"Opravdu chce� smazat postavu �{selectedName}�?",
                    "Potvrzen� smaz�n�",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Pokud u�ivatel klikne na "Ano"
                if (result == DialogResult.Yes)
                {
                    listBoxCharacters.Items.RemoveAt(selectedIndex);
                    characters.RemoveAt(selectedIndex); // Pokud m� List<Character> characters
                    textBoxName.Clear();
                    numericUpDownAge.Value = 0;
                    numericUpDownStrength.Value = 0;
                    numericUpDownHealth.Value = 0;
                    richTextBoxDetails.Clear();
                    richTextBoxLore.Clear();
                }
            }
            else
            {
                MessageBox.Show("Nejprve pros�m vyber postavu, kterou chce� smazat.");
            }
        }

        private void richTextBoxDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = listBoxCharacters.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < characters.Count)
            {
                // Z�sk�n� postavy
                Character selectedChar = characters[selectedIndex];

                // Aktualizace dat
                selectedChar.Name = textBoxName.Text;
                selectedChar.Age = (int)numericUpDownAge.Value;
                selectedChar.Strength = (int)numericUpDownStrength.Value;
                selectedChar.Health = (int)numericUpDownHealth.Value;
                selectedChar.Lore = richTextBoxLore.Text;

                // Aktualizace
                listBoxCharacters.Items[selectedIndex] = selectedChar.Name;

                richTextBoxDetails.Text = $"Jm�no: {selectedChar.Name}\n" +
                                                   $"V�k: {selectedChar.Age}\n" +
                                                   $"S�la: {selectedChar.Strength}\n" +
                                                   $"Zdrav�: {selectedChar.Health}\n" +
                                                   $"P��b�h: {selectedChar.Lore}";

                MessageBox.Show("Postava byla �sp�n� upravena.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxName.Clear();
                numericUpDownAge.Value = 0;
                numericUpDownStrength.Value = 0;
                numericUpDownHealth.Value = 0;
                richTextBoxDetails.Clear();
                richTextBoxLore.Clear();
            }
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxLore_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Ulo�it postavy jako JSON";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportCharactersToJson(saveFileDialog.FileName);
                MessageBox.Show("Postavy byly �sp�n� exportov�ny.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                savingFile = saveFileDialog.FileName;
                SaveSettings();
            }

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Na��st postavy ze souboru";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportCharactersFromJson(openFileDialog.FileName);
            }
        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAdditionalAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAdditionalAttributes.Items.Add("M�sto narozen�");
            comboBoxAdditionalAttributes.Items.Add("Rodi�e");
            comboBoxAdditionalAttributes.Items.Add("Povol�n�");
            comboBoxAdditionalAttributes.Items.Add("Zvl�tn� schopnosti");


        }

        private void buttonAddAttribute_Click(object sender, EventArgs e)
        {
            // Z�sk�n� vybran� postavy z listboxu
            var selectedCharacter = (Character)listBoxCharacters.SelectedItem;

            // Pokud je postava vybran�
            if (selectedCharacter != null)
            {
                // Z�sk�n� vybran�ho atributu a jeho hodnoty
                string attributeName = comboBoxAdditionalAttributes.SelectedItem?.ToString();
                string attributeValue = textBoxAttributeValue.Text;

                // Pokud jsou oba atributy zad�ny
                if (!string.IsNullOrEmpty(attributeName) && !string.IsNullOrEmpty(attributeValue))
                {
                    // P�id�n� do AdditionalAttributes
                    selectedCharacter.AdditionalAttributes[attributeName] = attributeValue;

                    // Aktualizov�n� UI (nap�. zobrazit p�idan� atribut)
                    UpdateCharacterListBox();
                }
                else
                {
                    MessageBox.Show("Vyberte atribut a zadejte jeho hodnotu.");
                }
            }
            else
            {
                MessageBox.Show("Vyberte postavu.");
            }
        }

        private void textBoxAttributeValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownAge_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();

        }

        
    }
}
