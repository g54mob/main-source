using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Solvers
{
	public sealed class TFQMR : IIterativeSolver<MathNet.Numerics.Complex32>
	{
		private static void CalculateTrueResidual(Matrix<MathNet.Numerics.Complex32> matrix, Vector<MathNet.Numerics.Complex32> residual, Vector<MathNet.Numerics.Complex32> x, Vector<MathNet.Numerics.Complex32> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1, residual);
			residual.Add(b, residual);
		}

		private static bool IsEven(int number)
		{
			return number % 2 == 0;
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
			DenseVector denseVector = new DenseVector(input.Count);
			DenseVector denseVector2 = DenseVector.OfVector(input);
			DenseVector denseVector3 = new DenseVector(input.Count);
			DenseVector denseVector4 = new DenseVector(input.Count);
			DenseVector denseVector5 = new DenseVector(input.Count);
			DenseVector denseVector6 = DenseVector.OfVector(input);
			DenseVector denseVector7 = new DenseVector(input.Count);
			DenseVector denseVector8 = new DenseVector(input.Count);
			DenseVector denseVector9 = DenseVector.OfVector(input);
			DenseVector denseVector10 = new DenseVector(input.Count);
			DenseVector denseVector11 = new DenseVector(input.Count);
			DenseVector denseVector12 = new DenseVector(input.Count);
			MathNet.Numerics.Complex32 complex = 0;
			MathNet.Numerics.Complex32 complex2 = 0;
			float num = 0f;
			float num2 = (float)input.L2Norm();
			MathNet.Numerics.Complex32 complex3 = num2 * num2;
			preconditioner.Approximate(denseVector9, denseVector10);
			matrix.Multiply(denseVector10, denseVector5);
			denseVector5.CopyTo(denseVector4);
			for (int i = 0; iterator.DetermineStatus(i, result, input, denseVector6) == IterationStatus.Continue; i++)
			{
				if (IsEven(i))
				{
					MathNet.Numerics.Complex32 complex4 = denseVector2.ConjugateDotProduct(denseVector5);
					if (complex4.Real.AlmostEqualNumbersBetween(0f, 1) && complex4.Imaginary.AlmostEqualNumbersBetween(0f, 1))
					{
						iterator.Cancel();
						break;
					}
					complex = complex3 / complex4;
					denseVector5.Multiply(-complex, denseVector11);
					denseVector9.Add(denseVector11, denseVector8);
					preconditioner.Approximate(denseVector8, denseVector10);
					matrix.Multiply(denseVector10, denseVector3);
				}
				DenseVector obj = (IsEven(i) ? denseVector4 : denseVector3);
				DenseVector denseVector13 = (IsEven(i) ? denseVector9 : denseVector8);
				obj.Multiply(-complex, denseVector11);
				denseVector6.Add(denseVector11, denseVector12);
				denseVector12.CopyTo(denseVector6);
				denseVector.Multiply(num * num * complex2 / complex, denseVector10);
				denseVector13.Add(denseVector10, denseVector);
				num = (float)denseVector6.L2Norm() / num2;
				float num3 = 1f / (float)Math.Sqrt(1f + num * num);
				num2 *= num * num3;
				complex2 = num3 * num3 * complex;
				denseVector.Multiply(complex2, denseVector11);
				denseVector7.Add(denseVector11, denseVector12);
				denseVector12.CopyTo(denseVector7);
				if (iterator.DetermineStatus(i, result, input, denseVector6) != IterationStatus.Continue)
				{
					preconditioner.Approximate(denseVector7, result);
					CalculateTrueResidual(matrix, denseVector10, result, input);
					if (iterator.DetermineStatus(i, result, input, denseVector10) != IterationStatus.Continue)
					{
						break;
					}
				}
				if (!IsEven(i))
				{
					if (complex3.Real.AlmostEqualNumbersBetween(0f, 1) && complex3.Imaginary.AlmostEqualNumbersBetween(0f, 1))
					{
						iterator.Cancel();
						break;
					}
					MathNet.Numerics.Complex32 complex5 = denseVector2.ConjugateDotProduct(denseVector6);
					MathNet.Numerics.Complex32 scalar = complex5 / complex3;
					complex3 = complex5;
					denseVector8.Multiply(scalar, denseVector11);
					denseVector6.Add(denseVector11, denseVector9);
					preconditioner.Approximate(denseVector9, denseVector10);
					matrix.Multiply(denseVector10, denseVector4);
					denseVector5.Multiply(scalar, denseVector11);
					denseVector3.Add(denseVector11, denseVector10);
					denseVector10.Multiply(scalar, denseVector11);
					denseVector4.Add(denseVector11, denseVector5);
				}
				preconditioner.Approximate(denseVector7, result);
			}
		}
	}
}
