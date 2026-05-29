using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	[CallbackIdentity(3406)]
	public struct DownloadItemResult_t
	{
		public const int k_iCallback = 3406;

		public AppId_t m_unAppID;

		public PublishedFileId_t m_nPublishedFileId;

		public EResult m_eResult;
	}
}
