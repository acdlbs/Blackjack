using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            controller.StartGame(3);

            controller.DisplayGame(Console.Out);


            
            Console.ReadLine();
        }


    }
}
