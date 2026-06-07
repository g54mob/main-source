using System;

namespace BestHTTP.Connections.HTTP2
{
	[Flags]
	public enum HTTP2PushPromiseFlags : byte
	{
		None = 0,
		END_HEADERS = 4,
		PADDED = 8
	}
}
