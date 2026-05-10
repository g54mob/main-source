using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Navmesh/RelevantGraphSurface")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_relevant_graph_surface.php")]
	public class RelevantGraphSurface : VersionedMonoBehaviour
	{
		private static RelevantGraphSurface root;

		public float maxRange;

		private RelevantGraphSurface prev;

		private RelevantGraphSurface next;

		private Vector3 position;

		public Vector3 Position => default(Vector3);

		public RelevantGraphSurface Next => null;

		public RelevantGraphSurface Prev => null;

		public static RelevantGraphSurface Root => null;

		public void UpdatePosition()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public static void UpdateAllPositions()
		{
		}

		public static void FindAllGraphSurfaces()
		{
		}

		public void OnDrawGizmos()
		{
		}

		public void OnDrawGizmosSelected()
		{
		}
	}
}
