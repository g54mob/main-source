using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Double
{
	internal class MatrixBuilder : MatrixBuilder<double>
	{
		public override double Zero => 0.0;

		public override double One => 1.0;

		public override Matrix<double> Dense(DenseColumnMajorMatrixStorage<double> storage)
		{
			return new DenseMatrix(storage);
		}

		public override Matrix<double> Sparse(SparseCompressedRowMatrixStorage<double> storage)
		{
			return new SparseMatrix(storage);
		}

		public override Matrix<double> Diagonal(DiagonalMatrixStorage<double> storage)
		{
			return new DiagonalMatrix(storage);
		}

		public override Matrix<double> Random(int rows, int columns, IContinuousDistribution distribution)
		{
			return Dense(rows, columns, Generate.Random(rows * columns, distribution));
		}

		public override IIterationStopCriterion<double>[] IterativeSolverStopCriteria(int maxIterations = 1000)
		{
			return new IIterationStopCriterion<double>[4]
			{
				new FailureStopCriterion<double>(),
				new DivergenceStopCriterion<double>(),
				new IterationCountStopCriterion<double>(maxIterations),
				new ResidualStopCriterion<double>(1E-12)
			};
		}

		internal override double Add(double x, double y)
		{
			return x + y;
		}
	}
}
