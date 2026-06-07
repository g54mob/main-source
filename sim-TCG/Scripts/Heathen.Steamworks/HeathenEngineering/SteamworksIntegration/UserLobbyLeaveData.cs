using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct UserLobbyLeaveData
	{
		public UserData user;

		public EChatMemberStateChange state;
	}
}
