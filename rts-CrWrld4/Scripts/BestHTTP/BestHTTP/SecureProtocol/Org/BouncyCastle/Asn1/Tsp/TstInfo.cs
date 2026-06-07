using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Tsp
{
	public class TstInfo : Asn1Encodable
	{
		private readonly DerInteger version;

		private readonly DerObjectIdentifier tsaPolicyId;

		private readonly MessageImprint messageImprint;

		private readonly DerInteger serialNumber;

		private readonly DerGeneralizedTime genTime;

		private readonly Accuracy accuracy;

		private readonly DerBoolean ordering;

		private readonly DerInteger nonce;

		private readonly GeneralName tsa;

		private readonly X509Extensions extensions;

		public DerInteger Version => null;

		public MessageImprint MessageImprint => null;

		public DerObjectIdentifier Policy => null;

		public DerInteger SerialNumber => null;

		public Accuracy Accuracy => null;

		public DerGeneralizedTime GenTime => null;

		public DerBoolean Ordering => null;

		public DerInteger Nonce => null;

		public GeneralName Tsa => null;

		public X509Extensions Extensions => null;

		public static TstInfo GetInstance(object obj)
		{
			return null;
		}

		private TstInfo(Asn1Sequence seq)
		{
		}

		public TstInfo(DerObjectIdentifier tsaPolicyId, MessageImprint messageImprint, DerInteger serialNumber, DerGeneralizedTime genTime, Accuracy accuracy, DerBoolean ordering, DerInteger nonce, GeneralName tsa, X509Extensions extensions)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
