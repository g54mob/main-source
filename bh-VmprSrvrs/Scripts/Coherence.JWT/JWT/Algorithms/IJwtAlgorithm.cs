using System.Security.Cryptography;

namespace JWT.Algorithms
{
	public interface IJwtAlgorithm
	{
		string Name { get; }

		HashAlgorithmName HashAlgorithmName { get; }

		byte[] Sign(byte[] key, byte[] bytesToSign);
	}
}
