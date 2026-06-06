using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal readonly struct TransformFloat : ITransform<TransformFloat, float, float2>
	{
		private readonly float2x2 rotScale;

		private readonly float2 translation;

		public TransformFloat Identity => default(TransformFloat);

		public float AreaScalingFactor => 0f;

		public TransformFloat(float2x2 rotScale, float2 translation)
		{
			this.rotScale = default(float2x2);
			this.translation = default(float2);
		}

		private static TransformFloat Translate(float2 offset)
		{
			return default(TransformFloat);
		}

		private static TransformFloat Scale(float2 scale)
		{
			return default(TransformFloat);
		}

		private static TransformFloat Rotate(float2x2 rotation)
		{
			return default(TransformFloat);
		}

		public static TransformFloat operator *(TransformFloat lhs, TransformFloat rhs)
		{
			return default(TransformFloat);
		}

		public TransformFloat Inverse()
		{
			return default(TransformFloat);
		}

		public float2 Transform(float2 point)
		{
			return default(float2);
		}

		public TransformFloat CalculatePCATransformation(NativeArray<float2> positions)
		{
			return default(TransformFloat);
		}

		public TransformFloat CalculateLocalTransformation(NativeArray<float2> positions)
		{
			return default(TransformFloat);
		}

		private static void Eigen(float2x2 matrix, out float2 eigval, out float2x2 eigvec)
		{
			eigval = default(float2);
			eigvec = default(float2x2);
		}

		private static float2x2 Kron(float2 a, float2 b)
		{
			return default(float2x2);
		}
	}
}
