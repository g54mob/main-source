using System;

namespace BestHTTP.Connections.HTTP2
{
	[Flags]
	public enum HTTP2HeadersFlags : byte
	{
		None = 0,
		END_STREAM = 1,
		END_HEADERS = 4,
		PADDED = 8,
		PRIORITY = 0x20
	}
}
