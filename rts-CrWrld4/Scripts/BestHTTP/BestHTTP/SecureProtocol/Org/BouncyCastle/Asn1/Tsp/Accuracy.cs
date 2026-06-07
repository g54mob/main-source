namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Tsp
{
	public class Accuracy : Asn1Encodable
	{
		private readonly DerInteger seconds;

		private readonly DerInteger millis;

		private readonly DerInteger micros;

		protected const int MinMillis = 1;

		protected const int MaxMillis = 999;

		protected const int MinMicros = 1;

		protected const int MaxMicros = 999;

		public DerInteger Seconds => null;

		public DerInteger Millis => null;

		public DerInteger Micros => null;

		public Accuracy(DerInteger seconds, DerInteger millis, DerInteger micros)
		{
		}

		private Accuracy(Asn1Sequence seq)
		{
		}

		public static Accuracy GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
