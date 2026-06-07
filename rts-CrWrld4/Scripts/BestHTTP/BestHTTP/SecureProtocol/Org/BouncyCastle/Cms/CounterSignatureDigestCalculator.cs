namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	internal class CounterSignatureDigestCalculator : IDigestCalculator
	{
		private readonly string alg;

		private readonly byte[] data;

		internal CounterSignatureDigestCalculator(string alg, byte[] data)
		{
		}

		public byte[] GetDigest()
		{
			return null;
		}
	}
}
