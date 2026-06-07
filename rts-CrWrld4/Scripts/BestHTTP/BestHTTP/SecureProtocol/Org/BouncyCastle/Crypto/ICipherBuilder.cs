using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public interface ICipherBuilder
	{
		object AlgorithmDetails { get; }

		int GetMaxOutputSize(int inputLen);

		ICipher BuildCipher(Stream stream);
	}
}
