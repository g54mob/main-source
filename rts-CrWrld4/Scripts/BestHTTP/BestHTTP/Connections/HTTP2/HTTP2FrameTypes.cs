namespace BestHTTP.Connections.HTTP2
{
	public enum HTTP2FrameTypes : byte
	{
		DATA = 0,
		HEADERS = 1,
		PRIORITY = 2,
		RST_STREAM = 3,
		SETTINGS = 4,
		PUSH_PROMISE = 5,
		PING = 6,
		GOAWAY = 7,
		WINDOW_UPDATE = 8,
		CONTINUATION = 9,
		ALT_SVC = 10
	}
}
