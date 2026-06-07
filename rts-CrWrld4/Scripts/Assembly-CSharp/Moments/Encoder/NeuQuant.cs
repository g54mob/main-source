namespace Moments.Encoder
{
	public class NeuQuant
	{
		protected static readonly int netsize;

		protected static readonly int prime1;

		protected static readonly int prime2;

		protected static readonly int prime3;

		protected static readonly int prime4;

		protected static readonly int minpicturebytes;

		protected static readonly int maxnetpos;

		protected static readonly int netbiasshift;

		protected static readonly int ncycles;

		protected static readonly int intbiasshift;

		protected static readonly int intbias;

		protected static readonly int gammashift;

		protected static readonly int gamma;

		protected static readonly int betashift;

		protected static readonly int beta;

		protected static readonly int betagamma;

		protected static readonly int initrad;

		protected static readonly int radiusbiasshift;

		protected static readonly int radiusbias;

		protected static readonly int initradius;

		protected static readonly int radiusdec;

		protected static readonly int alphabiasshift;

		protected static readonly int initalpha;

		protected int alphadec;

		protected static readonly int radbiasshift;

		protected static readonly int radbias;

		protected static readonly int alpharadbshift;

		protected static readonly int alpharadbias;

		protected byte[] thepicture;

		protected int lengthcount;

		protected int samplefac;

		protected int[][] network;

		protected int[] netindex;

		protected int[] bias;

		protected int[] freq;

		protected int[] radpower;

		public NeuQuant(byte[] thepic, int len, int sample)
		{
		}

		public byte[] ColorMap()
		{
			return null;
		}

		public void Inxbuild()
		{
		}

		public void Learn()
		{
		}

		public int Map(int b, int g, int r)
		{
			return 0;
		}

		public byte[] Process()
		{
			return null;
		}

		public void Unbiasnet()
		{
		}

		protected void Alterneigh(int rad, int i, int b, int g, int r)
		{
		}

		protected void Altersingle(int alpha, int i, int b, int g, int r)
		{
		}

		protected int Contest(int b, int g, int r)
		{
			return 0;
		}
	}
}
