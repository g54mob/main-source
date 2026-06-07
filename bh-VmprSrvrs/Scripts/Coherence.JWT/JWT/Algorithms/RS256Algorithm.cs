using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public sealed class RS256Algorithm : RSAlgorithm
	{
		public override string Name => null;

		public override HashAlgorithmName HashAlgorithmName => default(HashAlgorithmName);

		public RS256Algorithm(RSA publicKey, RSA privateKey)
			: base(null, null)
		{
		}

		public RS256Algorithm(RSA publicKey)
			: base(null, null)
		{
		}

		public RS256Algorithm(X509Certificate2 cert)
			: base(null, null)
		{
		}
	}
}
