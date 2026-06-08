using System;
using System.Collections.Generic;

namespace TwitchLib.Client.Events
{
	public class OnExistingUsersDetectedArgs : EventArgs
	{
		public List<string> Users;

		public string Channel;
	}
}
