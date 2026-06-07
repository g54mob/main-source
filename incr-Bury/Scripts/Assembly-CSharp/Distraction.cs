using System;
using Unity.Netcode;
using UnityEngine;

[Serializable]
public class Distraction : INetworkSerializable
{
	public Vector3 location;

	public float distance;

	public float priority;

	public float duration;

	public Distraction()
	{
	}

	public Distraction(Vector3 _location, float _prio, float _dist, float _dur = 5f)
	{
		location = _location;
		distance = _dist;
		priority = _prio;
		duration = _dur;
	}

	public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
	{
		serializer.SerializeValue(ref location);
		serializer.SerializeValue(ref distance, default(FastBufferWriter.ForPrimitives));
		serializer.SerializeValue(ref priority, default(FastBufferWriter.ForPrimitives));
		serializer.SerializeValue(ref duration, default(FastBufferWriter.ForPrimitives));
	}
}
