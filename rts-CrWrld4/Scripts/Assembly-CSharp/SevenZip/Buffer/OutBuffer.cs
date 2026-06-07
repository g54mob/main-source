using System.IO;

namespace SevenZip.Buffer
{
	public class OutBuffer
	{
		private byte[] m_Buffer;

		private uint m_Pos;

		private uint m_BufferSize;

		private Stream m_Stream;

		private ulong m_ProcessedSize;

		public OutBuffer(uint bufferSize)
		{
		}

		public void SetStream(Stream stream)
		{
		}

		public void FlushStream()
		{
		}

		public void CloseStream()
		{
		}

		public void ReleaseStream()
		{
		}

		public void Init()
		{
		}

		public void WriteByte(byte b)
		{
		}

		public void FlushData()
		{
		}

		public ulong GetProcessedSize()
		{
			return 0uL;
		}
	}
}
