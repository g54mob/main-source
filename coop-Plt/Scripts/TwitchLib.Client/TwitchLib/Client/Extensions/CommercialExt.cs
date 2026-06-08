using System;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class CommercialExt
	{
		public static void StartCommercial(this ITwitchClient client, JoinedChannel channel, CommercialLength length)
		{
			switch (length)
			{
			case CommercialLength.Seconds30:
				client.SendMessage(channel, ".commercial 30");
				break;
			case CommercialLength.Seconds60:
				client.SendMessage(channel, ".commercial 60");
				break;
			case CommercialLength.Seconds90:
				client.SendMessage(channel, ".commercial 90");
				break;
			case CommercialLength.Seconds120:
				client.SendMessage(channel, ".commercial 120");
				break;
			case CommercialLength.Seconds150:
				client.SendMessage(channel, ".commercial 150");
				break;
			case CommercialLength.Seconds180:
				client.SendMessage(channel, ".commercial 180");
				break;
			default:
				throw new ArgumentOutOfRangeException("length", length, null);
			}
		}

		public static void StartCommercial(this ITwitchClient client, string channel, CommercialLength length)
		{
			switch (length)
			{
			case CommercialLength.Seconds30:
				client.SendMessage(channel, ".commercial 30");
				break;
			case CommercialLength.Seconds60:
				client.SendMessage(channel, ".commercial 60");
				break;
			case CommercialLength.Seconds90:
				client.SendMessage(channel, ".commercial 90");
				break;
			case CommercialLength.Seconds120:
				client.SendMessage(channel, ".commercial 120");
				break;
			case CommercialLength.Seconds150:
				client.SendMessage(channel, ".commercial 150");
				break;
			case CommercialLength.Seconds180:
				client.SendMessage(channel, ".commercial 180");
				break;
			default:
				throw new ArgumentOutOfRangeException("length", length, null);
			}
		}
	}
}
