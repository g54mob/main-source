namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DHValidationParameters
	{
		private readonly byte[] seed;

		private readonly int counter;

		public int Counter => 0;

		public DHValidationParameters(byte[] seed, int counter)
		{
		}

		public byte[] GetSeed()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(DHValidationParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
