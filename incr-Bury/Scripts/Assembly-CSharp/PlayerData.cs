using System;
using Unity.Netcode;

[Serializable]
public class PlayerData : INetworkSerializable
{
	public string playerName;

	public ulong steamID;

	public ulong clientID;

	public string voiceSessionName = "";

	public PlayerData()
	{
	}

	public PlayerData(string _playerName, ulong _steamID, ulong _clientID)
	{
		playerName = _playerName;
		steamID = _steamID;
		clientID = _clientID;
		voiceSessionName = "";
	}

	public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
	{
		serializer.SerializeValue(ref playerName);
		serializer.SerializeValue(ref steamID, default(FastBufferWriter.ForPrimitives));
		serializer.SerializeValue(ref clientID, default(FastBufferWriter.ForPrimitives));
		serializer.SerializeValue(ref voiceSessionName);
	}
}
