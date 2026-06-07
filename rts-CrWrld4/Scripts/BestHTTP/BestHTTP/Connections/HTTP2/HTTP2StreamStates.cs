namespace BestHTTP.Connections.HTTP2
{
	public enum HTTP2StreamStates
	{
		Idle = 0,
		Open = 1,
		HalfClosedLocal = 2,
		HalfClosedRemote = 3,
		Closed = 4
	}
}
