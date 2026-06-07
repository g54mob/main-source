using System;
using UnityEngine;

[Serializable]
public class Perlin2D
{
	public float horizontalSeed = 5349.324f;

	public float verticalSeed = 3412.21f;

	public float horizontalFrequency = 1f;

	public float horizontalGain = 1f;

	public float verticalFrequency = 1f;

	public float verticalGain = 1f;

	public Vector3 Get(float at)
	{
		float x = (-0.5f + Mathf.PerlinNoise(horizontalSeed, at * horizontalFrequency)) * horizontalGain;
		float y = (-0.5f + Mathf.PerlinNoise(verticalSeed, at * verticalFrequency)) * verticalGain;
		return new Vector3(x, y, at);
	}

	public Vector3 GetDirection(float at, float samplingDistance = 2f)
	{
		Vector3 vector = Get(at + samplingDistance);
		Vector3 vector2 = Get(at - samplingDistance);
		return (vector - vector2).normalized;
	}
}
