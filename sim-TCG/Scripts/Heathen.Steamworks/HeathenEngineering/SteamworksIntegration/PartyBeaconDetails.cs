using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct PartyBeaconDetails
	{
		public PartyBeaconID_t id;

		public UserData owner;

		public SteamPartyBeaconLocation_t location;

		public string metadata;
	}
}
