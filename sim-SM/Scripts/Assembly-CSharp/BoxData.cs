using System;
using ExitGames.Client.Photon;
using UnityEngine;

[Serializable]
public class BoxData
{
	public int m_UID;

	public BoxSize Size;

	public TransformData Transform;

	public bool IsOpen;

	public int ProductID;

	public int ProductCount;

	private static readonly byte[] INT_BUF;

	private static readonly byte[] BOOL_BUF;

	public ProductSO Product => null;

	public int UID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public BoxData()
	{
	}

	public BoxData(BoxSize _Size, Vector3 _position, Quaternion _rotation, bool _IsOpen, int _ProductID, int _ProductCount)
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
