using System;
using UnityEngine;

[Serializable]
public class SerializableVector3
{
	public float x;

	public float y;

	public float z;

	public SerializableVector3(Vector3 v)
	{
		Save(v);
	}

	public SerializableVector3 GetCopy()
	{
		return new SerializableVector3(Load());
	}

	public void Save(Vector3 v)
	{
		x = v.x;
		y = v.y;
		z = v.z;
	}

	public Vector3 Load()
	{
		return new Vector3(x, y, z);
	}
}
