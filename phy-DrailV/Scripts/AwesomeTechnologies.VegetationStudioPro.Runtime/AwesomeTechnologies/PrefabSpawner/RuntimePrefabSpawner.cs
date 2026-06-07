using System;
using System.Collections.Generic;
using AwesomeTechnologies.Common;
using AwesomeTechnologies.VegetationSystem;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.PrefabSpawner
{
	public class RuntimePrefabSpawner : MonoBehaviour
	{
		public VegetationSystemPro VegetationSystemPro;

		public int CurrentTabIndex;

		public int VegetationPackageIndex;

		private Transform _runtimePrefabParent;

		public bool ShowDebugCells;

		public bool ShowRuntimePrefabs;

		private Vector3 _lastFloatingOriginOffset;

		[NonSerialized]
		public VisibleVegetationCellSelector VisibleVegetationCellSelector;

		[NonSerialized]
		public readonly List<VegetationPackageRuntimePrefabInfo> PackageRuntimePrefabInfoList = new List<VegetationPackageRuntimePrefabInfo>();

		private void Reset()
		{
			FindVegetationSystemPro();
		}

		private void FindVegetationSystemPro()
		{
			if (!VegetationSystemPro)
			{
				VegetationSystemPro = GetComponent<VegetationSystemPro>();
			}
		}

		public void RefreshRuntimePrefabs()
		{
			SetupRuntimePrefabSystem();
		}

		private void OnEnable()
		{
			FindVegetationSystemPro();
			SetFloatingOrigin();
			SetupDelegates();
			SetupRuntimePrefabSystem();
		}

		private void SetFloatingOrigin()
		{
			if ((bool)VegetationSystemPro)
			{
				_lastFloatingOriginOffset = VegetationSystemPro.FloatingOriginOffset;
			}
		}

		private void TestFloatingOrigin()
		{
			if ((bool)VegetationSystemPro)
			{
				if (_lastFloatingOriginOffset != VegetationSystemPro.FloatingOriginOffset)
				{
					UpdateFloatingOrigin(VegetationSystemPro.FloatingOriginOffset - _lastFloatingOriginOffset);
				}
				_lastFloatingOriginOffset = VegetationSystemPro.FloatingOriginOffset;
			}
		}

		private void UpdateFloatingOrigin(Vector3 deltaFloatingOriginOffset)
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.RuntimePrefabStorage.UpdateFloatingOrigin(deltaFloatingOriginOffset);
					}
				}
			}
		}

		private void SetupDelegates()
		{
			if ((bool)VegetationSystemPro)
			{
				VegetationSystemPro vegetationSystemPro = VegetationSystemPro;
				vegetationSystemPro.OnRefreshVegetationSystemDelegate = (VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate)Delegate.Combine(vegetationSystemPro.OnRefreshVegetationSystemDelegate, new VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate(OnRefreshVegetationSystem));
				VegetationSystemPro vegetationSystemPro2 = VegetationSystemPro;
				vegetationSystemPro2.OnRefreshRuntimePrefabSpawnerDelegate = (VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate)Delegate.Combine(vegetationSystemPro2.OnRefreshRuntimePrefabSpawnerDelegate, new VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate(OnRefreshVegetationSystem));
				VegetationSystemPro vegetationSystemPro3 = VegetationSystemPro;
				vegetationSystemPro3.OnClearCacheDelegate = (VegetationSystemPro.MultiOnClearCacheDelegate)Delegate.Combine(vegetationSystemPro3.OnClearCacheDelegate, new VegetationSystemPro.MultiOnClearCacheDelegate(OnClearCache));
				VegetationSystemPro vegetationSystemPro4 = VegetationSystemPro;
				vegetationSystemPro4.OnClearCacheVegetationCellDelegate = (VegetationSystemPro.MultiOnClearCacheVegetationCellDelegate)Delegate.Combine(vegetationSystemPro4.OnClearCacheVegetationCellDelegate, new VegetationSystemPro.MultiOnClearCacheVegetationCellDelegate(OnClearCacheVegetationCell));
				VegetationSystemPro vegetationSystemPro5 = VegetationSystemPro;
				vegetationSystemPro5.OnClearCacheVegetationItemDelegate = (VegetationSystemPro.MultiOnClearCacheVegetationItemDelegate)Delegate.Combine(vegetationSystemPro5.OnClearCacheVegetationItemDelegate, new VegetationSystemPro.MultiOnClearCacheVegetationItemDelegate(OnClearCacheVegetationItem));
				VegetationSystemPro vegetationSystemPro6 = VegetationSystemPro;
				vegetationSystemPro6.OnClearCacheVegetationCellVegetatonItemDelegate = (VegetationSystemPro.MultiOnClearCacheVegetationCellVegetationItemDelegate)Delegate.Combine(vegetationSystemPro6.OnClearCacheVegetationCellVegetatonItemDelegate, new VegetationSystemPro.MultiOnClearCacheVegetationCellVegetationItemDelegate(OnClearCacheVegetationCellVegetationItem));
				VegetationSystemPro vegetationSystemPro7 = VegetationSystemPro;
				vegetationSystemPro7.OnRenderCompleteDelegate = (VegetationSystemPro.MultOnRenderCompleteDelegate)Delegate.Combine(vegetationSystemPro7.OnRenderCompleteDelegate, new VegetationSystemPro.MultOnRenderCompleteDelegate(OnRenderComplete));
			}
		}

		private void RemoveDelegates()
		{
			if ((bool)VegetationSystemPro)
			{
				VegetationSystemPro vegetationSystemPro = VegetationSystemPro;
				vegetationSystemPro.OnRefreshVegetationSystemDelegate = (VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate)Delegate.Remove(vegetationSystemPro.OnRefreshVegetationSystemDelegate, new VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate(OnRefreshVegetationSystem));
				VegetationSystemPro vegetationSystemPro2 = VegetationSystemPro;
				vegetationSystemPro2.OnRefreshRuntimePrefabSpawnerDelegate = (VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate)Delegate.Remove(vegetationSystemPro2.OnRefreshRuntimePrefabSpawnerDelegate, new VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate(OnRefreshVegetationSystem));
				VegetationSystemPro vegetationSystemPro3 = VegetationSystemPro;
				vegetationSystemPro3.OnClearCacheDelegate = (VegetationSystemPro.MultiOnClearCacheDelegate)Delegate.Remove(vegetationSystemPro3.OnClearCacheDelegate, new VegetationSystemPro.MultiOnClearCacheDelegate(OnClearCache));
				VegetationSystemPro vegetationSystemPro4 = VegetationSystemPro;
				vegetationSystemPro4.OnClearCacheVegetationCellDelegate = (VegetationSystemPro.MultiOnClearCacheVegetationCellDelegate)Delegate.Remove(vegetationSystemPro4.OnClearCacheVegetationCellDelegate, new VegetationSystemPro.MultiOnClearCacheVegetationCellDelegate(OnClearCacheVegetationCell));
				VegetationSystemPro vegetationSystemPro5 = VegetationSystemPro;
				vegetationSystemPro5.OnClearCacheVegetationItemDelegate = (VegetationSystemPro.MultiOnClearCacheVegetationItemDelegate)Delegate.Remove(vegetationSystemPro5.OnClearCacheVegetationItemDelegate, new VegetationSystemPro.MultiOnClearCacheVegetationItemDelegate(OnClearCacheVegetationItem));
				VegetationSystemPro vegetationSystemPro6 = VegetationSystemPro;
				vegetationSystemPro6.OnClearCacheVegetationCellVegetatonItemDelegate = (VegetationSystemPro.MultiOnClearCacheVegetationCellVegetationItemDelegate)Delegate.Remove(vegetationSystemPro6.OnClearCacheVegetationCellVegetatonItemDelegate, new VegetationSystemPro.MultiOnClearCacheVegetationCellVegetationItemDelegate(OnClearCacheVegetationCellVegetationItem));
				VegetationSystemPro vegetationSystemPro7 = VegetationSystemPro;
				vegetationSystemPro7.OnRenderCompleteDelegate = (VegetationSystemPro.MultOnRenderCompleteDelegate)Delegate.Remove(vegetationSystemPro7.OnRenderCompleteDelegate, new VegetationSystemPro.MultOnRenderCompleteDelegate(OnRenderComplete));
			}
		}

		private void OnDisable()
		{
			DisposeRuntimePrefabSystem();
			RemoveDelegates();
		}

		public void SetRuntimePrefabVisibility(bool value)
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.SetRuntimePrefabVisibility(value);
					}
				}
			}
		}

		private void OnClearCache(VegetationSystemPro vegetationSystemPro)
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.VegetationItemSelector.RefreshAllVegetationCells();
					}
				}
			}
		}

		private void OnClearCacheVegetationCell(VegetationSystemPro vegetationSystemPro, VegetationCell vegetationCell)
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.VegetationItemSelector.RefreshVegetationCell(vegetationCell);
					}
				}
			}
		}

		private void OnClearCacheVegetationItem(VegetationSystemPro vegetationSystemPro, int vegetationPackageIndex, int vegetationItemIndex)
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					if (i == vegetationPackageIndex && j == vegetationItemIndex)
					{
						VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
						for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
						{
							vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.VegetationItemSelector.RefreshAllVegetationCells();
						}
					}
				}
			}
		}

		private void OnClearCacheVegetationCellVegetationItem(VegetationSystemPro vegetationSystemPro, VegetationCell vegetationCell, int vegetationPackageIndex, int vegetationItemIndex)
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					if (i == vegetationPackageIndex && j == vegetationItemIndex)
					{
						VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
						for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
						{
							vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.VegetationItemSelector.RefreshVegetationCell(vegetationCell);
						}
					}
				}
			}
		}

		private void OnRefreshVegetationSystem(VegetationSystemPro vegetationSystemPro)
		{
			SetupRuntimePrefabSystem();
		}

		public void UpdateCullingDistance()
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.UpdateRuntimePrefabDistance();
					}
				}
			}
		}

		public void SetupRuntimePrefabSystem()
		{
			if (!VegetationSystemPro)
			{
				return;
			}
			DisposeRuntimePrefabSystem();
			CreateRuntimePrefabParent();
			VisibleVegetationCellSelector = new VisibleVegetationCellSelector();
			for (int i = 0; i <= VegetationSystemPro.VegetationPackageProList.Count - 1; i++)
			{
				VegetationPackagePro vegetationPackagePro = VegetationSystemPro.VegetationPackageProList[i];
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = new VegetationPackageRuntimePrefabInfo();
				for (int j = 0; j <= vegetationPackagePro.VegetationInfoList.Count - 1; j++)
				{
					VegetationItemInfoPro vegetationItemInfoPro = vegetationPackagePro.VegetationInfoList[j];
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = new VegetationItemRuntimePrefabInfo();
					for (int k = 0; k <= vegetationItemInfoPro.RuntimePrefabRuleList.Count - 1; k++)
					{
						RuntimePrefabRule runtimePrefabRule = vegetationItemInfoPro.RuntimePrefabRuleList[k];
						RuntimePrefabManager item = new RuntimePrefabManager(VisibleVegetationCellSelector, VegetationSystemPro, vegetationItemInfoPro, runtimePrefabRule, _runtimePrefabParent, ShowRuntimePrefabs);
						vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Add(item);
					}
					vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Add(vegetationItemRuntimePrefabInfo);
				}
				PackageRuntimePrefabInfoList.Add(vegetationPackageRuntimePrefabInfo);
			}
			VisibleVegetationCellSelector.Init(VegetationSystemPro);
		}

		private void CreateRuntimePrefabParent()
		{
			GameObject gameObject = new GameObject("Run-time prefabs")
			{
				hideFlags = HideFlags.DontSave
			};
			gameObject.transform.SetParent(base.transform);
			_runtimePrefabParent = gameObject.transform;
		}

		private void DestroyRuntimePrefabParent()
		{
			if ((bool)_runtimePrefabParent)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(_runtimePrefabParent.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(_runtimePrefabParent.gameObject);
				}
			}
		}

		private void OnRenderComplete(VegetationSystemPro vegetationSystemPro)
		{
			if (PackageRuntimePrefabInfoList.Count == 0)
			{
				return;
			}
			TestFloatingOrigin();
			JobHandle processCullingHandle = default(JobHandle);
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						RuntimePrefabManager runtimePrefabManager = vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k];
						if (runtimePrefabManager != null)
						{
							processCullingHandle = runtimePrefabManager.VegetationItemSelector.ProcessInvisibleCells(processCullingHandle);
							processCullingHandle = runtimePrefabManager.VegetationItemSelector.ProcessVisibleCells(processCullingHandle);
							processCullingHandle = runtimePrefabManager.VegetationItemSelector.ProcessCulling(processCullingHandle);
						}
					}
				}
			}
			processCullingHandle.Complete();
			for (int l = 0; l <= PackageRuntimePrefabInfoList.Count - 1; l++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo2 = PackageRuntimePrefabInfoList[l];
				for (int m = 0; m <= vegetationPackageRuntimePrefabInfo2.RuntimePrefabManagerList.Count - 1; m++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo2 = vegetationPackageRuntimePrefabInfo2.RuntimePrefabManagerList[m];
					for (int n = 0; n <= vegetationItemRuntimePrefabInfo2.RuntimePrefabManagerList.Count - 1; n++)
					{
						vegetationItemRuntimePrefabInfo2.RuntimePrefabManagerList[n]?.VegetationItemSelector.ProcessEvents();
					}
				}
			}
		}

		public void DisposeRuntimePrefabSystem()
		{
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k]?.Dispose();
					}
				}
				vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Clear();
			}
			PackageRuntimePrefabInfoList.Clear();
			VisibleVegetationCellSelector?.Dispose();
			VisibleVegetationCellSelector = null;
			DestroyRuntimePrefabParent();
		}

		public int GetLoadedInstanceCount()
		{
			int num = 0;
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						RuntimePrefabManager runtimePrefabManager = vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k];
						num += runtimePrefabManager.VegetationItemSelector.InstanceList.Length;
					}
				}
			}
			return num;
		}

		public int GetVisibleColliders()
		{
			int num = 0;
			for (int i = 0; i <= PackageRuntimePrefabInfoList.Count - 1; i++)
			{
				VegetationPackageRuntimePrefabInfo vegetationPackageRuntimePrefabInfo = PackageRuntimePrefabInfoList[i];
				for (int j = 0; j <= vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; j++)
				{
					VegetationItemRuntimePrefabInfo vegetationItemRuntimePrefabInfo = vegetationPackageRuntimePrefabInfo.RuntimePrefabManagerList[j];
					for (int k = 0; k <= vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList.Count - 1; k++)
					{
						RuntimePrefabManager runtimePrefabManager = vegetationItemRuntimePrefabInfo.RuntimePrefabManagerList[k];
						num += runtimePrefabManager.RuntimePrefabStorage.RuntimePrefabInfoList.Count;
					}
				}
			}
			return num;
		}

		private void OnDrawGizmosSelected()
		{
			if (ShowDebugCells)
			{
				VisibleVegetationCellSelector?.DrawDebugGizmos();
			}
		}
	}
}
