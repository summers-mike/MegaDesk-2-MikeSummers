using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_4_MikeSummers
{
    class DeskQuote
    {

        // DeskQuote model attribute members
        public string CustomerName { get; set; }
        public DateTime QuoteDate { get; set; }
        public int RushDays { get; set; }
        public Desk Desk = new Desk();
        public decimal QuoteAmount { get; set; }

        // Working member variables
        private decimal SurfaceArea = 0;

        // Constants (future source is some data source)
        private const int PRICE_BASE = 200;
        private const int SIZE_THRESHOLD = 1000;  // inches squared
        private const int PRICE_PER_DRAWER = 50;
        private const int PRICE_PER_SURFACEAREA = 1; // extra cost per sq inch greater than desktop size threshold
        private const int RUSH1 = 3;  // Rush order days options
        private const int RUSH2 = 5;
        private const int RUSH3 = 7;
        private const int RUSH_THRESHOLD = 2000; // inches squared - see problem specs for rush order costs

        public DeskQuote(string customerName, DateTime quoteDate, decimal width, 
                        decimal depth, int drawers, DesktopMaterial material, int rushDays)
        {
            // Constructor when object is built - set attribute values
            CustomerName = customerName;
            Desk.Width = width;
            Desk.Depth = depth;
            Desk.NumOfDrawers = drawers;
            Desk.DesktopMaterial = material;
            RushDays = rushDays;

            // calculate Surface Area member variable for use in multiple functions
            SurfaceArea = Desk.Width * Desk.Depth;
        }

        
        public decimal CalculateQuoteTotal()
        {
            return PRICE_BASE + SurfaceAreaCost() + DrawerCost() + (int)Desk.DesktopMaterial + RushOrderCost();
        }

        
        // according to video, this can be private as well, since it's not used outside of DeskQuote
        public decimal SurfaceAreaCost()
        {
            // Determine if additional cost is warrented with desk areas greater than desktop size threshold
            if (SurfaceArea > SIZE_THRESHOLD)
            {
                return (SurfaceArea - SIZE_THRESHOLD) * PRICE_PER_SURFACEAREA;
            }
            else
            {
                return 0;
            }
        }
        

        
        // according to video, this can be private as well, since it's not used outside of DeskQuote
        public int DrawerCost()
        {
            return Desk.NumOfDrawers * PRICE_PER_DRAWER;
        }
        

        
        // according to video, this can be private as well, since it's not used outside of DeskQuote
        public int RushOrderCost()
        {
            int rushCost = 0;
            // OK to not have the 2-dim array for rush order prices until next version

            //
            //int[,] rushOrderPrices = GetRushOrderPrices(); // call function that reads in price chart
            // define 2d arrya here - don't go to file for now.
            int[,] rushOrderPrices = new int[,] { { 60, 70, 80 }, { 40, 50, 60 }, { 30, 30, 40 } };
            switch (RushDays)
            {
                case RUSH1:
                    if (SurfaceArea < SIZE_THRESHOLD)
                    {
                        rushCost = rushOrderPrices[0, 0];
                    }
                    else if (SurfaceArea <= RUSH_THRESHOLD)
                    {
                        rushCost = rushOrderPrices[0, 1];
                    }
                    else
                    {
                        rushCost = rushOrderPrices[0, 2];
                    }
                    break;
                case RUSH2:
                    if (SurfaceArea < SIZE_THRESHOLD)
                    {
                        rushCost = rushOrderPrices[1, 0];
                    }
                    else if (SurfaceArea <= RUSH_THRESHOLD)
                    {
                        rushCost = rushOrderPrices[1, 1];
                    }
                    else
                    {
                        rushCost = rushOrderPrices[1, 2];
                    }
                    break;
                case RUSH3:
                    if (SurfaceArea < SIZE_THRESHOLD)
                    {
                        rushCost = rushOrderPrices[2, 0];
                    }
                    else if (SurfaceArea <= RUSH_THRESHOLD)
                    {
                        rushCost = rushOrderPrices[2, 1];
                    }
                    else
                    {
                        rushCost = rushOrderPrices[2, 2];
                    }
                    break;
            }

            return rushCost;
        }

        // According to video, this is for MegaDesk 2 - Week 5.
        // bin/Debug/rushOrderPrices.txt content:
        // each on their own line: 60, 70, 80, 40, 50, 60, 30, 30, 40  (no commas)
        /*
        public int[,] GetRushOrderPrices ()
        {
            int[,] rushOrderPrices = new int[3, 3];
            try
            {
                string[] lines = FileStyleUriParser.ReadAllLines("rushOrderPrices.txt");
                int readLineCount = 0;
                for (int i=0; i<3; i++)
                {
                    rushOrderPrices[i, j] = int.Parse(lines[readLineCount]);
                    readLineCount++;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Rush Order Price Data Read Error: " + e.Message);
            }
            return rushOrderPrices;
        }
        */
        



        private decimal pwidth;
        private decimal pdepth;
        private int pnumOfDrawers;
        private string pmaterial;
        private int prushDays;

        private decimal BASESIZE = 1000;
        private decimal SURFACECOST = 1; // cost per square inch over the base size

        public string customerName { get; set; }
        public DateTime quoteDate { get; set; }

        public DeskQuote(decimal width, decimal depth, int numOfDrawers, string material, int rushDays)
        {
            pwidth = width;
            pdepth = depth;
            pnumOfDrawers = numOfDrawers;
            pmaterial = material;
            prushDays = rushDays;
        }

        public decimal surfaceAreaCost()
        {
            // determine if the size of the desk is large enough for additional charge
            if ( pwidth * pdepth > BASESIZE)
            {
                return (pwidth * pdepth - BASESIZE) * SURFACECOST;
            }
            else
            {
                return 0;
            }
        }
    }

    
}
