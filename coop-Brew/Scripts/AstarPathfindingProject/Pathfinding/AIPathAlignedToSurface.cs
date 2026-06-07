using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/aipathalignedtosurface.html")]
	public class AIPathAlignedToSurface : AIPath
	{
		private static readonly Dictionary<Mesh, int> scratchDictionary;

		protected override void OnEnable()
		{
		}

		protected override void ApplyGravity(float deltaTime)
		{
		}

		public static void UpdateMovementPlanes(AIPathAlignedToSurface[] components, int count)
		{
		}

		private void SetInterpolatedNormal(Vector3 normal)
		{
		}

		protected override void UpdateMovementPlane()
		{
		}
	}
}
