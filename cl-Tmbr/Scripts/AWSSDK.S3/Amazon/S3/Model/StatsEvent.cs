using Amazon.Runtime.EventStreams;

namespace Amazon.S3.Model
{
	public class StatsEvent : IS3Event, IEventStreamEvent
	{
		public Stats Details { get; set; }

		public StatsEvent()
		{
		}

		public StatsEvent(IEventStreamMessage message)
		{
			Details = Stats.Unmarshall(message.Payload);
		}
	}
}
