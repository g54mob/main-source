using System;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.IntegralTransforms
{
	public static class Hartley
	{
		public static double[] NaiveForward(double[] timeSpace, HartleyOptions options)
		{
			double[] array = Naive(timeSpace);
			ForwardScaleByOptions(options, array);
			return array;
		}

		public static double[] NaiveInverse(double[] frequencySpace, HartleyOptions options)
		{
			double[] array = Naive(frequencySpace);
			InverseScaleByOptions(options, array);
			return array;
		}

		private static void ForwardScaleByOptions(HartleyOptions options, double[] samples)
		{
			if ((options & HartleyOptions.NoScaling) != HartleyOptions.NoScaling && (options & HartleyOptions.AsymmetricScaling) != HartleyOptions.AsymmetricScaling)
			{
				double num = Math.Sqrt(1.0 / (double)samples.Length);
				for (int i = 0; i < samples.Length; i++)
				{
					samples[i] *= num;
				}
			}
		}

		private static void InverseScaleByOptions(HartleyOptions options, double[] samples)
		{
			if ((options & HartleyOptions.NoScaling) != HartleyOptions.NoScaling)
			{
				double num = 1.0 / (double)samples.Length;
				if ((options & HartleyOptions.AsymmetricScaling) != HartleyOptions.AsymmetricScaling)
				{
					num = Math.Sqrt(num);
				}
				for (int i = 0; i < samples.Length; i++)
				{
					samples[i] *= num;
				}
			}
		}

		internal static double[] Naive(double[] samples)
		{
			double w0 = Math.PI * 2.0 / (double)samples.Length;
			double[] spectrum = new double[samples.Length];
			CommonParallel.For(0, samples.Length, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					double num = w0 * (double)i;
					double num2 = 0.0;
					for (int j = 0; j < samples.Length; j++)
					{
						double num3 = (double)j * num;
						num2 += samples[j] * 1.4142135623730951 * Math.Cos(num3 - Math.PI / 4.0);
					}
					spectrum[i] = num2;
				}
			});
			return spectrum;
		}
	}
}
