using System;

namespace BestHTTP.Connections.HTTP2
{
	[Flags]
	public enum HTTP2DataFlags : byte
	{
		None = 0,
		END_STREAM = 1,
		PADDED = 8
	}
}
