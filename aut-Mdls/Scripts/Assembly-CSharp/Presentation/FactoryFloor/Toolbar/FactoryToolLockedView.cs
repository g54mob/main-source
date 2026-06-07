using Data.SaveData.PersistentSOs;
using Logic.FactoryTools;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class FactoryToolLockedView : FactoryLockedView
	{
		[SerializeField]
		private LockedFactoryToolsPersistentSO lockedFactoryPersistentSO;

		[SerializeField]
		private FactoryTool _factoryTool;

		[SerializeField]
		private LockedFactoryToolsUpdatedEventSO _lockedFactoryToolsUpdatedEvent;

		protected override void Start()
		{
			if (!(_factoryTool == null))
			{
				base.Start();
				_lockedFactoryToolsUpdatedEvent.Register(HandleLockedUpdated);
			}
		}

		private void HandleLockedUpdated(FactoryTool unlockedFactoryTool)
		{
			if (_factoryTool == unlockedFactoryTool)
			{
				UpdateUnlockVisuals();
			}
		}

		protected override bool GetIsLocked()
		{
			return lockedFactoryPersistentSO.IsFactoryToolLocked(_factoryTool);
		}

		private void OnDestroy()
		{
			_lockedFactoryToolsUpdatedEvent.UnRegister(HandleLockedUpdated);
		}
	}
}
