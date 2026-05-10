using ExitGames.Client.Photon;

public class OrderData
{
	public int ProductID;

	public int ProductCount;

	public float CachedPrice;

	public const int Size = 12;

	private static readonly byte[] m_Bytes;

	public static short Serialize(StreamBuffer outStream, object customObject)
	{
		return 0;
	}

	public static object Deserialize(StreamBuffer inStream, short length)
	{
		return null;
	}
}
