using System.Threading.Tasks;

namespace BotFramework.Topics
{
    public interface ITopic<T>
        where T : ITopicBotContext<T>
    {
        Task<bool> StartTopic(T context);
        Task<bool> ContinueTopic(T context);
        Task<bool> ResumeTopic(T context);
    }
}