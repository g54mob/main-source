using System.Collections.Generic;
using System.Linq;
using Data.Buildings;
using Data.Operator;
using Data.Shapes;
using Events.UI.ModuleViewer;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Pinned Modules", fileName = "PinnedModulesPersistentSO", order = 0)]
	public class PinnedModulesPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private PinModuleUIEvent _pinModuleUIEvent;

		[SerializeField]
		private PinnedModulesViewLocator _pinnedModulesViewLocator;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private ModuleChallengeSO _moduleChallengeSo;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			if (_pinnedModulesViewLocator.PinnedModulesBarView != null)
			{
				_pinnedModulesViewLocator.PinnedModulesBarView.DestroyAllPinnedModules();
			}
			if (!(saveData is PinnedModulesSaveData pinnedModulesSaveData))
			{
				return;
			}
			foreach (var pinnedModule in pinnedModulesSaveData.PinnedModules)
			{
				int item = pinnedModule.shapeIndex;
				ModuleViewerData moduleViewerData = _factoryObjectDatabase.BuildingsObjectData.BuildingDatas.FirstOrDefault((BuildingObjectData data) => data != null && data.ID == pinnedModule.objectIndex)?.GetModuleViewerData;
				if (moduleViewerData != null)
				{
					_pinModuleUIEvent.Fire((moduleViewerData, item));
					continue;
				}
				foreach (ModuleChallengeSet set in _moduleChallengeSo.Sets)
				{
					if (set.GetModuleViewerData.FactoryObjectID == pinnedModule.objectIndex)
					{
						_pinModuleUIEvent.Fire((set.GetModuleViewerData, item));
						break;
					}
				}
			}
		}

		public override void ResetToDefaults()
		{
			if (_pinnedModulesViewLocator.PinnedModulesBarView != null)
			{
				_pinnedModulesViewLocator.PinnedModulesBarView.DestroyAllPinnedModules();
			}
		}

		public override AbstractSaveData GetSaveData()
		{
			List<(ModuleViewerData, ShapeData)> pinnedModules = _pinnedModulesViewLocator.PinnedModulesBarView.PinnedModules;
			List<(int, int)> list = new List<(int, int)>();
			foreach (var pinnedModule in pinnedModules)
			{
				int item = pinnedModule.Item1.Modules.FindIndex((ModuleViewerData.ShapeDataAndAmount module) => module.Shape.Data == pinnedModule.Item2);
				int factoryObjectID = pinnedModule.Item1.FactoryObjectID;
				list.Add((factoryObjectID, item));
			}
			return new PinnedModulesSaveData(list);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<PinnedModulesSaveData>(fullPath);
		}
	}
}
