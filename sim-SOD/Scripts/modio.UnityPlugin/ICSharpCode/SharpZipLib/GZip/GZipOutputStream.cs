using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.GZip
{
	public class GZipOutputStream : DeflaterOutputStream
	{
		private enum OutputState
		{
			Header = 0,
			Footer = 1,
			Finished = 2,
			Closed = 3
		}

		protected Crc32 crc;

		private OutputState state_;

		private string fileName;

		private GZipFlags flags;

		public string FileName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GZipOutputStream(Stream baseOutputStream)
			: base(null)
		{
		}

		public GZipOutputStream(Stream baseOutputStream, int size)
			: base(null)
		{
		}

		public void SetLevel(int level)
		{
		}

		public int GetLevel()
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
		}

		public override void Finish()
		{
		}

		private static string CleanFilename(string path)
		{
			return null;
		}

		private void WriteHeader()
		{
		}
	}
}
