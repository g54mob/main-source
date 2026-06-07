using System.Collections.Generic;
using System.Linq;
using Logic.Factory;
using Logic.FactoryTools;
using NaughtyAttributes;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Locked Factory Tools", fileName = "LockedFactoryToolsPersistentSO", order = 0)]
	public class LockedFactoryToolsPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private LockedFactoryToolsUpdatedEventSO _lockedFactoryToolsUpdatedEvent;

		[SerializeField]
		private List<FactoryTool> _lockedTools;

		[SerializeField]
		private FactorySaver _factorySaver;

		[Button(null, EButtonEnableMode.Always)]
		private void PersistAllObjectsAsUnlocked()
		{
			ResetToDefaults();
			_factorySaver.SaveFactory(SaveSystem.CreateFullLevelsSavePath("Level"));
		}

		public void UnlockAll()
		{
			foreach (FactoryTool item in new List<FactoryTool>(_lockedTools))
			{
				UnlockTool(item);
			}
			_lockedTools.Clear();
		}

		public void UnlockTool(FactoryTool toolToBeUnlocked)
		{
			if (_lockedTools.Contains(toolToBeUnlocked))
			{
				_lockedTools.Remove(toolToBeUnlocked);
				_lockedFactoryToolsUpdatedEvent.Fire(toolToBeUnlocked);
			}
		}

		public void DebugLockAll()
		{
			_lockedTools = Resources.FindObjectsOfTypeAll(typeof(FactoryTool)).Cast<FactoryTool>().ToList();
			foreach (FactoryTool lockedTool in _lockedTools)
			{
				_lockedFactoryToolsUpdatedEvent.Fire(lockedTool);
			}
		}

		public void Lock(FactoryTool factoryTool)
		{
			if (!_lockedTools.Contains(factoryTool))
			{
				_lockedTools.Add(factoryTool);
				_lockedFactoryToolsUpdatedEvent.Fire(factoryTool);
			}
		}

		public bool IsFactoryToolLocked(FactoryTool tool)
		{
			return _lockedTools.Contains(tool);
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			UnlockAll();
			List<string> lockedToolsNames = (saveData as LockedToolsSaveData)._lockedToolsNames;
			IEnumerable<FactoryTool> enumerable = Resources.FindObjectsOfTypeAll(typeof(FactoryTool)).Cast<FactoryTool>();
			_lockedTools.Clear();
			foreach (string item in lockedToolsNames)
			{
				foreach (FactoryTool item2 in enumerable)
				{
					if (item.Equals(item2.name))
					{
						_lockedTools.Add(item2);
						_lockedFactoryToolsUpdatedEvent.Fire(item2);
						break;
					}
				}
			}
		}

		public override void ResetToDefaults()
		{
			UnlockAll();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new LockedToolsSaveData(_lockedTools.Select((FactoryTool o) => o.name).ToList());
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<LockedToolsSaveData>(fullPath);
		}
	}
}
