using System;

public class NoiseGenerator
{
	private class Grad
	{
		public double x;

		public double y;

		public double z;

		public double w;

		public Grad(double x, double y, double z)
		{
		}

		public Grad(double x, double y, double z, double w)
		{
		}
	}

	private int[] perm;

	private static Grad[] grad4;

	private static double F4;

	private static double G4;

	public NoiseGenerator(Random r)
	{
	}

	public float SeamlessNoise(float x, float y, float w, float h, bool seamless, int octaves = 1, int multiplierX = 25, int multiplierY = 25, float amplitude = 0.5f, float lacunarity = 2f, float persistence = 0.9f)
	{
		return 0f;
	}

	public double Noise4D(double x, double y, double z, double w)
	{
		return 0.0;
	}

	private static int fastfloor(double x)
	{
		return 0;
	}

	private static double dot(Grad g, double x, double y)
	{
		return 0.0;
	}

	private static double dot(Grad g, double x, double y, double z)
	{
		return 0.0;
	}

	private static double dot(Grad g, double x, double y, double z, double w)
	{
		return 0.0;
	}
}
