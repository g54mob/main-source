using System;
using Data.FactoryFloor.Drones;

namespace SaveData.FactoryFloor.SaveStates.Drones
{
	[Serializable]
	public class SupplyTankDroneSaveStateDto
	{
		public int StepsElapsed;

		public SupplyTankDroneBehaviour.SupplyTankDroneState DroneState;

		public BaseDroneSaveStateDto BaseDroneSaveStateDto;
	}
}
