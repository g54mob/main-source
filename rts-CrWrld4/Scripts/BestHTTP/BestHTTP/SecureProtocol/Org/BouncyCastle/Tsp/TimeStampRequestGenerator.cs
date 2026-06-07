using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	public class TimeStampRequestGenerator
	{
		private DerObjectIdentifier reqPolicy;

		private DerBoolean certReq;

		private IDictionary extensions;

		private IList extOrdering;

		public void SetReqPolicy(string reqPolicy)
		{
		}

		public void SetCertReq(bool certReq)
		{
		}

		public void AddExtension(string oid, bool critical, Asn1Encodable value)
		{
		}

		public void AddExtension(string oid, bool critical, byte[] value)
		{
		}

		public virtual void AddExtension(DerObjectIdentifier oid, bool critical, Asn1Encodable extValue)
		{
		}

		public virtual void AddExtension(DerObjectIdentifier oid, bool critical, byte[] extValue)
		{
		}

		public TimeStampRequest Generate(string digestAlgorithm, byte[] digest)
		{
			return null;
		}

		public TimeStampRequest Generate(string digestAlgorithmOid, byte[] digest, BigInteger nonce)
		{
			return null;
		}

		public virtual TimeStampRequest Generate(DerObjectIdentifier digestAlgorithm, byte[] digest)
		{
			return null;
		}

		public virtual TimeStampRequest Generate(DerObjectIdentifier digestAlgorithm, byte[] digest, BigInteger nonce)
		{
			return null;
		}
	}
}
