using UnityEngine;

namespace HQFPSTemplate
{
	public static class Vector3Utils
	{
		public static Vector3 LocalToWorld(Vector3 vector, Transform transform)
		{
			return transform.rotation * vector;
		}

		public static Vector3 WorldToLocal(Vector3 vector, Transform transform)
		{
			return Quaternion.Inverse(transform.rotation) * vector;
		}

		public static Vector3 JitterVector(Vector3 vector, float xJit = 0f, float yJit = 0f, float zJit = 0f)
		{
			vector = new Vector3(vector.x - Mathf.Abs(vector.x * Random.Range(0f, xJit)) * 2f, vector.y - Mathf.Abs(vector.y * Random.Range(0f, yJit)) * 2f, vector.z - Mathf.Abs(vector.z * Random.Range(0f, zJit)) * 2f);
			return vector;
		}

		public static Vector3 GetNaNSafeVector3(Vector3 vector3)
		{
			if (float.IsNaN(vector3.x))
			{
				vector3.x = 0f;
			}
			if (float.IsNaN(vector3.y))
			{
				vector3.y = 0f;
			}
			if (float.IsNaN(vector3.z))
			{
				vector3.z = 0f;
			}
			return vector3;
		}
	}
}
