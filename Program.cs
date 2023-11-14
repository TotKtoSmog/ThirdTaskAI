namespace ThirdTaskAI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cell A = new Cell('█', ConsoleColor.Red, "TypeA");
            Cell B = new Cell('█', ConsoleColor.Green, "TypeB");
            Cell C = new Cell('█', ConsoleColor.White, "Empty");
            Map map = new Map(100,A,B,C);
            map.Create();
            map.algorithmStart(1000, 10);

        }
    }
}