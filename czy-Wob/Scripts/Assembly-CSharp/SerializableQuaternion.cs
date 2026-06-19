using System;
using UnityEngine;

[Serializable]
public class SerializableQuaternion
{
	public float x;

	public float y;

	public float z;

	public float w;

	public SerializableQuaternion(Quaternion q)
	{
		Save(q);
	}

	public SerializableQuaternion(float x, float y, float z, float w)
	{
		Save(new Quaternion(x, y, z, w));
	}

	public void Save(Quaternion q)
	{
		x = q.x;
		y = q.y;
		z = q.z;
		w = q.w;
	}

	public Quaternion Load()
	{
		return new Quaternion(x, y, z, w);
	}

	public SerializableQuaternion GetCopy()
	{
		return new SerializableQuaternion(Load());
	}
}
