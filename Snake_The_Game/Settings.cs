using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_The_Game
{
    class Settings
    // We're gonna make static classes that will make  the other classes accessibale to other classes
    {
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static string directions;

        public Settings()
        {
            Width = 16;
            Height = 16;

            directions = "left";
        }


    }
}
