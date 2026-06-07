using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Procedural Graph Mover")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/proceduralgraphmover.html")]
	public class ProceduralGraphMover : VersionedMonoBehaviour
	{
		public float updateDistance;

		public Transform target;

		public NavGraph graph;

		[HideInInspector]
		public int graphIndex;

		public bool updatingGraph { get; private set; }

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void UpdateGraph(bool async = true)
		{
		}

		private void UpdateGridGraph(GridGraph graph, bool async)
		{
		}

		private static Vector2Int RecastGraphTileShift(RecastGraph graph, Vector3 targetCenter)
		{
			return default(Vector2Int);
		}

		private void UpdateRecastGraph(RecastGraph graph, Vector2Int delta, bool async)
		{
		}
	}
}
