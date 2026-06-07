using System;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivitySettingEventArgs : EventArgs
	{
		public NetworkedActivitySetting Setting { get; }

		public NetworkedActivitySettingEventArgs(NetworkedActivitySetting setting)
		{
			Setting = setting;
		}
	}
}
