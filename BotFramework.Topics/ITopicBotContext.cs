using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Classic.Dialogs;

namespace BotFramework.Topics
{
    public interface ITopicBotContext<T> : ITurnContext 
        where T : ITopicBotContext<T>
    {
        ConversationState<T> ConversationState { get; }
    }
}