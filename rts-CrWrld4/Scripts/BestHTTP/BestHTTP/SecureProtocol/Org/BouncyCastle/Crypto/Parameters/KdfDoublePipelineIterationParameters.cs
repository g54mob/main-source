namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class KdfDoublePipelineIterationParameters : IDerivationParameters
	{
		private static readonly int UNUSED_R;

		private readonly byte[] ki;

		private readonly bool useCounter;

		private readonly int r;

		private readonly byte[] fixedInputData;

		public byte[] Ki => null;

		public bool UseCounter => false;

		public int R => 0;

		public byte[] FixedInputData => null;

		private KdfDoublePipelineIterationParameters(byte[] ki, byte[] fixedInputData, int r, bool useCounter)
		{
		}

		public static KdfDoublePipelineIterationParameters CreateWithCounter(byte[] ki, byte[] fixedInputData, int r)
		{
			return null;
		}

		public static KdfDoublePipelineIterationParameters CreateWithoutCounter(byte[] ki, byte[] fixedInputData)
		{
			return null;
		}
	}
}
