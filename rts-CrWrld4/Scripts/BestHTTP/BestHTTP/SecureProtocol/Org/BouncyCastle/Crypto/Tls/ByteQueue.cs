using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class ByteQueue
	{
		private const int DefaultCapacity = 1024;

		private byte[] databuf;

		private int skipped;

		private int available;

		private bool readOnlyBuf;

		public int Available => 0;

		public static int NextTwoPow(int i)
		{
			return 0;
		}

		public ByteQueue()
		{
		}

		public ByteQueue(int capacity)
		{
		}

		public ByteQueue(byte[] buf, int off, int len)
		{
		}

		public void AddData(byte[] data, int offset, int len)
		{
		}

		public void CopyTo(Stream output, int length)
		{
		}

		public void Read(byte[] buf, int offset, int len, int skip)
		{
		}

		public MemoryStream ReadFrom(int length)
		{
			return null;
		}

		public void RemoveData(int i)
		{
		}

		public void RemoveData(byte[] buf, int off, int len, int skip)
		{
		}

		public byte[] RemoveData(int len, int skip)
		{
			return null;
		}

		public void Shrink()
		{
		}
	}
}
