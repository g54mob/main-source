using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class PathFindingData : MonoBehaviour
	{
		[SerializeField]
		private PathFindingWaypoint[] _allPathFindingWaypoints;

		internal PathFindingWaypoint[] AllPathFindingWaypoints => null;

		public void SetPathFindingWaypoints(PathFindingWaypoint[] waypoints)
		{
		}

		internal bool IsValid(out string error)
		{
			error = null;
			return false;
		}
	}
}
