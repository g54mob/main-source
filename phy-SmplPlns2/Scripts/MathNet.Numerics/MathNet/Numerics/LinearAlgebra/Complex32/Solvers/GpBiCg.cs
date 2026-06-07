using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Solvers
{
	public sealed class GpBiCg : IIterativeSolver<MathNet.Numerics.Complex32>
	{
		private int _numberOfBiCgStabSteps = 1;

		private int _numberOfGpbiCgSteps = 4;

		public int NumberOfBiCgStabSteps
		{
			get
			{
				return _numberOfBiCgStabSteps;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_numberOfBiCgStabSteps = value;
			}
		}

		public int NumberOfGpBiCgSteps
		{
			get
			{
				return _numberOfGpbiCgSteps;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_numberOfGpbiCgSteps = value;
			}
		}

		private static void CalculateTrueResidual(Matrix<MathNet.Numerics.Complex32> matrix, Vector<MathNet.Numerics.Complex32> residual, Vector<MathNet.Numerics.Complex32> x, Vector<MathNet.Numerics.Complex32> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1, residual);
			residual.Add(b, residual);
		}

		private bool ShouldRunBiCgStabSteps(int iterationNumber)
		{
			int num = iterationNumber % (_numberOfBiCgStabSteps + _numberOfGpbiCgSteps);
			if (num >= 0)
			{
				return num < _numberOfBiCgStabSteps;
			}
			return false;
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
			DenseVector denseVector2 = new DenseVector(matrix.RowCount);
			CalculateTrueResidual(matrix, denseVector2, denseVector, input);
			MathNet.Numerics.Complex32 scalar = 0;
			DenseVector denseVector3 = DenseVector.OfVector(denseVector2);
			DenseVector denseVector4 = new DenseVector(denseVector2.Count);
			DenseVector denseVector5 = new DenseVector(denseVector2.Count);
			DenseVector denseVector6 = new DenseVector(denseVector2.Count);
			DenseVector denseVector7 = new DenseVector(denseVector2.Count);
			DenseVector denseVector8 = new DenseVector(denseVector2.Count);
			DenseVector denseVector9 = new DenseVector(denseVector2.Count);
			DenseVector denseVector10 = new DenseVector(denseVector2.Count);
			DenseVector denseVector11 = new DenseVector(denseVector2.Count);
			DenseVector denseVector12 = new DenseVector(denseVector2.Count);
			DenseVector denseVector13 = new DenseVector(denseVector2.Count);
			DenseVector denseVector14 = new DenseVector(denseVector2.Count);
			DenseVector denseVector15 = new DenseVector(denseVector2.Count);
			for (int i = 0; iterator.DetermineStatus(i, denseVector, input, denseVector2) == IterationStatus.Continue; i++)
			{
				denseVector8.Subtract(denseVector10, denseVector13);
				denseVector13.Multiply(scalar, denseVector14);
				denseVector2.Add(denseVector14, denseVector8);
				preconditioner.Approximate(denseVector8, denseVector13);
				matrix.Multiply(denseVector13, denseVector9);
				MathNet.Numerics.Complex32 complex = denseVector3.ConjugateDotProduct(denseVector2) / denseVector3.ConjugateDotProduct(denseVector9);
				denseVector9.Subtract(denseVector6, denseVector13);
				denseVector4.Subtract(denseVector2, denseVector11);
				denseVector13.Multiply(complex, denseVector14);
				denseVector11.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector11);
				denseVector4.CopyTo(denseVector5);
				denseVector9.Multiply(-complex, denseVector14);
				denseVector2.Add(denseVector14, denseVector4);
				preconditioner.Approximate(denseVector4, denseVector13);
				matrix.Multiply(denseVector13, denseVector7);
				MathNet.Numerics.Complex32 complex2 = denseVector7.ConjugateDotProduct(denseVector7);
				if (complex2.Real.AlmostEqualNumbersBetween(0f, 1) && complex2.Imaginary.AlmostEqualNumbersBetween(0f, 1))
				{
					complex2 = 1f;
				}
				MathNet.Numerics.Complex32 complex3 = denseVector7.ConjugateDotProduct(denseVector4);
				MathNet.Numerics.Complex32 complex4;
				MathNet.Numerics.Complex32 complex5;
				if ((_numberOfBiCgStabSteps == 0 && i == 0) || ShouldRunBiCgStabSteps(i))
				{
					complex4 = complex3 / complex2;
					complex5 = 0;
				}
				else
				{
					MathNet.Numerics.Complex32 complex6 = denseVector11.ConjugateDotProduct(denseVector11);
					if (complex6.Real.AlmostEqualNumbersBetween(0f, 1) && complex6.Imaginary.AlmostEqualNumbersBetween(0f, 1))
					{
						complex6 = 1f;
					}
					MathNet.Numerics.Complex32 complex7 = denseVector11.ConjugateDotProduct(denseVector4);
					MathNet.Numerics.Complex32 complex8 = denseVector7.ConjugateDotProduct(denseVector11);
					MathNet.Numerics.Complex32 complex9 = complex2 * complex6 - complex8 * complex8;
					complex4 = (complex6 * complex3 - complex7 * complex8) / complex9;
					complex5 = (complex2 * complex7 - complex8 * complex3) / complex9;
				}
				denseVector10.Multiply(scalar, denseVector14);
				denseVector5.Add(denseVector14, denseVector13);
				denseVector13.Subtract(denseVector2, denseVector15);
				denseVector15.CopyTo(denseVector13);
				denseVector13.Multiply(complex5, denseVector13);
				denseVector9.Multiply(complex4, denseVector14);
				denseVector13.Add(denseVector14, denseVector10);
				denseVector12.Multiply(complex5, denseVector12);
				denseVector10.Multiply(-complex, denseVector14);
				denseVector12.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector12);
				denseVector2.Multiply(complex4, denseVector14);
				denseVector12.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector12);
				denseVector8.Multiply(complex, denseVector14);
				denseVector.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector);
				denseVector.Add(denseVector12, denseVector15);
				denseVector15.CopyTo(denseVector);
				denseVector2.CopyTo(denseVector5);
				denseVector11.Multiply(-complex5, denseVector14);
				denseVector4.Add(denseVector14, denseVector2);
				denseVector7.Multiply(-complex4, denseVector14);
				denseVector2.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector2);
				scalar = ((!complex4.Real.AlmostEqualNumbersBetween(0f, 1) || !complex4.Imaginary.AlmostEqualNumbersBetween(0f, 1)) ? (complex / complex4 * denseVector3.ConjugateDotProduct(denseVector2) / denseVector3.ConjugateDotProduct(denseVector5)) : ((MathNet.Numerics.Complex32)0));
				denseVector9.Multiply(scalar, denseVector14);
				denseVector7.Add(denseVector14, denseVector6);
				preconditioner.Approximate(denseVector, result);
				if (iterator.DetermineStatus(i, result, input, denseVector2) != IterationStatus.Continue)
				{
					CalculateTrueResidual(matrix, denseVector2, result, input);
				}
			}
		}
	}
}
