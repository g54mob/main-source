using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(1311)]
	public struct RemoteStorageDeletePublishedFileResult_t
	{
		public const int k_iCallback = 1311;

		public EResult m_eResult;

		public PublishedFileId_t m_nPublishedFileId;
	}
}
