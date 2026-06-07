using System;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal sealed class UserGramSchmidt : GramSchmidt
	{
		public static UserGramSchmidt Create(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			Matrix<MathNet.Numerics.Complex32> matrix2 = matrix.Clone();
			Matrix<MathNet.Numerics.Complex32> matrix3 = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(matrix, matrix.ColumnCount, matrix.ColumnCount, fullyMutable: true);
			for (int i = 0; i < matrix2.ColumnCount; i++)
			{
				float num = (float)matrix2.Column(i).L2Norm();
				if (num == 0f)
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
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int l = 0; l < matrix2.RowCount; l++)
					{
						zero += matrix2.Column(i)[l].Conjugate() * matrix2.Column(k)[l];
					}
					matrix3.At(i, k, zero);
					for (int m = 0; m < matrix2.RowCount; m++)
					{
						MathNet.Numerics.Complex32 value = matrix2.At(m, k) - matrix2.At(m, i) * zero;
						matrix2.At(m, k, value);
					}
				}
			}
			return new UserGramSchmidt(matrix2, matrix3);
		}

		private UserGramSchmidt(Matrix<MathNet.Numerics.Complex32> q, Matrix<MathNet.Numerics.Complex32> rFull)
			: base(q, rFull)
		{
		}

		public override void Solve(Matrix<MathNet.Numerics.Complex32> input, Matrix<MathNet.Numerics.Complex32> result)
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
			Matrix<MathNet.Numerics.Complex32> matrix = input.Clone();
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[base.Q.RowCount];
			for (int i = 0; i < input.ColumnCount; i++)
			{
				for (int j = 0; j < base.Q.RowCount; j++)
				{
					array[j] = matrix.At(j, i);
				}
				for (int k = 0; k < base.Q.ColumnCount; k++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int l = 0; l < base.Q.RowCount; l++)
					{
						zero += base.Q.At(l, k).Conjugate() * array[l];
					}
					matrix.At(k, i, zero);
				}
			}
			for (int num = base.Q.ColumnCount - 1; num >= 0; num--)
			{
				for (int m = 0; m < input.ColumnCount; m++)
				{
					matrix.At(num, m, matrix.At(num, m) / FullR.At(num, num));
				}
				for (int n = 0; n < num; n++)
				{
					for (int num2 = 0; num2 < input.ColumnCount; num2++)
					{
						matrix.At(n, num2, matrix.At(n, num2) - matrix.At(num, num2) * FullR.At(n, num));
					}
				}
			}
			for (int num3 = 0; num3 < FullR.ColumnCount; num3++)
			{
				for (int num4 = 0; num4 < input.ColumnCount; num4++)
				{
					result.At(num3, num4, matrix.At(num3, num4));
				}
			}
		}

		public override void Solve(Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result)
		{
			if (base.Q.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.Q.ColumnCount != result.Count)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(base.Q, result);
			}
			Vector<MathNet.Numerics.Complex32> vector = input.Clone();
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[base.Q.RowCount];
			for (int i = 0; i < base.Q.RowCount; i++)
			{
				array[i] = vector[i];
			}
			for (int j = 0; j < base.Q.ColumnCount; j++)
			{
				MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
				for (int k = 0; k < base.Q.RowCount; k++)
				{
					zero += base.Q.At(k, j).Conjugate() * array[k];
				}
				vector[j] = zero;
			}
			for (int num = base.Q.ColumnCount - 1; num >= 0; num--)
			{
				vector[num] /= FullR.At(num, num);
				for (int l = 0; l < num; l++)
				{
					vector[l] -= vector[num] * FullR.At(l, num);
				}
			}
			for (int m = 0; m < FullR.ColumnCount; m++)
			{
				result[m] = vector[m];
			}
		}
	}
}
