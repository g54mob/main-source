using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsTypedStream
	{
		private class FullReaderStream : FilterStream
		{
			internal FullReaderStream(Stream input)
				: base(null)
			{
			}

			public override int Read(byte[] buf, int off, int len)
			{
				return 0;
			}
		}

		private const int BufferSize = 32768;

		private readonly string _oid;

		private readonly Stream _in;

		public string ContentType => null;

		public Stream ContentStream => null;

		public CmsTypedStream(Stream inStream)
		{
		}

		public CmsTypedStream(string oid, Stream inStream)
		{
		}

		public CmsTypedStream(string oid, Stream inStream, int bufSize)
		{
		}

		public void Drain()
		{
		}
	}
}
