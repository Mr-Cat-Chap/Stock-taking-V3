using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Sotkc_taking_V3
{
    public partial class Form1 : Form
    {
        string SavePlace;
        string LoadPlace;
        string settings; //Where the information is saved
        string settings1;
        string settings2;
        string settings3;
        string settings4;
        string settings5;

        //string SettingsCheck = File.ReadLines($@"Settings.txt").Take(1).First();

        public Form1()
        {
            InitializeComponent();

            if (File.Exists($@"Settings.txt"))
            {
                LoadPlace = File.ReadLines($@"Settings.txt").Take(1).First();

                if (LoadPlace != "" || LoadPlace != null)
                {
                    Load_Click(new object(), new EventArgs());
                }
            }
            else
            {
                if (File.Exists($@"SaveData.txt"))
                {
                    LoadPlace = $@"SaveData.txt";
                    Load_Click(new object(), new EventArgs());
                }
            }
            {
                /*else
                {
                    File.WriteAllText($@"Settings.txt", $@"SaveData.txt");

                    LoadPlace = File.ReadLines($@"settings.txt").Take(1).First();
                }
                */
            } //Old code for something that didn't really work and was causing the loading error
        }

        private void SaveSettingsVoid(object sender, EventArgs e)
        {
            if (settings == null || settings == "")
            {
                settings = $@"SaveData.txt";
            }

            string SavingSettings = settings + "\n" + settings1 + "\n" + settings2 + "\n" + settings3 + "\n" + settings4 + "\n" + settings5;

            File.WriteAllText($@"Settings.txt", SavingSettings);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var Input = new List<TextBox>()
            {
                Item1, Amount1,
                Item2, Amount2,
                Item3, Amount3,
                Item4, Amount4,
                Item5, Amount5,
                Item6, Amount6
            };

            string output = String.Join("\n", Input.Select(x => x.Text));

            //foreach (TextBox output in) ;

            if (SavePlace == null || SavePlace == "")
            {
                SavePlace = $@"SaveData.txt";

                //Open No Save Location form
            }
            
            File.WriteAllText(SavePlace, output);

            SaveSettingsVoid(new object(), new EventArgs());

            Save.Text = "Saved";

            //Old code for saving
            {
            /*
            using (StreamWriter outputfile = new StreamWriter($@"SaveData.txt"))
            {
                string OutPut = Item1.Text + "\n" + Amount1.Text + "\n" + Item2.Text + "\n" + Amount2.Text + "\n" + Item3.Text + "\n" + Amount3.Text
                    + "\n" + Item4.Text + "\n" + Amount4.Text + "\n" + Item5.Text + "\n" + Amount5.Text + "\n" + Item6.Text + "\n" + Amount6.Text;

                outputfile.WriteLine(OutPut);
            };
            */
            }

            //My attempt to make a timer v
            {
                /*

                 My attempt at making the saved button count up. 

                   for (int a = 0; a < 60; a++)
                {
                    int savedSince = a;

                    Save.Text = "Saved" + " " + Convert.ToString(savedSince);

                    Task.Delay(1000);
                }

                Save.Text = "Saved <1 Min";

                */
            }
        }

        private void TextBoxesVoid(TextBox SelectedBox)
        {
            foreach (TextBox tb in this.Controls)
            {
                if (tb != null)
                {
                    tb.Text = "";
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (LoadPlace == "" || LoadPlace == null)
            {
                LoadLocation_Click(new object(), new EventArgs());
            }
            else
            {
                using (StreamReader inputfile = new StreamReader(LoadPlace))
                {
                    Item1.Text = inputfile.ReadLine();
                    Amount1.Text = inputfile.ReadLine();

                    Item2.Text = inputfile.ReadLine();
                    Amount2.Text = inputfile.ReadLine();

                    Item3.Text = inputfile.ReadLine();
                    Amount3.Text = inputfile.ReadLine();

                    Item4.Text = inputfile.ReadLine();
                    Amount4.Text = inputfile.ReadLine();

                    Item5.Text = inputfile.ReadLine();
                    Amount5.Text = inputfile.ReadLine();

                    Item6.Text = inputfile.ReadLine();
                    Amount6.Text = inputfile.ReadLine();
                }

                SaveSettingsVoid(new object(), new EventArgs());
            }

        }

        private void UpdateAmount (TextBox amountBox, int Adjustment)
        {
            int amount;

            if (amountBox.Text == "")
            {
                amount = 1;
                amountBox.Text = amount.ToString();
            }
            else
            {
                amount = Convert.ToInt32(amountBox.Text) + Adjustment;
                amountBox.Text = amount.ToString();
            }
        }

        private void Add1_Click(object sender, EventArgs e) => UpdateAmount(Amount1, 1);

        private void Decrease1_Click(object sender, EventArgs e) => UpdateAmount(Amount1, -1);

        private void Add2_Click(object sender, EventArgs e) => UpdateAmount(Amount2, 1);

        private void Decrease2_Click(object sender, EventArgs e) => UpdateAmount(Amount2, -1);

        private void Add3_Click(object sender, EventArgs e) => UpdateAmount(Amount3, 1);

        private void Decrease3_Click(object sender, EventArgs e) => UpdateAmount(Amount3, -1);

        private void Add4_Click(object sender, EventArgs e) => UpdateAmount(Amount4, 1);

        private void Decrease4_Click(object sender, EventArgs e) => UpdateAmount(Amount4, -1);

        private void Add5_Click(object sender, EventArgs e) => UpdateAmount(Amount5, 1);

        private void Decrease5_Click(object sender, EventArgs e) => UpdateAmount(Amount5, -1);

        private void Add6_Click(object sender, EventArgs e) => UpdateAmount(Amount6, 1);
        
        private void Decrease6_Click(object sender, EventArgs e) => UpdateAmount(Amount6, -1);

        private void SaveLocation_Click(object sender, EventArgs e)
        {
            SaveFileDialog FindingSaveLocation = new SaveFileDialog();
            FindingSaveLocation.Title = "Choose location to save";
            FindingSaveLocation.InitialDirectory = $@"";
            FindingSaveLocation.Filter = "Text file (.txt)|*.txt";
            FindingSaveLocation.FilterIndex = 2;
            FindingSaveLocation.RestoreDirectory = false;
            if (FindingSaveLocation.ShowDialog() == DialogResult.OK)
            {
                SavePlace = FindingSaveLocation.FileName;
                LoadPlace = FindingSaveLocation.FileName;
            }

            settings = SavePlace;

            Save_Click(new object(), new EventArgs());
        }

        private void LoadLocation_Click(object sender, EventArgs e)
        {
            OpenFileDialog FindingLoadLocation = new OpenFileDialog();
            FindingLoadLocation.Title = "Choose location to load";
            FindingLoadLocation.InitialDirectory = $@"";
            FindingLoadLocation.Filter = "Text file (*.txt)|*.txt";
            FindingLoadLocation.FilterIndex = 2;
            FindingLoadLocation.RestoreDirectory = false;
            if (FindingLoadLocation.ShowDialog() == DialogResult.OK)
            {
                LoadPlace = FindingLoadLocation.FileName;
                SavePlace = FindingLoadLocation.FileName;
            }

            settings = LoadPlace;

            Load_Click(new object(), new EventArgs());
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            //Make this more efficent one day
            Item1.Text = "";
            Amount1.Text = "";

            Item2.Text = "";
            Amount2.Text = "";

            Item3.Text = "";
            Amount3.Text = "";

            Item4.Text = "";
            Amount4.Text = "";

            Item5.Text = "";
            Amount5.Text = "";

            Item6.Text = "";
            Amount6.Text = "";
        }
    }
}
