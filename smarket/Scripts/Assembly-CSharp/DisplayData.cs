using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

[Serializable]
public class DisplayData
{
	public TransformData Transform;

	public List<ItemQuantity> DisplaySlots;

	public int FurnitureID;

	private static byte[] m_Bytes;

	private static readonly byte[] INTBuffer;

	private static readonly byte[] ShortBuffer;

	private static int WriteInt(StreamBuffer outStream, int value)
	{
		return 0;
	}

	private static int ReadInt(StreamBuffer inStream)
	{
		return 0;
	}

	private static int WriteShort(StreamBuffer outStream, short value)
	{
		return 0;
	}

	private static short ReadShort(StreamBuffer inStream)
	{
		return 0;
	}

	private static int ComputeItemQuantitySize(ItemQuantity it)
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
