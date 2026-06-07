namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class KdfFeedbackParameters : IDerivationParameters
	{
		private static readonly int UNUSED_R;

		private readonly byte[] ki;

		private readonly byte[] iv;

		private readonly bool useCounter;

		private readonly int r;

		private readonly byte[] fixedInputData;

		public byte[] Ki => null;

		public byte[] Iv => null;

		public bool UseCounter => false;

		public int R => 0;

		public byte[] FixedInputData => null;

		private KdfFeedbackParameters(byte[] ki, byte[] iv, byte[] fixedInputData, int r, bool useCounter)
		{
		}

		public static KdfFeedbackParameters CreateWithCounter(byte[] ki, byte[] iv, byte[] fixedInputData, int r)
		{
			return null;
		}

		public static KdfFeedbackParameters CreateWithoutCounter(byte[] ki, byte[] iv, byte[] fixedInputData)
		{
			return null;
		}
	}
}
