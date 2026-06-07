using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class DronesSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public float HarvesterPadDroneMaxVelocity;

		public float SupplyTankDroneMaxVelocity;

		public int MaxDroneAmountPerHarvesterPad;

		public int MaxDroneAmountPerSupplyTank;

		public DronesSaveData(float harvesterPadDroneMaxVelocity, float supplyTankDroneMaxVelocity, int maxDroneAmountPerHarvesterPad, int maxDroneAmountPerSupplyTank)
			: base(0)
		{
			HarvesterPadDroneMaxVelocity = harvesterPadDroneMaxVelocity;
			SupplyTankDroneMaxVelocity = supplyTankDroneMaxVelocity;
			MaxDroneAmountPerHarvesterPad = maxDroneAmountPerHarvesterPad;
			MaxDroneAmountPerSupplyTank = maxDroneAmountPerSupplyTank;
		}
	}
}
