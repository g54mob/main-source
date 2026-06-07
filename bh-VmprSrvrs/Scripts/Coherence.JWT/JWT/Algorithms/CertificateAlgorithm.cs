using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public abstract class CertificateAlgorithm<T> : IAsymmetricAlgorithm, IJwtAlgorithm where T : class
	{
		protected readonly T _publicKey;

		protected readonly T _privateKey;

		public abstract string Name { get; }

		public abstract HashAlgorithmName HashAlgorithmName { get; }

		protected CertificateAlgorithm(T publicKey, T privateKey)
		{
		}

		protected CertificateAlgorithm(T publicKey)
		{
		}

		protected CertificateAlgorithm(X509Certificate2 cert)
		{
		}

		public byte[] Sign(byte[] key, byte[] bytesToSign)
		{
			return null;
		}

		public byte[] Sign(byte[] bytesToSign)
		{
			return null;
		}

		public bool Verify(byte[] bytesToSign, byte[] signature)
		{
			return false;
		}

		protected abstract T GetPublicKey(X509Certificate2 cert);

		protected abstract T GetPrivateKey(X509Certificate2 cert);

		protected abstract byte[] SignData(byte[] bytesToSign);

		protected abstract bool VerifyData(byte[] bytesToSign, byte[] signature);
	}
}
