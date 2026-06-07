namespace OffroadExplorer.Lobby
{
	public enum HostLostReason
	{
		HostEndedSession = 0,
		TransportDisconnect = 1,
		HeartbeatTimeout = 2,
		TransportFailure = 3,
		Unknown = 4
	}
}
