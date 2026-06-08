using System;
using TwitchLib.PubSub.Models.Responses;

namespace TwitchLib.PubSub.Events
{
	public class OnListenResponseArgs : EventArgs
	{
		public string Topic;

		public Response Response;

		public bool Successful;

		public string ChannelId;
	}
}
