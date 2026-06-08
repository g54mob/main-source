using System.Threading.Tasks;

namespace Amazon.Runtime.EventStreams
{
	public interface IEventStreamPublisher
	{
		Task<IEventStreamMessage> NextEventAsync();
	}
}
