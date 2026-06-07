using System;
using ExitGames.Client.Photon;

[Serializable]
public class IceCreamFlavourData
{
	public int ProductID;

	private int _Remaining;

	private static readonly byte[] m_Bytes;

	public int Remaining
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public IceCreamFlavourData(int id, int remaining)
	{
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
