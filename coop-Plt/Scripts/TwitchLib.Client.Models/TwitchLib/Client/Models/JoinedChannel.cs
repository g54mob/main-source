namespace TwitchLib.Client.Models
{
	public class JoinedChannel
	{
		public string Channel { get; }

		public ChannelState ChannelState { get; protected set; }

		public ChatMessage PreviousMessage { get; protected set; }

		public JoinedChannel(string channel)
		{
			Channel = channel;
		}

		public void HandleMessage(ChatMessage message)
		{
			PreviousMessage = message;
		}
	}
}
