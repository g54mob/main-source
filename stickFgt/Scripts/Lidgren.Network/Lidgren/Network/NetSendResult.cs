namespace Lidgren.Network
{
	public enum NetSendResult
	{
		FailedNotConnected = 0,
		Sent = 1,
		Queued = 2,
		Dropped = 3
	}
}
