using System;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MegaDesk_4_MikeSummers
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
            /*
            string[] text = System.IO.File.ReadAllLines("quotes.txt");
            foreach (string x in text)
            {
                showAllQuotes.Items.Add(x);
            }
            */


            string path = @"quotes.json";
            if (File.Exists(path))
            {

                using (StreamReader r = new StreamReader(path))
                {
                    string[] text = System.IO.File.ReadAllLines(path);
                    foreach (string x in text)
                    {
                        showAllQuotes.Items.Add(x);
                    }
                    r.Close();
                }
            }
            else
            {
                MessageBox.Show("Could not find a file");
            }
        }



        private void CancelViewAllQuotes_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }
    }
}
