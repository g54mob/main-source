using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class Challenge : Asn1Encodable
	{
		private readonly AlgorithmIdentifier owf;

		private readonly Asn1OctetString witness;

		private readonly Asn1OctetString challenge;

		public virtual AlgorithmIdentifier Owf => null;

		private Challenge(Asn1Sequence seq)
		{
		}

		public static Challenge GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
