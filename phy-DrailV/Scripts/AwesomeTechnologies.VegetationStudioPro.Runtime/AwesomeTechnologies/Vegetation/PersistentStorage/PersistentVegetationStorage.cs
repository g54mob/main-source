using System;
using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	[HelpURL("http://www.awesometech.no/index.php/persistent-vegetation-storage")]
	public class PersistentVegetationStorage : MonoBehaviour
	{
		public PersistentVegetationStoragePackage PersistentVegetationStoragePackage;

		public VegetationSystemPro VegetationSystemPro;

		[NonSerialized]
		public int CurrentTabIndex;

		public int SelectedBrushIndex;

		public float BrushSize = 5f;

		public float SampleDistance = 1f;

		public bool RandomizePosition = true;

		public bool PaintOnColliders;

		public bool UseSteepnessRules;

		public bool IgnoreHeight = true;

		public bool DisablePersistentStorage;

		public LayerMask GroundLayerMask;

		public int SelectedVegetationPackageIndex;

		public string SelectedEditVegetationID;

		public string SelectedPaintVegetationID;

		public string SelectedBakeVegetationID;

		public string SelectedStorageVegetationID;

		public string SelectedPrecisionPaintingVegetationID;

		public PrecisionPaintingMode PrecisionPaintingMode = PrecisionPaintingMode.TerrainAndMeshes;

		public List<IVegetationImporter> VegetationImporterList = new List<IVegetationImporter>();

		public int SelectedImporterIndex;

		public bool HasValidPersistentStorage(int cellCount)
		{
			if (PersistentVegetationStoragePackage == null)
			{
				return false;
			}
			if (PersistentVegetationStoragePackage.PersistentVegetationCellList.Count != cellCount)
			{
				return false;
			}
			return true;
		}

		public void SetPersistentVegetationStoragePackage(PersistentVegetationStoragePackage persistentVegetationStoragePackage)
		{
			PersistentVegetationStoragePackage = persistentVegetationStoragePackage;
			if ((bool)VegetationSystemPro)
			{
				VegetationSystemPro.ClearCache();
			}
		}

		public void InitializePersistentStorage()
		{
			if (PersistentVegetationStoragePackage != null)
			{
				PersistentVegetationStoragePackage.ClearPersistentVegetationCells();
				for (int i = 0; i <= VegetationSystemPro.VegetationCellList.Count - 1; i++)
				{
					PersistentVegetationStoragePackage.AddVegetationCell();
				}
			}
		}

		public void InitializePersistentStorage(int cellCount)
		{
			if (PersistentVegetationStoragePackage != null)
			{
				PersistentVegetationStoragePackage.ClearPersistentVegetationCells();
				for (int i = 0; i <= cellCount - 1; i++)
				{
					PersistentVegetationStoragePackage.AddVegetationCell();
				}
			}
		}

		public void AddVegetationItemInstance(string vegetationItemID, Vector3 worldPosition, Vector3 scale, Quaternion rotation, bool applyMeshRotation, byte vegetationSourceID, float distanceFalloff, bool clearCellCache = false)
		{
			if (!VegetationSystemPro || !PersistentVegetationStoragePackage)
			{
				return;
			}
			Rect area = new Rect(new Vector2(worldPosition.x, worldPosition.z), Vector2.zero);
			VegetationItemInfoPro vegetationItemInfo = VegetationSystemPro.GetVegetationItemInfo(vegetationItemID);
			if (applyMeshRotation)
			{
				rotation *= Quaternion.Euler(vegetationItemInfo.RotationOffset);
			}
			List<VegetationCell> list = new List<VegetationCell>();
			VegetationSystemPro.VegetationCellQuadTree.Query(area, list);
			for (int i = 0; i <= list.Count - 1; i++)
			{
				int index = list[i].Index;
				if (clearCellCache)
				{
					VegetationItemIndexes vegetationItemIndexes = VegetationSystemPro.GetVegetationItemIndexes(vegetationItemID);
					VegetationSystemPro.ClearCache(list[i], vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
				}
				PersistentVegetationStoragePackage.AddVegetationItemInstance(index, vegetationItemID, worldPosition - VegetationSystemPro.VegetationSystemPosition, scale, rotation, vegetationSourceID, distanceFalloff);
			}
		}

		public void AddVegetationItemInstanceEx(string vegetationItemID, Vector3 worldPosition, Vector3 scale, Quaternion rotation, byte vegetationSourceID, float minimumDistance, float distanceFalloff, bool clearCellCache = false)
		{
			if (!VegetationSystemPro || !PersistentVegetationStoragePackage || VegetationSystemPro.VegetationCellQuadTree == null)
			{
				return;
			}
			Rect area = new Rect(new Vector2(worldPosition.x, worldPosition.z), Vector2.zero);
			List<VegetationCell> list = new List<VegetationCell>();
			VegetationSystemPro.VegetationCellQuadTree.Query(area, list);
			for (int i = 0; i <= list.Count - 1; i++)
			{
				int index = list[i].Index;
				if (clearCellCache)
				{
					VegetationItemIndexes vegetationItemIndexes = VegetationSystemPro.GetVegetationItemIndexes(vegetationItemID);
					VegetationSystemPro.ClearCache(list[i], vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
				}
				PersistentVegetationStoragePackage.AddVegetationItemInstanceEx(index, vegetationItemID, worldPosition - VegetationSystemPro.VegetationSystemPosition, scale, rotation, vegetationSourceID, minimumDistance, distanceFalloff);
			}
		}

		public void RemoveVegetationItemInstance(string vegetationItemID, Vector3 worldPosition, float minimumDistance, bool clearCellCache = false)
		{
			if (!VegetationSystemPro || !PersistentVegetationStoragePackage)
			{
				return;
			}
			Rect area = new Rect(new Vector2(worldPosition.x, worldPosition.z), Vector2.zero);
			List<VegetationCell> list = new List<VegetationCell>();
			VegetationSystemPro.VegetationCellQuadTree.Query(area, list);
			for (int i = 0; i <= list.Count - 1; i++)
			{
				int index = list[i].Index;
				if (clearCellCache)
				{
					VegetationItemIndexes vegetationItemIndexes = VegetationSystemPro.GetVegetationItemIndexes(vegetationItemID);
					VegetationSystemPro.ClearCache(list[i], vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
				}
				PersistentVegetationStoragePackage.RemoveVegetationItemInstance(index, vegetationItemID, worldPosition - VegetationSystemPro.VegetationSystemPosition, minimumDistance);
			}
		}

		public void RemoveVegetationItemInstance2D(string vegetationItemID, Vector3 worldPosition, float minimumDistance, bool clearCellCache = false)
		{
			if (!VegetationSystemPro || !PersistentVegetationStoragePackage)
			{
				return;
			}
			Rect area = new Rect(new Vector2(worldPosition.x, worldPosition.z), Vector2.zero);
			List<VegetationCell> list = new List<VegetationCell>();
			VegetationSystemPro.VegetationCellQuadTree.Query(area, list);
			for (int i = 0; i <= list.Count - 1; i++)
			{
				int index = list[i].Index;
				if (clearCellCache)
				{
					VegetationItemIndexes vegetationItemIndexes = VegetationSystemPro.GetVegetationItemIndexes(vegetationItemID);
					VegetationSystemPro.ClearCache(list[i], vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
				}
				PersistentVegetationStoragePackage.RemoveVegetationItemInstance2D(index, vegetationItemID, worldPosition - VegetationSystemPro.VegetationSystemPosition, minimumDistance);
			}
		}

		public void RepositionCellItems(int cellIndex, string vegetationItemID)
		{
			PersistentVegetationInfo persistentVegetationInfo = PersistentVegetationStoragePackage.PersistentVegetationCellList[cellIndex].GetPersistentVegetationInfo(vegetationItemID);
			if (persistentVegetationInfo != null)
			{
				List<PersistentVegetationItem> list = new List<PersistentVegetationItem>();
				list.AddRange(persistentVegetationInfo.VegetationItemList);
				persistentVegetationInfo.ClearCell();
				for (int i = 0; i <= list.Count - 1; i++)
				{
					AddVegetationItemInstance(vegetationItemID, list[i].Position + VegetationSystemPro.VegetationSystemPosition, list[i].Scale, list[i].Rotation, applyMeshRotation: false, list[i].VegetationSourceID, list[i].DistanceFalloff, clearCellCache: true);
				}
				VegetationItemIndexes vegetationItemIndexes = VegetationSystemPro.GetVegetationItemIndexes(vegetationItemID);
				VegetationSystemPro.ClearCache(VegetationSystemPro.VegetationCellList[cellIndex], vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
			}
		}

		public int GetPersistentVegetationCellCount()
		{
			if ((bool)PersistentVegetationStoragePackage && PersistentVegetationStoragePackage.PersistentVegetationCellList != null)
			{
				return PersistentVegetationStoragePackage.PersistentVegetationCellList.Count;
			}
			return 0;
		}

		public PersistentVegetationCell GetPersistentVegetationCell(int index)
		{
			if ((bool)PersistentVegetationStoragePackage && PersistentVegetationStoragePackage.PersistentVegetationCellList != null && index < PersistentVegetationStoragePackage.PersistentVegetationCellList.Count)
			{
				return PersistentVegetationStoragePackage.PersistentVegetationCellList[index];
			}
			return null;
		}

		private void Reset()
		{
			VegetationSystemPro = GetComponent<VegetationSystemPro>();
			if ((bool)VegetationSystemPro)
			{
				VegetationSystemPro.DetectPersistentVegetationStorage();
			}
		}

		public void Dispose()
		{
			if ((bool)PersistentVegetationStoragePackage)
			{
				PersistentVegetationStoragePackage.Dispose();
			}
		}

		public void RemoveVegetationItemInstances(string vegetationItemID, byte vegetationSourceID)
		{
			if (!(PersistentVegetationStoragePackage == null))
			{
				PersistentVegetationStoragePackage.RemoveVegetationItemInstances(vegetationItemID, vegetationSourceID);
			}
		}

		public void RemoveVegetationItemInstances(string vegetationItemID)
		{
			if (!(PersistentVegetationStoragePackage == null))
			{
				PersistentVegetationStoragePackage.RemoveVegetationItemInstances(vegetationItemID);
			}
		}

		public void BakeVegetationItem(string vegetationItemID)
		{
			if (!VegetationSystemPro)
			{
				return;
			}
			if (vegetationItemID == "")
			{
				Debug.Log("vegetationItemID empty");
				return;
			}
			GC.Collect();
			VegetationItemInfoPro vegetationItemInfo = VegetationSystemPro.GetVegetationItemInfo(vegetationItemID);
			vegetationItemInfo.EnableRuntimeSpawn = true;
			for (int i = 0; i <= VegetationSystemPro.VegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = VegetationSystemPro.VegetationCellList[i];
				VegetationSystemPro.SpawnVegetationCell(vegetationCell, vegetationItemID);
				NativeList<MatrixInstance> vegetationItemInstances = VegetationSystemPro.GetVegetationItemInstances(vegetationCell, vegetationItemID);
				for (int j = 0; j <= vegetationItemInstances.Length - 1; j++)
				{
					Matrix4x4 matrix = vegetationItemInstances[j].Matrix;
					PersistentVegetationStoragePackage.AddVegetationItemInstance(vegetationCell.Index, vegetationItemID, MatrixTools.ExtractTranslationFromMatrix(matrix) - VegetationSystemPro.VegetationSystemPosition, MatrixTools.ExtractScaleFromMatrix(matrix), MatrixTools.ExtractRotationFromMatrix(matrix), 0, vegetationItemInstances[j].DistanceFalloff);
				}
				vegetationCell.ClearCache();
			}
			VegetationSystemPro.ClearCache(vegetationItemID);
			vegetationItemInfo.EnableRuntimeSpawn = false;
		}
	}
}
