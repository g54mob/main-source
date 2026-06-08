using System;
using System.Linq;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class BeingHostedNotification
	{
		public string BotUsername { get; }

		public string Channel { get; }

		public string HostedByChannel { get; }

		public bool IsAutoHosted { get; }

		public int Viewers { get; }

		public BeingHostedNotification(string botUsername, IrcMessage ircMessage)
		{
			Channel = ircMessage.Channel;
			BotUsername = botUsername;
			HostedByChannel = ircMessage.Message.Split(' ').First();
			if (ircMessage.Message.Contains("up to "))
			{
				string[] array = ircMessage.Message.Split(new string[1] { "up to " }, StringSplitOptions.None);
				if (array[1].Contains(" ") && int.TryParse(array[1].Split(' ')[0], out var result))
				{
					Viewers = result;
				}
			}
			if (ircMessage.Message.Contains("auto hosting"))
			{
				IsAutoHosted = true;
			}
		}

		public BeingHostedNotification(string channel, string botUsername, string hostedByChannel, int viewers, bool isAutoHosted)
		{
			Channel = channel;
			BotUsername = botUsername;
			HostedByChannel = hostedByChannel;
			Viewers = viewers;
			IsAutoHosted = isAutoHosted;
		}
	}
}
