namespace NAudio.Codecs
{
	public class G722Codec
	{
		private static readonly int[] wl;

		private static readonly int[] rl42;

		private static readonly int[] ilb;

		private static readonly int[] wh;

		private static readonly int[] rh2;

		private static readonly int[] qm2;

		private static readonly int[] qm4;

		private static readonly int[] qm5;

		private static readonly int[] qm6;

		private static readonly int[] qmf_coeffs;

		private static readonly int[] q6;

		private static readonly int[] iln;

		private static readonly int[] ilp;

		private static readonly int[] ihn;

		private static readonly int[] ihp;

		private static short Saturate(int amp)
		{
			return 0;
		}

		private static void Block4(G722CodecState s, int band, int d)
		{
		}

		public int Decode(G722CodecState state, short[] outputBuffer, byte[] inputG722Data, int inputLength)
		{
			return 0;
		}

		public int Encode(G722CodecState state, byte[] outputBuffer, short[] inputBuffer, int inputBufferCount)
		{
			return 0;
		}
	}
}
