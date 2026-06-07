using System;
using Steamworks;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct LobbyInvite
	{
		public LobbyInvite_t data;

		public UserData FromUser => data.m_ulSteamIDUser;

		public LobbyData ToLobby => data.m_ulSteamIDLobby;

		public GameData ForGame => data.m_ulGameID;

		public static implicit operator LobbyInvite(LobbyInvite_t native)
		{
			return new LobbyInvite
			{
				data = native
			};
		}

		public static implicit operator LobbyInvite_t(LobbyInvite heathen)
		{
			return heathen.data;
		}
	}
}
