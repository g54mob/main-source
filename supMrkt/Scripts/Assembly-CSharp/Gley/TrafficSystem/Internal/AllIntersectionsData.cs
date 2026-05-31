using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	internal class AllIntersectionsData
	{
		private readonly GenericIntersection[] _allIntersections;

		private readonly TrafficLightsIntersection[] _trafficLightsIntersections;

		private readonly PriorityIntersection[] _priorityIntersections;

		private readonly TrafficLightsCrossing[] _trafficLightsCrossings;

		private readonly PriorityCrossing[] _priorityCrossings;

		internal GenericIntersection[] AllIntersections => null;

		internal TrafficLightsIntersection[] TrafficLightsIntersections => null;

		internal PriorityIntersection[] PriorityIntersections => null;

		internal TrafficLightsCrossing[] TrafficLightsCrossings => null;

		internal PriorityCrossing[] PriorityCrossings => null;

		internal AllIntersectionsData(IntersectionsDataHandler intersectionsDataHandler, TrafficWaypointsDataHandler trafficWaypointsDataHandler, IPedestrianWaypointsDataHandler pedestrianWaypointsDataHandler, TrafficLightsBehaviour trafficLightsBehaviour, float greenLightTime, float yellowLightTime)
		{
		}
	}
}
