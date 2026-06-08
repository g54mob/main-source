using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnWhisperCommandReceivedArgs : EventArgs
	{
		public WhisperCommand Command;
	}
}
