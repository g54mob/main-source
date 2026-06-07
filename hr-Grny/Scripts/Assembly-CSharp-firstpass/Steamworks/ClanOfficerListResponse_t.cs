using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(335)]
	public struct ClanOfficerListResponse_t
	{
		public const int k_iCallback = 335;

		public CSteamID m_steamIDClan;

		public int m_cOfficers;

		public byte m_bSuccess;
	}
}
