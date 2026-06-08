namespace TwitchLib.Client.Models
{
	public class OutboundChatMessage
	{
		public string Channel { get; set; }

		public string Message { get; set; }

		public string Username { get; set; }

		public string ReplyToId { get; set; }

		public override string ToString()
		{
			string text = Username.ToLower();
			string text2 = Channel.ToLower();
			if (ReplyToId == null)
			{
				return ":" + text + "!" + text + "@" + text + ".tmi.twitch.tv PRIVMSG #" + text2 + " :" + Message;
			}
			return "@reply-parent-msg-id=" + ReplyToId + " PRIVMSG #" + text2 + " :" + Message;
		}
	}
}
