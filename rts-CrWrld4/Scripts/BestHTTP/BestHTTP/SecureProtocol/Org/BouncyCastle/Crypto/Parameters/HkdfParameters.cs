namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class HkdfParameters : IDerivationParameters
	{
		private readonly byte[] ikm;

		private readonly bool skipExpand;

		private readonly byte[] salt;

		private readonly byte[] info;

		public virtual bool SkipExtract => false;

		private HkdfParameters(byte[] ikm, bool skip, byte[] salt, byte[] info)
		{
		}

		public HkdfParameters(byte[] ikm, byte[] salt, byte[] info)
		{
		}

		public static HkdfParameters SkipExtractParameters(byte[] ikm, byte[] info)
		{
			return null;
		}

		public static HkdfParameters DefaultParameters(byte[] ikm)
		{
			return null;
		}

		public virtual byte[] GetIkm()
		{
			return null;
		}

		public virtual byte[] GetSalt()
		{
			return null;
		}

		public virtual byte[] GetInfo()
		{
			return null;
		}
	}
}
