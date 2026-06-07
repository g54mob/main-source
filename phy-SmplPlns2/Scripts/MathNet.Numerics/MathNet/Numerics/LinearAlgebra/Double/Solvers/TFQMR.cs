using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Double.Solvers
{
	public sealed class TFQMR : IIterativeSolver<double>
	{
		private static void CalculateTrueResidual(Matrix<double> matrix, Vector<double> residual, Vector<double> x, Vector<double> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1.0, residual);
			residual.Add(b, residual);
		}

		private static bool IsEven(int number)
		{
			return number % 2 == 0;
		}

		public void Solve(Matrix<double> matrix, Vector<double> input, Vector<double> result, Iterator<double> iterator, IPreconditioner<double> preconditioner)
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(input, matrix);
			}
			if (iterator == null)
			{
				iterator = new Iterator<double>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<double>();
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
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = input.L2Norm();
			double num5 = num4 * num4;
			preconditioner.Approximate(denseVector8, denseVector9);
			matrix.Multiply(denseVector9, denseVector4);
			denseVector4.CopyTo(denseVector3);
			for (int i = 0; iterator.DetermineStatus(i, result, input, denseVector5) == IterationStatus.Continue; i++)
			{
				if (IsEven(i))
				{
					double num6 = denseVector4.DotProduct(other);
					if (num6.AlmostEqualNumbersBetween(0.0, 1L))
					{
						iterator.Cancel();
						break;
					}
					num = num5 / num6;
					denseVector4.Multiply(0.0 - num, denseVector10);
					denseVector8.Add(denseVector10, denseVector7);
					preconditioner.Approximate(denseVector7, denseVector9);
					matrix.Multiply(denseVector9, denseVector2);
				}
				DenseVector obj = (IsEven(i) ? denseVector3 : denseVector2);
				DenseVector denseVector12 = (IsEven(i) ? denseVector8 : denseVector7);
				obj.Multiply(0.0 - num, denseVector10);
				denseVector5.Add(denseVector10, denseVector11);
				denseVector11.CopyTo(denseVector5);
				denseVector.Multiply(num3 * num3 * num2 / num, denseVector9);
				denseVector12.Add(denseVector9, denseVector);
				num3 = denseVector5.L2Norm() / num4;
				double num7 = 1.0 / Math.Sqrt(1.0 + num3 * num3);
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
					if (num5.AlmostEqualNumbersBetween(0.0, 1L))
					{
						iterator.Cancel();
						break;
					}
					double num8 = denseVector5.DotProduct(other);
					double scalar = num8 / num5;
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
