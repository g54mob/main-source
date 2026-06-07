using System;

public static class RandomExtensions
{
	public static double SampleNormal(this Random random, double mean, double std)
	{
		double d = 1.0 - random.NextDouble();
		double num = 1.0 - random.NextDouble();
		return Math.Sqrt(-2.0 * Math.Log(d)) * Math.Cos(Math.PI * 2.0 * num) * std + mean;
	}

	public static float SampleNormal(this Random random, float mean, float std)
	{
		float num = 1f - (float)random.NextDouble();
		float num2 = 1f - (float)random.NextDouble();
		return (float)(Math.Sqrt(-2.0 * Math.Log(num)) * Math.Cos(Math.PI * 2.0 * (double)num2)) * std + mean;
	}
}
