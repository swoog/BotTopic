using System.Collections.Generic;
using Microsoft.Bot.Builder.Core.Extensions;
using Newtonsoft.Json;

namespace BotFramework.Topics
{
    public class ConversationState<T>
        where T : ITopicBotContext<T>
    {
        private List<ITopic<T>> previous;
        private ITopic<T> activeTopic;

        public ConversationState()
        {
            this.previous = new List<ITopic<T>>();
        }

        public ITopic<T> ActiveTopic
        {
            get => activeTopic;
        }

        public List<ITopic<T>> Previous
        {
            get => previous;
        }

        public string ActiveTopicJson
        {
            get => JsonConvert.SerializeObject(this.activeTopic, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
            set => this.activeTopic = JsonConvert.DeserializeObject<ITopic<T>>(value, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public string PreviousJson
        {
            get => JsonConvert.SerializeObject(this.Previous, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
            set => this.previous = JsonConvert.DeserializeObject<List<ITopic<T>>>(value, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public void SetActiveTopic(ITopic<T> topic)
        {
            this.activeTopic = topic;
        }
    }
}