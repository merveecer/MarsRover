using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Helper
{
    public static class Helper
    {
        public static string GetDirectionNameByIndex(int index)
        {
            string[] constantDirections = { "N", "W", "S", "E" }; //increasing Left side
            return constantDirections[index];
        }
    }
}
