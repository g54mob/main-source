using Data.Buildings;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class FactoryObjectLockedView : FactoryLockedView
	{
		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedPersistentSO;

		[SerializeField]
		private FactoryObjectData _factoryObjectData;

		[SerializeField]
		private LockedFactoryObjectsUpdatedEventSO _lockedFactoryObjectsUpdatedEvent;

		protected override void Start()
		{
			base.Start();
			_lockedFactoryObjectsUpdatedEvent.Register(HandleLockedUpdated);
			HandleLockedUpdated(_factoryObjectData);
		}

		private void OnDestroy()
		{
			_lockedFactoryObjectsUpdatedEvent.UnRegister(HandleLockedUpdated);
		}

		private void HandleLockedUpdated(FactoryObjectData unlockedFactoryObjectData)
		{
			if (_factoryObjectData == unlockedFactoryObjectData)
			{
				UpdateUnlockVisuals();
			}
		}

		protected override bool GetIsLocked()
		{
			return _lockedPersistentSO.IsFactoryObjectLocked(_factoryObjectData);
		}

		public void StartWithBuildingData(BuildingObjectData buildingData)
		{
			_factoryObjectData = buildingData;
			UpdateUnlockVisuals();
			_lockedFactoryObjectsUpdatedEvent.Register(HandleLockedUpdated);
		}
	}
}
