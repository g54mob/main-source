using System;
using BestHTTP.WebSocket.Frames;

namespace BestHTTP.WebSocket
{
	public abstract class WebSocketBaseImplementation
	{
		protected HTTPRequest _internalRequest;

		public virtual WebSocketStates State { get; protected set; }

		public virtual bool IsOpen { get; protected set; }

		public virtual int BufferedAmount { get; protected set; }

		public HTTPRequest InternalRequest => null;

		public virtual int Latency { get; protected set; }

		public virtual DateTime LastMessageReceived { get; protected set; }

		public WebSocket Parent { get; }

		public Uri Uri { get; protected set; }

		public string Origin { get; }

		public string Protocol { get; }

		public WebSocketBaseImplementation(WebSocket parent, Uri uri, string origin, string protocol)
		{
		}

		public abstract void StartOpen();

		public abstract void StartClose(ushort code, string message);

		public abstract void Send(string message);

		public abstract void Send(byte[] buffer);

		public abstract void Send(byte[] buffer, ulong offset, ulong count);

		protected abstract void CreateInternalRequest();

		public abstract void Send(WebSocketFrame frame);
	}
}
