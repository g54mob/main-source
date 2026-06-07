using System;
using AwesomeTechnologies.Common;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.PrefabSpawner
{
	public class RuntimePrefabManager
	{
		[NonSerialized]
		public readonly VegetationItemSelector VegetationItemSelector;

		[NonSerialized]
		public readonly RuntimePrefabPool RuntimePrefabPool;

		[NonSerialized]
		public readonly RuntimePrefabStorage RuntimePrefabStorage;

		private readonly VegetationSystemPro _vegetationSystemPro;

		private readonly RuntimePrefabRule _runtimePrefabRule;

		private bool _showPrefabsInHierarchy;

		public RuntimePrefabManager(VisibleVegetationCellSelector visibleVegetationCellSelector, VegetationSystemPro vegetationSystemPro, VegetationItemInfoPro vegetationItemInfoPro, RuntimePrefabRule runtimePrefabRule, Transform prefabParent, bool showPrefabsInHierarchy)
		{
			_showPrefabsInHierarchy = showPrefabsInHierarchy;
			_vegetationSystemPro = vegetationSystemPro;
			_runtimePrefabRule = runtimePrefabRule;
			float cullingDistance = vegetationSystemPro.VegetationSettings.GetVegetationDistance() * runtimePrefabRule.DistanceFactor;
			VegetationItemSelector = new VegetationItemSelector(visibleVegetationCellSelector, vegetationSystemPro, vegetationItemInfoPro, useSpawnChance: true, _runtimePrefabRule.SpawnFrequency, _runtimePrefabRule.Seed)
			{
				CullingDistance = cullingDistance
			};
			VegetationItemSelector vegetationItemSelector = VegetationItemSelector;
			vegetationItemSelector.OnVegetationItemVisibleDelegate = (VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate)Delegate.Combine(vegetationItemSelector.OnVegetationItemVisibleDelegate, new VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate(OnVegetationItemVisible));
			VegetationItemSelector vegetationItemSelector2 = VegetationItemSelector;
			vegetationItemSelector2.OnVegetationItemInvisibleDelegate = (VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate)Delegate.Combine(vegetationItemSelector2.OnVegetationItemInvisibleDelegate, new VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate(OnVegetationItemInvisible));
			VegetationItemSelector vegetationItemSelector3 = VegetationItemSelector;
			vegetationItemSelector3.OnVegetationCellInvisibleDelegate = (VegetationItemSelector.MultiOnVegetationCellVisibilityChangeDelegate)Delegate.Combine(vegetationItemSelector3.OnVegetationCellInvisibleDelegate, new VegetationItemSelector.MultiOnVegetationCellVisibilityChangeDelegate(OnVegetationCellInvisible));
			RuntimePrefabPool = new RuntimePrefabPool(_runtimePrefabRule, vegetationItemInfoPro, prefabParent, _showPrefabsInHierarchy, _vegetationSystemPro);
			RuntimePrefabStorage = new RuntimePrefabStorage(RuntimePrefabPool);
		}

		public void SetRuntimePrefabVisibility(bool value)
		{
			_showPrefabsInHierarchy = value;
			RuntimePrefabStorage.SetPrefabVisibility(value);
		}

		public void UpdateRuntimePrefabDistance()
		{
			float cullingDistance = _vegetationSystemPro.VegetationSettings.GetVegetationDistance() * _runtimePrefabRule.DistanceFactor;
			VegetationItemSelector.CullingDistance = cullingDistance;
		}

		private void OnVegetationItemVisible(ItemSelectorInstanceInfo itemSelectorInstanceInfo, VegetationItemIndexes vegetationItemIndexes, string vegetationItemID)
		{
			GameObject runtimeObject = RuntimePrefabPool.GetObject(itemSelectorInstanceInfo);
			RuntimePrefabStorage.AddRuntimePrefab(runtimeObject, itemSelectorInstanceInfo.VegetationCellIndex, itemSelectorInstanceInfo.VegetationCellItemIndex);
		}

		private void OnVegetationItemInvisible(ItemSelectorInstanceInfo itemSelectorInstanceInfo, VegetationItemIndexes vegetationItemIndexes, string vegetationItemID)
		{
			RuntimePrefabStorage.RemoveRuntimePrefab(itemSelectorInstanceInfo.VegetationCellIndex, itemSelectorInstanceInfo.VegetationCellItemIndex, RuntimePrefabPool);
		}

		private void OnVegetationCellInvisible(int vegetationCellIndex)
		{
			RuntimePrefabStorage.RemoveRuntimePrefab(vegetationCellIndex);
		}

		public void Dispose()
		{
			VegetationItemSelector vegetationItemSelector = VegetationItemSelector;
			vegetationItemSelector.OnVegetationItemVisibleDelegate = (VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate)Delegate.Remove(vegetationItemSelector.OnVegetationItemVisibleDelegate, new VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate(OnVegetationItemVisible));
			VegetationItemSelector vegetationItemSelector2 = VegetationItemSelector;
			vegetationItemSelector2.OnVegetationItemInvisibleDelegate = (VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate)Delegate.Remove(vegetationItemSelector2.OnVegetationItemInvisibleDelegate, new VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate(OnVegetationItemInvisible));
			VegetationItemSelector vegetationItemSelector3 = VegetationItemSelector;
			vegetationItemSelector3.OnVegetationCellInvisibleDelegate = (VegetationItemSelector.MultiOnVegetationCellVisibilityChangeDelegate)Delegate.Remove(vegetationItemSelector3.OnVegetationCellInvisibleDelegate, new VegetationItemSelector.MultiOnVegetationCellVisibilityChangeDelegate(OnVegetationCellInvisible));
			VegetationItemSelector?.Dispose();
			RuntimePrefabStorage?.Dispose();
			RuntimePrefabPool?.Dispose();
		}
	}
}
