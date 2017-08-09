using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Model
{
    public class Methods
    {
        public int AddUnit(int i)
        {
            return i++;
        }

        public int SubUnit(int i)
        {
            return i--;
        }

        public bool LessThanOrEqual(int a, int b)
        {
            if (a <= b) return true;
            return false;
        }

        public bool GreaterThanOrEqual(int a, int b)
        {
            if (a >= b) return true;
            return false;
        }

        public int ReplaceZeroWith257()
        {
            var zero = 0;
            return zero + 5;
        }

    }
}

