using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.WebSocket.Frames
{
	[Il2CppEagerStaticClassConstruction]
	public sealed class WebSocketFrame
	{
		public WebSocketFrameTypes Type { get; private set; }

		public bool IsFinal { get; private set; }

		public byte Header { get; private set; }

		public byte[] Data { get; private set; }

		public int DataLength { get; private set; }

		public bool UseExtensions { get; private set; }

		public override string ToString()
		{
			return null;
		}

		public WebSocketFrame(WebSocket webSocket, WebSocketFrameTypes type, byte[] data)
		{
		}

		public WebSocketFrame(WebSocket webSocket, WebSocketFrameTypes type, byte[] data, bool useExtensions)
		{
		}

		public WebSocketFrame(WebSocket webSocket, WebSocketFrameTypes type, byte[] data, bool isFinal, bool useExtensions)
		{
		}

		public WebSocketFrame(WebSocket webSocket, WebSocketFrameTypes type, byte[] data, ulong pos, ulong length, bool isFinal, bool useExtensions)
		{
		}

		public RawFrameData Get()
		{
			return default(RawFrameData);
		}

		public WebSocketFrame[] Fragment(uint maxFragmentSize)
		{
			return null;
		}
	}
}
