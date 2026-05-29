using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Navmesh/RecastTileUpdateHandler")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_recast_tile_update_handler.php")]
	public class RecastTileUpdateHandler : MonoBehaviour
	{
		private RecastGraph graph;

		private bool[] dirtyTiles;

		private bool anyDirtyTiles;

		private float earliestDirty;

		public float maxThrottlingDelay;

		public void SetGraph(RecastGraph graph)
		{
		}

		public void ScheduleUpdate(Bounds bounds)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void UpdateDirtyTiles()
		{
		}
	}
}
