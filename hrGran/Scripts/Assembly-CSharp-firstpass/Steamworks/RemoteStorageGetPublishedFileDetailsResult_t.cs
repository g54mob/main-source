using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 9760)]
	[CallbackIdentity(1318)]
	public struct RemoteStorageGetPublishedFileDetailsResult_t
	{
		public const int k_iCallback = 1318;

		public EResult m_eResult;

		public PublishedFileId_t m_nPublishedFileId;

		public AppId_t m_nCreatorAppID;

		public AppId_t m_nConsumerAppID;

		public string m_rgchTitle;

		public string m_rgchDescription;

		public UGCHandle_t m_hFile;

		public UGCHandle_t m_hPreviewFile;

		public ulong m_ulSteamIDOwner;

		public uint m_rtimeCreated;

		public uint m_rtimeUpdated;

		public ERemoteStoragePublishedFileVisibility m_eVisibility;

		public bool m_bBanned;

		public string m_rgchTags;

		public bool m_bTagsTruncated;

		public string m_pchFileName;

		public int m_nFileSize;

		public int m_nPreviewFileSize;

		public string m_rgchURL;

		public EWorkshopFileType m_eFileType;

		public bool m_bAcceptedForUse;
	}
}
