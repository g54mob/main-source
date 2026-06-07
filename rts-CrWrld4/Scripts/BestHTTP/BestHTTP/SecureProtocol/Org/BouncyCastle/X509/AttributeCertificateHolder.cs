using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class AttributeCertificateHolder : IX509Selector, ICloneable
	{
		internal readonly Holder holder;

		public int DigestedObjectType => 0;

		public string DigestAlgorithm => null;

		public string OtherObjectTypeID => null;

		public BigInteger SerialNumber => null;

		internal AttributeCertificateHolder(Asn1Sequence seq)
		{
		}

		public AttributeCertificateHolder(X509Name issuerName, BigInteger serialNumber)
		{
		}

		public AttributeCertificateHolder(X509Certificate cert)
		{
		}

		public AttributeCertificateHolder(X509Name principal)
		{
		}

		public AttributeCertificateHolder(int digestedObjectType, string digestAlgorithm, string otherObjectTypeID, byte[] objectDigest)
		{
		}

		public byte[] GetObjectDigest()
		{
			return null;
		}

		private GeneralNames GenerateGeneralNames(X509Name principal)
		{
			return null;
		}

		private bool MatchesDN(X509Name subject, GeneralNames targets)
		{
			return false;
		}

		private object[] GetNames(GeneralName[] names)
		{
			return null;
		}

		private X509Name[] GetPrincipals(GeneralNames names)
		{
			return null;
		}

		public X509Name[] GetEntityNames()
		{
			return null;
		}

		public X509Name[] GetIssuer()
		{
			return null;
		}

		public object Clone()
		{
			return null;
		}

		public bool Match(X509Certificate x509Cert)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Match(object obj)
		{
			return false;
		}
	}
}
