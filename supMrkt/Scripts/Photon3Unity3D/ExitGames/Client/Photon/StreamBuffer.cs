using System.IO;

namespace ExitGames.Client.Photon
{
	public class StreamBuffer
	{
		private const int DefaultInitialSize = 0;

		private int pos;

		private int len;

		private byte[] buf;

		public bool CanRead => false;

		public bool CanSeek => false;

		public bool CanWrite => false;

		public int Length => 0;

		public int Position
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Available => 0;

		public StreamBuffer(int size = 0)
		{
		}

		public StreamBuffer(byte[] buf)
		{
		}

		public byte[] ToArray()
		{
			return null;
		}

		public byte[] ToArrayFromPos()
		{
			return null;
		}

		public void Compact()
		{
		}

		public byte[] GetBuffer()
		{
			return null;
		}

		public byte[] GetBufferAndAdvance(int length, out int offset)
		{
			offset = default(int);
			return null;
		}

		public void Flush()
		{
		}

		public long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public void SetLength(long value)
		{
		}

		public void SetCapacityMinimum(int neededSize)
		{
		}

		public int Read(byte[] buffer, int dstOffset, int count)
		{
			return 0;
		}

		public void Write(byte[] buffer, int srcOffset, int count)
		{
		}

		public byte ReadByte()
		{
			return 0;
		}

		public void WriteByte(byte value)
		{
		}

		public void WriteBytes(byte v0, byte v1)
		{
		}

		public void WriteBytes(byte v0, byte v1, byte v2)
		{
		}

		public void WriteBytes(byte v0, byte v1, byte v2, byte v3)
		{
		}

		public void WriteBytes(byte v0, byte v1, byte v2, byte v3, byte v4, byte v5, byte v6, byte v7)
		{
		}

		private bool CheckSize(int size)
		{
			return false;
		}
	}
}
