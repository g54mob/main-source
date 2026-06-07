using System;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct LobbyGameServer
	{
		public CSteamID id;

		public uint ipAddress;

		public ushort port;

		public string IpAddress
		{
			get
			{
				return Utilities.IPUintToString(ipAddress);
			}
			set
			{
				ipAddress = Utilities.IPStringToUint(value);
			}
		}
	}
}
