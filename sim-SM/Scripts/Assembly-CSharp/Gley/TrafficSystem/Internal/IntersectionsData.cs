using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	public class IntersectionsData : MonoBehaviour
	{
		[SerializeField]
		private IntersectionDataType[] _allIntersections;

		[SerializeField]
		private PriorityIntersectionData[] _allPriorityIntersections;

		[SerializeField]
		private TrafficLightsIntersectionData[] _allLightsIntersections;

		[SerializeField]
		private TrafficLightsCrossingData[] _allLightsCrossings;

		[SerializeField]
		private PriorityCrossingData[] _allPriorityCrossings;

		internal IntersectionDataType[] AllIntersections => null;

		internal PriorityIntersectionData[] AllPriorityIntersections => null;

		internal TrafficLightsIntersectionData[] AllLightsIntersections => null;

		internal TrafficLightsCrossingData[] AllLightsCrossings => null;

		internal PriorityCrossingData[] AllPriorityCrossings => null;

		public void SetTrafficIntersectionData(IntersectionDataType[] allIntersections, TrafficLightsIntersectionData[] allLightsIntersections, PriorityIntersectionData[] allPriorityIntersections, TrafficLightsCrossingData[] allLightsCrossings, PriorityCrossingData[] allPriorityCrossings)
		{
		}

		internal bool IsValid(out string error)
		{
			error = null;
			return false;
		}
	}
}
