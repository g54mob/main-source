using System;
using System.Security.Cryptography;
using MessagePack;
using UnityEngine;

[Serializable]
[MessagePackObject(false)]
public struct MapPartSerialized : ISerializationCallbackReceiver
{
	[Key(0)]
	public byte[] png;

	[Key(1)]
	public byte[] timestampPng;

	[Key(2)]
	public MapTimestampHash TimestampHash { get; private set; }

	public MapPartSerialized(byte[] png, byte[] timestampPng, MapTimestampHash timestampHash)
	{
		this.png = png;
		this.timestampPng = timestampPng;
		TimestampHash = timestampHash;
	}

	public void RecomputeTimestampHash()
	{
		ulong num = 0uL;
		ulong num2 = 0uL;
		using MD5 mD = MD5.Create();
		byte[] array = mD.ComputeHash(timestampPng);
		for (int i = 0; i < 8; i++)
		{
			num |= (ulong)array[i] << 8 * i;
		}
		for (int j = 0; j < 8; j++)
		{
			num2 |= (ulong)array[8 + j] << 8 * j;
		}
		TimestampHash = new MapTimestampHash(num, num2);
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		RecomputeTimestampHash();
	}
}
