using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public sealed class RS384Algorithm : RSAlgorithm
	{
		public override string Name => null;

		public override HashAlgorithmName HashAlgorithmName => default(HashAlgorithmName);

		public RS384Algorithm(RSA publicKey, RSA privateKey)
			: base(null, null)
		{
		}

		public RS384Algorithm(RSA publicKey)
			: base(null, null)
		{
		}

		public RS384Algorithm(X509Certificate2 cert)
			: base(null, null)
		{
		}
	}
}
