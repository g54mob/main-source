using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 252)]
	[CallbackIdentity(1021)]
	public struct AppProofOfPurchaseKeyResponse_t
	{
		public const int k_iCallback = 1021;

		public EResult m_eResult;

		public uint m_nAppID;

		public uint m_cchKeyLength;

		public string m_rgchKey;
	}
}
