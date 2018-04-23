using Microsoft.Bot.Builder.Core.Extensions;

namespace BotFramework.Topics
{
    public class ConversationState<T> : StoreItem 
        where T : ITopicBotContext<T>
    {
        public ITopic<T> ActiveTopic { get; set; }
    }
}