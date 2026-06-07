namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class KeyUsage : DerBitString
	{
		public const int DigitalSignature = 128;

		public const int NonRepudiation = 64;

		public const int KeyEncipherment = 32;

		public const int DataEncipherment = 16;

		public const int KeyAgreement = 8;

		public const int KeyCertSign = 4;

		public const int CrlSign = 2;

		public const int EncipherOnly = 1;

		public const int DecipherOnly = 32768;

		public new static KeyUsage GetInstance(object obj)
		{
			return null;
		}

		public static KeyUsage FromExtensions(X509Extensions extensions)
		{
			return null;
		}

		public KeyUsage(int usage)
			: base(null, 0)
		{
		}

		private KeyUsage(DerBitString usage)
			: base(null, 0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
