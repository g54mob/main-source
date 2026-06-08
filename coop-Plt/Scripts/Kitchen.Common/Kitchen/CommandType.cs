namespace Kitchen
{
	public enum CommandType
	{
		Null = 0,
		RequestFullRefresh = 1,
		RequestPause = 2,
		RequestUnpause = 3,
		Disconnecting = 4,
		NewConnection = 5,
		Kick = 6,
		KeepAlive = 7
	}
}
