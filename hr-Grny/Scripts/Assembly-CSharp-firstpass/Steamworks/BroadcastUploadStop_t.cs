using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	[CallbackIdentity(4605)]
	public struct BroadcastUploadStop_t
	{
		public const int k_iCallback = 4605;

		public EBroadcastUploadResult m_eResult;
	}
}
