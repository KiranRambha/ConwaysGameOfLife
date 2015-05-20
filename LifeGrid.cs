using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class LifeGrid
    {
        int[][] grid;
        int currentGeneration;

        /// <summary>
        /// Constructor for the LifeGrid Class.
        /// </summary>
        /// <param name="width">The Width of the grid.</param>
        /// <param name="height">The Height of the grid.</param>
        /// <param name="fileName">The file from which data needs to be read.</param>
        public LifeGrid(int height, int width, String fileName)
        {
            grid = new int[height][];
            for (int i = 0; i < height; i++)
            {
                grid[i] = new int[width];
            }

            for (int i = 0; i < getGridHeight(); i++)
            {
                for (int j = 0; j < getGridWidth(); j++)
                {
                    grid[i][j] = 0;
                }
            }
                currentGeneration = 0;
            String file = fileName;
            String[] lines = System.IO.File.ReadAllLines(@"C:\Users\kiran\Documents\Visual Studio 2013\Projects\ConwaysGameOfLife\" + file);
   
            //interating throught the grid and initialising it with the file.
            int tempheight = 0;
            foreach (string line in lines)
            {
                if (tempheight < getGridHeight())
                {
                    for (int gridwidth = 0; gridwidth < getGridWidth() && gridwidth < line.Length; gridwidth++)
                    {
                        if (line[gridwidth] == 'O')
                        {
                            grid[tempheight][gridwidth] = 1;
                        }
                        else
                        {
                            grid[tempheight][gridwidth] = 0;
                        }
                    }
                }
                tempheight++;
            }
        }


        /// <summary>
        /// Prints the grid to the Console.
        /// </summary>
        public void show()
        {
            Console.WriteLine("*********************************************************************************************************");
            for (int gridHeight = 0; gridHeight < getGridHeight(); gridHeight++)
            {
                for (int gridWidth = 0; gridWidth < getGridWidth(); gridWidth++)
                {
                    if (grid[gridHeight][gridWidth] == 1)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("The current generation is: " + getCurrentGeneration());
            Console.WriteLine("*********************************************************************************************************");
        }


        /// <summary>
        /// This method is used to get the height of the grid.
        /// </summary>
        /// <returns>Returns the height of the grid</returns>
        public int getGridHeight()
        {
            return grid.Length;
        }


        /// <summary>
        /// This method is used to get the width of the grid.
        /// </summary>
        /// <returns>Returns the width of the grid</returns>
        public int getGridWidth()
        {
            return grid[0].Length;
        }


        /// <summary>
        /// Returns the current grid generation
        /// </summary>
        /// <returns>Returns the value of currentGeneration</returns>
        public int getCurrentGeneration()
        {
            return currentGeneration;
        }


        /// <summary>
        /// This method returns the content of the given cell
        /// </summary>
        /// <param name="height">The column value</param>
        /// <param name="width">The row value</param>
        /// <returns>Returns the value of the selected cell</returns>
        public int getCellContent(int height, int width)
        {
            return grid[height][width];
        }


        /// <summary>
        /// This method counts the number of neighbours surrounding a particular cell and returns it.
        /// </summary>
        /// <param name="x">The x co-ordinate</param>
        /// <param name="y">The y co-ordinate</param>
        /// <returns>Returns the number of neighbours surrounding a cell.</returns>
        public int getNumberOfNeighbours(int x, int y)
        {
            int count = 0, height = x, width = y;
            int tempheight = height - 1, tempwidth = width - 1;
            for (int i = tempheight; i <= tempheight + 2; i++)
            {
                for (int j = tempwidth; j <= tempwidth + 2; j++)
                {
                    if (i >= 0 && i < getGridHeight() && j >= 0 && j < getGridWidth())
                    {
                        if (grid[i][j] == 1)
                        {
                            count++;
                        }
                    } 
                }
            }
            if (grid[height][width] == 1)
            {
                count--;
            }
            return count;
        }


        /// <summary>
        /// This method applies the appropriate rules to the grid and refreshes the grid with new values.
        /// </summary>
        public void run()
        {
            int[][] newGrid = new int[getGridHeight()][];
            for (int i = 0; i < getGridHeight(); i++)
            {
                newGrid[i] = new int[getGridWidth()];
            }

            for (int height = 0; height < getGridHeight(); height++)
            {
                for (int width = 0; width < getGridWidth(); width++)
                {
                    if (grid[height][width] == 1 && getNumberOfNeighbours(height, width) < 2)
                    {
                        newGrid[height][width] = 0;
                    }
                    else if (grid[height][width] == 1 && (getNumberOfNeighbours(height, width) == 2 || getNumberOfNeighbours(height, width) == 3))
                    {
                        newGrid[height][width] = 1;
                    }
                    else if (grid[height][width] == 1 && getNumberOfNeighbours(height, width) > 3)
                    {
                        newGrid[height][width] = 0;
                    }
                    else if (grid[height][width] == 0 && getNumberOfNeighbours(height, width) == 3)
                    {
                        newGrid[height][width] = 1;
                    }
                    else
                    {
                        newGrid[height][width] = 0;
                    }
                }
            }
            grid = newGrid.Select(x => x.ToArray()).ToArray();
            currentGeneration++;
        }
    }
}
