using System;
using System.Collections.Generic;

namespace TwitchLib.Client.Events
{
	public class OnModeratorsReceivedArgs : EventArgs
	{
		public string Channel;

		public List<string> Moderators;
	}
}
