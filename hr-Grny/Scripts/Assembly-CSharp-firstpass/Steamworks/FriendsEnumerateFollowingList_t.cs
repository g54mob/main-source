using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 412)]
	[CallbackIdentity(346)]
	public struct FriendsEnumerateFollowingList_t
	{
		public const int k_iCallback = 346;

		public EResult m_eResult;

		public CSteamID[] m_rgSteamID;

		public int m_nResultsReturned;

		public int m_nTotalResultCount;
	}
}
