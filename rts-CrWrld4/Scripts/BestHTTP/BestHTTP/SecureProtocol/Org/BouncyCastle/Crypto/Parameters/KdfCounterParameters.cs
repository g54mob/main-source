namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class KdfCounterParameters : IDerivationParameters
	{
		private byte[] ki;

		private byte[] fixedInputDataCounterPrefix;

		private byte[] fixedInputDataCounterSuffix;

		private int r;

		public byte[] Ki => null;

		public byte[] FixedInputData => null;

		public byte[] FixedInputDataCounterPrefix => null;

		public byte[] FixedInputDataCounterSuffix => null;

		public int R => 0;

		public KdfCounterParameters(byte[] ki, byte[] fixedInputDataCounterSuffix, int r)
		{
		}

		public KdfCounterParameters(byte[] ki, byte[] fixedInputDataCounterPrefix, byte[] fixedInputDataCounterSuffix, int r)
		{
		}
	}
}
