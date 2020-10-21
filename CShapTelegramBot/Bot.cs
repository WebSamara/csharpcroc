using System;
using System.IO;
using System.Net;
using Telegram.Bot;

namespace CShapTelegramBot
{
    /// <summary>
    /// Основной модуль бота
    /// [!] Файл назывался Class1 - переименовал по имени класса
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
            switch (e.Message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    Console.WriteLine(e.Message.Text);
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Ты отправил мне сообщение");
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    // [!] Я бы поменял местами сообщение и загрузку файла
                    // иначе получается, что мы уже доложили о том, что все хорошо,
                    // а потом может быть ошибка
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Ты отправил мне файл и я его сохранил :)");
                    DownloadFile(e.Message.Document.FileId, $@"C:\doc\{e.Message.Document.FileName}");
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Ты отправил мне фото");
                    break;

                default:
                    Console.WriteLine(e.Message.Type);
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Я хз что это");
                    break;
            }
        }

        private async void DownloadFile(string fileId, string path)
        {
            try
            {
                var file = await client.GetFileAsync(fileId);
                // [!] Можно использовать using:

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await client.DownloadFileAsync(file.FilePath, fileStream);
                }
                // [!] И тогда Close/Dispose уже не нужно
                // fileStream.Close();
                // fileStream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error downloading: " + ex.Message);
            }
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
