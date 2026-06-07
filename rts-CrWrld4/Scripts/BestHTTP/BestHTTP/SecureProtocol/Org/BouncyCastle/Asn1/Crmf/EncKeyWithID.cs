using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class EncKeyWithID : Asn1Encodable
	{
		private readonly PrivateKeyInfo privKeyInfo;

		private readonly Asn1Encodable identifier;

		public virtual PrivateKeyInfo PrivateKey => null;

		public virtual bool HasIdentifier => false;

		public virtual bool IsIdentifierUtf8String => false;

		public virtual Asn1Encodable Identifier => null;

		public static EncKeyWithID GetInstance(object obj)
		{
			return null;
		}

		private EncKeyWithID(Asn1Sequence seq)
		{
		}

		public EncKeyWithID(PrivateKeyInfo privKeyInfo)
		{
		}

		public EncKeyWithID(PrivateKeyInfo privKeyInfo, DerUtf8String str)
		{
		}

		public EncKeyWithID(PrivateKeyInfo privKeyInfo, GeneralName generalName)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
