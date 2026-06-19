using System;

[Serializable]
public class ServerPrefsData
{
	public string gameId;

	public string password;

	public int world;

	public string worldName;

	public string worldSeed;

	public uint hashedWorldSeed;

	public int maxNumberPlayers;

	public int maxNumberPacketsSentPerFrame;

	public int networkSendRate;

	public WorldMode worldMode;

	public int seasonOverride;
}
