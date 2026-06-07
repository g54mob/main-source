namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class TargetInformation : Asn1Encodable
	{
		private readonly Asn1Sequence targets;

		public static TargetInformation GetInstance(object obj)
		{
			return null;
		}

		private TargetInformation(Asn1Sequence targets)
		{
		}

		public virtual Targets[] GetTargetsObjects()
		{
			return null;
		}

		public TargetInformation(Targets targets)
		{
		}

		public TargetInformation(Target[] targets)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
