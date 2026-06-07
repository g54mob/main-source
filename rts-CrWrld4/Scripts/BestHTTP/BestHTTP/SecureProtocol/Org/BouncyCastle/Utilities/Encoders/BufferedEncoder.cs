namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Encoders
{
	public class BufferedEncoder
	{
		internal byte[] Buffer;

		internal int bufOff;

		internal ITranslator translator;

		public BufferedEncoder(ITranslator translator, int bufferSize)
		{
		}

		public int ProcessByte(byte input, byte[] outBytes, int outOff)
		{
			return 0;
		}

		public int ProcessBytes(byte[] input, int inOff, int len, byte[] outBytes, int outOff)
		{
			return 0;
		}
	}
}
