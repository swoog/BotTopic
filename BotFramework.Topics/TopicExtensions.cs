using System.Linq;
using System.Threading.Tasks;

namespace BotFramework.Topics
{
    public static class TopicExtensions
    {
        public static async Task<bool> StartTopic<TContext, T>(this TContext context, T topic)
            where T : ITopic<TContext>
            where TContext : ITopicBotContext<TContext>
        {
            context.ConversationState.Previous.Add(context.ConversationState.ActiveTopic);
            context.ConversationState.ActiveTopic = topic;
            return await context.ConversationState.ActiveTopic.StartTopic(context);
        }

        public static async Task<bool> EndTopic<TContext>(this TContext context)
            where TContext : ITopicBotContext<TContext>
        {
            context.ConversationState.ActiveTopic = context.ConversationState.Previous.LastOrDefault();
            context.ConversationState.Previous =
                context.ConversationState.Previous.Take(context.ConversationState.Previous.Count - 1).ToList();
            if (context.ConversationState.ActiveTopic != null)
            {
                await context.ConversationState.ActiveTopic.ContinueTopic(context);
            }

            return true;
        }
    }
}