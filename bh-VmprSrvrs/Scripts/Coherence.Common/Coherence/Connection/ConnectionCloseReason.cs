namespace Coherence.Connection
{
	public enum ConnectionCloseReason : byte
	{
		Unknown = 0,
		InvalidChallenge = 1,
		ServerError = 2,
		MaxEntitiesReached = 3,
		RoomFull = 4,
		GracefulClose = 5,
		InvalidData = 6,
		Timeout = 7,
		RoomNotFound = 8,
		ReceiveFrequencyExceeded = 9,
		PersistenceNotReady = 10,
		VersionIncompatible = 11,
		ServerHighLoad = 12,
		SocketClosedByPeer = 13
	}
}
