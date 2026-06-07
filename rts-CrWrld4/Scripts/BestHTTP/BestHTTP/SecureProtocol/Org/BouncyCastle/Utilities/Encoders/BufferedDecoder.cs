namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Encoders
{
	public class BufferedDecoder
	{
		internal byte[] buffer;

		internal int bufOff;

		internal ITranslator translator;

		public BufferedDecoder(ITranslator translator, int bufferSize)
		{
		}

		public int ProcessByte(byte input, byte[] output, int outOff)
		{
			return 0;
		}

		public int ProcessBytes(byte[] input, int inOff, int len, byte[] outBytes, int outOff)
		{
			return 0;
		}
	}
}
