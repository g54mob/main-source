using System;
using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Events
{
	public class OnWhisperArgs : EventArgs
	{
		public Whisper Whisper;

		public string ChannelId;
	}
}
