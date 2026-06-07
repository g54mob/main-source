using System.Security.Cryptography;

namespace JWT.Algorithms
{
	public abstract class HMACSHAAlgorithm : IJwtAlgorithm
	{
		public abstract string Name { get; }

		public abstract HashAlgorithmName HashAlgorithmName { get; }

		public byte[] Sign(byte[] key, byte[] bytesToSign)
		{
			return null;
		}

		protected abstract HMAC CreateAlgorithm(byte[] key);
	}
}
