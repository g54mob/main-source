using System;
using System.Collections.Generic;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	[Serializable]
	public abstract class GenericIntersection : IIntersection
	{
		protected List<int> _carsInIntersection;

		public abstract bool IsPathFree(int waypointIndex);

		public void VehicleEnter(int vehicleIndex)
		{
		}

		public void VehicleLeft(int vehicleIndex)
		{
		}

		public abstract void PedestrianPassed(int agentIndex);

		internal abstract void UpdateIntersection(float realtimeSinceStartup);

		internal abstract int[] GetPedStopWaypoint();

		internal abstract string GetName();

		internal abstract List<int> GetStopWaypoints();

		internal void RemoveVehicle(int index)
		{
		}

		internal virtual void ResetIntersection()
		{
		}
	}
}
