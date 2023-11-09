namespace ThirdTaskAI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cell A = new Cell('1', "TypeA");
            Cell B = new Cell('2', "TypeB");
            Cell C = new Cell('0', "Empty");
            Map map = new Map(10,A,B,C);
            map.Create();
            map.show();

        }
    }
}