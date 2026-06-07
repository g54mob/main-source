using UnityEngine;

namespace Lean.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanPlane")]
	[AddComponentMenu("Lean/Common/Lean Plane")]
	public class LeanPlane : MonoBehaviour
	{
		public bool ClampX;

		public float MinX;

		public float MaxX;

		public bool ClampY;

		public float MinY;

		public float MaxY;

		public float SnapX;

		public float SnapY;

		public Vector3 GetClosest(Vector3 position, float offset = 0f)
		{
			return default(Vector3);
		}

		public bool TryRaycast(Ray ray, ref Vector3 hit, float offset = 0f, bool getClosest = true)
		{
			return false;
		}

		public Vector3 GetClosest(Ray ray, float offset = 0f)
		{
			return default(Vector3);
		}

		private static bool RayToPlane(Vector3 point, Vector3 normal, Ray ray, ref float distance)
		{
			return false;
		}
	}
}
