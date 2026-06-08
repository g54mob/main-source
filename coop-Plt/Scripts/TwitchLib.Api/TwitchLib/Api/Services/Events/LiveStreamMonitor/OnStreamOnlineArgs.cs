using System;
using TwitchLib.Api.Helix.Models.Streams.GetStreams;

namespace TwitchLib.Api.Services.Events.LiveStreamMonitor
{
	public class OnStreamOnlineArgs : EventArgs
	{
		public string Channel;

		public Stream Stream;
	}
}
