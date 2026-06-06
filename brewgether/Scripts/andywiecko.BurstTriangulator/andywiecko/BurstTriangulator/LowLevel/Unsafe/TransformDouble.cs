using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal readonly struct TransformDouble : ITransform<TransformDouble, double, double2>
	{
		private readonly double2x2 rotScale;

		private readonly double2 translation;

		public TransformDouble Identity => default(TransformDouble);

		public double AreaScalingFactor => 0.0;

		public TransformDouble(double2x2 rotScale, double2 translation)
		{
			this.rotScale = default(double2x2);
			this.translation = default(double2);
		}

		private static TransformDouble Translate(double2 offset)
		{
			return default(TransformDouble);
		}

		private static TransformDouble Scale(double2 scale)
		{
			return default(TransformDouble);
		}

		private static TransformDouble Rotate(double2x2 rotation)
		{
			return default(TransformDouble);
		}

		public static TransformDouble operator *(TransformDouble lhs, TransformDouble rhs)
		{
			return default(TransformDouble);
		}

		public TransformDouble Inverse()
		{
			return default(TransformDouble);
		}

		public double2 Transform(double2 point)
		{
			return default(double2);
		}

		public TransformDouble CalculatePCATransformation(NativeArray<double2> positions)
		{
			return default(TransformDouble);
		}

		public TransformDouble CalculateLocalTransformation(NativeArray<double2> positions)
		{
			return default(TransformDouble);
		}

		private static void Eigen(double2x2 matrix, out double2 eigval, out double2x2 eigvec)
		{
			eigval = default(double2);
			eigvec = default(double2x2);
		}

		private static double2x2 Kron(double2 a, double2 b)
		{
			return default(double2x2);
		}
	}
}
