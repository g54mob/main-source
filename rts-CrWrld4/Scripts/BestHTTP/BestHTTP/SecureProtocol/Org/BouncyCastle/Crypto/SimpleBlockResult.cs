namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public class SimpleBlockResult : IBlockResult
	{
		private readonly byte[] result;

		public int Length => 0;

		public SimpleBlockResult(byte[] result)
		{
		}

		public byte[] Collect()
		{
			return null;
		}

		public int Collect(byte[] destination, int offset)
		{
			return 0;
		}
	}
}
