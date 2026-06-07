using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public sealed class RS512Algorithm : RSAlgorithm
	{
		public override string Name => null;

		public override HashAlgorithmName HashAlgorithmName => default(HashAlgorithmName);

		public RS512Algorithm(RSA publicKey, RSA privateKey)
			: base(null, null)
		{
		}

		public RS512Algorithm(RSA publicKey)
			: base(null, null)
		{
		}

		public RS512Algorithm(X509Certificate2 cert)
			: base(null, null)
		{
		}
	}
}
