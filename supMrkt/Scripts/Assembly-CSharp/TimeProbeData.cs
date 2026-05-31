using System;
using UnityEngine;

[Serializable]
public struct TimeProbeData
{
	public float Percentage;

	public Texture Texture;

	public TimeProbeData(float percentage, Texture texture)
	{
		Percentage = 0f;
		Texture = null;
	}
}
