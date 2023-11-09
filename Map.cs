using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Cell typeA;
        private Cell typeB;
        private Cell empty;
        private int countShuffle;
        internal List<Point> unHappys;
        internal List<Point> Emptys;
        private Point _empty;
        private Point _unHappy;

        internal class Point
        {
            internal int x, y;
            internal Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        internal Map(int size, Cell typeA, Cell typeB, Cell empty)
        {
            if (size < 10) size = 10;
            this.size = size;
            celles = new Cell[size, size];
            this.typeA = typeA;
            this.typeB = typeB;
            this.empty = empty;
            countA = countB = size * size / 100 * 40;
            countShuffle = 5;
            Emptys = new List<Point>();
            unHappys = new List<Point>();
            FillEmpty();
        }
        
        internal void Create()
        {
            int count = 0;
            for(; count < countA; count++)
                celles[count % size, count / size] = typeA;
            for (; count < countA + countB; count++)
                celles[count % size, count / size] = typeB;
            for(int i = 0; i < countShuffle; i++)
                shuffleCelles();
            SetUnHappy();
            SetEmpty();
        }
        internal void show(bool isDivided = true)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.ForegroundColor = celles[i, j].color;
                    if (isDivided)
                        Console.Write($"{celles[i, j].texture} ");
                    else
                        Console.Write($"{celles[i, j].texture}");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void SetEmpty()
        {
            Emptys.Clear();
            for (int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                    if (celles[i,j].tag == empty.tag)
                        Emptys.Add(new Point(i,j));
        }
        private void SetUnHappy()
        {
            unHappys.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int count = 0;
                    if (celles[i, j].tag == empty.tag) continue;
                    if (i != 0 && celles[i, j].tag == celles[i - 1, j].tag) count++;
                    if (i != size - 1 && celles[i, j].tag == celles[i + 1, j].tag) count++;
                    if (j != 0 && celles[i, j].tag == celles[i , j - 1].tag) count++;
                    if (j != size - 1 && celles[i, j].tag == celles[i , j + 1].tag) count++;
                    if (i != 0 && j != 0 && celles[i, j].tag == celles[i - 1, j - 1].tag) count++;
                    if (i != 0 && j < size - 1 && celles[i, j].tag == celles[i - 1, j + 1].tag) count++;
                    if (i != size - 1 && j != 0 && celles[i, j].tag == celles[i + 1, j - 1].tag) count++;
                    if (i != size - 1 && j != size - 1 && celles[i, j].tag == celles[i + 1, j + 1].tag) count++;
                    if(count < 2)
                        unHappys.Add(new Point(i, j));
                }
            }

        }
        private void FillEmpty()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    celles[i, j] = empty;
        }
        internal void shuffleCelles()
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

        internal void Step()
        {
            Random rnd = new Random();
            int indexUHP = rnd.Next(unHappys.Count);
            int indexEMP = rnd.Next(Emptys.Count);
            _empty = Emptys[indexEMP];
            _unHappy = unHappys[indexUHP];
            swap(unHappys[indexUHP].x, unHappys[indexUHP].y, Emptys[indexEMP].x, Emptys[indexEMP].y);
            SetEmpty();
            SetUnHappy();
        }

        internal void algorithmStart(int maxCountStep, int delay)
        {
            long count = 0;
            while(unHappys.Count != 0 && count< maxCountStep)
            {
                count++;
                Console.Clear();
                Step();
                show(false);
                Console.WriteLine("===============");
                Console.WriteLine($"Номер шага: {count}");
                Console.WriteLine($"Кол-во пустых: {Emptys.Count}");
                Console.WriteLine($"Кол-во несчастливых: {unHappys.Count}");
                Console.WriteLine($"Выбрана не клетка на позиции: ({_unHappy.x}, {_unHappy.x})");
                Console.WriteLine($"Перемещена на позицию: ({_empty.x}, {_empty.x})");
                Console.WriteLine("===============");
                Thread.Sleep(delay);
            }
        }

    }
}
