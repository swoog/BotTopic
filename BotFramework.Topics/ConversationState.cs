using System.Collections.Generic;
using Microsoft.Bot.Builder.Core.Extensions;

namespace BotFramework.Topics
{
    public class ConversationState<T>
        where T : ITopicBotContext<T>
    {
        public ConversationState()
        {
            this.Previous = new List<ITopic<T>>();
        }

        public ITopic<T> ActiveTopic { get; set; }
        public List<ITopic<T>> Previous { get; set; }
    }
}