namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ParametersWithIV : ICipherParameters
	{
		private readonly ICipherParameters parameters;

		private readonly byte[] iv;

		public ICipherParameters Parameters => null;

		public ParametersWithIV(ICipherParameters parameters, byte[] iv)
		{
		}

		public ParametersWithIV(ICipherParameters parameters, byte[] iv, int ivOff, int ivLen)
		{
		}

		public byte[] GetIV()
		{
			return null;
		}
	}
}
