using System;
using Telegram.Bot;

namespace CShapTelegramBot
{
    class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Bot bot;
            bot = new Bot();
            bot.Run();
            Console.WriteLine("Нажмите ENTER для отключения бота");
            Console.ReadLine();
        }
    }
}
