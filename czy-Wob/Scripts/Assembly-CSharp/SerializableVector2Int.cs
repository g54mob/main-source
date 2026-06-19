using System;
using UnityEngine;

[Serializable]
public class SerializableVector2Int
{
	public int x;

	public int y;

	public SerializableVector2Int(Vector2Int v)
	{
		Save(v);
	}

	public void Save(Vector2Int v)
	{
		x = v.x;
		y = v.y;
	}

	public Vector2Int Load()
	{
		return new Vector2Int(x, y);
	}

	public SerializableVector2Int GetCopy()
	{
		return new SerializableVector2Int(Load());
	}
}
