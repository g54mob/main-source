namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public sealed class SerpentEngine : SerpentEngineBase
	{
		protected override int[] MakeWorkingKey(byte[] key)
		{
			return null;
		}

		protected override void EncryptBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
		}

		protected override void DecryptBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
		}
	}
}
