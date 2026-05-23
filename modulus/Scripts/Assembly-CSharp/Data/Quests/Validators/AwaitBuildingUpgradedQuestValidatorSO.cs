using Data.Buildings;
using Data.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Building Upgraded", fileName = "AwaitBuildingUpgraded", order = 8)]
	public class AwaitBuildingUpgradedQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private int _minUpgradeStage;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private BuildingObjectData _specificBuilding;

		[SerializeField]
		private int _buildingAmount = 1;

		private bool _isSetup;

		private float _currentProgress;

		private bool _enoughBuildingsUpgraded;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				CheckUpgradedBuildings();
				if (!_enoughBuildingsUpgraded)
				{
					BuildingBehaviour.OnBuildingUpgraded += HandleBuildingUpgradedEvent;
				}
				_isSetup = true;
			}
			if (base.HasProgress)
			{
				CheckIfAnyBuildingIsUpgrading();
			}
			return _enoughBuildingsUpgraded;
		}

		private void CheckUpgradedBuildings()
		{
			int num = 0;
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (allDistinctObjectList.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour) && !(behaviour.BuildingObjectData != _specificBuilding) && behaviour.CurrentBuildingStage >= _minUpgradeStage)
				{
					num++;
				}
			}
			_enoughBuildingsUpgraded = num >= _buildingAmount;
		}

		private void CheckIfAnyBuildingIsUpgrading()
		{
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (allDistinctObjectList.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour) && behaviour.IsUpgrading && behaviour.CurrentBuildingStage == _minUpgradeStage - 1 && behaviour.CurrentProgress > _currentProgress)
				{
					_currentProgress = behaviour.CurrentProgress;
				}
			}
		}

		private void HandleBuildingUpgradedEvent(BuildingBehaviour buildingBehaviour, int upgradeStage)
		{
			CheckUpgradedBuildings();
		}

		public override float GetProgress()
		{
			return _currentProgress;
		}

		public override void Reset()
		{
			_isSetup = false;
			_enoughBuildingsUpgraded = false;
			_currentProgress = 0f;
			BuildingBehaviour.OnBuildingUpgraded -= HandleBuildingUpgradedEvent;
		}
	}
}
