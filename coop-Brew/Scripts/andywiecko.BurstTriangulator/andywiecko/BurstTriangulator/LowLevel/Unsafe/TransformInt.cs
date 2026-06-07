using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal readonly struct TransformInt : ITransform<TransformInt, int, int2>
	{
		private readonly int2 translation;

		public TransformInt Identity => default(TransformInt);

		public int AreaScalingFactor => 0;

		public TransformInt(int2 translation)
		{
			this.translation = default(int2);
		}

		public TransformInt Inverse()
		{
			return default(TransformInt);
		}

		public int2 Transform(int2 point)
		{
			return default(int2);
		}

		public TransformInt CalculatePCATransformation(NativeArray<int2> positions)
		{
			return default(TransformInt);
		}

		public TransformInt CalculateLocalTransformation(NativeArray<int2> positions)
		{
			return default(TransformInt);
		}
	}
}
