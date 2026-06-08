using UnityEngine;

namespace GRP
{
	public struct Vector3Json
	{
		public float x;

		public float y;

		public float z;

		public Vector3Json(float x, float y, float z)
		{
			this.x = 0f;
			this.y = 0f;
			this.z = 0f;
		}

		public Vector3 ToVector()
		{
			return default(Vector3);
		}

		public static Vector3Json FromVector(Vector3 v)
		{
			return default(Vector3Json);
		}
	}
}
