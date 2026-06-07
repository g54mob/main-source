using System;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal sealed class UserGramSchmidt : GramSchmidt
	{
		public static UserGramSchmidt Create(Matrix<double> matrix)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			Matrix<double> matrix2 = matrix.Clone();
			Matrix<double> matrix3 = Matrix<double>.Build.SameAs(matrix, matrix.ColumnCount, matrix.ColumnCount, fullyMutable: true);
			for (int i = 0; i < matrix2.ColumnCount; i++)
			{
				double num = matrix2.Column(i).L2Norm();
				if (num == 0.0)
				{
					throw new ArgumentException("Matrix must not be rank deficient.");
				}
				matrix3.At(i, i, num);
				for (int j = 0; j < matrix2.RowCount; j++)
				{
					matrix2.At(j, i, matrix2.At(j, i) / num);
				}
				for (int k = i + 1; k < matrix2.ColumnCount; k++)
				{
					double num2 = matrix2.Column(i).DotProduct(matrix2.Column(k));
					matrix3.At(i, k, num2);
					for (int l = 0; l < matrix2.RowCount; l++)
					{
						double value = matrix2.At(l, k) - matrix2.At(l, i) * num2;
						matrix2.At(l, k, value);
					}
				}
			}
			return new UserGramSchmidt(matrix2, matrix3);
		}

		private UserGramSchmidt(Matrix<double> q, Matrix<double> rFull)
			: base(q, rFull)
		{
		}

		public override void Solve(Matrix<double> input, Matrix<double> result)
		{
			if (input.ColumnCount != result.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (base.Q.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (base.Q.ColumnCount != result.RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			Matrix<double> matrix = input.Clone();
			double[] array = new double[base.Q.RowCount];
			for (int i = 0; i < input.ColumnCount; i++)
			{
				for (int j = 0; j < base.Q.RowCount; j++)
				{
					array[j] = matrix.At(j, i);
				}
				for (int k = 0; k < base.Q.ColumnCount; k++)
				{
					double num = 0.0;
					for (int l = 0; l < base.Q.RowCount; l++)
					{
						num += base.Q.At(l, k) * array[l];
					}
					matrix.At(k, i, num);
				}
			}
			for (int num2 = base.Q.ColumnCount - 1; num2 >= 0; num2--)
			{
				for (int m = 0; m < input.ColumnCount; m++)
				{
					matrix.At(num2, m, matrix.At(num2, m) / FullR.At(num2, num2));
				}
				for (int n = 0; n < num2; n++)
				{
					for (int num3 = 0; num3 < input.ColumnCount; num3++)
					{
						matrix.At(n, num3, matrix.At(n, num3) - matrix.At(num2, num3) * FullR.At(n, num2));
					}
				}
			}
			for (int num4 = 0; num4 < FullR.ColumnCount; num4++)
			{
				for (int num5 = 0; num5 < input.ColumnCount; num5++)
				{
					result.At(num4, num5, matrix.At(num4, num5));
				}
			}
		}

		public override void Solve(Vector<double> input, Vector<double> result)
		{
			if (base.Q.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.Q.ColumnCount != result.Count)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(base.Q, result);
			}
			Vector<double> vector = input.Clone();
			double[] array = new double[base.Q.RowCount];
			for (int i = 0; i < base.Q.RowCount; i++)
			{
				array[i] = vector[i];
			}
			for (int j = 0; j < base.Q.ColumnCount; j++)
			{
				double num = 0.0;
				for (int k = 0; k < base.Q.RowCount; k++)
				{
					num += base.Q.At(k, j) * array[k];
				}
				vector[j] = num;
			}
			for (int num2 = base.Q.ColumnCount - 1; num2 >= 0; num2--)
			{
				vector[num2] /= FullR.At(num2, num2);
				for (int l = 0; l < num2; l++)
				{
					vector[l] -= vector[num2] * FullR.At(l, num2);
				}
			}
			for (int m = 0; m < FullR.ColumnCount; m++)
			{
				result[m] = vector[m];
			}
		}
	}
}
