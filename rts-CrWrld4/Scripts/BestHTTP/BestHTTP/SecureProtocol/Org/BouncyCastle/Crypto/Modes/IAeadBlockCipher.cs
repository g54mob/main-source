namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	public interface IAeadBlockCipher : IAeadCipher
	{
		int GetBlockSize();

		IBlockCipher GetUnderlyingCipher();
	}
}
