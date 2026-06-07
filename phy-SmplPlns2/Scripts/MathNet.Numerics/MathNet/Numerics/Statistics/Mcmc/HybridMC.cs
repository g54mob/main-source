using System;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public class HybridMC : HybridMCGeneric<double[]>
	{
		private readonly int _length;

		private Normal _pDistribution;

		private double[] _mpSdv;

		public double[] MomentumStdDev
		{
			get
			{
				return (double[])_mpSdv.Clone();
			}
			set
			{
				CheckVariance(value);
				_mpSdv = (double[])value.Clone();
			}
		}

		public HybridMC(double[] x0, DensityLn<double[]> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval = 0)
			: this(x0, pdfLnP, frogLeapSteps, stepSize, burnInterval, new double[x0.Length], SystemRandomSource.Default, Grad)
		{
			for (int i = 0; i < _length; i++)
			{
				_mpSdv[i] = 1.0;
			}
		}

		public HybridMC(double[] x0, DensityLn<double[]> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval, double[] pSdv)
			: this(x0, pdfLnP, frogLeapSteps, stepSize, burnInterval, pSdv, SystemRandomSource.Default)
		{
		}

		public HybridMC(double[] x0, DensityLn<double[]> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval, double[] pSdv, System.Random randomSource)
			: this(x0, pdfLnP, frogLeapSteps, stepSize, burnInterval, pSdv, randomSource, Grad)
		{
		}

		public HybridMC(double[] x0, DensityLn<double[]> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval, double[] pSdv, System.Random randomSource, DiffMethod diff)
			: base(x0, pdfLnP, frogLeapSteps, stepSize, burnInterval, randomSource, diff)
		{
			_length = x0.Length;
			MomentumStdDev = pSdv;
			Initialize(x0);
			Burn(base.BurnInterval);
		}

		private void Initialize(double[] x0)
		{
			Current = (double[])x0.Clone();
			_pDistribution = new Normal(0.0, 1.0, base.RandomSource);
		}

		private void CheckVariance(double[] pSdv)
		{
			if (pSdv == null)
			{
				throw new ArgumentNullException("pSdv", "Standard deviation cannot be null.");
			}
			if (pSdv.Length != _length)
			{
				throw new ArgumentOutOfRangeException("pSdv", "Standard deviation of momentum must have same length as sample.");
			}
			if (pSdv.Any((double sdv) => sdv < 0.0))
			{
				throw new ArgumentOutOfRangeException("pSdv", "Standard deviation must be positive.");
			}
		}

		protected override double[] Copy(double[] source)
		{
			double[] array = new double[_length];
			Array.Copy(source, 0, array, 0, _length);
			return array;
		}

		protected override double[] Create()
		{
			return new double[_length];
		}

		protected override void DoAdd(ref double[] first, double factor, double[] second)
		{
			for (int i = 0; i < _length; i++)
			{
				first[i] += factor * second[i];
			}
		}

		protected override void DoSubtract(ref double[] first, double factor, double[] second)
		{
			for (int i = 0; i < _length; i++)
			{
				first[i] -= factor * second[i];
			}
		}

		protected override double DoProduct(double[] first, double[] second)
		{
			double num = 0.0;
			for (int i = 0; i < _length; i++)
			{
				num += first[i] * second[i];
			}
			return num;
		}

		protected override void RandomizeMomentum(ref double[] p)
		{
			for (int i = 0; i < _length; i++)
			{
				p[i] = _mpSdv[i] * _pDistribution.Sample();
			}
		}

		private static double[] Grad(DensityLn<double[]> function, double[] x)
		{
			int num = x.Length;
			double[] array = new double[num];
			double[] array2 = new double[num];
			double[] array3 = new double[num];
			Array.Copy(x, 0, array2, 0, num);
			Array.Copy(x, 0, array3, 0, num);
			for (int i = 0; i < num; i++)
			{
				double num2 = x[i];
				double num3 = Math.Max(0.001, 1E-06 * num2);
				array2[i] += num3;
				array3[i] -= num3;
				array[i] = (function(array2) - function(array3)) / (2.0 * num3);
				array2[i] = num2;
				array3[i] = num2;
			}
			return array;
		}
	}
}
