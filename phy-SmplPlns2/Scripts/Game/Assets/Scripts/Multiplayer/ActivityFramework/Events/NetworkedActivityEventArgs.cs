using System;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityEventArgs : EventArgs
	{
		public NetworkedActivityScript Activity { get; }

		public NetworkedActivityEventArgs(NetworkedActivityScript activity)
		{
			Activity = activity;
		}
	}
}
