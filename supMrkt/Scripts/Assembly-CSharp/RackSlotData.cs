using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

[Serializable]
public class RackSlotData
{
	public List<BoxData> RackedBoxDatas;

	public int ProductID;

	public int BoxID;

	private static readonly byte[] INTBuf;

	private const short BoxDataSize = 45;

	public int TotalProductCount => 0;

	public int BoxCount => 0;

	public void Clear()
	{
	}

	public void Setup(int productID, int boxID)
	{
	}

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
