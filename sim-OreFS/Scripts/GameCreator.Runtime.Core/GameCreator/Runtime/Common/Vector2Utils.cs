using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class Vector2Utils
	{
		public static Vector2 XY(this Vector3 vector3)
		{
			return new Vector2(vector3.x, vector3.y);
		}

		public static Vector2 XZ(this Vector3 vector3)
		{
			return new Vector2(vector3.x, vector3.z);
		}

		public static Vector2 YZ(this Vector3 vector3)
		{
			return new Vector2(vector3.y, vector3.z);
		}
	}
}
