using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 1, Size = 18)]
	[CallbackIdentity(208)]
	public struct GSClientGroupStatus_t
	{
		public const int k_iCallback = 208;

		public CSteamID m_SteamIDUser;

		public CSteamID m_SteamIDGroup;

		public bool m_bMember;

		public bool m_bOfficer;
	}
}
