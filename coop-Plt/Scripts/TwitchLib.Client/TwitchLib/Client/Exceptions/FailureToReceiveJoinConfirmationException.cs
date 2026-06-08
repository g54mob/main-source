namespace TwitchLib.Client.Exceptions
{
	public class FailureToReceiveJoinConfirmationException
	{
		public string Channel { get; protected set; }

		public string Details { get; protected set; }

		public FailureToReceiveJoinConfirmationException(string channel, string details = null)
		{
			Channel = channel;
			Details = details;
		}
	}
}
