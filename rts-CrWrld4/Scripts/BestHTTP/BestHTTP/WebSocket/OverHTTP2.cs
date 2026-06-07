using System;
using System.Collections.Generic;
using BestHTTP.Connections.HTTP2;
using BestHTTP.Extensions;
using BestHTTP.WebSocket.Frames;
using BestHTTP.WebSocket.Implementations.Utils;

namespace BestHTTP.WebSocket
{
	public sealed class OverHTTP2 : WebSocketBaseImplementation, IHeartbeat
	{
		private List<WebSocketFrameReader> IncompleteFrames;

		private HTTP2Handler http2Handler;

		private LockedBufferSegmenStream upStream;

		private bool closeSent;

		private DateTime lastPing;

		private bool waitingForPong;

		private CircularBuffer<int> rtts;

		private PeekableIncomingSegmentStream incomingSegmentStream;

		public override int BufferedAmount => 0;

		public override bool IsOpen => false;

		public override int Latency => 0;

		public OverHTTP2(WebSocket parent, HTTP2Handler handler, Uri uri, string origin, string protocol)
			: base(null, null, null, null)
		{
		}

		protected override void CreateInternalRequest()
		{
		}

		private void OnHeadersReceived(HTTPRequest req, HTTPResponse resp)
		{
		}

		private static bool CanReadFullFrame(PeekableIncomingSegmentStream stream)
		{
			return false;
		}

		private bool OnFrame(HTTPRequest request, HTTPResponse response, byte[] dataFragment, int dataFragmentLength)
		{
			return false;
		}

		private void OnInternalRequestCallback(HTTPRequest req, HTTPResponse resp)
		{
		}

		public override void StartOpen()
		{
		}

		public override void StartClose(ushort code, string message)
		{
		}

		public override void Send(string message)
		{
		}

		public override void Send(byte[] buffer)
		{
		}

		public override void Send(byte[] data, ulong offset, ulong count)
		{
		}

		public override void Send(WebSocketFrame frame)
		{
		}

		private int CalculateLatency()
		{
			return 0;
		}

		public void OnHeartbeatUpdate(TimeSpan dif)
		{
		}

		private void OnApplicationForegroundStateChanged(bool isPaused)
		{
		}

		private void SendPing()
		{
		}

		private void CloseWithError(string message)
		{
		}
	}
}
