using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 296)]
	[CallbackIdentity(1317)]
	public struct RemoteStorageDownloadUGCResult_t
	{
		public const int k_iCallback = 1317;

		public EResult m_eResult;

		public UGCHandle_t m_hFile;

		public AppId_t m_nAppID;

		public int m_nSizeInBytes;

		public string m_pchFileName;

		public ulong m_ulSteamIDOwner;
	}
}
