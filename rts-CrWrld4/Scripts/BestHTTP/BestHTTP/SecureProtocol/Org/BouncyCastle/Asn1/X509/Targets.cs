namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class Targets : Asn1Encodable
	{
		private readonly Asn1Sequence targets;

		public static Targets GetInstance(object obj)
		{
			return null;
		}

		private Targets(Asn1Sequence targets)
		{
		}

		public Targets(Target[] targets)
		{
		}

		public virtual Target[] GetTargets()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
