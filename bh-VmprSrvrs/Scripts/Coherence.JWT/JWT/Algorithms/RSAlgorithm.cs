using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public abstract class RSAlgorithm : CertificateAlgorithm<RSA>
	{
		protected RSAlgorithm(RSA publicKey, RSA privateKey)
			: base((RSA)default(_00210), (RSA)default(_00210))
		{
		}

		protected RSAlgorithm(RSA publicKey)
			: base((RSA)default(_00210), (RSA)default(_00210))
		{
		}

		protected RSAlgorithm(X509Certificate2 cert)
			: base((RSA)default(_00210), (RSA)default(_00210))
		{
		}

		protected override RSA GetPublicKey(X509Certificate2 cert)
		{
			return null;
		}

		protected override RSA GetPrivateKey(X509Certificate2 cert)
		{
			return null;
		}

		protected override byte[] SignData(byte[] bytesToSign)
		{
			return null;
		}

		protected override bool VerifyData(byte[] bytesToSign, byte[] signature)
		{
			return false;
		}
	}
}
