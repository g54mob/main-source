using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerOctetStringGenerator : BerGenerator
	{
		private class BufferedBerOctetStream : BaseOutputStream
		{
			private byte[] _buf;

			private int _off;

			private readonly BerOctetStringGenerator _gen;

			private readonly DerOutputStream _derOut;

			internal BufferedBerOctetStream(BerOctetStringGenerator gen, byte[] buf)
			{
			}

			public override void WriteByte(byte b)
			{
			}

			public override void Write(byte[] buf, int offset, int len)
			{
			}

			public override void Close()
			{
			}
		}

		public BerOctetStringGenerator(Stream outStream)
			: base(null)
		{
		}

		public BerOctetStringGenerator(Stream outStream, int tagNo, bool isExplicit)
			: base(null)
		{
		}

		public Stream GetOctetOutputStream()
		{
			return null;
		}

		public Stream GetOctetOutputStream(int bufSize)
		{
			return null;
		}

		public Stream GetOctetOutputStream(byte[] buf)
		{
			return null;
		}
	}
}
