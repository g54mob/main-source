using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class AuthorityKeyIdentifier : Asn1Encodable
	{
		private readonly Asn1OctetString keyidentifier;

		private readonly GeneralNames certissuer;

		private readonly DerInteger certserno;

		public GeneralNames AuthorityCertIssuer => null;

		public BigInteger AuthorityCertSerialNumber => null;

		public static AuthorityKeyIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static AuthorityKeyIdentifier GetInstance(object obj)
		{
			return null;
		}

		public static AuthorityKeyIdentifier FromExtensions(X509Extensions extensions)
		{
			return null;
		}

		protected internal AuthorityKeyIdentifier(Asn1Sequence seq)
		{
		}

		public AuthorityKeyIdentifier(SubjectPublicKeyInfo spki)
		{
		}

		public AuthorityKeyIdentifier(SubjectPublicKeyInfo spki, GeneralNames name, BigInteger serialNumber)
		{
		}

		public AuthorityKeyIdentifier(GeneralNames name, BigInteger serialNumber)
		{
		}

		public AuthorityKeyIdentifier(byte[] keyIdentifier)
		{
		}

		public AuthorityKeyIdentifier(byte[] keyIdentifier, GeneralNames name, BigInteger serialNumber)
		{
		}

		public byte[] GetKeyIdentifier()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
