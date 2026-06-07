namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Smime
{
	public class SmimeCapability : Asn1Encodable
	{
		public static readonly DerObjectIdentifier PreferSignedData;

		public static readonly DerObjectIdentifier CannotDecryptAny;

		public static readonly DerObjectIdentifier SmimeCapabilitiesVersions;

		public static readonly DerObjectIdentifier DesCbc;

		public static readonly DerObjectIdentifier DesEde3Cbc;

		public static readonly DerObjectIdentifier RC2Cbc;

		private DerObjectIdentifier capabilityID;

		private Asn1Object parameters;

		public DerObjectIdentifier CapabilityID => null;

		public Asn1Object Parameters => null;

		public SmimeCapability(Asn1Sequence seq)
		{
		}

		public SmimeCapability(DerObjectIdentifier capabilityID, Asn1Encodable parameters)
		{
		}

		public static SmimeCapability GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
