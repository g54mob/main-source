using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class AllVehiclesData
	{
		private readonly VehicleComponent[] _allVehicles;

		internal VehicleComponent[] AllVehicles => null;

		internal AllVehiclesData(Transform parent, VehiclePool vehiclePool, int nrOfVehicles, LayerMask buildingLayers, LayerMask obstacleLayers, LayerMask playerLayers, LayerMask roadLayers, bool lightsOn, ModifyTriggerSize modifyTriggerSize)
		{
		}

		private VehicleComponent LoadVehicle(int vehicleIndex, GameObject carPrefab, Transform parent, LayerMask buildingLayers, LayerMask obstacleLayers, LayerMask playerLayers, LayerMask roadLayers, bool excluded, bool lightsOn, ModifyTriggerSize modifyTriggerSize)
		{
			return null;
		}
	}
}
