using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	public struct UserStatsStored_t
	{
		public const int k_iCallback = 1102;

		public ulong m_nGameID;

		public EResult m_eResult;
	}
}
