using UnityEngine;

namespace Coffee.UIEffectInternal
{
	internal static class TransformExtensionsForTransformSensitivity
	{
		private const float k_DefaultEpsilon = 0.1f;

		public static bool HasChanged(this Transform self, ref Matrix4x4 prev, TransformSensitivity sensitivity)
		{
			return false;
		}

		public static bool HasChanged(this Transform self, Transform baseTransform, ref Matrix4x4 prev, TransformSensitivity sensitivity)
		{
			return false;
		}

		private static float Convert(TransformSensitivity self)
		{
			return 0f;
		}

		private static bool HasChanged_Internal(this Transform self, Transform baseTransform, ref Matrix4x4 prev, float epsilon)
		{
			return false;
		}

		private static bool Approximately(Matrix4x4 self, Matrix4x4 other, float epsilon = 0.1f)
		{
			return false;
		}
	}
}
