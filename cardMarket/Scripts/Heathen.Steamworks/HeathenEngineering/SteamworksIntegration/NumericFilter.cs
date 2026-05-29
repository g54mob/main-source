using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct NumericFilter
	{
		public string key;

		public int value;

		public ELobbyComparison comparison;
	}
}
