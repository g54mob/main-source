using System;
using UnityEngine;

[Serializable]
public class SRect
{
	public float x;

	public float y;

	public float width;

	public float height;

	public SRect(float X, float Y, float W, float H)
	{
		x = X;
		y = Y;
		width = W;
		height = H;
	}

	public SRect()
	{
	}

	public static explicit operator SRect(Rect r)
	{
		return new SRect(r.x, r.y, r.width, r.height);
	}

	public Rect ToRect()
	{
		return new Rect(x, y, width, height);
	}
}
