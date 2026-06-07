using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Complex32
{
	internal class VectorBuilder : VectorBuilder<MathNet.Numerics.Complex32>
	{
		public override MathNet.Numerics.Complex32 Zero => MathNet.Numerics.Complex32.Zero;

		public override MathNet.Numerics.Complex32 One => MathNet.Numerics.Complex32.One;

		public override Vector<MathNet.Numerics.Complex32> Dense(DenseVectorStorage<MathNet.Numerics.Complex32> storage)
		{
			return new DenseVector(storage);
		}

		public override Vector<MathNet.Numerics.Complex32> Sparse(SparseVectorStorage<MathNet.Numerics.Complex32> storage)
		{
			return new SparseVector(storage);
		}

		public override Vector<MathNet.Numerics.Complex32> Random(int length, IContinuousDistribution distribution)
		{
			return Dense(Generate.RandomComplex32(length, distribution));
		}
	}
}
