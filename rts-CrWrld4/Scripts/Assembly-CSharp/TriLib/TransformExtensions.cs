using UnityEngine;

namespace TriLib
{
	public static class TransformExtensions
	{
		public static void LoadMatrix(this Transform transform, Matrix4x4 matrix, bool local = true)
		{
		}

		public static Bounds EncapsulateBounds(this Transform transform)
		{
			return default(Bounds);
		}

		public static Transform FindDeepChild(this Transform transform, string name, bool endsWith = false)
		{
			return null;
		}

		public static void DestroyChildren(this Transform transform, bool destroyImmediate = false)
		{
		}
	}
}
