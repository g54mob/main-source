using Data.FactoryFloor.Behaviours;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Drones
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/SupplyTankRecipientSavingBehaviour", fileName = "SupplyTankRecipientSavingBehaviour", order = 0)]
	public class SupplyTankRecipientSavingBehaviour : FactoryObjectBehaviour
	{
		private SupplyTankRecipientBehaviour _supplyTankRecipient;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_supplyTankRecipient = factoryObject.GetFactoryObjectBehaviour<SupplyTankRecipientBehaviour>();
			SupplyTankRecipientSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<SupplyTankRecipientSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				ApplySaveState(behaviourSaveStateDto);
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new SupplyTankRecipientSaveStateDto
			{
				HasCapsule = _supplyTankRecipient.HasCapsule,
				CurrentResourceAmount = _supplyTankRecipient.CurrentResourceAmount
			};
		}

		private void ApplySaveState(SupplyTankRecipientSaveStateDto saveStateDto)
		{
			_supplyTankRecipient.SetSaveState(saveStateDto);
		}

		public override void Update()
		{
		}
	}
}
