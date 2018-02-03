using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_4_MikeSummers
{
    class Desk
    {
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public int NumOfDrawers { get; set; }
        public DesktopMaterial DesktopMaterial { get; set; }

        // Desk Constraints / Constants
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;
    }

    public enum DesktopMaterial
    {
        Pine = 50,
        Laminate = 100,
        Oak = 200,
        Rosewood = 300,
        Veneer = 125
    }


}
