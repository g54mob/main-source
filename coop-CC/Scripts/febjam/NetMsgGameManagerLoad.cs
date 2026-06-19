using Mirror;

public struct NetMsgGameManagerLoad : NetworkMessage
{
	public bool isRun;

	public string sceneName;

	public int seed;

	public sbyte contractIndex;
}
