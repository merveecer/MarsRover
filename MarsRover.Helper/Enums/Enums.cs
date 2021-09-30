using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Helper.Enums
{
    public class Enums
    {
        public enum Direction
        {
            [Description("N")]
            N = 0,
            [Description("W")]

            W = 1,
            [Description("S")]

            S = 2,
            [Description("E")]

            E = 3
        }
        public enum Instruction
        {
            L = 0,
            R = 1,
            M = 2
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
          
        }
    }
}
