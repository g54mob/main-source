using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Complex32
{
	internal class MatrixBuilder : MatrixBuilder<MathNet.Numerics.Complex32>
	{
		public override MathNet.Numerics.Complex32 Zero => MathNet.Numerics.Complex32.Zero;

		public override MathNet.Numerics.Complex32 One => MathNet.Numerics.Complex32.One;

		public override Matrix<MathNet.Numerics.Complex32> Dense(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> storage)
		{
			return new DenseMatrix(storage);
		}

		public override Matrix<MathNet.Numerics.Complex32> Sparse(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32> storage)
		{
			return new SparseMatrix(storage);
		}

		public override Matrix<MathNet.Numerics.Complex32> Diagonal(DiagonalMatrixStorage<MathNet.Numerics.Complex32> storage)
		{
			return new DiagonalMatrix(storage);
		}

		public override Matrix<MathNet.Numerics.Complex32> Random(int rows, int columns, IContinuousDistribution distribution)
		{
			return Dense(rows, columns, Generate.RandomComplex32(rows * columns, distribution));
		}

		public override IIterationStopCriterion<MathNet.Numerics.Complex32>[] IterativeSolverStopCriteria(int maxIterations = 1000)
		{
			return new IIterationStopCriterion<MathNet.Numerics.Complex32>[4]
			{
				new FailureStopCriterion<MathNet.Numerics.Complex32>(),
				new DivergenceStopCriterion<MathNet.Numerics.Complex32>(),
				new IterationCountStopCriterion<MathNet.Numerics.Complex32>(maxIterations),
				new ResidualStopCriterion<MathNet.Numerics.Complex32>(1E-06)
			};
		}

		internal override MathNet.Numerics.Complex32 Add(MathNet.Numerics.Complex32 x, MathNet.Numerics.Complex32 y)
		{
			return x + y;
		}
	}
}
