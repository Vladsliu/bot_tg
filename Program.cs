using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot_tg
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5553817118:AAEpLnJ1PZqyl7OZUrcCQpuaOS6xTbLnxgQ");
            client.StartReceiving(Update, Error );
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                Console.WriteLine(message.Chat.FirstName);
                Console.WriteLine(message.Text);
                if (message.Text.ToLower().Contains("Hello")) ;
                {
                  await botClient.SendTextMessageAsync(message.Chat.Id, "Hello, my name bot, send me a photo");
                    return;
                }
            }
            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "The photo breaks the law, the FBI is looking for you");
            }

        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
