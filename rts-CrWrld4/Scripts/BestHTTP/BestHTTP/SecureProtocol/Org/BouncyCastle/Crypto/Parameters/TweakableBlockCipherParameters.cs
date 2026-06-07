namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class TweakableBlockCipherParameters : ICipherParameters
	{
		private readonly byte[] tweak;

		private readonly KeyParameter key;

		public KeyParameter Key => null;

		public byte[] Tweak => null;

		public TweakableBlockCipherParameters(KeyParameter key, byte[] tweak)
		{
		}
	}
}
