using Steamworks;

namespace SwissCode.Steam
{
	public class SteamFriendsFacade : SteamFacade
	{
		public bool IsFriend(CSteamID steamId, EFriendFlags flags = EFriendFlags.k_EFriendFlagImmediate)
		{
			if (Initialized)
			{
				return SteamFriends.HasFriend(steamId, flags);
			}
			return false;
		}

		public void SetRichPresence(string key, string value)
		{
			if (Initialized)
			{
				SteamFriends.SetRichPresence(key, value);
			}
		}

		public void ClearRichPresence()
		{
			if (Initialized)
			{
				SteamFriends.ClearRichPresence();
			}
		}
	}
}
