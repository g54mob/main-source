using System;
using UnityEngine;

[Serializable]
public class SerializableColor
{
	public float r;

	public float g;

	public float b;

	public float a;

	public SerializableColor GetCopy()
	{
		return new SerializableColor(Load());
	}

	public SerializableColor(Color c)
	{
		Save(c);
	}

	private void Save(Color c)
	{
		r = c.r;
		g = c.g;
		b = c.b;
		a = c.a;
	}

	public Color Load()
	{
		return new Color(r, g, b, a);
	}
}
