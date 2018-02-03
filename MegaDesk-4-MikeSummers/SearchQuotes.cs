using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_4_MikeSummers
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
            //string text = System.IO.File.ReadAllText("quotes.txt");
            //string[] text = System.IO.File.ReadAllLines("quotes.txt");
            //readText.Text = text[0];
        }

        public void runMyQuery()
        {
            // Get value from drop down
            //string materialToFiler;
            var mySelectedMaterial = materialSelector.SelectedItem.ToString();
            if (mySelectedMaterial == "Oak")
            {
                //string materialToFilter = mySelectedMaterial;
                DoTheSearch("Oak"); 
            }
            else if (mySelectedMaterial == "Laminate")
            {
                DoTheSearch("Laminate");
            }
            else if (mySelectedMaterial == "Pine")
            {
                DoTheSearch("Pine");
            }
            else if (mySelectedMaterial == "Rosewood")
            {
                DoTheSearch("Rosewood");
            }
            else if (mySelectedMaterial == "Veneer")
            {
                DoTheSearch("Veneer");
            }
        }

        public void DoTheSearch(string whichMaterial)
        {
            string[] text = System.IO.File.ReadAllLines("quotes.txt");
            foreach (string x in text)
            {
                if (x.Equals(whichMaterial))
                {
                    readText.Text = "hello";
                }
            }
        }


        private void CancelSearchQuotes_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewQuoteButton_Click_1(object sender, EventArgs e)
        {
            runMyQuery();
        }
    }
}
