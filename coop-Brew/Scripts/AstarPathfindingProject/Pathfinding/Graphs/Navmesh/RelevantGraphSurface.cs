using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[AddComponentMenu("Pathfinding/Navmesh/RelevantGraphSurface")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/relevantgraphsurface.html")]
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

		public override void DrawGizmos()
		{
		}
	}
}
