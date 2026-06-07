namespace UnityWebSocketSharp.Net
{
	internal class ReadBufferState
	{
		private HttpStreamAsyncResult _asyncResult;

		private byte[] _buffer;

		private int _count;

		private int _initialCount;

		private int _offset;

		public HttpStreamAsyncResult AsyncResult
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public byte[] Buffer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Count
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int InitialCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Offset
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ReadBufferState(byte[] buffer, int offset, int count, HttpStreamAsyncResult asyncResult)
		{
		}
	}
}
