using Data.Variables;
using Data.Variables.Drones;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Drones", fileName = "DronesPersistentSO")]
	public class DronesPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private DroneMaxVelocityData _harvesterPadDroneMaxVelocityData;

		[SerializeField]
		private DroneMaxVelocityData _supplyTankDroneMaxVelocityData;

		[SerializeField]
		private DroneMaxAmountPerHarvesterPadData _droneMaxAmountPerHarvesterPadData;

		[SerializeField]
		private IntVariableSO _droneMaxAmountPerSupplyTankData;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			DronesSaveData dronesSaveData = saveData as DronesSaveData;
			_harvesterPadDroneMaxVelocityData.SetValue(dronesSaveData.HarvesterPadDroneMaxVelocity);
			_supplyTankDroneMaxVelocityData.SetValue(dronesSaveData.SupplyTankDroneMaxVelocity);
			_droneMaxAmountPerHarvesterPadData.SetValue(dronesSaveData.MaxDroneAmountPerHarvesterPad);
			_droneMaxAmountPerSupplyTankData.SetValue(dronesSaveData.MaxDroneAmountPerSupplyTank);
		}

		public override void ResetToDefaults()
		{
			_harvesterPadDroneMaxVelocityData.SetValue(_harvesterPadDroneMaxVelocityData.DefaultValue);
			_supplyTankDroneMaxVelocityData.SetValue(_supplyTankDroneMaxVelocityData.DefaultValue);
			_droneMaxAmountPerHarvesterPadData.SetValue(_droneMaxAmountPerHarvesterPadData.DefaultValue);
			_droneMaxAmountPerSupplyTankData.SetValue(_droneMaxAmountPerSupplyTankData.DefaultValue);
		}

		public override AbstractSaveData GetSaveData()
		{
			return new DronesSaveData(_harvesterPadDroneMaxVelocityData.Value, _supplyTankDroneMaxVelocityData.Value, _droneMaxAmountPerHarvesterPadData.Value, _droneMaxAmountPerSupplyTankData.Value);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<DronesSaveData>(fullPath);
		}
	}
}
