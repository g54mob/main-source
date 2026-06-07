using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Paddings
{
	public class ISO7816d4Padding : IBlockCipherPadding
	{
		public string PaddingName => null;

		public void Init(SecureRandom random)
		{
		}

		public int AddPadding(byte[] input, int inOff)
		{
			return 0;
		}

		public int PadCount(byte[] input)
		{
			return 0;
		}
	}
}
