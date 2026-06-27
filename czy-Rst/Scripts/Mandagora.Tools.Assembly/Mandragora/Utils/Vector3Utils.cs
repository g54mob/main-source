using UnityEngine;

namespace Mandragora.Utils
{
	public static class Vector3Utils
	{
		public static Vector3 SnapToStep(Vector3 point, Vector3 step)
		{
			return Vector3.Scale(new Vector3(Mathf.Round(point.x / step.x), Mathf.Round(point.y / step.y), Mathf.Round(point.z / step.z)), step);
		}
	}
}
