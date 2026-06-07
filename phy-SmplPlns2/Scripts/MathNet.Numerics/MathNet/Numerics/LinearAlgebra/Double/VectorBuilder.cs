using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Double
{
	internal class VectorBuilder : VectorBuilder<double>
	{
		public override double Zero => 0.0;

		public override double One => 1.0;

		public override Vector<double> Dense(DenseVectorStorage<double> storage)
		{
			return new DenseVector(storage);
		}

		public override Vector<double> Sparse(SparseVectorStorage<double> storage)
		{
			return new SparseVector(storage);
		}

		public override Vector<double> Random(int length, IContinuousDistribution distribution)
		{
			return Dense(Generate.Random(length, distribution));
		}
	}
}
