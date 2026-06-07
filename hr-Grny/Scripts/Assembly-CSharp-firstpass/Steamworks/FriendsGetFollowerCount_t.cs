using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 16)]
	[CallbackIdentity(344)]
	public struct FriendsGetFollowerCount_t
	{
		public const int k_iCallback = 344;

		public EResult m_eResult;

		public CSteamID m_steamID;

		public int m_nCount;
	}
}
