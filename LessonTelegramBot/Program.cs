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

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.    {message.Chat.HasProtectedContent}");






























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



    /**
    Message message2 = await botClient.SendPhotoAsync(
    chatId: chatId,
    photo: InputFile.FromUri("https://www.seiu1000.org/sites/main/files/main-images/camera_lense_0.jpeg"),
    caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
    parseMode: ParseMode.Html,
    cancellationToken: cancellationToken);
    */


    //Message message3 = await botClient.SendAudioAsync(
    //    chatId: chatId,
    //    audio: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3"),
    //    /*
    //    performer: "Joel Thomas Hunger",
    //    title: "Fun Guitar and Ukulele",
    //    duration: 91, // in seconds
    //    */
    //    cancellationToken: cancellationToken);



    /** audo jo'natishidi
    await using Stream stream = System.IO.File.OpenRead("C:/Users/dotnetbillioner/Downloads/konsta-o‘zbekistonlik_(uzxit.net).mp3");
    /// "C:/Users/dotnetbillioner/Downloads/8d82b5_Counter_Strike_Go_Go_Go_Sound_Effect.ogg"
    /// 
    Message message4 = await botClient.SendVoiceAsync(
        chatId: chatId,
        voice: InputFile.FromStream(stream),
        duration: 36,
        cancellationToken: cancellationToken);
    */

    /** 4 burche video jo'natish
    Message message4 = await botClient.SendVideoAsync(
    chatId: chatId,
    video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
    thumbnail: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg"),
    supportsStreaming: true,
    cancellationToken: cancellationToken);
    */

    /****
    // compyuterimizdan videoni telegram botga ulash va yuklab olsih

    //await using Stream stream = System.IO.File.OpenRead("C:/Users/dotnetbillioner/Music/tg/321167599_919088929348204_6362471068059503365_n.mp4");
    await using Stream stream = System.IO.File.OpenRead("C:/Users/dotnetbillioner/Downloads/video-waves.mp4");

    Message message5 = await botClient.SendVideoNoteAsync(
        chatId: chatId,
        videoNote: InputFile.FromStream(stream),
        duration: 47,
        length: 360, // value of width/height
        cancellationToken: cancellationToken);
    */

    /***
    Message[] messages5 = await botClient.SendMediaGroupAsync(
        chatId: chatId,
        media: new IAlbumInputMedia[]
        {
            new InputMediaPhoto(
                InputFile.FromUri("https://cdn.pixabay.com/photo/2017/06/20/19/22/fuchs-2424369_640.jpg")),
            new InputMediaPhoto(
                InputFile.FromUri("https://cdn.pixabay.com/photo/2017/04/11/21/34/giraffe-2222908_640.jpg")),
        },
        cancellationToken: cancellationToken);
    */

    //Message message6 = await botClient.SendDocumentAsync(
    //    chatId: chatId,
    //    document: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg"),
    //    caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
    //    parseMode: ParseMode.Html,
    //    cancellationToken: cancellationToken);


    //Message message7 = await botClient.SendAnimationAsync(
    //chatId: chatId,
    //animation: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-waves.mp4"),
    //caption: "Waves",
    //cancellationToken: cancellationToken);



    //// chatda anonym pool yasaberadigan bot
    //Message pollMessage = await botClient.SendPollAsync(
    //chatId: "@myblog_discuss",
    //question: "Dotnetta nechta t bor",
    //options: new[]
    //{
    //    "1 ta",
    //    "2 ta",
    //    "3 ta",
    //},
    //cancellationToken: cancellationToken);



    //Poll poll = await botClient.StopPollAsync(
    //chatId: pollMessage.Chat.Id,
    //messageId: pollMessage.MessageId,
    //cancellationToken: cancellationToken);


    //Message message8 = await botClient.SendVenueAsync(
    //    chatId: chatId,
    //    latitude: 50.0840172f,
    //    longitude: 14.418288f,
    //    title: "Man Hanging out",
    //    address: "Husova, 110 00 Staré Město, Czechia",
    //    cancellationToken: cancellationToken);


    // using Telegram.Bot.Types.ReplyMarkups;


    /**
    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
    new KeyboardButton[] { "Help me", "Call me ☎️" },
})
    {
        ResizeKeyboard = true
    };

    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Choose a response",
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: cancellationToken);

    */


    /**
    // using Telegram.Bot.Types.ReplyMarkups;

    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
    new KeyboardButton[] { "Help me" },
    new KeyboardButton[] { "Call me ☎️" },
})
    {
        ResizeKeyboard = true
    };

    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Choose a response",
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: cancellationToken);
    */

    /**
    // using Telegram.Bot.Types.ReplyMarkups;

    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    {
    KeyboardButton.WithRequestLocation("Share Location"),
    KeyboardButton.WithRequestContact("Share Contact"),
});

    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Who or Where are you?",
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: cancellationToken);
    */
    // using Telegram.Bot.Types.ReplyMarkups;

    InlineKeyboardMarkup inlineKeyboard = new(new[]
    {
    InlineKeyboardButton.WithSwitchInlineQuery(
        text: "switch_inline_query"),
    InlineKeyboardButton.WithSwitchInlineQueryCurrentChat(
        text: "switch_inline_query_current_chat"),
});

    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "A message with an inline keyboard markup",
        replyMarkup: inlineKeyboard,
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
