using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	[CallbackIdentity(1023)]
	public struct FileDetailsResult_t
	{
		public const int k_iCallback = 1023;

		public EResult m_eResult;

		public ulong m_ulFileSize;

		public byte[] m_FileSHA;

		public uint m_unFlags;
	}
}
