using System.Collections.Generic;
using ExitGames.Client.Photon;

public class IceCreamRequest
{
	public class Builder
	{
		private IceCreamRequest m_Request;

		public Builder AddFlavour(IceCreamFlavour flavour, int count = 1)
		{
			return null;
		}

		public Builder SetTopping(IceCreamTopping topping)
		{
			return null;
		}

		public Builder SetCone(int value)
		{
			return null;
		}

		public IceCreamRequest Build()
		{
			return null;
		}
	}

	private int m_ConeId;

	private IceCreamTopping m_Topping;

	private Dictionary<IceCreamFlavour, int> m_FlavourCountPair;

	private static readonly byte[] m_SerializationByteBuffer;

	public int ConeId => 0;

	public IceCreamTopping Topping => null;

	public IEnumerable<KeyValuePair<IceCreamFlavour, int>> Flavours => null;

	public static short Serialize(StreamBuffer outStream, object customObject)
	{
		return 0;
	}

	public static object Deserialize(StreamBuffer inStream, short length)
	{
		return null;
	}

	public float Compare(IceCreamStatus status)
	{
		return 0f;
	}

	public static Builder CreateBuilder()
	{
		return null;
	}
}
