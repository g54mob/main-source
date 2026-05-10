using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class PriorityIntersection : GenericIntersection, IDestroyable
	{
		private readonly List<int> _waypointsToCkeck;

		private readonly List<Color> _waypointColor;

		private readonly float _requiredTime;

		private List<PedestrianCrossing> _pedestriansCrossing;

		private PriorityIntersectionData _priorityIntersectionData;

		private Vector3 _position;

		private float _currentTime;

		private int _currentRoadIndex;

		private int _tempRoadIndex;

		private bool _changeRequested;

		internal PriorityIntersection(PriorityIntersectionData priorityIntersectionData, TrafficWaypointsDataHandler trafficWaypointsDataHandler, IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler)
		{
		}

		public void Assign()
		{
		}

		public override bool IsPathFree(int waypointIndex)
		{
			return false;
		}

		public override void PedestrianPassed(int pedestrianIndex)
		{
		}

		internal override string GetName()
		{
			return null;
		}

		internal override void ResetIntersection()
		{
		}

		internal Vector3 GetPosition()
		{
			return default(Vector3);
		}

		internal List<int> GetWaypointsToCkeck()
		{
			return null;
		}

		internal List<Color> GetWaypointColors()
		{
			return null;
		}

		internal override List<int> GetStopWaypoints()
		{
			return null;
		}

		internal override void UpdateIntersection(float realtimeSinceStartup)
		{
		}

		internal int GetCarsInIntersection()
		{
			return 0;
		}

		internal List<PedestrianCrossing> GetPedestriansCrossing()
		{
			return null;
		}

		internal override int[] GetPedStopWaypoint()
		{
			return null;
		}

		private void InitializePedestrianWaypoints(IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler)
		{
		}

		private void PedestrianWantsToCross(int pedestrianIndex, IIntersection intersection, int waypointIndex)
		{
		}

		private int GetRoadToCross(int waypoint)
		{
			return 0;
		}

		private bool IsPedestrianCrossing(int road)
		{
			return false;
		}

		public void OnDestroy()
		{
		}
	}
}
