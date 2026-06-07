using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Tsp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	public class TimeStampRequest : X509ExtensionBase
	{
		private TimeStampReq req;

		private X509Extensions extensions;

		public int Version => 0;

		public string MessageImprintAlgOid => null;

		public string ReqPolicy => null;

		public BigInteger Nonce => null;

		public bool CertReq => false;

		internal X509Extensions Extensions => null;

		public virtual bool HasExtensions => false;

		public TimeStampRequest(TimeStampReq req)
		{
		}

		public TimeStampRequest(byte[] req)
		{
		}

		public TimeStampRequest(Stream input)
		{
		}

		private TimeStampRequest(Asn1InputStream str)
		{
		}

		public byte[] GetMessageImprintDigest()
		{
			return null;
		}

		public void Validate(IList algorithms, IList policies, IList extensions)
		{
		}

		public byte[] GetEncoded()
		{
			return null;
		}

		public virtual X509Extension GetExtension(DerObjectIdentifier oid)
		{
			return null;
		}

		public virtual IList GetExtensionOids()
		{
			return null;
		}

		protected override X509Extensions GetX509Extensions()
		{
			return null;
		}
	}
}
