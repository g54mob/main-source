using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct LobbyEnter
	{
		public LobbyEnter_t data;

		public LobbyData Lobby => data.m_ulSteamIDLobby;

		public EChatRoomEnterResponse Response => (EChatRoomEnterResponse)data.m_EChatRoomEnterResponse;

		public bool Locked => data.m_bLocked;

		public static implicit operator LobbyEnter(LobbyEnter_t native)
		{
			return new LobbyEnter
			{
				data = native
			};
		}

		public static implicit operator LobbyEnter_t(LobbyEnter heathen)
		{
			return heathen.data;
		}
	}
}
