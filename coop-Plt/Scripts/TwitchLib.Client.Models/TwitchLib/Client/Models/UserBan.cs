using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class UserBan
	{
		public string BanReason;

		public string Channel;

		public string Username;

		public string RoomId;

		public string TargetUserId;

		public UserBan(IrcMessage ircMessage)
		{
			Channel = ircMessage.Channel;
			Username = ircMessage.Message;
			if (ircMessage.Tags.TryGetValue("ban-reason", out var value))
			{
				BanReason = value;
			}
			if (ircMessage.Tags.TryGetValue("room-id", out var value2))
			{
				RoomId = value2;
			}
			if (ircMessage.Tags.TryGetValue("target-user-id", out var value3))
			{
				TargetUserId = value3;
			}
		}

		public UserBan(string channel, string username, string banReason, string roomId, string targetUserId)
		{
			Channel = channel;
			Username = username;
			BanReason = banReason;
			RoomId = roomId;
			TargetUserId = targetUserId;
		}
	}
}
