using UnityEngine;

namespace Gh
{
	public static class RaycastTarget
	{
		public static Vector3 Cast()
		{
			return default(Vector3);
		}

		public static Vector3 Cast(Vector3 screenPoint, float level = 0f)
		{
			return default(Vector3);
		}

		public static Vector3? TryCast(Vector3 screenPoint, float level = 0f)
		{
			return null;
		}

		public static Vector3 Cast(Vector3 screenPoint, Vector3 axis, float level = 0f)
		{
			return default(Vector3);
		}

		public static Vector3 Cast(Camera customCamera, Vector3 screenPoint, Vector3 axis, float level)
		{
			return default(Vector3);
		}

		public static Vector3? TryCast(Camera customCamera, Vector3 screenPoint, Vector3 axis, float level)
		{
			return null;
		}

		public static Vector3? CastMousePoint()
		{
			return null;
		}

		public static Vector3? CastMousePoint(LayerMask hitableLayers)
		{
			return null;
		}
	}
}
