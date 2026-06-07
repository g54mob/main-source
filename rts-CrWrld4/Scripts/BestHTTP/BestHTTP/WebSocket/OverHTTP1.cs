using System;
using BestHTTP.WebSocket.Frames;

namespace BestHTTP.WebSocket
{
	internal sealed class OverHTTP1 : WebSocketBaseImplementation
	{
		private bool requestSent;

		private WebSocketResponse webSocket;

		public override bool IsOpen => false;

		public override int BufferedAmount => 0;

		public override int Latency => 0;

		public override DateTime LastMessageReceived => default(DateTime);

		public OverHTTP1(WebSocket parent, Uri uri, string origin, string protocol)
			: base(null, null, null, null)
		{
		}

		protected override void CreateInternalRequest()
		{
		}

		public override void StartClose(ushort code, string message)
		{
		}

		public override void StartOpen()
		{
		}

		private void OnInternalRequestCallback(HTTPRequest req, HTTPResponse resp)
		{
		}

		private void OnInternalRequestUpgraded(HTTPRequest req, HTTPResponse resp)
		{
		}

		public override void Send(string message)
		{
		}

		public override void Send(byte[] buffer)
		{
		}

		public override void Send(byte[] buffer, ulong offset, ulong count)
		{
		}

		public override void Send(WebSocketFrame frame)
		{
		}
	}
}
