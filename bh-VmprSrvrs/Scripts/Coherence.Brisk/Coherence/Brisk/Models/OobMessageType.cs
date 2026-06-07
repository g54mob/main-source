namespace Coherence.Brisk.Models
{
	public enum OobMessageType : byte
	{
		ChangeSendFrequencyRequest = 1,
		KeepAlive = 2,
		ConnectRequest = 7,
		ConnectResponse = 8,
		DisconnectRequest = 9,
		Ack = 11
	}
}
