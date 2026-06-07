using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(304)]
	public struct PersonaStateChange_t
	{
		public const int k_iCallback = 304;

		public ulong m_ulSteamID;

		public EPersonaChange m_nChangeFlags;
	}
}
