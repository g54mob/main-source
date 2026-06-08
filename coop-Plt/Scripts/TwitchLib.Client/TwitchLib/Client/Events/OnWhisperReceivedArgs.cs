using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnWhisperReceivedArgs : EventArgs
	{
		public WhisperMessage WhisperMessage;
	}
}
