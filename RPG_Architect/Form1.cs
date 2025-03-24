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
        "Místo narození",
        "Datum narození",
        "Otec",
        "Matka",
        "Zbraò",
        "Zvláštní schopnost",
        "Povolání v minulosti",
        "Osudový nepøítel"
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
                        // MessageBox.Show("Postavy byly úspìšnì importovány.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Vymazání aktuálních položek v ListBoxu
            listBoxCharacters.Items.Clear();

            // Pøidání postav do ListBoxu
            foreach (var character in characters)
            {
                listBoxCharacters.Items.Add(character);  // Pøidá celý objekt postavy
            }

            // Nastavení, co se bude zobrazovat v ListBoxu (zobrazí pouze jméno postavy)
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

                // Používáme System.Text.Json pro deserializaci
                var importedCharacters = JsonConvert.DeserializeObject<List<Character>>(jsonString);

                if (importedCharacters != null)
                {
                    characters.AddRange(importedCharacters);
                    UpdateCharacterListBox();
                    MessageBox.Show("Postavy byly úspìšnì importovány.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Soubor neobsahuje žádná data.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pøi naèítání: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // pøidání postavy
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            int age = (int)numericUpDownAge.Value;
            int strength = (int)numericUpDownStrength.Value;
            int health = (int)numericUpDownHealth.Value;
            string lore = richTextBoxLore.Text;

            // Vytvoøení postavy
            Character newCharacter = new Character(name, age, strength, health, lore);

            // Pøidání postavy do seznamu
            characters.Add(newCharacter);

            // Pøidání postavy do ListBoxu
            listBoxCharacters.Items.Add(newCharacter);

            // Vymazání TextBoxù po pøidání postavy
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

                // Zobrazit info v editaèních polích
                textBoxName.Text = selectedChar.Name;
                numericUpDownAge.Value = selectedChar.Age;
                numericUpDownStrength.Value = selectedChar.Strength;
                numericUpDownHealth.Value = selectedChar.Health;
                richTextBoxDetails.Text = selectedChar.Lore;
                richTextBoxLore.Text = selectedChar.Lore;

                // Zobrazit také v textovém poli
                richTextBoxDetails.Text = $"Jméno: {selectedChar.Name}\n" +
                                                   $"Vìk: {selectedChar.Age}\n" +
                                                   $"Síla: {selectedChar.Strength}\n" +
                                                   $"Zdraví: {selectedChar.Health}\n" +
                                                   $"Pøíbìh: {selectedChar.Lore}";
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

                // Zobrazíme potvrzovací okno
                DialogResult result = MessageBox.Show(
                    $"Opravdu chceš smazat postavu „{selectedName}“?",
                    "Potvrzení smazání",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Pokud uživatel klikne na "Ano"
                if (result == DialogResult.Yes)
                {
                    listBoxCharacters.Items.RemoveAt(selectedIndex);
                    characters.RemoveAt(selectedIndex); // Pokud máš List<Character> characters
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
                MessageBox.Show("Nejprve prosím vyber postavu, kterou chceš smazat.");
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
                // Získání postavy
                Character selectedChar = characters[selectedIndex];

                // Aktualizace dat
                selectedChar.Name = textBoxName.Text;
                selectedChar.Age = (int)numericUpDownAge.Value;
                selectedChar.Strength = (int)numericUpDownStrength.Value;
                selectedChar.Health = (int)numericUpDownHealth.Value;
                selectedChar.Lore = richTextBoxLore.Text;

                // Aktualizace
                listBoxCharacters.Items[selectedIndex] = selectedChar.Name;

                richTextBoxDetails.Text = $"Jméno: {selectedChar.Name}\n" +
                                                   $"Vìk: {selectedChar.Age}\n" +
                                                   $"Síla: {selectedChar.Strength}\n" +
                                                   $"Zdraví: {selectedChar.Health}\n" +
                                                   $"Pøíbìh: {selectedChar.Lore}";

                MessageBox.Show("Postava byla úspìšnì upravena.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            saveFileDialog.Title = "Uložit postavy jako JSON";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportCharactersToJson(saveFileDialog.FileName);
                MessageBox.Show("Postavy byly úspìšnì exportovány.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                savingFile = saveFileDialog.FileName;
                SaveSettings();
            }

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Naèíst postavy ze souboru";

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
            comboBoxAdditionalAttributes.Items.Add("Místo narození");
            comboBoxAdditionalAttributes.Items.Add("Rodièe");
            comboBoxAdditionalAttributes.Items.Add("Povolání");
            comboBoxAdditionalAttributes.Items.Add("Zvláštní schopnosti");


        }

        private void buttonAddAttribute_Click(object sender, EventArgs e)
        {
            // Získání vybrané postavy z listboxu
            var selectedCharacter = (Character)listBoxCharacters.SelectedItem;

            // Pokud je postava vybraná
            if (selectedCharacter != null)
            {
                // Získání vybraného atributu a jeho hodnoty
                string attributeName = comboBoxAdditionalAttributes.SelectedItem?.ToString();
                string attributeValue = textBoxAttributeValue.Text;

                // Pokud jsou oba atributy zadány
                if (!string.IsNullOrEmpty(attributeName) && !string.IsNullOrEmpty(attributeValue))
                {
                    // Pøidání do AdditionalAttributes
                    selectedCharacter.AdditionalAttributes[attributeName] = attributeValue;

                    // Aktualizování UI (napø. zobrazit pøidaný atribut)
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
