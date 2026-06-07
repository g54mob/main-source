using System;
using Steamworks;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct FriendRichPresenceUpdate
	{
		public FriendRichPresenceUpdate_t data;

		public readonly UserData Friend => data.m_steamIDFriend;

		public readonly AppData App => data.m_nAppID;

		public static implicit operator FriendRichPresenceUpdate(FriendRichPresenceUpdate_t native)
		{
			return new FriendRichPresenceUpdate
			{
				data = native
			};
		}

		public static implicit operator FriendRichPresenceUpdate_t(FriendRichPresenceUpdate heathen)
		{
			return heathen.data;
		}
	}
}
