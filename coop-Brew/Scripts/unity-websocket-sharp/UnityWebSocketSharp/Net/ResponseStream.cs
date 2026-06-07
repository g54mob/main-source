using System;
using System.IO;

namespace UnityWebSocketSharp.Net
{
	internal class ResponseStream : Stream
	{
		private MemoryStream _bodyBuffer;

		private static readonly byte[] _crlf;

		private bool _disposed;

		private Stream _innerStream;

		private static readonly byte[] _lastChunk;

		private static readonly int _maxHeadersLength;

		private HttpListenerResponse _response;

		private bool _sendChunked;

		private Action<byte[], int, int> _write;

		private Action<byte[], int, int> _writeBody;

		private Action<byte[], int, int> _writeChunked;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		static ResponseStream()
		{
		}

		internal ResponseStream(Stream innerStream, HttpListenerResponse response, bool ignoreWriteExceptions)
		{
		}

		private bool flush(bool closing)
		{
			return false;
		}

		private void flushBody(bool closing)
		{
		}

		private bool flushHeaders()
		{
			return false;
		}

		private static byte[] getChunkSizeBytes(int size)
		{
			return null;
		}

		private void writeChunked(byte[] buffer, int offset, int count)
		{
		}

		private void writeChunkedWithoutThrowingException(byte[] buffer, int offset, int count)
		{
		}

		private void writeWithoutThrowingException(byte[] buffer, int offset, int count)
		{
		}

		internal void Close(bool force)
		{
		}

		internal void InternalWrite(byte[] buffer, int offset, int count)
		{
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		public override void Close()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			return 0;
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
