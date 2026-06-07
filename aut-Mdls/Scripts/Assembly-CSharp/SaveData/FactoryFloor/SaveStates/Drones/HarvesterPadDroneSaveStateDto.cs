using System;
using Data.FactoryFloor.Drones;

namespace SaveData.FactoryFloor.SaveStates.Drones
{
	[Serializable]
	public class HarvesterPadDroneSaveStateDto
	{
		public int StepsElapsed;

		public HarvestPadDroneBehaviour.HarvestPadDroneState DroneState;

		public BaseDroneSaveStateDto BaseDroneSaveStateDto;
	}
}
