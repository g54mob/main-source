using Data.Buildings;
using Data.FactoryFloor;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementBuildingUpgradedSO", menuName = "Story/StoryElementBuildingUpgradedSO")]
	public class StoryElementBuildingUpgradedSO : StoryElementSO
	{
		[SerializeField]
		private int _minUpgradeStage;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private BuildingObjectData _specificBuilding;

		public override void Initialize()
		{
			BuildingBehaviour.OnBuildingUpgraded += HandleBuildingUpgradedEvent;
		}

		public override void Destroy()
		{
			BuildingBehaviour.OnBuildingUpgraded -= HandleBuildingUpgradedEvent;
		}

		private void HandleBuildingUpgradedEvent(BuildingBehaviour buildingBehaviour, int upgradeStage)
		{
			if (!(buildingBehaviour.BuildingObjectData != _specificBuilding) && buildingBehaviour.CurrentBuildingStage >= _minUpgradeStage)
			{
				TryExecute();
			}
		}
	}
}
