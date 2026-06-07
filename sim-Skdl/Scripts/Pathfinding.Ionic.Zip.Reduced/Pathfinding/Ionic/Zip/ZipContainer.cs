using System.IO;
using System.Text;
using Pathfinding.Ionic.Zlib;

namespace Pathfinding.Ionic.Zip
{
	internal class ZipContainer
	{
		private ZipFile _zf;

		private ZipOutputStream _zos;

		private ZipInputStream _zis;

		public ZipFile ZipFile => null;

		public ZipOutputStream ZipOutputStream => null;

		public string Name => null;

		public string Password => null;

		public Zip64Option Zip64 => default(Zip64Option);

		public int BufferSize => 0;

		public ParallelDeflateOutputStream ParallelDeflater
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public long ParallelDeflateThreshold => 0L;

		public int ParallelDeflateMaxBufferPairs => 0;

		public int CodecBufferSize => 0;

		public CompressionStrategy Strategy => default(CompressionStrategy);

		public Zip64Option UseZip64WhenSaving => default(Zip64Option);

		public Encoding AlternateEncoding => null;

		public Encoding DefaultEncoding => null;

		public ZipOption AlternateEncodingUsage => default(ZipOption);

		public Stream ReadStream => null;

		public ZipContainer(object o)
		{
		}
	}
}
