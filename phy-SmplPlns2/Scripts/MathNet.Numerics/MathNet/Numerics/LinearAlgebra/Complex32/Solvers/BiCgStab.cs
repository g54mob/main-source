using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Solvers
{
	public sealed class BiCgStab : IIterativeSolver<MathNet.Numerics.Complex32>
	{
		private static void CalculateTrueResidual(Matrix<MathNet.Numerics.Complex32> matrix, Vector<MathNet.Numerics.Complex32> residual, Vector<MathNet.Numerics.Complex32> x, Vector<MathNet.Numerics.Complex32> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1, residual);
			residual.Add(b, residual);
		}

		public void Solve(Matrix<MathNet.Numerics.Complex32> matrix, Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result, Iterator<MathNet.Numerics.Complex32> iterator, IPreconditioner<MathNet.Numerics.Complex32> preconditioner)
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
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(input, matrix);
			}
			if (iterator == null)
			{
				iterator = new Iterator<MathNet.Numerics.Complex32>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<MathNet.Numerics.Complex32>();
			}
			preconditioner.Initialize(matrix);
			DenseVector denseVector = new DenseVector(matrix.RowCount);
			CalculateTrueResidual(matrix, denseVector, result, input);
			Vector<MathNet.Numerics.Complex32> vector = denseVector.Clone();
			DenseVector denseVector2 = new DenseVector(denseVector.Count);
			DenseVector denseVector3 = new DenseVector(denseVector.Count);
			DenseVector denseVector4 = new DenseVector(denseVector.Count);
			DenseVector denseVector5 = new DenseVector(denseVector.Count);
			DenseVector denseVector6 = new DenseVector(denseVector.Count);
			DenseVector denseVector7 = new DenseVector(denseVector.Count);
			DenseVector denseVector8 = new DenseVector(denseVector.Count);
			MathNet.Numerics.Complex32 complex = 0;
			MathNet.Numerics.Complex32 complex2 = 0;
			MathNet.Numerics.Complex32 complex3 = 0;
			int num = 0;
			while (iterator.DetermineStatus(num, result, input, denseVector) == IterationStatus.Continue)
			{
				MathNet.Numerics.Complex32 complex4 = complex;
				complex = vector.ConjugateDotProduct(denseVector);
				if (complex.Real.AlmostEqualNumbersBetween(0f, 1) && complex.Imaginary.AlmostEqualNumbersBetween(0f, 1))
				{
					throw new NumericalBreakdownException();
				}
				if (num != 0)
				{
					MathNet.Numerics.Complex32 scalar = complex / complex4 * (complex2 / complex3);
					denseVector4.Multiply(-complex3, denseVector7);
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
				complex2 = complex * 1f / vector.ConjugateDotProduct(denseVector4);
				denseVector4.Multiply(-complex2, denseVector7);
				denseVector.Add(denseVector7, denseVector5);
				denseVector3.Multiply(complex2, denseVector7);
				denseVector7.Add(denseVector6, denseVector8);
				denseVector8.CopyTo(denseVector7);
				denseVector7.Add(result, denseVector8);
				denseVector8.CopyTo(denseVector7);
				if (iterator.DetermineStatus(num, denseVector7, input, denseVector5) != IterationStatus.Continue)
				{
					denseVector7.CopyTo(result);
					CalculateTrueResidual(matrix, denseVector, result, input);
					if (iterator.DetermineStatus(num, result, input, denseVector) != IterationStatus.Continue)
					{
						break;
					}
					num++;
					continue;
				}
				preconditioner.Approximate(denseVector5, denseVector6);
				matrix.Multiply(denseVector6, denseVector7);
				complex3 = denseVector7.ConjugateDotProduct(denseVector5) / denseVector7.ConjugateDotProduct(denseVector7);
				denseVector7.Multiply(-complex3, denseVector);
				denseVector.Add(denseVector5, denseVector8);
				denseVector8.CopyTo(denseVector);
				denseVector6.Multiply(complex3, denseVector7);
				result.Add(denseVector7, denseVector8);
				denseVector8.CopyTo(result);
				denseVector3.Multiply(complex2, denseVector7);
				result.Add(denseVector7, denseVector8);
				denseVector8.CopyTo(result);
				if (complex3.Real.AlmostEqualNumbersBetween(0f, 1) && complex3.Imaginary.AlmostEqualNumbersBetween(0f, 1))
				{
					throw new NumericalBreakdownException();
				}
				if (iterator.DetermineStatus(num, result, input, denseVector) != IterationStatus.Continue)
				{
					CalculateTrueResidual(matrix, denseVector, result, input);
				}
				num++;
			}
		}
	}
}
