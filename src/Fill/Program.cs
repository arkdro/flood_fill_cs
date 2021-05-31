using System;

namespace Fill
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new Fill();
            var data = new int[,] {{1,2}, {1,4}, {1,1}, {7,1}};
            f.fill(data, 0, 1, 10, 2);
        }
    }
}
