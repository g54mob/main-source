using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsCompressedDataStreamGenerator
	{
		private class CmsCompressedOutputStream : BaseOutputStream
		{
			private ZOutputStream _out;

			private BerSequenceGenerator _sGen;

			private BerSequenceGenerator _cGen;

			private BerSequenceGenerator _eiGen;

			internal CmsCompressedOutputStream(ZOutputStream outStream, BerSequenceGenerator sGen, BerSequenceGenerator cGen, BerSequenceGenerator eiGen)
			{
			}

			public override void WriteByte(byte b)
			{
			}

			public override void Write(byte[] bytes, int off, int len)
			{
			}

			public override void Close()
			{
			}
		}

		public const string ZLib = "1.2.840.113549.1.9.16.3.8";

		private int _bufferSize;

		public void SetBufferSize(int bufferSize)
		{
		}

		public Stream Open(Stream outStream, string compressionOID)
		{
			return null;
		}

		public Stream Open(Stream outStream, string contentOID, string compressionOID)
		{
			return null;
		}
	}
}
