namespace Kitchen.NetworkSupport
{
	public enum NetworkState
	{
		Unknown = 0,
		Disconnected = 1,
		ConnectedButNoInternet = 2,
		ConnectedButNoPlatform = 3,
		ConnectedButNoService = 4,
		Connected = 5
	}
}
