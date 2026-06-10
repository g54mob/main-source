using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	public class InflaterInputBuffer
	{
		private int rawLength;

		private byte[] rawData;

		private int clearTextLength;

		private byte[] clearText;

		private byte[] internalClearText;

		private int available;

		private ICryptoTransform cryptoTransform;

		private Stream inputStream;

		public int RawLength => 0;

		public byte[] RawData => null;

		public int ClearTextLength => 0;

		public byte[] ClearText => null;

		public int Available
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ICryptoTransform CryptoTransform
		{
			set
			{
			}
		}

		public InflaterInputBuffer(Stream stream)
		{
		}

		public InflaterInputBuffer(Stream stream, int bufferSize)
		{
		}

		public void SetInflaterInput(Inflater inflater)
		{
		}

		public void Fill()
		{
		}

		public int ReadRawBuffer(byte[] buffer)
		{
			return 0;
		}

		public int ReadRawBuffer(byte[] outBuffer, int offset, int length)
		{
			return 0;
		}

		public int ReadClearTextBuffer(byte[] outBuffer, int offset, int length)
		{
			return 0;
		}

		public byte ReadLeByte()
		{
			return 0;
		}

		public int ReadLeShort()
		{
			return 0;
		}

		public int ReadLeInt()
		{
			return 0;
		}

		public long ReadLeLong()
		{
			return 0L;
		}
	}
}
