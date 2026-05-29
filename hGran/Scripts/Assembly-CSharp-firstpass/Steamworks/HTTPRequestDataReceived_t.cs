using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	[CallbackIdentity(2103)]
	public struct HTTPRequestDataReceived_t
	{
		public const int k_iCallback = 2103;

		public HTTPRequestHandle m_hRequest;

		public ulong m_ulContextValue;

		public uint m_cOffset;

		public uint m_cBytesReceived;
	}
}
