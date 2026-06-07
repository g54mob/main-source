using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using BestHTTP.Core;
using BestHTTP.Extensions;
using BestHTTP.WebSocket.Frames;

namespace BestHTTP.WebSocket
{
	public sealed class WebSocketResponse : HTTPResponse, IHeartbeat, IProtocol, IDisposable
	{
		public static int RTTBufferCapacity;

		public Action<WebSocketResponse, string> OnText;

		public Action<WebSocketResponse, byte[]> OnBinary;

		public Action<WebSocketResponse, WebSocketFrameReader> OnIncompleteFrame;

		public Action<WebSocketResponse, ushort, string> OnClosed;

		private int _bufferedAmount;

		public DateTime lastMessage;

		private List<WebSocketFrameReader> IncompleteFrames;

		private ConcurrentQueue<WebSocketFrameReader> CompletedFrames;

		private WebSocketFrameReader CloseFrame;

		private ConcurrentQueue<WebSocketFrame> unsentFrames;

		private AutoResetEvent newFrameSignal;

		private int sendThreadCreated;

		private int closedThreads;

		private bool closeSent;

		private bool closed;

		private DateTime lastPing;

		private bool waitingForPong;

		private CircularBuffer<int> rtts;

		public WebSocket WebSocket { get; internal set; }

		public HostConnectionKey ConnectionKey { get; private set; }

		public bool IsClosed => false;

		public TimeSpan PingFrequnecy { get; private set; }

		public uint MaxFragmentSize { get; set; }

		public int BufferedAmount => 0;

		public int Latency { get; private set; }

		internal WebSocketResponse(HTTPRequest request, Stream stream, bool isStreamed, bool isFromCache)
			: base(null, isFromCache: false)
		{
		}

		internal void StartReceive()
		{
		}

		internal void CloseStream()
		{
		}

		public void Send(string message)
		{
		}

		public void Send(byte[] data)
		{
		}

		public void Send(byte[] data, ulong offset, ulong count)
		{
		}

		public void Send(WebSocketFrame frame)
		{
		}

		public void Close()
		{
		}

		public void Close(ushort code, string msg)
		{
		}

		public void StartPinging(int frequency)
		{
		}

		private void SendThreadFunc()
		{
		}

		private void ReceiveThreadFunc()
		{
		}

		void IProtocol.HandleEvents()
		{
		}

		void IHeartbeat.OnHeartbeatUpdate(TimeSpan dif)
		{
		}

		private void OnApplicationForegroundStateChanged(bool isPaused)
		{
		}

		private void SendPing()
		{
		}

		private void CloseWithError(HTTPRequestStates state, string message)
		{
		}

		private int CalculateLatency()
		{
			return 0;
		}

		void IProtocol.CancellationRequested()
		{
		}

		private void TryToCleanup()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
