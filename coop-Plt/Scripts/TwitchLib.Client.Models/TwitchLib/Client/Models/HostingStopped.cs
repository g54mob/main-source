using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class HostingStopped
	{
		public string HostingChannel;

		public int Viewers;

		public HostingStopped(IrcMessage ircMessage)
		{
			string[] array = ircMessage.Message.Split(' ');
			HostingChannel = ircMessage.Channel;
			Viewers = ((!array[1].StartsWith("-")) ? int.Parse(array[1]) : 0);
		}

		public HostingStopped(string hostingChannel, int viewers)
		{
			HostingChannel = hostingChannel;
			Viewers = viewers;
		}
	}
}
