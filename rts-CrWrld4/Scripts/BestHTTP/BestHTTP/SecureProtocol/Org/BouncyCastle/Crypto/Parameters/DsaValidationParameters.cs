namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DsaValidationParameters
	{
		private readonly byte[] seed;

		private readonly int counter;

		private readonly int usageIndex;

		public virtual int Counter => 0;

		public virtual int UsageIndex => 0;

		public DsaValidationParameters(byte[] seed, int counter)
		{
		}

		public DsaValidationParameters(byte[] seed, int counter, int usageIndex)
		{
		}

		public virtual byte[] GetSeed()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected virtual bool Equals(DsaValidationParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
