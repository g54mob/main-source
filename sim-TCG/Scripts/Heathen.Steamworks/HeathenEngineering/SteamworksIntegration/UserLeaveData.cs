using System;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct UserLeaveData
	{
		public ChatRoom room;

		public UserData user;

		public bool kicked;

		public bool dropped;
	}
}
