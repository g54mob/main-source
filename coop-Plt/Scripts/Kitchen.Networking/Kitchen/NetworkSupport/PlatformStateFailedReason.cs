namespace Kitchen.NetworkSupport
{
	public enum PlatformStateFailedReason
	{
		None = 0,
		NoAuth = 1,
		NoConnection = 2,
		NoSubscription = 3,
		NoNetService = 4,
		NoMiddlewareService = 5,
		Banned = 6,
		Kicked = 7,
		IHVNetworkServiceSignOut = 8,
		MiddlewareError = 9,
		InsufficientPrivileges = 10,
		Timeout = 11,
		HostDisconnected = 12,
		RoomFull = 13,
		InvalidJoinCode = 14,
		Unknown = 15
	}
}
