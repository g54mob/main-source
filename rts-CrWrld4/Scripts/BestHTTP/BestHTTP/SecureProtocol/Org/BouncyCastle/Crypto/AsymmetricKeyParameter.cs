namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public abstract class AsymmetricKeyParameter : ICipherParameters
	{
		private readonly bool privateKey;

		public bool IsPrivate => false;

		protected AsymmetricKeyParameter(bool privateKey)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(AsymmetricKeyParameter other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
