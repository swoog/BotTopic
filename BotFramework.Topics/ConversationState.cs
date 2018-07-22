using Microsoft.Bot.Builder.Core.Extensions;

namespace BotFramework.Topics
{
    public class ConversationState<T> : Microsoft.Bot.Builder.Core.Extensions.IStoreItem 
        where T : ITopicBotContext<T>
    {
        public ITopic<T> ActiveTopic { get; set; }
        public string eTag { get; set; }
    }
}