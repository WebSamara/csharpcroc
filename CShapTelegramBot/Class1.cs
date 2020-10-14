using System;
using Telegram.Bot;

namespace CShapTelegramBot
{
    /// <summary>
    /// Основной модуль бота
    /// </summary>
    public class Bot
    {
        /// <summary>
        /// Клиент Telegram
        /// </summary>
        private TelegramBotClient client;
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Bot() 
        {
            client = new TelegramBotClient("1386680338:AAFWdk_x63iwwYmdMxBuRD0ny_CM16e53mI");
            client.OnMessage += MessageProc;
        }
        /// <summary>
        /// Обработка сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageProc(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            client.SendTextMessageAsync(e.Message.Chat.Id, "Привет!)");
            Console.WriteLine(e.Message.Text);
        }

        /// <summary>
        /// Запуск
        /// </summary>
        public void Run() 
        {
            //Запуск обработки сообщений
            client.StartReceiving(); 
        }
    }
}
