using System;
using UnityEngine;

[Serializable]
public class SerializableRect
{
	public float x;

	public float y;

	public float width;

	public float height;

	public SerializableRect(Rect r)
	{
		Save(r);
	}

	public SerializableRect GetCopy()
	{
		return new SerializableRect(Load());
	}

	public void Save(Rect r)
	{
		x = r.x;
		y = r.y;
		width = r.width;
		height = r.height;
	}

	public Rect Load()
	{
		return new Rect(x, y, width, height);
	}
}
