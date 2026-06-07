using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Double.Solvers
{
	public sealed class BiCgStab : IIterativeSolver<double>
	{
		private static void CalculateTrueResidual(Matrix<double> matrix, Vector<double> residual, Vector<double> x, Vector<double> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1.0, residual);
			residual.Add(b, residual);
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
			DenseVector denseVector = new DenseVector(matrix.RowCount);
			CalculateTrueResidual(matrix, denseVector, result, input);
			Vector<double> vector = denseVector.Clone();
			DenseVector denseVector2 = new DenseVector(denseVector.Count);
			DenseVector denseVector3 = new DenseVector(denseVector.Count);
			DenseVector denseVector4 = new DenseVector(denseVector.Count);
			DenseVector denseVector5 = new DenseVector(denseVector.Count);
			DenseVector denseVector6 = new DenseVector(denseVector.Count);
			DenseVector denseVector7 = new DenseVector(denseVector.Count);
			DenseVector denseVector8 = new DenseVector(denseVector.Count);
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = 0;
			while (iterator.DetermineStatus(num4, result, input, denseVector) == IterationStatus.Continue)
			{
				double num5 = num;
				num = vector.DotProduct(denseVector);
				if (num.AlmostEqualNumbersBetween(0.0, 1L))
				{
					throw new NumericalBreakdownException();
				}
				if (num4 != 0)
				{
					double scalar = num / num5 * (num2 / num3);
					denseVector4.Multiply(0.0 - num3, denseVector7);
					denseVector2.Add(denseVector7, denseVector8);
					denseVector8.CopyTo(denseVector2);
					denseVector2.Multiply(scalar, denseVector2);
					denseVector2.Add(denseVector, denseVector8);
					denseVector8.CopyTo(denseVector2);
				}
				else
				{
					denseVector.CopyTo(denseVector2);
				}
				preconditioner.Approximate(denseVector2, denseVector3);
				matrix.Multiply(denseVector3, denseVector4);
				num2 = num * 1.0 / vector.DotProduct(denseVector4);
				denseVector4.Multiply(0.0 - num2, denseVector7);
				denseVector.Add(denseVector7, denseVector5);
				denseVector3.Multiply(num2, denseVector7);
				denseVector7.Add(denseVector6, denseVector8);
				denseVector8.CopyTo(denseVector7);
				denseVector7.Add(result, denseVector8);
				denseVector8.CopyTo(denseVector7);
				if (iterator.DetermineStatus(num4, denseVector7, input, denseVector5) != IterationStatus.Continue)
				{
					denseVector7.CopyTo(result);
					CalculateTrueResidual(matrix, denseVector, result, input);
					if (iterator.DetermineStatus(num4, result, input, denseVector) != IterationStatus.Continue)
					{
						break;
					}
					num4++;
					continue;
				}
				preconditioner.Approximate(denseVector5, denseVector6);
				matrix.Multiply(denseVector6, denseVector7);
				num3 = denseVector7.DotProduct(denseVector5) / denseVector7.DotProduct(denseVector7);
				denseVector7.Multiply(0.0 - num3, denseVector);
				denseVector.Add(denseVector5, denseVector8);
				denseVector8.CopyTo(denseVector);
				denseVector6.Multiply(num3, denseVector7);
				result.Add(denseVector7, denseVector8);
				denseVector8.CopyTo(result);
				denseVector3.Multiply(num2, denseVector7);
				result.Add(denseVector7, denseVector8);
				denseVector8.CopyTo(result);
				if (num3.AlmostEqualNumbersBetween(0.0, 1L))
				{
					throw new NumericalBreakdownException();
				}
				if (iterator.DetermineStatus(num4, result, input, denseVector) != IterationStatus.Continue)
				{
					CalculateTrueResidual(matrix, denseVector, result, input);
				}
				num4++;
			}
		}
	}
}
