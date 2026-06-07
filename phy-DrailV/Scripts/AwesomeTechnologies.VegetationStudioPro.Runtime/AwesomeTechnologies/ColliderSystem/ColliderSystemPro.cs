using System;
using System.Collections.Generic;
using AwesomeTechnologies.Common;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.ColliderSystem
{
	[AwesomeTechnologiesScriptOrder(105)]
	[ExecuteInEditMode]
	public class ColliderSystemPro : MonoBehaviour
	{
		public delegate void MultiCreateColliderDelegate(GameObject colliderGameObject);

		public delegate void MultiBeforeDestroyColliderDelegate(GameObject colliderGameObject);

		public VegetationSystemPro VegetationSystemPro;

		public bool SetBakedCollidersStatic = true;

		public bool ConvertBakedCollidersToMesh;

		[NonSerialized]
		public VisibleVegetationCellSelector VisibleVegetationCellSelector;

		[NonSerialized]
		public readonly List<VegetationPackageColliderInfo> PackageColliderInfoList = new List<VegetationPackageColliderInfo>();

		public NativeList<JobHandle> JobHandleList;

		public MultiCreateColliderDelegate OnCreateColliderDelegate;

		public MultiBeforeDestroyColliderDelegate OnBeforeDestroyColliderDelegate;

		public int CurrentTabIndex;

		public bool ShowDebugCells;

		private Transform _colliderParent;

		public bool ShowColliders;

		private Vector3 _lastFloatingOriginOffset;

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

		private void OnEnable()
		{
			FindVegetationSystemPro();
			SetFloatingOrigin();
			SetupDelegates();
			SetupColliderSystem();
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
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					vegetationPackageColliderInfo.ColliderManagerList[j]?.RuntimePrefabStorage.UpdateFloatingOrigin(deltaFloatingOriginOffset);
				}
			}
		}

		private void OnCreateCollider(GameObject colliderObject)
		{
			OnCreateColliderDelegate?.Invoke(colliderObject);
		}

		private void OnBeforeDestroyCollider(GameObject colliderObject)
		{
			OnBeforeDestroyColliderDelegate?.Invoke(colliderObject);
		}

		private void SetupDelegates()
		{
			if ((bool)VegetationSystemPro)
			{
				VegetationSystemPro vegetationSystemPro = VegetationSystemPro;
				vegetationSystemPro.OnRefreshVegetationSystemDelegate = (VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate)Delegate.Combine(vegetationSystemPro.OnRefreshVegetationSystemDelegate, new VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate(OnRefreshVegetationSystem));
				VegetationSystemPro vegetationSystemPro2 = VegetationSystemPro;
				vegetationSystemPro2.OnRefreshColliderSystemDelegate = (VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate)Delegate.Combine(vegetationSystemPro2.OnRefreshColliderSystemDelegate, new VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate(OnRefreshVegetationSystem));
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
				vegetationSystemPro2.OnRefreshColliderSystemDelegate = (VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate)Delegate.Remove(vegetationSystemPro2.OnRefreshColliderSystemDelegate, new VegetationSystemPro.MultiOnVegetationStudioRefreshDelegate(OnRefreshVegetationSystem));
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
			DisposeColliderSystem();
			RemoveDelegates();
		}

		public void SetColliderVisibility(bool value)
		{
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					vegetationPackageColliderInfo.ColliderManagerList[j]?.SetColliderVisibility(value);
				}
			}
		}

		private void OnClearCache(VegetationSystemPro vegetationSystemPro)
		{
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					vegetationPackageColliderInfo.ColliderManagerList[j]?.VegetationItemSelector.RefreshAllVegetationCells();
				}
			}
		}

		private void OnClearCacheVegetationCell(VegetationSystemPro vegetationSystemPro, VegetationCell vegetationCell)
		{
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					vegetationPackageColliderInfo.ColliderManagerList[j]?.VegetationItemSelector.RefreshVegetationCell(vegetationCell);
				}
			}
		}

		private void OnClearCacheVegetationItem(VegetationSystemPro vegetationSystemPro, int vegetationPackageIndex, int vegetationItemIndex)
		{
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					if (i == vegetationPackageIndex && j == vegetationItemIndex)
					{
						vegetationPackageColliderInfo.ColliderManagerList[j]?.VegetationItemSelector.RefreshAllVegetationCells();
					}
				}
			}
		}

		private void OnClearCacheVegetationCellVegetationItem(VegetationSystemPro vegetationSystemPro, VegetationCell vegetationCell, int vegetationPackageIndex, int vegetationItemIndex)
		{
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					if (i == vegetationPackageIndex && j == vegetationItemIndex)
					{
						vegetationPackageColliderInfo.ColliderManagerList[j]?.VegetationItemSelector.RefreshVegetationCell(vegetationCell);
					}
				}
			}
		}

		private void OnRefreshVegetationSystem(VegetationSystemPro vegetationSystemPro)
		{
			SetupColliderSystem();
		}

		public void UpdateCullingDistance()
		{
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					vegetationPackageColliderInfo.ColliderManagerList[j]?.UpdateColliderDistance();
				}
			}
		}

		public void SetupColliderSystem()
		{
			if (!VegetationSystemPro)
			{
				return;
			}
			DisposeColliderSystem();
			JobHandleList = new NativeList<JobHandle>(64, Allocator.Persistent);
			CreateColliderParent();
			VisibleVegetationCellSelector = new VisibleVegetationCellSelector();
			for (int i = 0; i <= VegetationSystemPro.VegetationPackageProList.Count - 1; i++)
			{
				VegetationPackagePro vegetationPackagePro = VegetationSystemPro.VegetationPackageProList[i];
				VegetationPackageColliderInfo vegetationPackageColliderInfo = new VegetationPackageColliderInfo();
				for (int j = 0; j <= vegetationPackagePro.VegetationInfoList.Count - 1; j++)
				{
					VegetationItemInfoPro vegetationItemInfoPro = vegetationPackagePro.VegetationInfoList[j];
					if (vegetationItemInfoPro.ColliderType != ColliderType.Disabled)
					{
						ColliderManager colliderManager = new ColliderManager(VisibleVegetationCellSelector, VegetationSystemPro, vegetationItemInfoPro, _colliderParent, ShowColliders);
						colliderManager.OnCreateColliderDelegate = (ColliderManager.MultiCreateColliderDelegate)Delegate.Combine(colliderManager.OnCreateColliderDelegate, new ColliderManager.MultiCreateColliderDelegate(OnCreateCollider));
						colliderManager.OnBeforeDestroyColliderDelegate = (ColliderManager.MultiBeforeDestroyColliderDelegate)Delegate.Combine(colliderManager.OnBeforeDestroyColliderDelegate, new ColliderManager.MultiBeforeDestroyColliderDelegate(OnBeforeDestroyCollider));
						vegetationPackageColliderInfo.ColliderManagerList.Add(colliderManager);
					}
					else
					{
						vegetationPackageColliderInfo.ColliderManagerList.Add(null);
					}
				}
				PackageColliderInfoList.Add(vegetationPackageColliderInfo);
			}
			VisibleVegetationCellSelector.Init(VegetationSystemPro);
		}

		private void CreateColliderParent()
		{
			GameObject gameObject = new GameObject("Run-time colliders")
			{
				hideFlags = HideFlags.DontSave
			};
			gameObject.transform.SetParent(base.transform);
			_colliderParent = gameObject.transform;
		}

		private void DestroyColliderParent()
		{
			if ((bool)_colliderParent)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(_colliderParent.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(_colliderParent.gameObject);
				}
			}
		}

		private void OnRenderComplete(VegetationSystemPro vegetationSystemPro)
		{
			if (PackageColliderInfoList.Count == 0)
			{
				return;
			}
			TestFloatingOrigin();
			JobHandleList.Clear();
			JobHandle jobHandle = default(JobHandle);
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					ColliderManager colliderManager = vegetationPackageColliderInfo.ColliderManagerList[j];
					if (colliderManager != null)
					{
						JobHandle processCullingHandle = jobHandle;
						processCullingHandle = colliderManager.VegetationItemSelector.ProcessInvisibleCells(processCullingHandle);
						processCullingHandle = colliderManager.VegetationItemSelector.ProcessVisibleCells(processCullingHandle);
						processCullingHandle = colliderManager.VegetationItemSelector.ProcessCulling(processCullingHandle);
						JobHandleList.Add(processCullingHandle);
					}
				}
			}
			JobHandle.CombineDependencies(JobHandleList).Complete();
			for (int k = 0; k <= PackageColliderInfoList.Count - 1; k++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo2 = PackageColliderInfoList[k];
				for (int l = 0; l <= vegetationPackageColliderInfo2.ColliderManagerList.Count - 1; l++)
				{
					vegetationPackageColliderInfo2.ColliderManagerList[l]?.VegetationItemSelector.ProcessEvents();
				}
			}
		}

		public void DisposeColliderSystem()
		{
			if (JobHandleList.IsCreated)
			{
				JobHandleList.Dispose();
			}
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					ColliderManager colliderManager = vegetationPackageColliderInfo.ColliderManagerList[j];
					if (colliderManager != null)
					{
						colliderManager.OnCreateColliderDelegate = (ColliderManager.MultiCreateColliderDelegate)Delegate.Remove(colliderManager.OnCreateColliderDelegate, new ColliderManager.MultiCreateColliderDelegate(OnCreateCollider));
						colliderManager.OnBeforeDestroyColliderDelegate = (ColliderManager.MultiBeforeDestroyColliderDelegate)Delegate.Remove(colliderManager.OnBeforeDestroyColliderDelegate, new ColliderManager.MultiBeforeDestroyColliderDelegate(OnBeforeDestroyCollider));
					}
					colliderManager?.Dispose();
				}
				vegetationPackageColliderInfo.ColliderManagerList.Clear();
			}
			PackageColliderInfoList.Clear();
			VisibleVegetationCellSelector?.Dispose();
			VisibleVegetationCellSelector = null;
			DestroyColliderParent();
		}

		public int GetLoadedInstanceCount()
		{
			int num = 0;
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					ColliderManager colliderManager = vegetationPackageColliderInfo.ColliderManagerList[j];
					if (colliderManager != null)
					{
						num += colliderManager.VegetationItemSelector.InstanceList.Length;
					}
				}
			}
			return num;
		}

		public int GetVisibleColliders()
		{
			int num = 0;
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					ColliderManager colliderManager = vegetationPackageColliderInfo.ColliderManagerList[j];
					if (colliderManager != null)
					{
						num += colliderManager.RuntimePrefabStorage.RuntimePrefabInfoList.Count;
					}
				}
			}
			return num;
		}

		public void BakeCollidersToScene()
		{
			for (int i = 0; i <= PackageColliderInfoList.Count - 1; i++)
			{
				VegetationPackageColliderInfo vegetationPackageColliderInfo = PackageColliderInfoList[i];
				VegetationPackagePro vegetationPackagePro = VegetationSystemPro.VegetationPackageProList[i];
				for (int j = 0; j <= vegetationPackageColliderInfo.ColliderManagerList.Count - 1; j++)
				{
					VegetationItemInfoPro vegetationItemInfoPro = vegetationPackagePro.VegetationInfoList[j];
					if (vegetationItemInfoPro.ColliderUseForBake)
					{
						ColliderManager colliderManager = vegetationPackageColliderInfo.ColliderManagerList[j];
						if (colliderManager != null)
						{
							BakeVegetationItemColliders(colliderManager, vegetationItemInfoPro);
						}
					}
				}
			}
		}

		private void BakeVegetationItemColliders(ColliderManager colliderManager, VegetationItemInfoPro vegetationItemInfoPro)
		{
			GC.Collect();
			GameObject gameObject = new GameObject("Baked colliders_" + vegetationItemInfoPro.Name + "_" + vegetationItemInfoPro.VegetationItemID);
			int num = 0;
			for (int i = 0; i <= VegetationSystemPro.VegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = VegetationSystemPro.VegetationCellList[i];
				VegetationSystemPro.SpawnVegetationCell(vegetationCell, vegetationItemInfoPro.VegetationItemID);
				NativeList<MatrixInstance> vegetationItemInstances = VegetationSystemPro.GetVegetationItemInstances(vegetationCell, vegetationItemInfoPro.VegetationItemID);
				for (int j = 0; j <= vegetationItemInstances.Length - 1; j++)
				{
					Matrix4x4 matrix = vegetationItemInstances[j].Matrix;
					Vector3 position = MatrixTools.ExtractTranslationFromMatrix(matrix);
					Vector3 scale = MatrixTools.ExtractScaleFromMatrix(matrix);
					Quaternion rotation = MatrixTools.ExtractRotationFromMatrix(matrix);
					ItemSelectorInstanceInfo info = new ItemSelectorInstanceInfo
					{
						Position = position,
						Scale = scale,
						Rotation = rotation
					};
					GameObject gameObject2 = colliderManager.ColliderPool.GetObject(info);
					gameObject2.hideFlags = HideFlags.None;
					gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: true);
					SetNavmeshArea(gameObject2, vegetationItemInfoPro.NavMeshArea);
					if (SetBakedCollidersStatic)
					{
						SetStatic(gameObject2);
					}
					if (ConvertBakedCollidersToMesh)
					{
						CreateNavMeshColliderMeshes(gameObject2);
					}
					num++;
				}
				vegetationCell.ClearCache();
			}
			VegetationSystemPro.ClearCache(vegetationItemInfoPro.VegetationItemID);
			if (num == 0)
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
		}

		private static void SetNavmeshArea(GameObject go, int navmeshArea)
		{
			foreach (Transform item in go.transform)
			{
				SetNavmeshArea(item.gameObject, navmeshArea);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (ShowDebugCells)
			{
				VisibleVegetationCellSelector?.DrawDebugGizmos();
			}
		}

		private static void CreateNavMeshColliderMeshes(GameObject go)
		{
			Material material = new Material(Shader.Find("Standard"));
			material.SetColor("_Color", Color.gray);
			Collider[] componentsInChildren = go.GetComponentsInChildren<Collider>();
			for (int i = 0; i <= componentsInChildren.Length - 1; i++)
			{
				CapsuleCollider capsuleCollider = componentsInChildren[i] as CapsuleCollider;
				if (capsuleCollider != null)
				{
					CapsuleCollider capsuleCollider2 = capsuleCollider;
					capsuleCollider2.gameObject.AddComponent<MeshFilter>().sharedMesh = MeshUtils.CreateCapsuleMesh(capsuleCollider2.radius, capsuleCollider2.height);
					capsuleCollider2.gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
					switch (capsuleCollider.direction)
					{
					case 0:
						capsuleCollider.transform.rotation = Quaternion.Euler(capsuleCollider.transform.rotation.eulerAngles.x, capsuleCollider.transform.rotation.eulerAngles.y, capsuleCollider.transform.rotation.eulerAngles.z - 90f);
						break;
					case 2:
						capsuleCollider.transform.rotation = Quaternion.Euler(capsuleCollider.transform.rotation.eulerAngles.x - 90f, capsuleCollider.transform.rotation.eulerAngles.y, capsuleCollider.transform.rotation.eulerAngles.z);
						break;
					}
					capsuleCollider.transform.localPosition += new Vector3(capsuleCollider2.center.x * capsuleCollider2.transform.localScale.x, capsuleCollider2.center.y * capsuleCollider2.transform.localScale.y, capsuleCollider2.center.z * capsuleCollider2.transform.localScale.z);
					UnityEngine.Object.DestroyImmediate(capsuleCollider2);
				}
				MeshCollider meshCollider = componentsInChildren[i] as MeshCollider;
				if (meshCollider != null)
				{
					MeshCollider meshCollider2 = meshCollider;
					meshCollider2.gameObject.AddComponent<MeshFilter>().sharedMesh = meshCollider2.sharedMesh;
					meshCollider2.gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
					UnityEngine.Object.DestroyImmediate(meshCollider2);
				}
				BoxCollider boxCollider = componentsInChildren[i] as BoxCollider;
				if (boxCollider != null)
				{
					BoxCollider boxCollider2 = boxCollider;
					boxCollider2.gameObject.AddComponent<MeshFilter>().sharedMesh = MeshUtils.CreateBoxMesh(boxCollider2.size.z, boxCollider2.size.x, boxCollider2.size.y);
					boxCollider2.gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
					boxCollider2.transform.localPosition += new Vector3(boxCollider2.center.x * boxCollider2.transform.localScale.x, boxCollider2.center.y * boxCollider2.transform.localScale.y, boxCollider2.center.z * boxCollider2.transform.localScale.z);
					UnityEngine.Object.DestroyImmediate(boxCollider2);
				}
				SphereCollider sphereCollider = componentsInChildren[i] as SphereCollider;
				if (sphereCollider != null)
				{
					SphereCollider sphereCollider2 = sphereCollider;
					sphereCollider2.gameObject.AddComponent<MeshFilter>().sharedMesh = MeshUtils.CreateSphereMesh(sphereCollider2.radius);
					sphereCollider2.gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
					sphereCollider2.transform.localPosition += new Vector3(sphereCollider2.center.x * sphereCollider2.transform.localScale.x, sphereCollider2.center.y * sphereCollider2.transform.localScale.y, sphereCollider2.center.z * sphereCollider2.transform.localScale.z);
					UnityEngine.Object.DestroyImmediate(sphereCollider2);
				}
			}
		}

		private static void SetStatic(GameObject go)
		{
		}
	}
}
