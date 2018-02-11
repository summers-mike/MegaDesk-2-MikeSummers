using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
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
    
    public partial class AddQuote : Form
    {

        #region Declarations

        string CustomerName = string.Empty;
        decimal DeskWidth = 0;
        decimal DeskDepth = 0;
        int Drawers = 0;  //number of desk drawers
        DesktopMaterial DesktopMaterial; //
        int RushOrderDays = 0; // rush order selection in days
        decimal DeskQuoteTotal = 0; // desk quote total

        #endregion


        public AddQuote()
        {
            InitializeComponent();
            NumDrawersComboBox.SelectedIndex = 0;
            rushDaysDropDown.SelectedIndex = 0;

            // Design Spec: Create a List of Desktop Materials from Enum
            List<DesktopMaterial> DesktopMaterialList = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();
            DesktopMaterialComboBox.DataSource = DesktopMaterialList;
        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            var ReturnMainMenu = (MainMenu)Tag;
            ReturnMainMenu.Show();
            this.Close();
        }

        private void WidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            // ??
        }

        private void DepthTextBox_Validating(object sender, CancelEventArgs e)
        {
            // ??
        }

        private void Dimensions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        class DeskInfo
        {
            public String CustomerName { get; set; }
            public decimal DeskWidth { get; set; }
            public decimal DeskDepth { get; set; }
            public int Drawers { get; set; }
            public String DesktopMaterial{ get; set; }
            public int RushOrderDays { get; set; }
            public decimal DeskQuoteTotal { get; set; }
            public DateTime DateTime { get; set; }
        }


        private void AddDeskButton_Click(object sender, EventArgs e)
        {
            // Input

            string DeskWidthString = WidthTextBox.Text;
            if (DeskWidthString == null || DeskWidthString == "")
            {
                
            }
            else
            {
                DeskWidth = decimal.Parse(WidthTextBox.Text);
            }

            string DeskDepthString = DepthTextBox.Text;
            if (DeskDepthString == null || DeskDepthString == "")
            {

            }
            else
            {
                DeskDepth = decimal.Parse(DepthTextBox.Text);
            }

            CustomerName = customerNameTextBox.Text;
            Drawers = int.Parse(NumDrawersComboBox.SelectedItem.ToString());

            string Material = DesktopMaterialComboBox.SelectedItem.ToString();
            Enum.TryParse(Material, out DesktopMaterial);

            // Get rush order value
            var myRushValue = rushDaysDropDown.SelectedItem.ToString();
            if (myRushValue == "3")
            {
                RushOrderDays = 3;
            }
            else if (myRushValue == "5")
            {
                RushOrderDays = 5;
            }
            else if (myRushValue == "7")
            {
                RushOrderDays = 7;
            }

            // Create new deskOrder object and calculate total

            DeskQuote NewOrder = new DeskQuote(CustomerName, DateTime.Now, DeskWidth,
                                               DeskDepth, Drawers, DesktopMaterial, RushOrderDays);
            DeskQuoteTotal = NewOrder.CalculateQuoteTotal();



            if (((CustomerName != "") || (CustomerName != null)) &&
                ((DeskWidth >= 24) && (DeskWidth <= 96)) &&
                ((DeskDepth >= 12) && (DeskDepth <= 48)) &&
                ((DesktopMaterial.ToString() != "") || (DesktopMaterial.ToString() != null)) &&
                ((Drawers >=0) && (Drawers < 8)) && 
                (DeskQuoteTotal != 0)
                )
            {

                try
                {

                    //json code here...

                    DeskInfo deskinfo = new DeskInfo();
                    deskinfo.CustomerName = CustomerName;
                    deskinfo.DeskDepth = DeskDepth;
                    deskinfo.DeskWidth = DeskWidth;
                    deskinfo.DesktopMaterial = DesktopMaterial.ToString();
                    deskinfo.Drawers = Drawers;
                    deskinfo.RushOrderDays = RushOrderDays;
                    deskinfo.DateTime = DateTime.Now;
                    deskinfo.DeskQuoteTotal = DeskQuoteTotal;


                    JsonSerializer serializer = new JsonSerializer();
                    //serializer.Converters.Add(new JavaScriptDateTimeConverter());

                    serializer.NullValueHandling = NullValueHandling.Ignore;

                    string path = @"quotes.json";
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true);

                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            sw.Write("\n");
                            serializer.Serialize(writer, deskinfo);
                        }

                        //myJson.WriteLine(deskinfo);
                        sw.Close();
                    }
                    else
                    {
                        //using (StreamWriter sw = new StreamWriter(path))
                        StreamWriter sw = new StreamWriter(path);

                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            serializer.Serialize(writer, deskinfo);
                        }
                        sw.Close();


                        /*
                        MemoryStream stream1 = new MemoryStream();
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DeskInfo));
                        ser.WriteObject(stream1, deskinfo);
                        */


                        //var recordToAdd = new JObject();
                        //recordToAdd["CustomerName"] = deskinfo.CustomerName;
                        //recordToAdd["Desk Width"] = DeskWidth;

                        //var serializeMe = JsonConvert.SerializeObject(Formatting.Indented);

                        //File.WriteAllText(@"quotes.json", serializeMe);



                        /*
                        var getJsonInfo = File.ReadAllText("quotes.json");

                        var jsonArray = JArray.Parse(getJsonInfo);

                        var recordToAdd = new JObject();
                        recordToAdd["CustomerName"] = CustomerName;
                        recordToAdd["Desk Width"] = DeskWidth;
                        jsonArray.Add(recordToAdd);

                        var serializeMe = JsonConvert.SerializeObject(Formatting.Indented);

                        File.WriteAllText(@"quotes.json", serializeMe);
                        */


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error creating or writing to JSON file");
                }




                // Show confirmation page on new screen
                var MainMenu = (MainMenu)Tag; // need to bring along a reference tag to the main menu form
                DisplayQuote newOrderView = new DisplayQuote(CustomerName, DateTime.Now.Date, DeskWidth,
                                                               DeskDepth, Drawers, DesktopMaterial,
                                                               RushOrderDays, DeskQuoteTotal)
                {
                    Tag = MainMenu
                };
                newOrderView.Show();
                this.Close();



            }
            else
            {
                MessageBox.Show("Please fill in all fields with valid entries.");
            }


            

            //try
            //{
                // build output string csv

                // Original code for ver 1.1

                /*
                var DeskRecord = CustomerName + ", " + DateTime.Now + ", " + DeskWidth + ", "
                                 + DeskDepth + ", " + Drawers + ", " + DesktopMaterial + ", "
                                 + RushOrderDays + ", " + DeskQuoteTotal;
                string cFile = @"quotes.txt";
                if (!File.Exists(cFile)) { StreamWriter sw = File.CreateText("quotes.txt"); }
                using (StreamWriter sw = File.AppendText("quotes.txt"))
                {
                    sw.WriteLine(DeskRecord);
                }
                */

                // MORE TO GO HERE??
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error creating file");
            //}

            
                

                

            



            
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            var ShowMainMenu = (MainMenu)Tag;
            ShowMainMenu.Show();
            this.Close();
        }






        private void CancelAddQuote_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void validatingWidth(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidWidth(WidthTextBox.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WidthTextBox.Select(0, WidthTextBox.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.widthErrorProvider.SetError(WidthTextBox, errorMsg);
            }
        }


        public bool ValidWidth(string myWidth, out string errorMessage)
        {
            if (myWidth.Length == 0)
            {
                errorMessage = "A width is required.";
                return false;
            }

            if ((Convert.ToDecimal(myWidth) >= 24) && (Convert.ToDecimal(myWidth) <= 96))
            {
                errorMessage = "";
                return true;
            }

            errorMessage = "Please enter a width between 24 and 96";
            return false;
        }



        private void validatedWidth(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            widthErrorProvider.SetError(WidthTextBox, "");
        }












        private void validatingDepth(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidDepth(DepthTextBox.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DepthTextBox.Select(0, DepthTextBox.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.depthErrorProvider.SetError(DepthTextBox, errorMsg);
            }
        }


        public bool ValidDepth(string myDepth, out string errorMessage)
        {
            if (myDepth.Length == 0)
            {
                errorMessage = "A Depth is required.";
                return false;
            }

            if ((Convert.ToDecimal(myDepth) >= 12) && (Convert.ToDecimal(myDepth) <= 48))
            {
                errorMessage = "";
                return true;
            }

            errorMessage = "Please enter a Depth between 12 and 48";
            return false;
        }



        private void validatedDepth(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            depthErrorProvider.SetError(DepthTextBox, "");
        }





        // old stuff
        /*
        private void validateDepth(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if ((char.IsControl(e.KeyChar)) || (!char.IsDigit(e.KeyChar)))
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        */
        
    }
}
