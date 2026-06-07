using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public sealed class RS1024Algorithm : RSAlgorithm
	{
		public override string Name => null;

		public override HashAlgorithmName HashAlgorithmName => default(HashAlgorithmName);

		public RS1024Algorithm(RSA publicKey, RSA privateKey)
			: base(null, null)
		{
		}

		public RS1024Algorithm(RSA publicKey)
			: base(null, null)
		{
		}

		public RS1024Algorithm(X509Certificate2 cert)
			: base(null, null)
		{
		}
	}
}
