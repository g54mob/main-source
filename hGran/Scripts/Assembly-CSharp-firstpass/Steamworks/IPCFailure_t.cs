using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 1)]
	[CallbackIdentity(117)]
	public struct IPCFailure_t
	{
		public const int k_iCallback = 117;

		public byte m_eFailureType;
	}
}
