using System.IO;
using Amazon.Runtime;

namespace Amazon.Util
{
	public interface ICryptoUtil
	{
		string HMACSign(string data, string key, SigningAlgorithm algorithmName);

		string HMACSign(byte[] data, string key, SigningAlgorithm algorithmName);

		byte[] ComputeSHA1Hash(byte[] data);

		byte[] ComputeSHA256Hash(byte[] data);

		byte[] ComputeSHA256Hash(Stream steam);

		byte[] ComputeMD5Hash(byte[] data);

		byte[] ComputeMD5Hash(Stream steam);

		byte[] HMACSignBinary(byte[] data, byte[] key, SigningAlgorithm algorithmName);

		string ComputeCRC32Hash(byte[] data);

		string ComputeCRC32CHash(byte[] data);

		string ComputeCRC64NVMEHash(byte[] data);
	}
}
