using System;
using UnityEngine;

[Serializable]
public class SColor
{
	public float R;

	public float G;

	public float B;

	public float A;

	public SColor(Color c)
	{
	}

	public SColor(float r, float g, float b, float a = 1f)
	{
	}

	public Color ToColor()
	{
		return default(Color);
	}

	public void FillColor(Color c)
	{
	}
}
