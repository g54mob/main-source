using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics.Distributions
{
	public class Multinomial : IDistribution
	{
		private System.Random _random;

		private readonly double[] _p;

		private readonly int _trials;

		public double[] P => (double[])_p.Clone();

		public int N => _trials;

		public System.Random RandomSource
		{
			get
			{
				return _random;
			}
			set
			{
				_random = value ?? SystemRandomSource.Default;
			}
		}

		public Vector<double> Mean => (double)_trials * (DenseVector)P;

		public Vector<double> Variance
		{
			get
			{
				DenseVector denseVector = P;
				for (int i = 0; i < denseVector.Count; i++)
				{
					denseVector[i] *= (double)_trials * (1.0 - denseVector[i]);
				}
				return denseVector;
			}
		}

		public Vector<double> Skewness
		{
			get
			{
				DenseVector denseVector = P;
				for (int i = 0; i < denseVector.Count; i++)
				{
					denseVector[i] = (1.0 - 2.0 * denseVector[i]) / Math.Sqrt((double)_trials * (1.0 - denseVector[i]) * denseVector[i]);
				}
				return denseVector;
			}
		}

		public Multinomial(double[] p, int n)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(p, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_p = (double[])p.Clone();
			_trials = n;
		}

		public Multinomial(double[] p, int n, System.Random randomSource)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(p, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_p = (double[])p.Clone();
			_trials = n;
		}

		public Multinomial(Histogram h, int n)
		{
			if (h == null)
			{
				throw new ArgumentNullException("h");
			}
			double[] array = new double[h.BucketCount];
			for (int i = 0; i < h.BucketCount; i++)
			{
				array[i] = h[i].Count;
			}
			if (Control.CheckDistributionParameters && !IsValidParameterSet(array, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_p = (double[])array.Clone();
			_trials = n;
			RandomSource = SystemRandomSource.Default;
		}

		public override string ToString()
		{
			return $"Multinomial(Dimension = {_p.Length}, Number of Trails = {_trials})";
		}

		public static bool IsValidParameterSet(IEnumerable<double> p, int n)
		{
			double num = 0.0;
			foreach (double item in p)
			{
				if (item < 0.0 || double.IsNaN(item))
				{
					return false;
				}
				num += item;
			}
			if (num == 0.0)
			{
				return false;
			}
			return n >= 0;
		}

		public double Probability(int[] x)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (x.Length != _p.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "x");
			}
			if (x.Sum() == _trials)
			{
				double num = SpecialFunctions.Multinomial(_trials, x);
				double num2 = 1.0;
				for (int i = 0; i < x.Length; i++)
				{
					num2 *= Math.Pow(_p[i], x[i]);
				}
				return num * num2;
			}
			return 0.0;
		}

		public double ProbabilityLn(int[] x)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (x.Length != _p.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "x");
			}
			if (x.Sum() == _trials)
			{
				double num = Math.Log(SpecialFunctions.Multinomial(_trials, x));
				double num2 = x.Select((int t, int i) => (double)t * Math.Log(_p[i])).Sum();
				return num + num2;
			}
			return 0.0;
		}

		public int[] Sample()
		{
			return Sample(_random, _p, _trials);
		}

		public IEnumerable<int[]> Samples()
		{
			while (true)
			{
				yield return Sample(_random, _p, _trials);
			}
		}

		public static int[] Sample(System.Random rnd, double[] p, int n)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(p, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cdfUnnormalized = Categorical.ProbabilityMassToCumulativeDistribution(p);
			int[] array = new int[p.Length];
			for (int i = 0; i < n; i++)
			{
				array[Categorical.SampleUnchecked(rnd, cdfUnnormalized)]++;
			}
			return array;
		}

		public static IEnumerable<int[]> Samples(System.Random rnd, double[] p, int n)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(p, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cp = Categorical.ProbabilityMassToCumulativeDistribution(p);
			while (true)
			{
				int[] array = new int[p.Length];
				for (int i = 0; i < n; i++)
				{
					array[Categorical.SampleUnchecked(rnd, cp)]++;
				}
				yield return array;
			}
		}
	}
}
