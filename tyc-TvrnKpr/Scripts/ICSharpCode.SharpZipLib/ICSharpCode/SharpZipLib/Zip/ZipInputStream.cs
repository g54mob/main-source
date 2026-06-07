using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ZipInputStream : InflaterInputStream
	{
		private delegate int ReadDataHandler(byte[] b, int offset, int length);

		private ReadDataHandler internalReader;

		private Crc32 crc;

		private ZipEntry entry;

		private long size;

		private int method;

		private int flags;

		private string password;

		public string Password
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CanDecompressEntry => false;

		public override int Available => 0;

		public override long Length => 0L;

		public ZipInputStream(Stream baseInputStream)
			: base(null)
		{
		}

		public ZipInputStream(Stream baseInputStream, int bufferSize)
			: base(null)
		{
		}

		public ZipEntry GetNextEntry()
		{
			return null;
		}

		private void ReadDataDescriptor()
		{
		}

		private void CompleteCloseEntry(bool testCrc)
		{
		}

		public void CloseEntry()
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		private int ReadingNotAvailable(byte[] destination, int offset, int count)
		{
			return 0;
		}

		private int ReadingNotSupported(byte[] destination, int offset, int count)
		{
			return 0;
		}

		private int InitialRead(byte[] destination, int offset, int count)
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private int BodyRead(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Close()
		{
		}
	}
}
