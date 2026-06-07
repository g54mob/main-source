using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class OptionalValidity : Asn1Encodable
	{
		private readonly Time notBefore;

		private readonly Time notAfter;

		public virtual Time NotBefore => null;

		public virtual Time NotAfter => null;

		private OptionalValidity(Asn1Sequence seq)
		{
		}

		public static OptionalValidity GetInstance(object obj)
		{
			return null;
		}

		public OptionalValidity(Time notBefore, Time notAfter)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
