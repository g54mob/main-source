using System;
using UnityEngine;

[Serializable]
public class Perlin1D
{
	public float seed = 2324.234f;

	public float frequency = 1f;

	public float scale = 1f;

	public float Get(float at)
	{
		return (-0.5f + Mathf.PerlinNoise(seed, at * frequency)) * scale;
	}

	public float Get01(float at)
	{
		return Mathf.PerlinNoise(seed, at * frequency);
	}
}
