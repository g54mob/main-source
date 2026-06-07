namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib
{
	internal sealed class InfBlocks
	{
		private const int MANY = 1440;

		private static readonly int[] inflate_mask;

		private static readonly int[] border;

		private const int Z_OK = 0;

		private const int Z_STREAM_END = 1;

		private const int Z_NEED_DICT = 2;

		private const int Z_ERRNO = -1;

		private const int Z_STREAM_ERROR = -2;

		private const int Z_DATA_ERROR = -3;

		private const int Z_MEM_ERROR = -4;

		private const int Z_BUF_ERROR = -5;

		private const int Z_VERSION_ERROR = -6;

		private const int TYPE = 0;

		private const int LENS = 1;

		private const int STORED = 2;

		private const int TABLE = 3;

		private const int BTREE = 4;

		private const int DTREE = 5;

		private const int CODES = 6;

		private const int DRY = 7;

		private const int DONE = 8;

		private const int BAD = 9;

		internal int mode;

		internal int left;

		internal int table;

		internal int index;

		internal int[] blens;

		internal int[] bb;

		internal int[] tb;

		internal InfCodes codes;

		private int last;

		internal int bitk;

		internal int bitb;

		internal int[] hufts;

		internal byte[] window;

		internal int end;

		internal int read;

		internal int write;

		internal object checkfn;

		internal long check;

		internal InfTree inftree;

		internal InfBlocks(ZStream z, object checkfn, int w)
		{
		}

		internal void reset(ZStream z, long[] c)
		{
		}

		internal int proc(ZStream z, int r)
		{
			return 0;
		}

		internal void free(ZStream z)
		{
		}

		internal void set_dictionary(byte[] d, int start, int n)
		{
		}

		internal int sync_point()
		{
			return 0;
		}

		internal int inflate_flush(ZStream z, int r)
		{
			return 0;
		}
	}
}
