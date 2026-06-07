using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class OriginatorIdentifierOrKey : Asn1Encodable, IAsn1Choice
	{
		private Asn1Encodable id;

		public Asn1Encodable ID => null;

		public IssuerAndSerialNumber IssuerAndSerialNumber => null;

		public SubjectKeyIdentifier SubjectKeyIdentifier => null;

		public OriginatorPublicKey OriginatorKey => null;

		public OriginatorPublicKey OriginatorPublicKey => null;

		public OriginatorIdentifierOrKey(IssuerAndSerialNumber id)
		{
		}

		public OriginatorIdentifierOrKey(Asn1OctetString id)
		{
		}

		public OriginatorIdentifierOrKey(SubjectKeyIdentifier id)
		{
		}

		public OriginatorIdentifierOrKey(OriginatorPublicKey id)
		{
		}

		public OriginatorIdentifierOrKey(Asn1Object id)
		{
		}

		private OriginatorIdentifierOrKey(Asn1TaggedObject id)
		{
		}

		public static OriginatorIdentifierOrKey GetInstance(Asn1TaggedObject o, bool explicitly)
		{
			return null;
		}

		public static OriginatorIdentifierOrKey GetInstance(object o)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
