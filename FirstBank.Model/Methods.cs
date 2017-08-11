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
            int zero = 0;
            int georgi = 0;
            return zero + georgi;

        }

        public int Replace257WithZero()
        {
            int zero = 257;
            return zero;

        }

    }
}

