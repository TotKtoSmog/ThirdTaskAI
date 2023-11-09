using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTaskAI
{
    internal class Map
    {
        private int size;
        private Cell[,]celles;
        private int countA;
        private int countB;
        private int countE;

        private Cell typeA;
        private Cell typeB;
        private Cell empty;
        internal Map(int size, Cell typeA, Cell typeB, Cell empty)
        {
            if (size < 10) size = 10;
            this.size = size;
            celles = new Cell[size, size];
            this.typeA = typeA;
            this.typeB = typeB;
            this.empty = empty;
            countA = countB = size * size / 100 * 40;
            countE = size * size - countA;
            FillEmpty();
        }
        internal void Create()
        {
            int count = 0;
            for(; count < countA; count++)
                celles[count % size, count / size] = typeA;
            for (; count < countA + countB; count++)
                celles[count % size, count / size] = typeB;
        }
        private void FillEmpty()
        {
            for(int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                    celles[i, j] = empty;
        }
        internal void show()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{celles[i, j].texture} ");
                Console.WriteLine();
            }    
        }
        
        private void shuffleCelles ()
        {
            Random rand = new Random();
            for(int i = 0; i < size; i++)
                for(int j = 0; j < size ; j++)
                    swap(i + rand.Next(size - i), j + rand.Next(size - j), i, j);
        }
        private void swap(int changeI, int changeJ, int i, int j)
        {
            Cell temp = celles[i, j];
            celles[i, j] = celles[changeI, changeJ];
            celles[changeI, changeJ] = temp;
        }

    }
}
