using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnUserBannedArgs : EventArgs
	{
		public UserBan UserBan;
	}
}
