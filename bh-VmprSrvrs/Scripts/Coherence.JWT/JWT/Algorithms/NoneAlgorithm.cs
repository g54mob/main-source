using System.Security.Cryptography;

namespace JWT.Algorithms
{
	public sealed class NoneAlgorithm : IJwtAlgorithm
	{
		public string Name => null;

		public HashAlgorithmName HashAlgorithmName => default(HashAlgorithmName);

		public byte[] Sign(byte[] key, byte[] bytesToSign)
		{
			return null;
		}
	}
}
