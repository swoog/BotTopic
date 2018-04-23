using Microsoft.Bot.Builder;

namespace BotFramework.Topics
{
    public interface ITopicBotContext<T> : IBotContext 
        where T : ITopicBotContext<T>
    {
        ConversationState<T> ConversationState { get; }
    }
}