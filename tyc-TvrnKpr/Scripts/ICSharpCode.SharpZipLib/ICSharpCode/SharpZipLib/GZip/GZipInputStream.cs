using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.GZip
{
	public class GZipInputStream : InflaterInputStream
	{
		protected Crc32 crc;

		private bool readGZIPHeader;

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

		private bool ReadHeader()
		{
			return false;
		}

		private void ReadFooter()
		{
		}
	}
}
