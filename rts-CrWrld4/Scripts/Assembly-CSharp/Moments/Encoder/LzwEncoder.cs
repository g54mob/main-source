using System.IO;

namespace Moments.Encoder
{
	public class LzwEncoder
	{
		private static readonly int EOF;

		private byte[] pixAry;

		private int initCodeSize;

		private int curPixel;

		private static readonly int BITS;

		private static readonly int HSIZE;

		private int n_bits;

		private int maxbits;

		private int maxcode;

		private int maxmaxcode;

		private int[] htab;

		private int[] codetab;

		private int hsize;

		private int free_ent;

		private bool clear_flg;

		private int g_init_bits;

		private int ClearCode;

		private int EOFCode;

		private int cur_accum;

		private int cur_bits;

		private int[] masks;

		private int a_count;

		private byte[] accum;

		public LzwEncoder(int width, int height, byte[] pixels, int color_depth)
		{
		}

		private void Add(byte c, Stream outs)
		{
		}

		private void ClearTable(Stream outs)
		{
		}

		private void ResetCodeTable(int hsize)
		{
		}

		private void Compress(int init_bits, Stream outs)
		{
		}

		public void Encode(Stream os)
		{
		}

		private void Flush(Stream outs)
		{
		}

		private int MaxCode(int n_bits)
		{
			return 0;
		}

		private int NextPixel()
		{
			return 0;
		}

		private void Output(int code, Stream outs)
		{
		}
	}
}
