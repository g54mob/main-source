using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 1)]
	[CallbackIdentity(4109)]
	public struct MusicPlayerWantsShuffled_t
	{
		public const int k_iCallback = 4109;

		public bool m_bShuffled;
	}
}
