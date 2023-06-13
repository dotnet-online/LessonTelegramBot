using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

const string YOUR_ACCESS_TOKEN_HERE = "6262907858:AAE2FWGs19fT9fTSIbeIwOoODlHofdQY3hs";

var botClient = new TelegramBotClient($"{YOUR_ACCESS_TOKEN_HERE}");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Message is not { } message)
        return;
    // Only process text messages
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");






























    // Echo received message text
    /**
      Message sentMessage = await botClient.SendTextMessageAsync(
         chatId: chatId,
         text: "You said:\n" + message.Chat.Username + "\n" + message.Chat.FirstName + "\n" + message.Chat.LastName + "\n" + message.Chat.Bio + "\n" + message.Chat.Location + " " + message.Text,
         cancellationToken: cancellationToken);
    */

    /**
    Message message1 = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Trying *all the parameters* of `sendMessage` method",
        parseMode: ParseMode.MarkdownV2,
        disableNotification: true,
        replyToMessageId: update.Message.MessageId,
        replyMarkup: new InlineKeyboardMarkup(
            InlineKeyboardButton.WithUrl(
                text: "Check sendMessage method",
                url: "https://telegrambots.github.io/book/1/example-bot.html")),
        cancellationToken: cancellationToken);
    */




    Message message2 = await botClient.SendPhotoAsync(
    chatId: chatId,
    photo: InputFile.FromUri("https://www.seiu1000.org/sites/main/files/main-images/camera_lense_0.jpeg"),
    caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
    parseMode: ParseMode.Html,
    cancellationToken: cancellationToken);























}




























Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
