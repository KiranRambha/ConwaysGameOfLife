using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            LifeGrid lifegrid;
            Console.WriteLine("Welcome to Conway's Game Of Life");
            Console.WriteLine("Enter the Width of the Grid");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Height of the Grid");
            int y = Convert.ToInt32(Console.ReadLine());
            lifegrid = new LifeGrid(y, x, "Grid.txt");
            while (true)
            {
                lifegrid.show();
                lifegrid.run();
                //Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}
