using System.Collections.Generic;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	public class Road : RoadBase
	{
		public List<Lane> lanes;

		public int otherLaneLinkDistance;

		public void SetDefaults(int nrOfLanes, float laneWidth, float waypointDistance, int otherLaneLinkDistance)
		{
		}

		public void SetRoadProperties(int globalMaxSpeed, int nrOfCars, bool leftSideTraffic)
		{
		}

		public override bool VerifyAssignments()
		{
			return false;
		}

		public void UpdateLaneNumber(int maxSpeed, int nrOfCars)
		{
		}

		public void AddLaneConnector(WaypointSettingsBase inConnector, WaypointSettingsBase outConnector, int index)
		{
		}

		public void SwitchDirection(int laneNumber)
		{
		}

		public List<int> GetAllowedCars(int laneNumber)
		{
			return null;
		}

		public int GetNrOfLanes()
		{
			return 0;
		}
	}
}
