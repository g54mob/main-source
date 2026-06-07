namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib
{
	public sealed class ZStream
	{
		private const int MAX_WBITS = 15;

		private const int DEF_WBITS = 15;

		private const int Z_NO_FLUSH = 0;

		private const int Z_PARTIAL_FLUSH = 1;

		private const int Z_SYNC_FLUSH = 2;

		private const int Z_FULL_FLUSH = 3;

		private const int Z_FINISH = 4;

		private const int MAX_MEM_LEVEL = 9;

		private const int Z_OK = 0;

		private const int Z_STREAM_END = 1;

		private const int Z_NEED_DICT = 2;

		private const int Z_ERRNO = -1;

		private const int Z_STREAM_ERROR = -2;

		private const int Z_DATA_ERROR = -3;

		private const int Z_MEM_ERROR = -4;

		private const int Z_BUF_ERROR = -5;

		private const int Z_VERSION_ERROR = -6;

		public byte[] next_in;

		public int next_in_index;

		public int avail_in;

		public long total_in;

		public byte[] next_out;

		public int next_out_index;

		public int avail_out;

		public long total_out;

		public string msg;

		internal Deflate dstate;

		internal Inflate istate;

		internal int data_type;

		public long adler;

		internal Adler32 _adler;

		public int inflateInit()
		{
			return 0;
		}

		public int inflateInit(bool nowrap)
		{
			return 0;
		}

		public int inflateInit(int w)
		{
			return 0;
		}

		public int inflateInit(int w, bool nowrap)
		{
			return 0;
		}

		public int inflate(int f)
		{
			return 0;
		}

		public int inflateEnd()
		{
			return 0;
		}

		public int inflateSync()
		{
			return 0;
		}

		public int inflateSetDictionary(byte[] dictionary, int dictLength)
		{
			return 0;
		}

		public int deflateInit(int level)
		{
			return 0;
		}

		public int deflateInit(int level, bool nowrap)
		{
			return 0;
		}

		public int deflateInit(int level, int bits)
		{
			return 0;
		}

		public int deflateInit(int level, int bits, bool nowrap)
		{
			return 0;
		}

		public int deflate(int flush)
		{
			return 0;
		}

		public int deflateEnd()
		{
			return 0;
		}

		public int deflateParams(int level, int strategy)
		{
			return 0;
		}

		public int deflateSetDictionary(byte[] dictionary, int dictLength)
		{
			return 0;
		}

		internal void flush_pending()
		{
		}

		internal int read_buf(byte[] buf, int start, int size)
		{
			return 0;
		}

		public void free()
		{
		}
	}
}
