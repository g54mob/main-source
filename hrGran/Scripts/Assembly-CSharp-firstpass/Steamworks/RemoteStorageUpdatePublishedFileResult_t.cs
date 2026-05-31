using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	[CallbackIdentity(1316)]
	public struct RemoteStorageUpdatePublishedFileResult_t
	{
		public const int k_iCallback = 1316;

		public EResult m_eResult;

		public PublishedFileId_t m_nPublishedFileId;

		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
