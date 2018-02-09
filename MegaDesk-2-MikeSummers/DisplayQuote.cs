using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_4_MikeSummers
{
    public partial class DisplayQuote : Form
    {

        public DisplayQuote(string customerName, DateTime quoteDate, decimal deskWidth, decimal deskDepth,
                            int drawers, DesktopMaterial desktopMaterial, int rushOrderDays, decimal quoteTotal)

        {
            InitializeComponent();
            q_customer.Text = customerName;
            q_date.Text = quoteDate.ToString("MM/dd/yy");
            q_width.Text = deskWidth.ToString();
            q_depth.Text = deskDepth.ToString();
            q_drawers.Text = drawers.ToString();
            q_material.Text = desktopMaterial.ToString();
            q_rush.Text = rushOrderDays.ToString();
            q_quote.Text = quoteTotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();

        }
    }
}
