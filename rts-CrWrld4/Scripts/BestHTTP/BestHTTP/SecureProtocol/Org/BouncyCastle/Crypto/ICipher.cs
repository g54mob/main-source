using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public interface ICipher
	{
		Stream Stream { get; }

		int GetMaxOutputSize(int inputLen);

		int GetUpdateOutputSize(int inputLen);
	}
}
