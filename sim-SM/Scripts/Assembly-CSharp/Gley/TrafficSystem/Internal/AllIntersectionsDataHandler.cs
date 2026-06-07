using System.Collections.Generic;

namespace Gley.TrafficSystem.Internal
{
	internal class AllIntersectionsDataHandler
	{
		private readonly AllIntersectionsData _allIntersectionsData;

		internal AllIntersectionsDataHandler(AllIntersectionsData data)
		{
		}

		internal void SetTrafficLightsBehaviour(TrafficLightsBehaviour trafficLightsBehaviour)
		{
		}

		internal void SetRoadToGreen(string intersectionName, int roadIndex, bool doNotChangeAgain)
		{
		}

		internal TrafficLightsColor GetTrafficLightsCrossingState(string crossingName)
		{
			return default(TrafficLightsColor);
		}

		internal void SetCrossingState(string crossingName, TrafficLightsColor newColor, bool doNotChangeAgain, float realtimeSinceStartup)
		{
		}

		internal bool IsPriorityCrossingRed(string crossingName)
		{
			return false;
		}

		internal void SetPriorityCrossingState(string crossingName, bool stop, bool stopUpdate)
		{
		}

		internal GenericIntersection[] GetAllIntersections()
		{
			return null;
		}

		internal List<GenericIntersection> GetIntersections(List<int> intersectionIndexes)
		{
			return null;
		}

		private GenericIntersection GetIntersection(int intersectionIndex)
		{
			return null;
		}

		private TrafficLightsIntersection GetTrafficLightsIntersection(int intersectionIndex)
		{
			return null;
		}

		private TrafficLightsCrossing GetTrafficLightsCrossing(int intersectionIndex)
		{
			return null;
		}

		private PriorityCrossing GetPriorityCrossing(int intersectionIndex)
		{
			return null;
		}
	}
}
