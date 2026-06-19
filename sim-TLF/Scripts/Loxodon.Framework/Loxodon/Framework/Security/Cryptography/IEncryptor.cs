namespace Loxodon.Framework.Security.Cryptography
{
	public interface IEncryptor
	{
		string AlgorithmName { get; }

		byte[] Encrypt(byte[] buffer);
	}
}
