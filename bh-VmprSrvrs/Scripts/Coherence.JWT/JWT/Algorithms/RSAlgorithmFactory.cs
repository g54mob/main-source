using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWT.Algorithms
{
	public sealed class RSAlgorithmFactory : JwtAlgorithmFactory
	{
		private readonly Func<X509Certificate2> _certFactory;

		private readonly RSA _publicKey;

		private readonly RSA _privateKey;

		public RSAlgorithmFactory(Func<X509Certificate2> certFactory)
		{
		}

		public RSAlgorithmFactory(RSA publicKey)
		{
		}

		public RSAlgorithmFactory(RSA publicKey, RSA privateKey)
		{
		}

		protected override IJwtAlgorithm Create(JwtAlgorithmName algorithm)
		{
			return null;
		}

		private RS256Algorithm CreateRS256Algorithm()
		{
			return null;
		}

		private RS384Algorithm CreateRS384Algorithm()
		{
			return null;
		}

		private RS512Algorithm CreateRS512Algorithm()
		{
			return null;
		}

		private RS1024Algorithm CreateRS1024Algorithm()
		{
			return null;
		}

		private RS2048Algorithm CreateRS2048Algorithm()
		{
			return null;
		}

		private RS4096Algorithm CreateRS4096Algorithm()
		{
			return null;
		}
	}
}
