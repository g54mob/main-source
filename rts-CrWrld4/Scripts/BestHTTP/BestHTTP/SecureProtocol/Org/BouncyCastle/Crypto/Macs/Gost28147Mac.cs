namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class Gost28147Mac : IMac
	{
		private const int blockSize = 8;

		private const int macSize = 4;

		private int bufOff;

		private byte[] buf;

		private byte[] mac;

		private bool firstStep;

		private int[] workingKey;

		private byte[] macIV;

		private byte[] S;

		public string AlgorithmName => null;

		private static int[] GenerateWorkingKey(byte[] userKey)
		{
			return null;
		}

		public void Init(ICipherParameters parameters)
		{
		}

		public int GetMacSize()
		{
			return 0;
		}

		private int gost28147_mainStep(int n1, int key)
		{
			return 0;
		}

		private void gost28147MacFunc(int[] workingKey, byte[] input, int inOff, byte[] output, int outOff)
		{
		}

		private static int bytesToint(byte[] input, int inOff)
		{
			return 0;
		}

		private static void intTobytes(int num, byte[] output, int outOff)
		{
		}

		private static byte[] CM5func(byte[] buf, int bufOff, byte[] mac)
		{
			return null;
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}
	}
}
