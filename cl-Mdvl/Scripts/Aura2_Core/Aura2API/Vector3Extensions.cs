using UnityEngine;

namespace Aura2API
{
	public static class Vector3Extensions
	{
		private static float[] _tmpFloatArray = new float[3];

		private static Vector4 _tmpVector4 = default(Vector4);

		public static float[] AsFloatArray(this Vector3 vector)
		{
			_tmpFloatArray[0] = vector.x;
			_tmpFloatArray[1] = vector.y;
			_tmpFloatArray[2] = vector.z;
			return _tmpFloatArray;
		}

		public static float[] AsFloatArray(this Vector3[] vector)
		{
			float[] array = new float[vector.Length * 3];
			for (int i = 0; i < vector.Length; i++)
			{
				array[i * 3] = vector[i].x;
				array[i * 3 + 1] = vector[i].y;
				array[i * 3 + 2] = vector[i].z;
			}
			return array;
		}

		public static Vector4 AsVector4(this Vector3 vector, float fourthValue)
		{
			_tmpVector4.x = vector.x;
			_tmpVector4.y = vector.y;
			_tmpVector4.z = vector.z;
			_tmpVector4.w = fourthValue;
			return _tmpVector4;
		}
	}
}
