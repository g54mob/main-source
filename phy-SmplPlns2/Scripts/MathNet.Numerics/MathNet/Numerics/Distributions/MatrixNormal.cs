using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class MatrixNormal : IDistribution
	{
		private System.Random _random;

		private readonly Matrix<double> _m;

		private readonly Matrix<double> _v;

		private readonly Matrix<double> _k;

		public Matrix<double> Mean => _m;

		public Matrix<double> RowCovariance => _v;

		public Matrix<double> ColumnCovariance => _k;

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

		public MatrixNormal(Matrix<double> m, Matrix<double> v, Matrix<double> k)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(m, v, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_m = m;
			_v = v;
			_k = k;
		}

		public MatrixNormal(Matrix<double> m, Matrix<double> v, Matrix<double> k, System.Random randomSource)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(m, v, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_m = m;
			_v = v;
			_k = k;
		}

		public override string ToString()
		{
			return $"MatrixNormal(Rows = {_m.RowCount}, Columns = {_m.ColumnCount})";
		}

		public static bool IsValidParameterSet(Matrix<double> m, Matrix<double> v, Matrix<double> k)
		{
			int rowCount = m.RowCount;
			int columnCount = m.ColumnCount;
			if (v.ColumnCount != rowCount || v.RowCount != rowCount)
			{
				return false;
			}
			if (k.ColumnCount != columnCount || k.RowCount != columnCount)
			{
				return false;
			}
			for (int i = 0; i < v.RowCount; i++)
			{
				if (v.At(i, i) <= 0.0)
				{
					return false;
				}
			}
			for (int j = 0; j < k.RowCount; j++)
			{
				if (k.At(j, j) <= 0.0)
				{
					return false;
				}
			}
			return true;
		}

		public double Density(Matrix<double> x)
		{
			if (x.RowCount != _m.RowCount || x.ColumnCount != _m.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentOutOfRangeException>(x, _m, "x");
			}
			Matrix<double> matrix = x - _m;
			Cholesky<double> cholesky = _v.Cholesky();
			Cholesky<double> cholesky2 = _k.Cholesky();
			return Math.Exp(-0.5 * cholesky2.Solve(matrix.Transpose() * cholesky.Solve(matrix)).Trace()) / Math.Pow(Math.PI * 2.0, (double)(x.RowCount * x.ColumnCount) / 2.0) / Math.Pow(cholesky2.Determinant, (double)x.RowCount / 2.0) / Math.Pow(cholesky.Determinant, (double)x.ColumnCount / 2.0);
		}

		public Matrix<double> Sample()
		{
			return Sample(_random, _m, _v, _k);
		}

		public static Matrix<double> Sample(System.Random rnd, Matrix<double> m, Matrix<double> v, Matrix<double> k)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(m, v, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			int rowCount = m.RowCount;
			int columnCount = m.ColumnCount;
			Matrix<double> covariance = v.KroneckerProduct(k.Inverse());
			Vector<double> vector = SampleVectorNormal(rnd, new DenseVector(rowCount * columnCount), covariance);
			Matrix<double> matrix = m.Clone();
			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < columnCount; j++)
				{
					matrix.At(i, j, matrix.At(i, j) + vector[j * rowCount + i]);
				}
			}
			return matrix;
		}

		private static Vector<double> SampleVectorNormal(System.Random rnd, Vector<double> mean, Matrix<double> covariance)
		{
			Cholesky<double> cholesky = covariance.Cholesky();
			Vector<double> vector = Vector<double>.Build.Random(mean.Count, new Normal(rnd));
			return mean + cholesky.Factor * vector;
		}
	}
}
