using System;
using ExitGames.Client.Photon;
using __Project__.Scripts.Data;
using __Project__.Scripts.WallPaintSystem;

[Serializable]
public class FurnitureBoxData
{
	public BoxSize Size;

	public TransformData Transform;

	public int FurnitureID;

	public BucketData bucketData;

	public CategorySignData categorySignData;

	public DisplayData displayData;

	public VendingData vendingData;

	public RackData rackData;

	public IceCreamManager.StandBoxData iceCreamStandData;

	private static readonly byte[] INTBuf;

	private static readonly byte[] BoolBuf;

	public FurnitureSO Furniture => null;

	public BucketSo Bucket => null;

	public FurnitureBoxData()
	{
	}

	public FurnitureBoxData(BoxSize Size, int FurnitureID)
	{
	}

	private static int WriteInt(StreamBuffer outStream, int v)
	{
		return 0;
	}

	private static int ReadInt(StreamBuffer inStream)
	{
		return 0;
	}

	private static int WriteBool(StreamBuffer outStream, bool v)
	{
		return 0;
	}

	private static bool ReadBool(StreamBuffer inStream)
	{
		return false;
	}

	private static void WriteShort(StreamBuffer s, short v)
	{
	}

	private static short ReadShort(StreamBuffer s)
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
