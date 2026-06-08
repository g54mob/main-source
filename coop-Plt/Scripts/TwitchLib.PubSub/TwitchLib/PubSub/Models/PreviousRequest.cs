using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models
{
	public class PreviousRequest
	{
		public string Nonce { get; }

		public PubSubRequestType RequestType { get; }

		public string Topic { get; }

		public PreviousRequest(string nonce, PubSubRequestType requestType, string topic = "none set")
		{
			Nonce = nonce;
			RequestType = requestType;
			Topic = topic;
		}
	}
}
