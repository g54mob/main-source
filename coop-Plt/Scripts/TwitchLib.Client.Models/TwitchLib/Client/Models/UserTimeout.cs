using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class UserTimeout
	{
		public string Channel;

		public int TimeoutDuration;

		public string TimeoutReason;

		public string Username;

		public UserTimeout(IrcMessage ircMessage)
		{
			Channel = ircMessage.Channel;
			Username = ircMessage.Message;
			foreach (string key in ircMessage.Tags.Keys)
			{
				string text = ircMessage.Tags[key];
				string text2 = key;
				string text3 = text2;
				if (!(text3 == "ban-duration"))
				{
					if (text3 == "ban-reason")
					{
						TimeoutReason = text;
					}
				}
				else
				{
					TimeoutDuration = int.Parse(text);
				}
			}
		}

		public UserTimeout(string channel, string username, int timeoutDuration, string timeoutReason)
		{
			Channel = channel;
			Username = username;
			TimeoutDuration = timeoutDuration;
			TimeoutReason = timeoutReason;
		}
	}
}
