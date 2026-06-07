using System.Collections.Generic;

namespace Gley.TrafficSystem.Internal
{
	internal class IdleVehiclesDataHandler
	{
		private IdleVehiclesData _idleVehiclesData;

		internal IdleVehiclesDataHandler(IdleVehiclesData idleVehiclesData)
		{
		}

		internal VehicleComponent GetAndRemoveVehicle(int vehicleIndex)
		{
			return null;
		}

		internal VehicleComponent PeakIdleVehicle(int vehicleIndex)
		{
			return null;
		}

		internal int GetRandomIndex()
		{
			return 0;
		}

		internal int GetIdleVehicleIndex(VehicleTypes type)
		{
			return 0;
		}

		internal VehicleTypes GetIdleVehicleType(int vehicleIndex)
		{
			return default(VehicleTypes);
		}

		internal float GetFrontWheelOffset(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetHalfVehicleLength(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetIdleVehicleHeight(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetIdleVehicleWidth(int vehicleIndex)
		{
			return 0f;
		}

		internal void AddVehicle(VehicleComponent vehicle)
		{
		}

		internal void RemoveVehicle(VehicleComponent vehicle)
		{
		}

		private List<VehicleComponent> GetAllVehiclesOfType(VehicleTypes type)
		{
			return null;
		}

		private VehicleComponent GetVehicle(int vehicleIndex)
		{
			return null;
		}

		public int GetVehicleIndex(VehicleComponent vehicle)
		{
			return 0;
		}

		private void RemoveVehicle(int vehicleIndex)
		{
		}

		private bool HasIdleVehicles()
		{
			return false;
		}

		private int GetNumberOfVehicles()
		{
			return 0;
		}

		private List<VehicleComponent> GetAllVehicles()
		{
			return null;
		}
	}
}
