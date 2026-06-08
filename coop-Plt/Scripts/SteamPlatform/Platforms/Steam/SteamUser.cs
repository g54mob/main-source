using Steamworks;

namespace Platforms.Steam
{
	public struct SteamUser : IUserDetails
	{
		public SteamId SteamID;

		public string Name;

		public SteamUser(SteamId id, string name)
		{
			Name = name;
			SteamID = id;
		}

		public bool IsEquivalent(IUserDetails other)
		{
			if (other is SteamUser steamUser)
			{
				return (ulong)SteamID == (ulong)steamUser.SteamID;
			}
			return false;
		}
	}
}
