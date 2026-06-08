using UnityEngine;

public struct ColorContext
{
	public Color ColorToUse;

	public float LerpFactor;

	public string Context;

	public ColorContext(Color color, float lerpFactor, string context)
	{
		ColorToUse = color;
		LerpFactor = lerpFactor;
		Context = context;
	}
}
