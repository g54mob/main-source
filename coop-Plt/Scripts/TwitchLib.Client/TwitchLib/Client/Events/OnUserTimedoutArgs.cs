using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnUserTimedoutArgs : EventArgs
	{
		public UserTimeout UserTimeout;
	}
}
