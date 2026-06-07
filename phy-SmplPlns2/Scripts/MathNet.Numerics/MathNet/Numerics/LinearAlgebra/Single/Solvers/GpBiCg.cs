using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Single.Solvers
{
	public sealed class GpBiCg : IIterativeSolver<float>
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

		private static void CalculateTrueResidual(Matrix<float> matrix, Vector<float> residual, Vector<float> x, Vector<float> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1f, residual);
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
			DenseVector denseVector2 = new DenseVector(matrix.RowCount);
			CalculateTrueResidual(matrix, denseVector2, denseVector, input);
			float scalar = 0f;
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
				float num = denseVector3.DotProduct(denseVector2) / denseVector3.DotProduct(denseVector9);
				denseVector9.Subtract(denseVector6, denseVector13);
				denseVector4.Subtract(denseVector2, denseVector11);
				denseVector13.Multiply(num, denseVector14);
				denseVector11.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector11);
				denseVector4.CopyTo(denseVector5);
				denseVector9.Multiply(0f - num, denseVector14);
				denseVector2.Add(denseVector14, denseVector4);
				preconditioner.Approximate(denseVector4, denseVector13);
				matrix.Multiply(denseVector13, denseVector7);
				float num2 = denseVector7.DotProduct(denseVector7);
				if (num2.AlmostEqualNumbersBetween(0f, 1))
				{
					num2 = 1f;
				}
				float num3 = denseVector7.DotProduct(denseVector4);
				float num4;
				float num5;
				if ((_numberOfBiCgStabSteps == 0 && i == 0) || ShouldRunBiCgStabSteps(i))
				{
					num4 = num3 / num2;
					num5 = 0f;
				}
				else
				{
					float num6 = denseVector11.DotProduct(denseVector11);
					if (num6.AlmostEqualNumbersBetween(0f, 1))
					{
						num6 = 1f;
					}
					float num7 = denseVector11.DotProduct(denseVector4);
					float num8 = denseVector7.DotProduct(denseVector11);
					float num9 = num2 * num6 - num8 * num8;
					num4 = (num6 * num3 - num7 * num8) / num9;
					num5 = (num2 * num7 - num8 * num3) / num9;
				}
				denseVector10.Multiply(scalar, denseVector14);
				denseVector5.Add(denseVector14, denseVector13);
				denseVector13.Subtract(denseVector2, denseVector15);
				denseVector15.CopyTo(denseVector13);
				denseVector13.Multiply(num5, denseVector13);
				denseVector9.Multiply(num4, denseVector14);
				denseVector13.Add(denseVector14, denseVector10);
				denseVector12.Multiply(num5, denseVector12);
				denseVector10.Multiply(0f - num, denseVector14);
				denseVector12.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector12);
				denseVector2.Multiply(num4, denseVector14);
				denseVector12.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector12);
				denseVector8.Multiply(num, denseVector14);
				denseVector.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector);
				denseVector.Add(denseVector12, denseVector15);
				denseVector15.CopyTo(denseVector);
				denseVector2.CopyTo(denseVector5);
				denseVector11.Multiply(0f - num5, denseVector14);
				denseVector4.Add(denseVector14, denseVector2);
				denseVector7.Multiply(0f - num4, denseVector14);
				denseVector2.Add(denseVector14, denseVector15);
				denseVector15.CopyTo(denseVector2);
				scalar = ((!num4.AlmostEqualNumbersBetween(0f, 1)) ? (num / num4 * denseVector3.DotProduct(denseVector2) / denseVector3.DotProduct(denseVector5)) : 0f);
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
