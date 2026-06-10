using UnityEngine;

namespace Aura2API
{
	public static class MathHelpers
	{
		public static Vector3 ProjectPointOnLine(Vector3 linePoint, Vector3 direction, Vector3 pointToProject)
		{
			return linePoint + Vector3.Dot(pointToProject - linePoint, direction) * direction;
		}
	}
}
