using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	internal class MatrixBuilder : MatrixBuilder<float>
	{
		public override float Zero => 0f;

		public override float One => 1f;

		public override Matrix<float> Dense(DenseColumnMajorMatrixStorage<float> storage)
		{
			return new DenseMatrix(storage);
		}

		public override Matrix<float> Sparse(SparseCompressedRowMatrixStorage<float> storage)
		{
			return new SparseMatrix(storage);
		}

		public override Matrix<float> Diagonal(DiagonalMatrixStorage<float> storage)
		{
			return new DiagonalMatrix(storage);
		}

		public override Matrix<float> Random(int rows, int columns, IContinuousDistribution distribution)
		{
			return Dense(rows, columns, Generate.RandomSingle(rows * columns, distribution));
		}

		public override IIterationStopCriterion<float>[] IterativeSolverStopCriteria(int maxIterations = 1000)
		{
			return new IIterationStopCriterion<float>[4]
			{
				new FailureStopCriterion<float>(),
				new DivergenceStopCriterion<float>(),
				new IterationCountStopCriterion<float>(maxIterations),
				new ResidualStopCriterion<float>(1E-06)
			};
		}

		internal override float Add(float x, float y)
		{
			return x + y;
		}
	}
}
