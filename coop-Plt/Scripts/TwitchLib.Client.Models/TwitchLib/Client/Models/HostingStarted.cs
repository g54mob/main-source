using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class HostingStarted
	{
		public string HostingChannel;

		public string TargetChannel;

		public int Viewers;

		public HostingStarted(IrcMessage ircMessage)
		{
			string[] array = ircMessage.Message.Split(' ');
			HostingChannel = ircMessage.Channel;
			TargetChannel = array[0];
			Viewers = ((!array[1].StartsWith("-")) ? int.Parse(array[1]) : 0);
		}

		public HostingStarted(string hostingChannel, string targetChannel, int viewers)
		{
			HostingChannel = hostingChannel;
			TargetChannel = targetChannel;
			Viewers = viewers;
		}
	}
}
