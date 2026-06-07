using System;

namespace BestHTTP.Connections.HTTP2
{
	[Flags]
	public enum HTTP2ContinuationFlags : byte
	{
		None = 0,
		END_HEADERS = 4
	}
}
