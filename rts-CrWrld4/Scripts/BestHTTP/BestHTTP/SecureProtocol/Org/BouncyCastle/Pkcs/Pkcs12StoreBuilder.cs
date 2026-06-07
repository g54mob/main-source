using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public class Pkcs12StoreBuilder
	{
		private DerObjectIdentifier keyAlgorithm;

		private DerObjectIdentifier certAlgorithm;

		private DerObjectIdentifier keyPrfAlgorithm;

		private DerObjectIdentifier certPrfAlgorithm;

		private bool useDerEncoding;

		public Pkcs12Store Build()
		{
			return null;
		}

		public Pkcs12StoreBuilder SetCertAlgorithm(DerObjectIdentifier certAlgorithm)
		{
			return null;
		}

		public Pkcs12StoreBuilder SetKeyAlgorithm(DerObjectIdentifier keyAlgorithm)
		{
			return null;
		}

		public Pkcs12StoreBuilder SetKeyAlgorithm(DerObjectIdentifier keyAlgorithm, DerObjectIdentifier keyPrfAlgorithm)
		{
			return null;
		}

		public Pkcs12StoreBuilder SetUseDerEncoding(bool useDerEncoding)
		{
			return null;
		}
	}
}
