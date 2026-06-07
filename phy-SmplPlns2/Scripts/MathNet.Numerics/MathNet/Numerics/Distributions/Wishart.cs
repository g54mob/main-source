using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Wishart : IDistribution
	{
		private System.Random _random;

		private readonly double _degreesOfFreedom;

		private readonly Matrix<double> _scale;

		private readonly Cholesky<double> _chol;

		public double DegreesOfFreedom => _degreesOfFreedom;

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

		public Matrix<double> Mean => _degreesOfFreedom * _scale;

		public Matrix<double> Mode => (_degreesOfFreedom - (double)_scale.RowCount - 1.0) * _scale;

		public Matrix<double> Variance => Matrix<double>.Build.Dense(_scale.RowCount, _scale.ColumnCount, (int i, int j) => _degreesOfFreedom * (_scale.At(i, j) * _scale.At(i, j) + _scale.At(i, i) * _scale.At(j, j)));

		public Wishart(double degreesOfFreedom, Matrix<double> scale)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(degreesOfFreedom, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_degreesOfFreedom = degreesOfFreedom;
			_scale = scale;
			_chol = _scale.Cholesky();
		}

		public Wishart(double degreesOfFreedom, Matrix<double> scale, System.Random randomSource)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(degreesOfFreedom, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_degreesOfFreedom = degreesOfFreedom;
			_scale = scale;
			_chol = _scale.Cholesky();
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
			if (degreesOfFreedom <= 0.0 || double.IsNaN(degreesOfFreedom))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return $"Wishart(DegreesOfFreedom = {_degreesOfFreedom}, Rows = {_scale.RowCount}, Columns = {_scale.ColumnCount})";
		}

		public double Density(Matrix<double> x)
		{
			int rowCount = _scale.RowCount;
			if (x.RowCount != rowCount || x.ColumnCount != rowCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentOutOfRangeException>(x, _scale, "x");
			}
			double x2 = x.Determinant();
			Matrix<double> matrix = _chol.Solve(x);
			double num = Math.Pow(Math.PI, (double)rowCount * ((double)rowCount - 1.0) / 4.0);
			for (int i = 1; i <= rowCount; i++)
			{
				num *= SpecialFunctions.Gamma((_degreesOfFreedom + 1.0 - (double)i) / 2.0);
			}
			return Math.Pow(x2, (_degreesOfFreedom - (double)rowCount - 1.0) / 2.0) * Math.Exp(-0.5 * matrix.Trace()) / Math.Pow(2.0, _degreesOfFreedom * (double)rowCount / 2.0) / Math.Pow(_chol.Determinant, _degreesOfFreedom / 2.0) / num;
		}

		public Matrix<double> Sample()
		{
			return DoSample(RandomSource, _degreesOfFreedom, _scale, _chol);
		}

		public static Matrix<double> Sample(System.Random rnd, double degreesOfFreedom, Matrix<double> scale)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(degreesOfFreedom, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return DoSample(rnd, degreesOfFreedom, scale, scale.Cholesky());
		}

		private static Matrix<double> DoSample(System.Random rnd, double degreesOfFreedom, Matrix<double> scale, Cholesky<double> chol)
		{
			int rowCount = scale.RowCount;
			DenseMatrix denseMatrix = new DenseMatrix(rowCount, rowCount);
			for (int i = 0; i < rowCount; i++)
			{
				denseMatrix.At(i, i, Math.Sqrt(Gamma.Sample(rnd, (degreesOfFreedom - (double)i) / 2.0, 0.5)));
			}
			for (int j = 1; j < rowCount; j++)
			{
				for (int k = 0; k < j; k++)
				{
					denseMatrix.At(j, k, Normal.Sample(rnd, 0.0, 1.0));
				}
			}
			Matrix<double> factor = chol.Factor;
			return factor * denseMatrix * denseMatrix.Transpose() * factor.Transpose();
		}
	}
}
