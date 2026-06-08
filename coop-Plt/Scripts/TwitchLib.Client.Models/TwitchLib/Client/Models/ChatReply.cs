namespace TwitchLib.Client.Models
{
	public class ChatReply
	{
		public string ParentDisplayName { get; internal set; }

		public string ParentMsgBody { get; internal set; }

		public string ParentMsgId { get; internal set; }

		public string ParentUserId { get; internal set; }

		public string ParentUserLogin { get; internal set; }
	}
}
