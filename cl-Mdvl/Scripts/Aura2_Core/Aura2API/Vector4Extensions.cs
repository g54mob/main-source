using UnityEngine;

namespace Aura2API
{
	public static class Vector4Extensions
	{
		private static float[] _tmpFloatArray = new float[4];

		private static Vector4 _tmpVector4 = default(Vector4);

		public static float[] AsFloatArray(this Vector4 vector)
		{
			_tmpFloatArray[0] = vector.x;
			_tmpFloatArray[1] = vector.y;
			_tmpFloatArray[2] = vector.z;
			_tmpFloatArray[3] = vector.w;
			return _tmpFloatArray;
		}

		public static float[] AsFloatArray(this Vector4[] vector)
		{
			float[] array = new float[vector.Length * 4];
			for (int i = 0; i < vector.Length; i++)
			{
				array[i * 4] = vector[i].x;
				array[i * 4 + 1] = vector[i].y;
				array[i * 4 + 2] = vector[i].z;
				array[i * 4 + 3] = vector[i].w;
			}
			return array;
		}

		public static Vector4 GetReciproqual(this Vector4 vector)
		{
			_tmpVector4.x = 1f / vector.x;
			_tmpVector4.y = 1f / vector.y;
			_tmpVector4.z = 1f / vector.z;
			_tmpVector4.w = 1f / vector.w;
			return _tmpVector4;
		}
	}
}
