namespace Gley.TrafficSystem.Internal
{
	public class IntersectionsDataHandler
	{
		private readonly IntersectionsData IntersectionsData;

		public IntersectionsDataHandler(IntersectionsData data)
		{
		}

		public IntersectionDataType[] GetIntersectionData()
		{
			return null;
		}

		public TrafficLightsCrossingData GetTrafficLightsCrossingData(int intersectionIndex)
		{
			return null;
		}

		public TrafficLightsIntersectionData GetTrafficLightsIntersectionData(int intersectionIndex)
		{
			return null;
		}

		public PriorityCrossingData GetPriorityCrossingData(int intersectionIndex)
		{
			return default(PriorityCrossingData);
		}

		public PriorityIntersectionData GetPriorityIntersectionData(int intersectionIndex)
		{
			return default(PriorityIntersectionData);
		}
	}
}
