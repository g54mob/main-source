using Data.Buildings;
using Data.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Monument Completed", fileName = "AwaitMonumentCompletedSubQuestValidatorSO", order = 8)]
	public class AwaitMonumentCompletedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private BuildingObjectData _specificBuilding;

		[SerializeField]
		private MonumentBuiltEvent _monumentBuiltEvent;

		private bool _monumentActivated;

		private bool _setup;

		public override bool IsValid()
		{
			if (!_setup)
			{
				_setup = true;
				_monumentActivated = BuildingAlreadyUpgraded();
				if (!_monumentActivated)
				{
					_monumentBuiltEvent.Register(OnMonumentBuilt);
				}
			}
			return _monumentActivated;
		}

		private void OnMonumentBuilt(FactoryObject factoryObj)
		{
			if (factoryObj.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour) && !(behaviour.BuildingObjectData != _specificBuilding))
			{
				_monumentBuiltEvent.UnRegister(OnMonumentBuilt);
				_monumentActivated = true;
			}
		}

		public override void Reset()
		{
			_monumentActivated = false;
			_setup = false;
			_monumentBuiltEvent.UnRegister(OnMonumentBuilt);
		}

		private bool BuildingAlreadyUpgraded()
		{
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (allDistinctObjectList.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour) && !(behaviour.BuildingObjectData != _specificBuilding) && behaviour.CurrentBuildingStage >= 1)
				{
					return true;
				}
			}
			return false;
		}
	}
}
