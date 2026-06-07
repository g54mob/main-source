namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.Qualified
{
	public class TypeOfBiometricData : Asn1Encodable, IAsn1Choice
	{
		public const int Picture = 0;

		public const int HandwrittenSignature = 1;

		internal Asn1Encodable obj;

		public bool IsPredefined => false;

		public int PredefinedBiometricType => 0;

		public DerObjectIdentifier BiometricDataOid => null;

		public static TypeOfBiometricData GetInstance(object obj)
		{
			return null;
		}

		public TypeOfBiometricData(int predefinedBiometricType)
		{
		}

		public TypeOfBiometricData(DerObjectIdentifier biometricDataOid)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
