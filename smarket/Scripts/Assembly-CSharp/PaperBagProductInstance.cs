using ExitGames.Client.Photon;

public class PaperBagProductInstance
{
	public int ProductID;

	private static byte[] m_Bytes;

	public PaperBagProductInstance(int productID)
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
