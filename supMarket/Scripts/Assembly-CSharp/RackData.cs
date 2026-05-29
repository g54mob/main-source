using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

[Serializable]
public class RackData
{
	public TransformData Transform;

	public List<RackSlotData> RackSlots;

	public int FurnitureID;

	private static readonly byte[] INTBuf;

	private static int WriteInt(StreamBuffer outStream, int value)
	{
		return 0;
	}

	private static int ReadInt(StreamBuffer inStream)
	{
		return 0;
	}

	public static short Serialize(StreamBuffer outStream, object customObject)
	{
		return 0;
	}

	public static object Deserialize(StreamBuffer inStream, short length)
	{
		return null;
	}
}
