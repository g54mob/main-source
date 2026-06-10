using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.GZip
{
	public class GZipInputStream : InflaterInputStream
	{
		protected Crc32 crc;

		private bool readGZIPHeader;

		private bool completedLastBlock;

		private string fileName;

		public GZipInputStream(Stream baseInputStream)
			: base(null)
		{
		}

		public GZipInputStream(Stream baseInputStream, int size)
			: base(null)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public string GetFilename()
		{
			return null;
		}

		private bool ReadHeader()
		{
			return false;
		}

		private void ReadFooter()
		{
		}
	}
}
