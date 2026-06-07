using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class ResponderID : Asn1Encodable, IAsn1Choice
	{
		private readonly Asn1Encodable id;

		public virtual X509Name Name => null;

		public static ResponderID GetInstance(object obj)
		{
			return null;
		}

		public ResponderID(Asn1OctetString id)
		{
		}

		public ResponderID(X509Name id)
		{
		}

		public static ResponderID GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public virtual byte[] GetKeyHash()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
