using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnUserStateChangedArgs : EventArgs
	{
		public UserState UserState;
	}
}
