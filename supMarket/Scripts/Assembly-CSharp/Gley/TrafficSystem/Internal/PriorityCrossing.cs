using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class PriorityCrossing : GenericIntersection, IDestroyable
	{
		private List<PedestrianCrossing> _pedestriansCrossing;

		private PriorityCrossingData _priorityCrossingData;

		private Vector3 _position;

		private Color _waypointColor;

		private bool _stopCars;

		private bool _stopUpdate;

		internal PriorityCrossing(PriorityCrossingData priorityCrossingData, TrafficWaypointsDataHandler trafficWaypointsDataHandler, IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler)
		{
		}

		public void Assign()
		{
		}

		public override bool IsPathFree(int waypointIndex)
		{
			return false;
		}

		internal override string GetName()
		{
			return null;
		}

		public override void PedestrianPassed(int pedestrianIndex)
		{
		}

		internal int[] GetWaypointsToCkeck()
		{
			return null;
		}

		internal Color GetWaypointColors()
		{
			return default(Color);
		}

		internal override List<int> GetStopWaypoints()
		{
			return null;
		}

		internal void SetPriorityCrossingState(bool stop, bool stopUpdate)
		{
		}

		internal bool GetPriorityCrossingState()
		{
			return false;
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

		internal Vector3 GetPosition()
		{
			return default(Vector3);
		}

		internal override void ResetIntersection()
		{
		}

		private void InitializePedestrianWaypoints(IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler)
		{
		}

		private void MakePedestriansCross(int road)
		{
		}

		private void PedestrianWantsToCross(int pedestrianIndex, IIntersection intersection, int waypointIndex)
		{
		}

		private void CheckColor()
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
