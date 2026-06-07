using System;
using System.Linq;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Dirichlet : IDistribution
	{
		private System.Random _random;

		private readonly double[] _alpha;

		public double[] Alpha => _alpha;

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

		public int Dimension => _alpha.Length;

		private double AlphaSum => _alpha.Sum();

		public double[] Mean
		{
			get
			{
				double alphaSum = AlphaSum;
				double[] array = new double[Dimension];
				for (int i = 0; i < Dimension; i++)
				{
					array[i] = _alpha[i] / alphaSum;
				}
				return array;
			}
		}

		public double[] Variance
		{
			get
			{
				double alphaSum = AlphaSum;
				double[] array = new double[_alpha.Length];
				for (int i = 0; i < _alpha.Length; i++)
				{
					array[i] = _alpha[i] * (alphaSum - _alpha[i]) / (alphaSum * alphaSum * (alphaSum + 1.0));
				}
				return array;
			}
		}

		public double Entropy
		{
			get
			{
				double num = _alpha.Sum((double t) => (t - 1.0) * SpecialFunctions.DiGamma(t));
				return SpecialFunctions.GammaLn(AlphaSum) + (AlphaSum - (double)Dimension) * SpecialFunctions.DiGamma(AlphaSum) - num;
			}
		}

		public Dirichlet(double[] alpha)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(alpha))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_alpha = (double[])alpha.Clone();
		}

		public Dirichlet(double[] alpha, System.Random randomSource)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(alpha))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_alpha = (double[])alpha.Clone();
		}

		public Dirichlet(double alpha, int k)
		{
			double[] array = new double[k];
			for (int i = 0; i < k; i++)
			{
				array[i] = alpha;
			}
			_random = SystemRandomSource.Default;
			if (Control.CheckDistributionParameters && !IsValidParameterSet(array))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_alpha = (double[])array.Clone();
		}

		public Dirichlet(double alpha, int k, System.Random randomSource)
		{
			double[] array = new double[k];
			for (int i = 0; i < k; i++)
			{
				array[i] = alpha;
			}
			_random = randomSource ?? SystemRandomSource.Default;
			if (Control.CheckDistributionParameters && !IsValidParameterSet(array))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_alpha = (double[])array.Clone();
		}

		public override string ToString()
		{
			return $"Dirichlet(Dimension = {Dimension})";
		}

		public static bool IsValidParameterSet(double[] alpha)
		{
			bool flag = true;
			foreach (double num in alpha)
			{
				if (num < 0.0)
				{
					return false;
				}
				if (num > 0.0)
				{
					flag = false;
				}
			}
			return !flag;
		}

		public double Density(double[] x)
		{
			return Math.Exp(DensityLn(x));
		}

		public double DensityLn(double[] x)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			bool flag = x.Length == _alpha.Length - 1;
			if (x.Length != _alpha.Length && !flag)
			{
				throw new ArgumentException("x");
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			for (int i = 0; i < x.Length; i++)
			{
				double num4 = x[i];
				if (num4 <= 0.0 || num4 >= 1.0)
				{
					return 0.0;
				}
				num += (_alpha[i] - 1.0) * Math.Log(num4) - SpecialFunctions.GammaLn(_alpha[i]);
				num2 += num4;
				num3 += _alpha[i];
			}
			if (flag)
			{
				if (num2 >= 1.0)
				{
					return 0.0;
				}
				num += (_alpha[_alpha.Length - 1] - 1.0) * Math.Log(1.0 - num2) - SpecialFunctions.GammaLn(_alpha[_alpha.Length - 1]);
				num3 += _alpha[_alpha.Length - 1];
			}
			else if (!num2.AlmostEqualRelative(1.0, 8))
			{
				return 0.0;
			}
			return num + SpecialFunctions.GammaLn(num3);
		}

		public double[] Sample()
		{
			return Sample(_random, _alpha);
		}

		public static double[] Sample(System.Random rnd, double[] alpha)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(alpha))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			int num = alpha.Length;
			double[] array = new double[num];
			double num2 = 0.0;
			for (int i = 0; i < num; i++)
			{
				if (alpha[i] == 0.0)
				{
					array[i] = 0.0;
				}
				else
				{
					array[i] = Gamma.Sample(rnd, alpha[i], 1.0);
				}
				num2 += array[i];
			}
			for (int j = 0; j < num; j++)
			{
				array[j] /= num2;
			}
			return array;
		}
	}
}
