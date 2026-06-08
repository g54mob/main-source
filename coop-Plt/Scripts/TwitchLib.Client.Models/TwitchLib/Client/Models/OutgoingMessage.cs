namespace TwitchLib.Client.Models
{
	public class OutgoingMessage
	{
		public string Channel { get; set; }

		public string Message { get; set; }

		public int Nonce { get; set; }

		public string Sender { get; set; }

		public MessageState State { get; set; }
	}
}
