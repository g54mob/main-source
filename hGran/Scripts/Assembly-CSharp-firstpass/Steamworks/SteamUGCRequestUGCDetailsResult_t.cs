using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 9784)]
	[CallbackIdentity(3402)]
	public struct SteamUGCRequestUGCDetailsResult_t
	{
		public const int k_iCallback = 3402;

		public SteamUGCDetails_t m_details;

		public bool m_bCachedData;
	}
}
