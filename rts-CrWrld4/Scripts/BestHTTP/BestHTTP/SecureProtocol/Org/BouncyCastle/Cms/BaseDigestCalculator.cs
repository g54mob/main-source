namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	internal class BaseDigestCalculator : IDigestCalculator
	{
		private readonly byte[] digest;

		internal BaseDigestCalculator(byte[] digest)
		{
		}

		public byte[] GetDigest()
		{
			return null;
		}
	}
}
