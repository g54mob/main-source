using System;
using UnityEngine;

[Serializable]
public class SerializableVector2
{
	public float x;

	public float y;

	public SerializableVector2(Vector2 v)
	{
		Save(v);
	}

	public SerializableVector2 GetCopy()
	{
		return new SerializableVector2(Load());
	}

	public void Save(Vector2 v)
	{
		x = v.x;
		y = v.y;
	}

	public Vector2 Load()
	{
		return new Vector2(x, y);
	}
}
