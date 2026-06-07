using System;

namespace BestHTTP.Connections.HTTP2
{
	[Flags]
	public enum HTTP2PingFlags : byte
	{
		None = 0,
		ACK = 1
	}
}
