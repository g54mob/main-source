using System;
using ExitGames.Client.Photon;
using NaisuPorter.CommonScripts;
using UnityEngine;

[Serializable]
public class TransformData
{
	public SerializableVector3 Position;

	public SerializableQuaternion Rotation;

	public const int Size = 28;

	private static byte[] m_Bytes;

	public TransformData()
	{
	}

	public TransformData(Vector3 position, Quaternion rotation)
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
