using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 1)]
	[CallbackIdentity(4110)]
	public struct MusicPlayerWantsLooped_t
	{
		public const int k_iCallback = 4110;

		public bool m_bLooped;
	}
}
