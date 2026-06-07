using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Categorical : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double[] _pmfNormalized;

		private readonly double[] _cdfUnnormalized;

		public double[] P => (double[])_pmfNormalized.Clone();

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

		public double Mean
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < _pmfNormalized.Length; i++)
				{
					num += (double)i * _pmfNormalized[i];
				}
				return num;
			}
		}

		public double StdDev => Math.Sqrt(Variance);

		public double Variance
		{
			get
			{
				double mean = Mean;
				double num = 0.0;
				for (int i = 0; i < _pmfNormalized.Length; i++)
				{
					double num2 = (double)i - mean;
					num += num2 * num2 * _pmfNormalized[i];
				}
				return num;
			}
		}

		public double Entropy => 0.0 - _pmfNormalized.Sum((double p) => p * Math.Log(p));

		public double Skewness
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public int Minimum => 0;

		public int Maximum => _pmfNormalized.Length - 1;

		public int Mode
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Median => InverseCumulativeDistribution(0.5);

		public Categorical(double[] probabilityMass)
			: this(probabilityMass, SystemRandomSource.Default)
		{
		}

		public Categorical(double[] probabilityMass, System.Random randomSource)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_cdfUnnormalized = new double[probabilityMass.Length];
			_cdfUnnormalized[0] = probabilityMass[0];
			for (int i = 1; i < probabilityMass.Length; i++)
			{
				_cdfUnnormalized[i] = _cdfUnnormalized[i - 1] + probabilityMass[i];
			}
			double num = _cdfUnnormalized[_cdfUnnormalized.Length - 1];
			_pmfNormalized = new double[probabilityMass.Length];
			for (int j = 0; j < probabilityMass.Length; j++)
			{
				_pmfNormalized[j] = probabilityMass[j] / num;
			}
		}

		public Categorical(Histogram histogram)
		{
			if (histogram == null)
			{
				throw new ArgumentNullException("histogram");
			}
			double[] array = new double[histogram.BucketCount];
			for (int i = 0; i < histogram.BucketCount; i++)
			{
				array[i] = histogram[i].Count;
			}
			_random = SystemRandomSource.Default;
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(array))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_cdfUnnormalized = new double[array.Length];
			_cdfUnnormalized[0] = array[0];
			for (int j = 1; j < array.Length; j++)
			{
				_cdfUnnormalized[j] = _cdfUnnormalized[j - 1] + array[j];
			}
			double num = _cdfUnnormalized[_cdfUnnormalized.Length - 1];
			_pmfNormalized = new double[array.Length];
			for (int k = 0; k < array.Length; k++)
			{
				_pmfNormalized[k] = array[k] / num;
			}
		}

		public override string ToString()
		{
			return $"Categorical(Dimension = {_pmfNormalized.Length})";
		}

		public static bool IsValidProbabilityMass(double[] p)
		{
			double num = 0.0;
			foreach (double num2 in p)
			{
				if (num2 < 0.0 || double.IsNaN(num2))
				{
					return false;
				}
				num += num2;
			}
			return num > 0.0;
		}

		public static bool IsValidCumulativeDistribution(double[] cdf)
		{
			double num = 0.0;
			foreach (double num2 in cdf)
			{
				if (num2 < 0.0 || double.IsNaN(num2) || num2 < num)
				{
					return false;
				}
				num = num2;
			}
			return num > 0.0;
		}

		public double Probability(int k)
		{
			if (k < 0)
			{
				return 0.0;
			}
			if (k >= _pmfNormalized.Length)
			{
				return 0.0;
			}
			return _pmfNormalized[k];
		}

		public double ProbabilityLn(int k)
		{
			if (k < 0)
			{
				return 0.0;
			}
			if (k >= _pmfNormalized.Length)
			{
				return 0.0;
			}
			return Math.Log(_pmfNormalized[k]);
		}

		public double CumulativeDistribution(double x)
		{
			if (x < 0.0)
			{
				return 0.0;
			}
			if (x >= (double)_cdfUnnormalized.Length)
			{
				return 1.0;
			}
			return _cdfUnnormalized[(int)Math.Floor(x)] / _cdfUnnormalized[_cdfUnnormalized.Length - 1];
		}

		public int InverseCumulativeDistribution(double probability)
		{
			if (probability < 0.0 || probability > 1.0 || double.IsNaN(probability))
			{
				throw new ArgumentOutOfRangeException("probability");
			}
			double value = probability * _cdfUnnormalized[_cdfUnnormalized.Length - 1];
			int num = Array.BinarySearch(_cdfUnnormalized, value);
			if (num < 0)
			{
				num = ~num;
			}
			return num;
		}

		public static double PMF(double[] probabilityMass, int k)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k < 0)
			{
				return 0.0;
			}
			if (k >= probabilityMass.Length)
			{
				return 0.0;
			}
			return probabilityMass[k] / probabilityMass.Sum();
		}

		public static double PMFLn(double[] probabilityMass, int k)
		{
			return Math.Log(PMF(probabilityMass, k));
		}

		public static double CDF(double[] probabilityMass, double x)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0)
			{
				return 0.0;
			}
			if (x >= (double)probabilityMass.Length)
			{
				return 1.0;
			}
			double[] array = ProbabilityMassToCumulativeDistribution(probabilityMass);
			return array[(int)Math.Floor(x)] / array[^1];
		}

		public static int InvCDF(double[] probabilityMass, double probability)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (probability < 0.0 || probability > 1.0 || double.IsNaN(probability))
			{
				throw new ArgumentOutOfRangeException("probability");
			}
			double[] array = ProbabilityMassToCumulativeDistribution(probabilityMass);
			double value = probability * array[^1];
			int num = Array.BinarySearch(array, value);
			if (num < 0)
			{
				num = ~num;
			}
			return num;
		}

		public static int InvCDFWithCumulativeDistribution(double[] cdfUnnormalized, double probability)
		{
			if (Control.CheckDistributionParameters && !IsValidCumulativeDistribution(cdfUnnormalized))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (probability < 0.0 || probability > 1.0 || double.IsNaN(probability))
			{
				throw new ArgumentOutOfRangeException("probability");
			}
			double value = probability * cdfUnnormalized[^1];
			int num = Array.BinarySearch(cdfUnnormalized, value);
			if (num < 0)
			{
				num = ~num;
			}
			return num;
		}

		internal static double[] ProbabilityMassToCumulativeDistribution(double[] probabilityMass)
		{
			double[] array = new double[probabilityMass.Length];
			array[0] = probabilityMass[0];
			for (int i = 1; i < probabilityMass.Length; i++)
			{
				array[i] = array[i - 1] + probabilityMass[i];
			}
			return array;
		}

		internal static int SampleUnchecked(System.Random rnd, double[] cdfUnnormalized)
		{
			double num = rnd.NextDouble() * cdfUnnormalized[^1];
			int i = 0;
			if (num == 0.0)
			{
				for (; 0.0 == cdfUnnormalized[i]; i++)
				{
				}
			}
			for (; num > cdfUnnormalized[i]; i++)
			{
			}
			return i;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double[] cdfUnnormalized)
		{
			double[] uniform = rnd.NextDoubles(values.Length);
			double w = cdfUnnormalized[cdfUnnormalized.Length - 1];
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					double num = uniform[i] * w;
					int j = 0;
					if (num == 0.0)
					{
						for (; 0.0 == cdfUnnormalized[j]; j++)
						{
						}
					}
					for (; num > cdfUnnormalized[j]; j++)
					{
					}
					values[i] = j;
				}
			});
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double[] cdfUnnormalized)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, cdfUnnormalized);
			}
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _cdfUnnormalized);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _cdfUnnormalized);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _cdfUnnormalized);
		}

		public static int Sample(System.Random rnd, double[] probabilityMass)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cdfUnnormalized = ProbabilityMassToCumulativeDistribution(probabilityMass);
			return SampleUnchecked(rnd, cdfUnnormalized);
		}

		public static IEnumerable<int> Samples(System.Random rnd, double[] probabilityMass)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cdfUnnormalized = ProbabilityMassToCumulativeDistribution(probabilityMass);
			return SamplesUnchecked(rnd, cdfUnnormalized);
		}

		public static void Samples(System.Random rnd, int[] values, double[] probabilityMass)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cdfUnnormalized = ProbabilityMassToCumulativeDistribution(probabilityMass);
			SamplesUnchecked(rnd, values, cdfUnnormalized);
		}

		public static int Sample(double[] probabilityMass)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cdfUnnormalized = ProbabilityMassToCumulativeDistribution(probabilityMass);
			return SampleUnchecked(SystemRandomSource.Default, cdfUnnormalized);
		}

		public static IEnumerable<int> Samples(double[] probabilityMass)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cdfUnnormalized = ProbabilityMassToCumulativeDistribution(probabilityMass);
			return SamplesUnchecked(SystemRandomSource.Default, cdfUnnormalized);
		}

		public static void Samples(int[] values, double[] probabilityMass)
		{
			if (Control.CheckDistributionParameters && !IsValidProbabilityMass(probabilityMass))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double[] cdfUnnormalized = ProbabilityMassToCumulativeDistribution(probabilityMass);
			SamplesUnchecked(SystemRandomSource.Default, values, cdfUnnormalized);
		}

		public static int SampleWithCumulativeDistribution(System.Random rnd, double[] cdfUnnormalized)
		{
			if (Control.CheckDistributionParameters && !IsValidCumulativeDistribution(cdfUnnormalized))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, cdfUnnormalized);
		}

		public static IEnumerable<int> SamplesWithCumulativeDistribution(System.Random rnd, double[] cdfUnnormalized)
		{
			if (Control.CheckDistributionParameters && !IsValidCumulativeDistribution(cdfUnnormalized))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, cdfUnnormalized);
		}

		public static void SamplesWithCumulativeDistribution(System.Random rnd, int[] values, double[] cdfUnnormalized)
		{
			if (Control.CheckDistributionParameters && !IsValidCumulativeDistribution(cdfUnnormalized))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, cdfUnnormalized);
		}

		public static int SampleWithCumulativeDistribution(double[] cdfUnnormalized)
		{
			if (Control.CheckDistributionParameters && !IsValidCumulativeDistribution(cdfUnnormalized))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, cdfUnnormalized);
		}

		public static IEnumerable<int> SamplesWithCumulativeDistribution(double[] cdfUnnormalized)
		{
			if (Control.CheckDistributionParameters && !IsValidCumulativeDistribution(cdfUnnormalized))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, cdfUnnormalized);
		}

		public static void SamplesWithCumulativeDistribution(int[] values, double[] cdfUnnormalized)
		{
			if (Control.CheckDistributionParameters && !IsValidCumulativeDistribution(cdfUnnormalized))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, cdfUnnormalized);
		}
	}
}
