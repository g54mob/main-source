using System.Collections.Generic;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	internal class TrafficLightsCrossing : GenericIntersection
	{
		private readonly TrafficLightsCrossingData _trafficLightsCrossingData;

		private TrafficLightsBehaviour _trafficLightsBehaviour;

		private TrafficLightsColor _intersectionState;

		private float _currentTime;

		private float _currentTimer;

		private bool _doNotChange;

		internal TrafficLightsCrossing(TrafficLightsCrossingData trafficLightsCrossingData, TrafficWaypointsDataHandler trafficWaypointsDataHandler, IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler, TrafficLightsBehaviour trafficLightsBehaviour)
		{
		}

		public override bool IsPathFree(int waypointIndex)
		{
			return false;
		}

		public override void PedestrianPassed(int pedestrianIndex)
		{
		}

		internal void SetTrafficLightsBehaviour(TrafficLightsBehaviour trafficLightsBehaviour)
		{
		}

		internal override void UpdateIntersection(float realtimeSinceStartup)
		{
		}

		internal void SetCrossingState(TrafficLightsColor newColor, bool doNotChangeAgain, float realtimeSinceStartup)
		{
		}

		internal override string GetName()
		{
			return null;
		}

		internal LightsStopWaypoints[] GetWaypoints()
		{
			return null;
		}

		internal override List<int> GetStopWaypoints()
		{
			return null;
		}

		internal TrafficLightsColor GetCrossingState()
		{
			return default(TrafficLightsColor);
		}

		internal override int[] GetPedStopWaypoint()
		{
			return null;
		}

		private void ApplyColorChanges()
		{
		}

		private void UpdateCurrentIntersectionWaypoints(int road, bool stop)
		{
		}

		private void GetPedestrianRoads(IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler)
		{
		}

		private void TriggerPedestrianWaypointsUpdate(bool stop)
		{
		}
	}
}
