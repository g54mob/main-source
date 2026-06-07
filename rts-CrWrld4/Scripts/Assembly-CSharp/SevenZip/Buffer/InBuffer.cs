using System.IO;

namespace SevenZip.Buffer
{
	public class InBuffer
	{
		private byte[] m_Buffer;

		private uint m_Pos;

		private uint m_Limit;

		private uint m_BufferSize;

		private Stream m_Stream;

		private bool m_StreamWasExhausted;

		private ulong m_ProcessedSize;

		public InBuffer(uint bufferSize)
		{
		}

		public void Init(Stream stream)
		{
		}

		public bool ReadBlock()
		{
			return false;
		}

		public void ReleaseStream()
		{
		}

		public bool ReadByte(byte b)
		{
			return false;
		}

		public byte ReadByte()
		{
			return 0;
		}

		public ulong GetProcessedSize()
		{
			return 0uL;
		}
	}
}
