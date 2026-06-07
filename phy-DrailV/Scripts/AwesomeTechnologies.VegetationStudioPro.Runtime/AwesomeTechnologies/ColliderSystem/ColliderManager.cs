using System;
using AwesomeTechnologies.Common;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.ColliderSystem
{
	public class ColliderManager
	{
		public delegate void MultiCreateColliderDelegate(GameObject colliderGameObject);

		public delegate void MultiBeforeDestroyColliderDelegate(GameObject colliderGameObject);

		[NonSerialized]
		public readonly VegetationItemSelector VegetationItemSelector;

		[NonSerialized]
		public readonly ColliderPool ColliderPool;

		[NonSerialized]
		public readonly RuntimePrefabStorage RuntimePrefabStorage;

		private readonly VegetationSystemPro _vegetationSystemPro;

		private readonly VegetationItemInfoPro _vegetationItemInfoPro;

		private bool _showColliders;

		public MultiCreateColliderDelegate OnCreateColliderDelegate;

		public MultiBeforeDestroyColliderDelegate OnBeforeDestroyColliderDelegate;

		public ColliderManager(VisibleVegetationCellSelector visibleVegetationCellSelector, VegetationSystemPro vegetationSystemPro, VegetationItemInfoPro vegetationItemInfoPro, Transform colliderParent, bool showColliders)
		{
			_showColliders = showColliders;
			_vegetationSystemPro = vegetationSystemPro;
			_vegetationItemInfoPro = vegetationItemInfoPro;
			float cullingDistance = vegetationSystemPro.VegetationSettings.GetVegetationDistance() * vegetationItemInfoPro.ColliderDistanceFactor;
			VegetationItemSelector = new VegetationItemSelector(visibleVegetationCellSelector, vegetationSystemPro, vegetationItemInfoPro, useSpawnChance: false, 1f, 0)
			{
				CullingDistance = cullingDistance
			};
			VegetationItemSelector vegetationItemSelector = VegetationItemSelector;
			vegetationItemSelector.OnVegetationItemVisibleDelegate = (VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate)Delegate.Combine(vegetationItemSelector.OnVegetationItemVisibleDelegate, new VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate(OnVegetationItemVisible));
			VegetationItemSelector vegetationItemSelector2 = VegetationItemSelector;
			vegetationItemSelector2.OnVegetationItemInvisibleDelegate = (VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate)Delegate.Combine(vegetationItemSelector2.OnVegetationItemInvisibleDelegate, new VegetationItemSelector.MultiOnVegetationItemVisibilityChangeDelegate(OnVegetationItemInvisible));
			VegetationItemSelector vegetationItemSelector3 = VegetationItemSelector;
			vegetationItemSelector3.OnVegetationCellInvisibleDelegate = (VegetationItemSelector.MultiOnVegetationCellVisibilityChangeDelegate)Delegate.Combine(vegetationItemSelector3.OnVegetationCellInvisibleDelegate, new VegetationItemSelector.MultiOnVegetationCellVisibilityChangeDelegate(OnVegetationCellInvisible));
			VegetationItemModelInfo vegetationItemModelInfo = vegetationSystemPro.GetVegetationItemModelInfo(vegetationItemInfoPro.VegetationItemID);
			ColliderPool = new ColliderPool(vegetationItemInfoPro, vegetationItemModelInfo, vegetationSystemPro, colliderParent, _showColliders);
			RuntimePrefabStorage = new RuntimePrefabStorage(ColliderPool);
		}

		public void SetColliderVisibility(bool value)
		{
			_showColliders = value;
			RuntimePrefabStorage.SetPrefabVisibility(value);
			ColliderPool.SetColliderVisibility(value);
		}

		public void UpdateColliderDistance()
		{
			float cullingDistance = _vegetationSystemPro.VegetationSettings.GetVegetationDistance() * _vegetationItemInfoPro.ColliderDistanceFactor;
			VegetationItemSelector.CullingDistance = cullingDistance;
		}

		private void OnVegetationItemVisible(ItemSelectorInstanceInfo itemSelectorInstanceInfo, VegetationItemIndexes vegetationItemIndexes, string vegetationItemID)
		{
			GameObject gameObject = ColliderPool.GetObject(itemSelectorInstanceInfo);
			RuntimePrefabStorage.AddRuntimePrefab(gameObject, itemSelectorInstanceInfo.VegetationCellIndex, itemSelectorInstanceInfo.VegetationCellItemIndex);
			OnCreateColliderDelegate?.Invoke(gameObject);
		}

		private void OnVegetationItemInvisible(ItemSelectorInstanceInfo itemSelectorInstanceInfo, VegetationItemIndexes vegetationItemIndexes, string vegetationItemID)
		{
			if (OnBeforeDestroyColliderDelegate != null)
			{
				GameObject runtimePrefab = RuntimePrefabStorage.GetRuntimePrefab(itemSelectorInstanceInfo.VegetationCellIndex, itemSelectorInstanceInfo.VegetationCellItemIndex);
				OnBeforeDestroyColliderDelegate(runtimePrefab);
			}
			RuntimePrefabStorage.RemoveRuntimePrefab(itemSelectorInstanceInfo.VegetationCellIndex, itemSelectorInstanceInfo.VegetationCellItemIndex, ColliderPool);
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
			ColliderPool?.Dispose();
		}
	}
}
