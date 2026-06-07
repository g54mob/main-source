namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ParametersWithSBox : ICipherParameters
	{
		private ICipherParameters parameters;

		private byte[] sBox;

		public ICipherParameters Parameters => null;

		public ParametersWithSBox(ICipherParameters parameters, byte[] sBox)
		{
		}

		public byte[] GetSBox()
		{
			return null;
		}
	}
}
