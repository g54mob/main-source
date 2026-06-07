using UnityEngine;

public class SimplexNoiseGenerator
{
	private int[] A;

	private float s;

	private float u;

	private float v;

	private float w;

	private int i;

	private int j;

	private int k;

	private float onethird;

	private float onesixth;

	private int[] T;

	public SimplexNoiseGenerator()
	{
	}

	public SimplexNoiseGenerator(string seed)
	{
	}

	public SimplexNoiseGenerator(int[] seed)
	{
	}

	public string GetSeed()
	{
		return null;
	}

	public float coherentNoise(float x, float y, int octaves = 1, int multiplierX = 25, int multiplierY = 25, float amplitude = 0.5f, float lacunarity = 2f, float persistence = 0.9f)
	{
		return 0f;
	}

	public int getDensity(Vector3 loc)
	{
		return 0;
	}

	public float noise(float x, float y, float z)
	{
		return 0f;
	}

	private float kay(int a)
	{
		return 0f;
	}

	private int shuffle(int i, int j, int k)
	{
		return 0;
	}

	private int b(int i, int j, int k, int B)
	{
		return 0;
	}

	private int b(int N, int B)
	{
		return 0;
	}

	private int fastfloor(float n)
	{
		return 0;
	}
}
