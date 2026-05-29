using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(1112)]
	public struct GlobalStatsReceived_t
	{
		public const int k_iCallback = 1112;

		public ulong m_nGameID;

		public EResult m_eResult;
	}
}
