using System;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct LobbyAuthenticationData
	{
		public ulong to;

		public byte[] ticket;

		public byte[] inventory;
	}
}
