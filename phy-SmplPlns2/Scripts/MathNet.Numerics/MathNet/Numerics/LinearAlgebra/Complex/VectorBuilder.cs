using System.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	internal class VectorBuilder : VectorBuilder<System.Numerics.Complex>
	{
		public override System.Numerics.Complex Zero => System.Numerics.Complex.Zero;

		public override System.Numerics.Complex One => System.Numerics.Complex.One;

		public override Vector<System.Numerics.Complex> Dense(DenseVectorStorage<System.Numerics.Complex> storage)
		{
			return new DenseVector(storage);
		}

		public override Vector<System.Numerics.Complex> Sparse(SparseVectorStorage<System.Numerics.Complex> storage)
		{
			return new SparseVector(storage);
		}

		public override Vector<System.Numerics.Complex> Random(int length, IContinuousDistribution distribution)
		{
			return Dense(Generate.RandomComplex(length, distribution));
		}
	}
}
