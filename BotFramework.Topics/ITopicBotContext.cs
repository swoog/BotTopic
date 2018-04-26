using Microsoft.Bot.Builder;

namespace BotFramework.Topics
{
    public interface ITopicBotContext<T> : ITurnContext
        where T : ITopicBotContext<T>
    {
        ConversationState<T> ConversationState { get; }
    }
}