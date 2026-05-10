using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

public struct IceCreamStatus : IDisposable
{
	public Dictionary<IceCreamFlavour, int> Flavours;

	public IceCreamTopping Topping;

	private static readonly byte[] m_SerializationByteBuffer;

	public int FlavourCount => 0;

	public int ConeIndex { get; set; }

	public IceCreamStatus(IceCreamTopping topping, int coneIndex)
	{
		Flavours = null;
		ConeIndex = 0;
		Topping = null;
	}

	public void Release()
	{
	}

	public void Dispose()
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
