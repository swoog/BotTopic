using System.Threading.Tasks;

namespace BotFramework.Topics
{
    public static class TopicExtensions
    {
        public static async Task<bool> StartTopic<TContext, T>(TContext context, T topic)
            where T : ITopic<TContext>
            where TContext : ITopicBotContext<TContext>
        {
            context.ConversationState.ActiveTopic = topic;
            return await context.ConversationState.ActiveTopic.StartTopic(context);
        }

        public static async Task<bool> EndTopic<TContext>(this TContext context)
            where TContext : ITopicBotContext<TContext>
        {
            context.ConversationState.ActiveTopic = null;
            return true;
        }
    }
}