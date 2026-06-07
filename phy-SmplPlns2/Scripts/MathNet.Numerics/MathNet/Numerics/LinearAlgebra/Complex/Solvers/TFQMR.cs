using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex.Solvers
{
	public sealed class TFQMR : IIterativeSolver<System.Numerics.Complex>
	{
		private static void CalculateTrueResidual(Matrix<System.Numerics.Complex> matrix, Vector<System.Numerics.Complex> residual, Vector<System.Numerics.Complex> x, Vector<System.Numerics.Complex> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1, residual);
			residual.Add(b, residual);
		}

		private static bool IsEven(int number)
		{
			return number % 2 == 0;
		}

		public void Solve(Matrix<System.Numerics.Complex> matrix, Vector<System.Numerics.Complex> input, Vector<System.Numerics.Complex> result, Iterator<System.Numerics.Complex> iterator, IPreconditioner<System.Numerics.Complex> preconditioner)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			if (input.Count != matrix.RowCount || result.Count != input.Count)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(matrix, input, result);
			}
			if (iterator == null)
			{
				iterator = new Iterator<System.Numerics.Complex>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<System.Numerics.Complex>();
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
			System.Numerics.Complex complex = 0;
			System.Numerics.Complex complex2 = 0;
			double num = 0.0;
			double num2 = input.L2Norm();
			System.Numerics.Complex complex3 = num2 * num2;
			preconditioner.Approximate(denseVector9, denseVector10);
			matrix.Multiply(denseVector10, denseVector5);
			denseVector5.CopyTo(denseVector4);
			for (int i = 0; iterator.DetermineStatus(i, result, input, denseVector6) == IterationStatus.Continue; i++)
			{
				if (IsEven(i))
				{
					System.Numerics.Complex complex4 = denseVector2.ConjugateDotProduct(denseVector5);
					if (complex4.Real.AlmostEqualNumbersBetween(0.0, 1L) && complex4.Imaginary.AlmostEqualNumbersBetween(0.0, 1L))
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
				num = denseVector6.L2Norm() / num2;
				double num3 = 1.0 / Math.Sqrt(1.0 + num * num);
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
					if (complex3.Real.AlmostEqualNumbersBetween(0.0, 1L) && complex3.Imaginary.AlmostEqualNumbersBetween(0.0, 1L))
					{
						iterator.Cancel();
						break;
					}
					System.Numerics.Complex complex5 = denseVector2.ConjugateDotProduct(denseVector6);
					System.Numerics.Complex scalar = complex5 / complex3;
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
