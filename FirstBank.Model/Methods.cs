using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
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

        public bool Greater(int a, int b)
        {
            if (a > b) return true;
            return false;
        }

        public int Lower(int a, int b, int c)
        {
            if (a < b) return 1;
            else return 0;
        }

        public int ReplaceZeroWith257()
        {
            var zero = 0;
            return zero + 5;
        }

    }
}

