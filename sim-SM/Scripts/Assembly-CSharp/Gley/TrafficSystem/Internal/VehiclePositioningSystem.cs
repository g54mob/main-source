using Gley.UrbanSystem.Internal;
using UnityEngine;
using UnityEngine.Jobs;

namespace Gley.TrafficSystem.Internal
{
	internal class VehiclePositioningSystem : IDestroyable
	{
		private TransformAccessArray allVehicles;

		private WaypointManager waypointManager;

		private TrafficWaypointsDataHandler _trafficWaypointsDataHandler;

		internal VehiclePositioningSystem(int nrOfCars, WaypointManager waypointManager, TrafficWaypointsDataHandler trafficWaypointsDataHandler)
		{
		}

		public void Assign()
		{
		}

		internal int IsInFront(int index1, int index2)
		{
			return 0;
		}

		internal bool IsSameOrientation(Vector3 heading1, Vector3 heading2)
		{
			return false;
		}

		internal bool IsSameHeading(Vector3 myHeading, Vector3 othervelocity)
		{
			return false;
		}

		internal void AddCar(Transform vehicle)
		{
		}

		internal Vector3 GetUpVector(int index)
		{
			return default(Vector3);
		}

		internal Vector3 GetForwardVector(int index)
		{
			return default(Vector3);
		}

		internal Vector3 GetRightVector(int index)
		{
			return default(Vector3);
		}

		internal Vector3 GetPosition(int index)
		{
			return default(Vector3);
		}

		internal bool IsGoingForward(Vector3 velicity, Vector3 heading)
		{
			return false;
		}

		private int CheckAngles(int index1, int index2)
		{
			return 0;
		}

		public void OnDestroy()
		{
		}
	}
}
