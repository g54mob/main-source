using System.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	internal class MatrixBuilder : MatrixBuilder<System.Numerics.Complex>
	{
		public override System.Numerics.Complex Zero => System.Numerics.Complex.Zero;

		public override System.Numerics.Complex One => System.Numerics.Complex.One;

		public override Matrix<System.Numerics.Complex> Dense(DenseColumnMajorMatrixStorage<System.Numerics.Complex> storage)
		{
			return new DenseMatrix(storage);
		}

		public override Matrix<System.Numerics.Complex> Sparse(SparseCompressedRowMatrixStorage<System.Numerics.Complex> storage)
		{
			return new SparseMatrix(storage);
		}

		public override Matrix<System.Numerics.Complex> Diagonal(DiagonalMatrixStorage<System.Numerics.Complex> storage)
		{
			return new DiagonalMatrix(storage);
		}

		public override Matrix<System.Numerics.Complex> Random(int rows, int columns, IContinuousDistribution distribution)
		{
			return Dense(rows, columns, Generate.RandomComplex(rows * columns, distribution));
		}

		public override IIterationStopCriterion<System.Numerics.Complex>[] IterativeSolverStopCriteria(int maxIterations = 1000)
		{
			return new IIterationStopCriterion<System.Numerics.Complex>[4]
			{
				new FailureStopCriterion<System.Numerics.Complex>(),
				new DivergenceStopCriterion<System.Numerics.Complex>(),
				new IterationCountStopCriterion<System.Numerics.Complex>(maxIterations),
				new ResidualStopCriterion<System.Numerics.Complex>(1E-12)
			};
		}

		internal override System.Numerics.Complex Add(System.Numerics.Complex x, System.Numerics.Complex y)
		{
			return x + y;
		}
	}
}
