namespace BestHTTP.WebSocket
{
	public enum WebSocketStates : byte
	{
		Connecting = 0,
		Open = 1,
		Closing = 2,
		Closed = 3,
		Unknown = 4
	}
}
