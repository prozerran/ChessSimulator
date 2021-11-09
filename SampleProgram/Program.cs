using System;

namespace SampleProgram
{
    public static class Program
    {
        public static void Main()
        {
            //var game = new Game();
            var game = new ComplexGame();

            game.Setup();
            game.Play(25);

            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}