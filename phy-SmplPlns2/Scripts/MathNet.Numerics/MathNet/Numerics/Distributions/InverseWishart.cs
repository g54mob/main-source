using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class InverseWishart : IDistribution
	{
		private System.Random _random;

		private readonly double _freedom;

		private readonly Matrix<double> _scale;

		private readonly Cholesky<double> _chol;

		public double DegreesOfFreedom => _freedom;

		public Matrix<double> Scale => _scale;

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

		public Matrix<double> Mean => _scale * (1.0 / (_freedom - (double)_scale.RowCount - 1.0));

		public Matrix<double> Mode => _scale * (1.0 / (_freedom + (double)_scale.RowCount + 1.0));

		public Matrix<double> Variance => Matrix<double>.Build.Dense(_scale.RowCount, _scale.ColumnCount, delegate(int i, int j)
		{
			double num = (_freedom - (double)_scale.RowCount + 1.0) * _scale.At(i, j) * _scale.At(i, j) + (_freedom - (double)_scale.RowCount - 1.0) * _scale.At(i, i) * _scale.At(j, j);
			double num2 = (_freedom - (double)_scale.RowCount) * (_freedom - (double)_scale.RowCount - 1.0) * (_freedom - (double)_scale.RowCount - 1.0) * (_freedom - (double)_scale.RowCount - 3.0);
			return num / num2;
		});

		public InverseWishart(double degreesOfFreedom, Matrix<double> scale)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(degreesOfFreedom, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_freedom = degreesOfFreedom;
			_scale = scale;
			_chol = _scale.Cholesky();
		}

		public InverseWishart(double degreesOfFreedom, Matrix<double> scale, System.Random randomSource)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(degreesOfFreedom, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_freedom = degreesOfFreedom;
			_scale = scale;
			_chol = _scale.Cholesky();
		}

		public override string ToString()
		{
			return $"InverseWishart(ν = {_freedom}, Rows = {_scale.RowCount}, Columns = {_scale.ColumnCount})";
		}

		public static bool IsValidParameterSet(double degreesOfFreedom, Matrix<double> scale)
		{
			if (scale.RowCount != scale.ColumnCount)
			{
				return false;
			}
			for (int i = 0; i < scale.RowCount; i++)
			{
				if (scale.At(i, i) <= 0.0)
				{
					return false;
				}
			}
			return degreesOfFreedom > 0.0;
		}

		public double Density(Matrix<double> x)
		{
			int rowCount = _scale.RowCount;
			if (x.RowCount != rowCount || x.ColumnCount != rowCount)
			{
				throw new ArgumentOutOfRangeException("x", "Matrix dimensions must agree.");
			}
			Cholesky<double> cholesky = x.Cholesky();
			double determinant = cholesky.Determinant;
			Matrix<double> matrix = cholesky.Solve(Scale);
			double num = Math.Pow(Math.PI, (double)rowCount * ((double)rowCount - 1.0) / 4.0);
			for (int i = 1; i <= rowCount; i++)
			{
				num *= SpecialFunctions.Gamma((_freedom + 1.0 - (double)i) / 2.0);
			}
			return Math.Pow(determinant, (0.0 - (_freedom + (double)rowCount + 1.0)) / 2.0) * Math.Exp(-0.5 * matrix.Trace()) * Math.Pow(_chol.Determinant, _freedom / 2.0) / Math.Pow(2.0, _freedom * (double)rowCount / 2.0) / num;
		}

		public Matrix<double> Sample()
		{
			return Sample(_random, _freedom, _scale);
		}

		public static Matrix<double> Sample(System.Random rnd, double degreesOfFreedom, Matrix<double> scale)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(degreesOfFreedom, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Wishart.Sample(rnd, degreesOfFreedom, scale.Inverse()).PseudoInverse();
		}
	}
}
