namespace TwitchLib.Client.Enums.Internal
{
	public enum IrcCommand
	{
		Unknown = 0,
		PrivMsg = 1,
		Notice = 2,
		Ping = 3,
		Pong = 4,
		Join = 5,
		Part = 6,
		HostTarget = 7,
		ClearChat = 8,
		ClearMsg = 9,
		UserState = 10,
		GlobalUserState = 11,
		Nick = 12,
		Pass = 13,
		Cap = 14,
		RPL_001 = 15,
		RPL_002 = 16,
		RPL_003 = 17,
		RPL_004 = 18,
		RPL_353 = 19,
		RPL_366 = 20,
		RPL_372 = 21,
		RPL_375 = 22,
		RPL_376 = 23,
		Whisper = 24,
		RoomState = 25,
		Reconnect = 26,
		ServerChange = 27,
		UserNotice = 28,
		Mode = 29
	}
}
