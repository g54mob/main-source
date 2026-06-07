namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class Target : Asn1Encodable, IAsn1Choice
	{
		public enum Choice
		{
			Name = 0,
			Group = 1
		}

		private readonly GeneralName targetName;

		private readonly GeneralName targetGroup;

		public virtual GeneralName TargetGroup => null;

		public virtual GeneralName TargetName => null;

		public static Target GetInstance(object obj)
		{
			return null;
		}

		private Target(Asn1TaggedObject tagObj)
		{
		}

		public Target(Choice type, GeneralName name)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
