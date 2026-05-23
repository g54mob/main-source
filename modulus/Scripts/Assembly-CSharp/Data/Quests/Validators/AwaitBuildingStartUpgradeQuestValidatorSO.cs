using Data.Buildings;
using Data.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Building Start Upgrade", fileName = "AwaitBuildingStartUpgrade", order = 8)]
	public class AwaitBuildingStartUpgradeQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		private bool _isSetup;

		private bool _eventWasCalled;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				BuildingBehaviour.OnBuildingStartUpgrade += BuildingBehaviourOnOnUpgradeStateChanged;
				_isSetup = true;
			}
			return _eventWasCalled;
		}

		private void BuildingBehaviourOnOnUpgradeStateChanged()
		{
			_eventWasCalled = true;
		}

		public override void Reset()
		{
			_isSetup = false;
			_eventWasCalled = false;
			BuildingBehaviour.OnBuildingStartUpgrade -= BuildingBehaviourOnOnUpgradeStateChanged;
		}
	}
}
