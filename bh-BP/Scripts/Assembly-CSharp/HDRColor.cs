using System;
using UnityEngine;

[Serializable]
public struct HDRColor
{
	public Color BaseColor;

	public float Intensity;

	public HDRColor(Color hdrColor)
	{
		BaseColor = default(Color);
		Intensity = 0f;
	}

	public Color ToColor()
	{
		return default(Color);
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public static bool operator ==(HDRColor c1, HDRColor c2)
	{
		return false;
	}

	public static bool operator !=(HDRColor c1, HDRColor c2)
	{
		return false;
	}
}
