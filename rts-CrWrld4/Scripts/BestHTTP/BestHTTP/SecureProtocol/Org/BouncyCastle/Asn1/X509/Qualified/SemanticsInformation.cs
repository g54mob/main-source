namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.Qualified
{
	public class SemanticsInformation : Asn1Encodable
	{
		private readonly DerObjectIdentifier semanticsIdentifier;

		private readonly GeneralName[] nameRegistrationAuthorities;

		public DerObjectIdentifier SemanticsIdentifier => null;

		public static SemanticsInformation GetInstance(object obj)
		{
			return null;
		}

		public SemanticsInformation(Asn1Sequence seq)
		{
		}

		public SemanticsInformation(DerObjectIdentifier semanticsIdentifier, GeneralName[] generalNames)
		{
		}

		public SemanticsInformation(DerObjectIdentifier semanticsIdentifier)
		{
		}

		public SemanticsInformation(GeneralName[] generalNames)
		{
		}

		public GeneralName[] GetNameRegistrationAuthorities()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
