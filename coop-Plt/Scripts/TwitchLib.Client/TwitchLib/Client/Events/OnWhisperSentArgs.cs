using System;

namespace TwitchLib.Client.Events
{
	public class OnWhisperSentArgs : EventArgs
	{
		public string Username;

		public string Receiver;

		public string Message;
	}
}
