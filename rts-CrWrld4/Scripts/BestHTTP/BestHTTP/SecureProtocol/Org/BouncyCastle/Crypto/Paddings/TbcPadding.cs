using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Paddings
{
	public class TbcPadding : IBlockCipherPadding
	{
		public string PaddingName => null;

		public virtual void Init(SecureRandom random)
		{
		}

		public virtual int AddPadding(byte[] input, int inOff)
		{
			return 0;
		}

		public virtual int PadCount(byte[] input)
		{
			return 0;
		}
	}
}
