using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	[CallbackIdentity(1331)]
	public struct RemoteStorageFileWriteAsyncComplete_t
	{
		public const int k_iCallback = 1331;

		public EResult m_eResult;
	}
}
