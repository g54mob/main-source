using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Extension
{
	public class SubjectKeyIdentifierStructure : SubjectKeyIdentifier
	{
		public SubjectKeyIdentifierStructure(Asn1OctetString encodedValue)
			: base((byte[])null)
		{
		}

		private static Asn1OctetString FromPublicKey(AsymmetricKeyParameter pubKey)
		{
			return null;
		}

		public SubjectKeyIdentifierStructure(AsymmetricKeyParameter pubKey)
			: base((byte[])null)
		{
		}
	}
}
