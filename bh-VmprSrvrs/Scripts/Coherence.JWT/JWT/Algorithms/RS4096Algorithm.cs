using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public sealed class RS4096Algorithm : RSAlgorithm
	{
		public override string Name => null;

		public override HashAlgorithmName HashAlgorithmName => default(HashAlgorithmName);

		public RS4096Algorithm(RSA publicKey, RSA privateKey)
			: base(null, null)
		{
		}

		public RS4096Algorithm(RSA publicKey)
			: base(null, null)
		{
		}

		public RS4096Algorithm(X509Certificate2 cert)
			: base(null, null)
		{
		}
	}
}
