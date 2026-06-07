using System.Collections.Generic;
using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.SocketIO3
{
	public struct OutgoingPacket
	{
		public bool IsBinary => false;

		public string Payload { get; set; }

		public List<byte[]> Attachements { get; set; }

		public BufferSegment PayloadData { get; set; }

		public bool IsVolatile { get; set; }
	}
}
