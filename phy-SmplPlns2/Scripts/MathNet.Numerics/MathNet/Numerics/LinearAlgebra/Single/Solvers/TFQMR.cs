using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Single.Solvers
{
	public sealed class TFQMR : IIterativeSolver<float>
	{
		private static void CalculateTrueResidual(Matrix<float> matrix, Vector<float> residual, Vector<float> x, Vector<float> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1f, residual);
			residual.Add(b, residual);
		}

		private static bool IsEven(int number)
		{
			return number % 2 == 0;
		}

		public void Solve(Matrix<float> matrix, Vector<float> input, Vector<float> result, Iterator<float> iterator, IPreconditioner<float> preconditioner)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			if (result.Count != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (input.Count != matrix.RowCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(input, matrix);
			}
			if (iterator == null)
			{
				iterator = new Iterator<float>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<float>();
			}
			preconditioner.Initialize(matrix);
			DenseVector denseVector = new DenseVector(input.Count);
			DenseVector other = DenseVector.OfVector(input);
			DenseVector denseVector2 = new DenseVector(input.Count);
			DenseVector denseVector3 = new DenseVector(input.Count);
			DenseVector denseVector4 = new DenseVector(input.Count);
			DenseVector denseVector5 = DenseVector.OfVector(input);
			DenseVector denseVector6 = new DenseVector(input.Count);
			DenseVector denseVector7 = new DenseVector(input.Count);
			DenseVector denseVector8 = DenseVector.OfVector(input);
			DenseVector denseVector9 = new DenseVector(input.Count);
			DenseVector denseVector10 = new DenseVector(input.Count);
			DenseVector denseVector11 = new DenseVector(input.Count);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = (float)input.L2Norm();
			float num5 = num4 * num4;
			preconditioner.Approximate(denseVector8, denseVector9);
			matrix.Multiply(denseVector9, denseVector4);
			denseVector4.CopyTo(denseVector3);
			for (int i = 0; iterator.DetermineStatus(i, result, input, denseVector5) == IterationStatus.Continue; i++)
			{
				if (IsEven(i))
				{
					float num6 = denseVector4.DotProduct(other);
					if (num6.AlmostEqualNumbersBetween(0f, 1))
					{
						iterator.Cancel();
						break;
					}
					num = num5 / num6;
					denseVector4.Multiply(0f - num, denseVector10);
					denseVector8.Add(denseVector10, denseVector7);
					preconditioner.Approximate(denseVector7, denseVector9);
					matrix.Multiply(denseVector9, denseVector2);
				}
				DenseVector obj = (IsEven(i) ? denseVector3 : denseVector2);
				DenseVector denseVector12 = (IsEven(i) ? denseVector8 : denseVector7);
				obj.Multiply(0f - num, denseVector10);
				denseVector5.Add(denseVector10, denseVector11);
				denseVector11.CopyTo(denseVector5);
				denseVector.Multiply(num3 * num3 * num2 / num, denseVector9);
				denseVector12.Add(denseVector9, denseVector);
				num3 = (float)denseVector5.L2Norm() / num4;
				float num7 = 1f / (float)Math.Sqrt(1f + num3 * num3);
				num4 *= num3 * num7;
				num2 = num7 * num7 * num;
				denseVector.Multiply(num2, denseVector10);
				denseVector6.Add(denseVector10, denseVector11);
				denseVector11.CopyTo(denseVector6);
				if (iterator.DetermineStatus(i, result, input, denseVector5) != IterationStatus.Continue)
				{
					preconditioner.Approximate(denseVector6, result);
					CalculateTrueResidual(matrix, denseVector9, result, input);
					if (iterator.DetermineStatus(i, result, input, denseVector9) != IterationStatus.Continue)
					{
						break;
					}
				}
				if (!IsEven(i))
				{
					if (num5.AlmostEqualNumbersBetween(0f, 1))
					{
						iterator.Cancel();
						break;
					}
					float num8 = denseVector5.DotProduct(other);
					float scalar = num8 / num5;
					num5 = num8;
					denseVector7.Multiply(scalar, denseVector10);
					denseVector5.Add(denseVector10, denseVector8);
					preconditioner.Approximate(denseVector8, denseVector9);
					matrix.Multiply(denseVector9, denseVector3);
					denseVector4.Multiply(scalar, denseVector10);
					denseVector2.Add(denseVector10, denseVector9);
					denseVector9.Multiply(scalar, denseVector10);
					denseVector3.Add(denseVector10, denseVector4);
				}
				preconditioner.Approximate(denseVector6, result);
			}
		}
	}
}
