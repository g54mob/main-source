using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 152)]
	[CallbackIdentity(3416)]
	public struct GetAppDependenciesResult_t
	{
		public const int k_iCallback = 3416;

		public EResult m_eResult;

		public PublishedFileId_t m_nPublishedFileId;

		public AppId_t[] m_rgAppIDs;

		public uint m_nNumAppDependencies;

		public uint m_nTotalNumAppDependencies;
	}
}
