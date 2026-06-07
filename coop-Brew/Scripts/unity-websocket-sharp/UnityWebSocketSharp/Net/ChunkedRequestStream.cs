using System;
using System.IO;

namespace UnityWebSocketSharp.Net
{
	internal class ChunkedRequestStream : RequestStream
	{
		private static readonly int _bufferLength;

		private HttpListenerContext _context;

		private ChunkStream _decoder;

		private bool _disposed;

		private bool _noMoreData;

		internal bool HasRemainingBuffer => false;

		internal byte[] RemainingBuffer => null;

		static ChunkedRequestStream()
		{
		}

		internal ChunkedRequestStream(Stream innerStream, byte[] initialBuffer, int offset, int count, HttpListenerContext context)
			: base(null, null, 0, 0, 0L)
		{
		}

		private void onRead(IAsyncResult asyncResult)
		{
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		public override void Close()
		{
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
