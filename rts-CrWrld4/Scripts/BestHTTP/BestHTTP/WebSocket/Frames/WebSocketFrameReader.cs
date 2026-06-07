using System.Collections.Generic;
using System.IO;

namespace BestHTTP.WebSocket.Frames
{
	public struct WebSocketFrameReader
	{
		public byte Header { get; private set; }

		public bool IsFinal { get; private set; }

		public WebSocketFrameTypes Type { get; private set; }

		public bool HasMask { get; private set; }

		public ulong Length { get; private set; }

		public byte[] Data { get; private set; }

		public string DataAsText { get; private set; }

		internal void Read(Stream stream)
		{
		}

		private byte ReadByte(Stream stream)
		{
			return 0;
		}

		public void Assemble(List<WebSocketFrameReader> fragments)
		{
		}

		public void DecodeWithExtensions(WebSocket webSocket)
		{
		}

		public void ReleaseData()
		{
		}
	}
}
