using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class InputChecks
    {
        public bool ToNumbers(string t)
        {
            if (IsEmpty(t)) 
            {
                return false;
            }
            if (t.StartsWith("-"))
            {
                if (t.Length == 1)
                {
                    return false;
                }
                  
                for (int i = 1; i < t.Length; i++)
                {
                    if (!char.IsDigit(t[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (char i in t)
                {
                    if (!char.IsDigit(i))
                    {
                        return false;
                    }
                }
                return true;
            }

        }
        public bool IsEmpty(string n)
        {
            return string.IsNullOrEmpty(n);
        }
    }
}
