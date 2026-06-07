using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsDeflateCompression : TlsCompression
	{
		protected class DeflateOutputStream : ZOutputStream
		{
			public DeflateOutputStream(Stream output, ZStream z, bool compress)
				: base(null)
			{
			}

			public override void Flush()
			{
			}
		}

		public const int LEVEL_NONE = 0;

		public const int LEVEL_FASTEST = 1;

		public const int LEVEL_SMALLEST = 9;

		public const int LEVEL_DEFAULT = -1;

		protected readonly ZStream zIn;

		protected readonly ZStream zOut;

		public TlsDeflateCompression()
		{
		}

		public TlsDeflateCompression(int level)
		{
		}

		public virtual Stream Compress(Stream output)
		{
			return null;
		}

		public virtual Stream Decompress(Stream output)
		{
			return null;
		}
	}
}
