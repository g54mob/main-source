using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsEnvelopedDataStreamGenerator : CmsEnvelopedGenerator
	{
		private class CmsEnvelopedDataOutputStream : BaseOutputStream
		{
			private readonly CmsEnvelopedGenerator _outer;

			private readonly CipherStream _out;

			private readonly BerSequenceGenerator _cGen;

			private readonly BerSequenceGenerator _envGen;

			private readonly BerSequenceGenerator _eiGen;

			public CmsEnvelopedDataOutputStream(CmsEnvelopedGenerator outer, CipherStream outStream, BerSequenceGenerator cGen, BerSequenceGenerator envGen, BerSequenceGenerator eiGen)
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

		private object _originatorInfo;

		private object _unprotectedAttributes;

		private int _bufferSize;

		private bool _berEncodeRecipientSet;

		private DerInteger Version => null;

		public CmsEnvelopedDataStreamGenerator()
		{
		}

		public CmsEnvelopedDataStreamGenerator(SecureRandom rand)
		{
		}

		public void SetBufferSize(int bufferSize)
		{
		}

		public void SetBerEncodeRecipients(bool berEncodeRecipientSet)
		{
		}

		private Stream Open(Stream outStream, string encryptionOid, CipherKeyGenerator keyGen)
		{
			return null;
		}

		private Stream Open(Stream outStream, AlgorithmIdentifier encAlgID, ICipherParameters cipherParameters, Asn1EncodableVector recipientInfos)
		{
			return null;
		}

		public Stream Open(Stream outStream, string encryptionOid)
		{
			return null;
		}

		public Stream Open(Stream outStream, string encryptionOid, int keySize)
		{
			return null;
		}
	}
}
