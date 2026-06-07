using System.Security.Cryptography;

namespace JWT.Algorithms
{
	public sealed class HMACSHA384Algorithm : HMACSHAAlgorithm
	{
		public override string Name => null;

		public override HashAlgorithmName HashAlgorithmName => default(HashAlgorithmName);

		protected override HMAC CreateAlgorithm(byte[] key)
		{
			return null;
		}
	}
}
