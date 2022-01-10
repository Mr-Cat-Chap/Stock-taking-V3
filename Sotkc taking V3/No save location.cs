using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sotkc_taking_V3
{
    public partial class No_save_location : Form
    {
        public No_save_location()
        {
            InitializeComponent();
        }

        string settings; //Where the settings are saved to
        string SavePlace;

        private void Yes_Click(object sender, EventArgs e)
        {
            SavePlace = $@"Settings.txt";
            //Close window
        }

        private void No_Click(object sender, EventArgs e)
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
            }

            settings = SavePlace;
            //Close window
        }
    }
}
