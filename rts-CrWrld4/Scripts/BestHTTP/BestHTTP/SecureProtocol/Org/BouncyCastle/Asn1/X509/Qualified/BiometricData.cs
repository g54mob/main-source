namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.Qualified
{
	public class BiometricData : Asn1Encodable
	{
		private readonly TypeOfBiometricData typeOfBiometricData;

		private readonly AlgorithmIdentifier hashAlgorithm;

		private readonly Asn1OctetString biometricDataHash;

		private readonly DerIA5String sourceDataUri;

		public TypeOfBiometricData TypeOfBiometricData => null;

		public AlgorithmIdentifier HashAlgorithm => null;

		public Asn1OctetString BiometricDataHash => null;

		public DerIA5String SourceDataUri => null;

		public static BiometricData GetInstance(object obj)
		{
			return null;
		}

		private BiometricData(Asn1Sequence seq)
		{
		}

		public BiometricData(TypeOfBiometricData typeOfBiometricData, AlgorithmIdentifier hashAlgorithm, Asn1OctetString biometricDataHash, DerIA5String sourceDataUri)
		{
		}

		public BiometricData(TypeOfBiometricData typeOfBiometricData, AlgorithmIdentifier hashAlgorithm, Asn1OctetString biometricDataHash)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
