using UnityEngine;

namespace TriLib
{
	public static class MatrixExtensions
	{
		public static Quaternion ExtractRotation(this Matrix4x4 matrix)
		{
			return default(Quaternion);
		}

		public static Vector3 ExtractPosition(this Matrix4x4 matrix)
		{
			return default(Vector3);
		}

		public static Vector3 ExtractScale(this Matrix4x4 matrix)
		{
			return default(Vector3);
		}
	}
}
