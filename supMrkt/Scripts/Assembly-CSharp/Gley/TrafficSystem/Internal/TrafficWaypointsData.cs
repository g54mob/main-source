using Photon.Pun;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	public class TrafficWaypointsData : MonoBehaviourPun
	{
		[SerializeField]
		private TrafficWaypoint[] _allTrafficWaypoints;

		internal TrafficWaypoint[] AllTrafficWaypoints => null;

		public void SetTrafficWaypoints(TrafficWaypoint[] waypoints)
		{
		}

		public void AssignZipperGiveWay()
		{
		}

		internal bool IsValid(out string error)
		{
			error = null;
			return false;
		}
	}
}
