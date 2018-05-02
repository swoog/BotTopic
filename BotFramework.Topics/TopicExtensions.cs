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
            if (context.ConversationState.ActiveTopic != null)
            {
                context.ConversationState.Previous.Add(context.ConversationState.ActiveTopic);
            }

            context.ConversationState.SetActiveTopic(topic);
            return await context.ConversationState.ActiveTopic.StartTopic(context);
        }

        public static async Task<bool> EndTopic<TContext>(this TContext context)
            where TContext : ITopicBotContext<TContext>
        {
            context.ConversationState.SetActiveTopic(context.ConversationState.Previous.LastOrDefault());
            context.ConversationState.Previous.Remove(context.ConversationState.ActiveTopic);
            if (context.ConversationState.ActiveTopic != null)
            {
                await context.ConversationState.ActiveTopic.ResumeTopic(context);
            }

            return true;
        }
    }
}