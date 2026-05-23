using System;
using System.Collections.Generic;
using SaveData.FactoryFloor.SaveStates;
using SaveData.FactoryFloor.SaveStates.Drones;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class SupplyTankBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public bool IsStoringResource;

		public int CurrentResourceDataID;

		public int CurrentResourceAmount;

		public bool[] CurrentCapsulesFilled = Array.Empty<bool>();

		public int[] CurrentCapsuleResourceIDs = Array.Empty<int>();

		public Dictionary<int, SupplyTankDroneSaveStateDto> DroneSaveStates;

		public SupplyTankBehaviourSaveStateDto(bool isStoringResource, int currentResourceDataID, int currentResourceAmount, bool[] currentCapsulesFilled, int[] currentCapsuleResourceIDs, Dictionary<int, SupplyTankDroneSaveStateDto> droneSaveStates)
		{
			IsStoringResource = isStoringResource;
			CurrentResourceDataID = currentResourceDataID;
			CurrentResourceAmount = currentResourceAmount;
			CurrentCapsulesFilled = currentCapsulesFilled;
			CurrentCapsuleResourceIDs = currentCapsuleResourceIDs;
			DroneSaveStates = droneSaveStates;
		}
	}
}
