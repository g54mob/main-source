using System.Collections.Generic;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	public class WaypointSettings : WaypointSettingsBase
	{
		public List<WaypointSettings> otherLanes;

		public List<WaypointSettings> giveWayList;

		public List<VehicleTypes> allowedCars;

		public float laneWidth;

		public int maxSpeed;

		public bool giveWay;

		public bool enter;

		public bool exit;

		public bool speedLocked;

		public bool carsLocked;

		public bool complexGiveWay;

		public bool zipperGiveWay;

		public override void Initialize()
		{
		}

		public void ResetProperties()
		{
		}

		public override void VerifyAssignments(bool showPrevsWarning)
		{
		}

		public void SetVehicleTypesForAllNeighbors(List<VehicleTypes> allowedVehicles)
		{
		}

		public void SetSpeedForAllNeighbors(int newSpeed)
		{
		}

		private bool IsValid(int value)
		{
			return false;
		}
	}
}
