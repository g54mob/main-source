using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public class Optimizers_ObstacleBounds
	{
		public Bounds Bounds;

		public Vector3 Normal;

		public Vector3 CastDirection;

		public Optimizers_ObstacleBounds(RaycastHit hit, Vector3 castDirection)
		{
			Bounds = hit.collider.bounds;
			Normal = hit.normal;
			CastDirection = castDirection;
		}
	}
}
