using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen.Test
{
    public class Helper
    {
        public static string GetTestString()
        {
            var sb = new StringBuilder();

            for (int i = PasswordGenerator.MinCharNum; i <= PasswordGenerator.MaxCharNum; i++)
            {
                sb.Append(Convert.ToChar(i));
            }

            return sb.ToString();
        }
    }
}
