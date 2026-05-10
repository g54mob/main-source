using System.Collections.Generic;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	internal class TrafficLightsIntersection : GenericIntersection
	{
		private readonly TrafficLightsIntersectionData _trafficLightsIntersectionData;

		private readonly TrafficLightsColor[] _intersectionState;

		private readonly float[] _roadGreenLightTime;

		private TrafficLightsBehaviour _trafficLightsBehaviour;

		private float _currentTime;

		private int _nrOfRoads;

		private int _currentRoad;

		private bool _yellowLight;

		private bool _stopUpdate;

		private bool _hasPedestrians;

		internal TrafficLightsIntersection(TrafficLightsIntersectionData trafficLightsIntersectionData, TrafficWaypointsDataHandler trafficWaypointsDataHandler, IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler, TrafficLightsBehaviour trafficLightsBehaviour, float greenLightTime, float yellowLightTime)
		{
		}

		public override void PedestrianPassed(int pedestrianIndex)
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

		internal override int[] GetPedStopWaypoint()
		{
			return null;
		}

		internal override void UpdateIntersection(float realtimeSinceStartup)
		{
		}

		internal override List<int> GetStopWaypoints()
		{
			return null;
		}

		internal void SetTrafficLightsBehaviour(TrafficLightsBehaviour trafficLightsBehaviour)
		{
		}

		internal void SetGreenRoad(int roadIndex, bool doNotChangeAgain)
		{
		}

		private void ApplyColorChanges()
		{
		}

		private void UpdateCurrentIntersectionWaypoints(int road, bool stop)
		{
		}

		private void ChangeCurrentRoadColors(int currentRoad, TrafficLightsColor newColor)
		{
		}

		private void ChangeAllRoadsExceptSelectd(int currentRoad, TrafficLightsColor newColor)
		{
		}

		private int GetValidValue(int roadNumber)
		{
			return 0;
		}

		private void GetPedestrianRoads(IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler)
		{
		}

		private void SetPedestrianGreenLightTime()
		{
		}

		private void TriggerPedestrianWaypointsUpdate(bool stop)
		{
		}
	}
}
