using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	[CallbackIdentity(3404)]
	public struct SubmitItemUpdateResult_t
	{
		public const int k_iCallback = 3404;

		public EResult m_eResult;

		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;

		public PublishedFileId_t m_nPublishedFileId;
	}
}
