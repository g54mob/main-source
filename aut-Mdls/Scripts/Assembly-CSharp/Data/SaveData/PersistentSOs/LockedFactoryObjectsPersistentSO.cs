#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using System.Linq;
using Data.Operator;
using Data.Variables;
using Data.Variables.Milestones;
using UnityEngine;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Locked Factory Objects", fileName = "LockedFactoryObjectsPersistentSO", order = 0)]
	public class LockedFactoryObjectsPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private LockedFactoryObjectsUpdatedEventSO _lockedFactoryObjectsUpdatedEvent;

		[SerializeField]
		private List<FactoryObjectData> _unlockedObjects;

		[SerializeField]
		private List<FactoryObjectData> _alwaysUnlockedInDevelopmentBuilds;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		[SerializeField]
		private GNNGateFinishedVariableSO _gNNGateFinished;

		[SerializeField]
		private FactoryObjectData _atlasStatueData;

		public void UnlockObject(FactoryObjectData objectToBeUnlocked)
		{
			if (!_unlockedObjects.Contains(objectToBeUnlocked))
			{
				_unlockedObjects.Add(objectToBeUnlocked);
				_lockedFactoryObjectsUpdatedEvent.Fire(objectToBeUnlocked);
			}
		}

		public void UnlockAll()
		{
			foreach (FactoryObjectData item in FindAllFactoryObjectDatas())
			{
				UnlockObject(item);
			}
		}

		public void LockAll()
		{
			foreach (FactoryObjectData unlockedObject in _unlockedObjects)
			{
				_lockedFactoryObjectsUpdatedEvent.Fire(unlockedObject);
			}
			_unlockedObjects.Clear();
		}

		public void Lock(FactoryObjectData factoryObjectData)
		{
			if (factoryObjectData == null)
			{
				this.LogWarning("Was passed a null factoryObjectData", "Lock", 54);
			}
			else if (_unlockedObjects.Contains(factoryObjectData))
			{
				_unlockedObjects.Remove(factoryObjectData);
				_lockedFactoryObjectsUpdatedEvent.Fire(factoryObjectData);
			}
		}

		public bool IsFactoryObjectLocked(FactoryObjectData factoryObjectData)
		{
			if (!_zenModeSO.Value)
			{
				return !_unlockedObjects.Contains(factoryObjectData);
			}
			return false;
		}

		public override void ResetToDefaults()
		{
			LockAll();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new UnlockedFactoryObjectsSaveData(_unlockedObjects.Select((FactoryObjectData o) => o.ID));
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			LockAll();
			List<int> unlockedObjectsIds = (saveData as UnlockedFactoryObjectsSaveData).UnlockedObjectsIds;
			foreach (FactoryObjectData item in FindAllFactoryObjectDatas())
			{
				if (unlockedObjectsIds.Contains(item.ID))
				{
					_unlockedObjects.Add(item);
					_lockedFactoryObjectsUpdatedEvent.Fire(item);
				}
			}
			if (_gNNGateFinished.Value)
			{
				UnlockObject(_atlasStatueData);
			}
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<UnlockedFactoryObjectsSaveData>(fullPath);
		}

		public static IEnumerable<FactoryObjectData> FindAllFactoryObjectDatas()
		{
			return Resources.FindObjectsOfTypeAll(typeof(FactoryObjectData)).Cast<FactoryObjectData>();
		}
	}
}
