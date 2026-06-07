using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UnityWebSocketSharp.Net
{
	internal sealed class HttpConnection
	{
		private int _attempts;

		private byte[] _buffer;

		private static readonly int _bufferLength;

		private HttpListenerContext _context;

		private StringBuilder _currentLine;

		private EndPointListener _endPointListener;

		private InputState _inputState;

		private RequestStream _inputStream;

		private LineState _lineState;

		private EndPoint _localEndPoint;

		private static readonly int _maxInputLength;

		private ResponseStream _outputStream;

		private int _position;

		private EndPoint _remoteEndPoint;

		private MemoryStream _requestBuffer;

		private int _reuses;

		private bool _secure;

		private Socket _socket;

		private Stream _stream;

		private object _sync;

		private int _timeout;

		private Dictionary<int, bool> _timeoutCanceled;

		private Timer _timer;

		public bool IsClosed => false;

		public bool IsLocal => false;

		public bool IsSecure => false;

		public IPEndPoint LocalEndPoint => null;

		public IPEndPoint RemoteEndPoint => null;

		public int Reuses => 0;

		public Stream Stream => null;

		static HttpConnection()
		{
		}

		internal HttpConnection(Socket socket, EndPointListener listener)
		{
		}

		private void close()
		{
		}

		private void closeSocket()
		{
		}

		private static MemoryStream createRequestBuffer(RequestStream inputStream)
		{
			return null;
		}

		private void disposeRequestBuffer()
		{
		}

		private void disposeStream()
		{
		}

		private void disposeTimer()
		{
		}

		private void init(MemoryStream requestBuffer, int timeout)
		{
		}

		private static void onRead(IAsyncResult asyncResult)
		{
		}

		private static void onTimeout(object state)
		{
		}

		private bool processInput(byte[] data, int length)
		{
			return false;
		}

		private bool processRequestBuffer()
		{
			return false;
		}

		private string readLineFrom(byte[] buffer, int offset, int length, out int nread)
		{
			nread = default(int);
			return null;
		}

		private MemoryStream takeOverRequestBuffer()
		{
			return null;
		}

		internal void BeginReadRequest()
		{
		}

		internal void Close(bool force)
		{
		}

		public void Close()
		{
		}

		public RequestStream GetRequestStream(long contentLength, bool chunked)
		{
			return null;
		}

		public ResponseStream GetResponseStream()
		{
			return null;
		}
	}
}
