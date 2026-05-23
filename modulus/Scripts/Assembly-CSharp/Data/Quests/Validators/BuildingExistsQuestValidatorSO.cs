using Data.Buildings;
using Data.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Building Exists", fileName = "BuildingExistsQuestValidatorSO", order = 9)]
	public class BuildingExistsQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private BuildingObjectData _specificBuilding;

		[SerializeField]
		private int _requiredAmount = 1;

		private bool _isSetup;

		private bool _enoughBuildingsCompleted;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_isSetup = true;
				CountHowManyBuildingsExist();
				if (!_enoughBuildingsCompleted)
				{
					BuildingBehaviour.OnBuildingUpgraded += HandleBuildingUpgradedEvent;
				}
			}
			return _enoughBuildingsCompleted;
		}

		private void CountHowManyBuildingsExist()
		{
			int num = 0;
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (allDistinctObjectList.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour) && !(behaviour.BuildingObjectData != _specificBuilding) && behaviour.CurrentBuildingStage >= 1)
				{
					num++;
				}
			}
			_enoughBuildingsCompleted = num >= _requiredAmount;
		}

		private void HandleBuildingUpgradedEvent(BuildingBehaviour buildingBehaviour, int upgradeStage)
		{
			if (upgradeStage >= 1 && buildingBehaviour.BuildingObjectData == _specificBuilding)
			{
				CountHowManyBuildingsExist();
			}
		}

		public override void Reset()
		{
			_isSetup = false;
			_enoughBuildingsCompleted = false;
			BuildingBehaviour.OnBuildingUpgraded -= HandleBuildingUpgradedEvent;
		}
	}
}
