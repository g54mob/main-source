using System;
using System.Collections.Generic;
using AwesomeTechnologies.Common;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class VegetationItemSelector
	{
		public delegate void MultiOnVegetationItemVisibilityChangeDelegate(ItemSelectorInstanceInfo itemSelectorInstanceInfo, VegetationItemIndexes vegetationItemIndexes, string vegetationItemID);

		public delegate void MultiOnVegetationCellVisibilityChangeDelegate(int vegetationCellIndex);

		private readonly VisibleVegetationCellSelector _visibleVegetationCellSelector;

		[NonSerialized]
		public readonly List<VegetationCell> ReadyToLoadVegetationCellList = new List<VegetationCell>();

		[NonSerialized]
		public readonly List<VegetationCell> ReadyToUnloadVegetationCellList = new List<VegetationCell>();

		[NonSerialized]
		public readonly List<VegetationCell> LoadedVegetationCellList = new List<VegetationCell>();

		public NativeList<ItemSelectorInstanceInfo> InstanceList;

		public MultiOnVegetationItemVisibilityChangeDelegate OnVegetationItemVisibleDelegate;

		public MultiOnVegetationItemVisibilityChangeDelegate OnVegetationItemInvisibleDelegate;

		public MultiOnVegetationCellVisibilityChangeDelegate OnVegetationCellInvisibleDelegate;

		private NativeList<int> _removeVegetationCellIndexList;

		private NativeList<int> _visibilityChangedIndexList;

		private readonly VegetationSystemPro _vegetationSystemPro;

		public readonly string VegetationItemID;

		private readonly VegetationItemIndexes _vegetationItemIndexes;

		public float CullingDistance = 50f;

		private readonly bool _useSpawnChance;

		private readonly float _spawnChance;

		private readonly int _spawnSeed;

		public VegetationItemSelector(VisibleVegetationCellSelector visibleVegetationCellSelector, VegetationSystemPro vegetationSystemPro, VegetationItemInfoPro vegetationItemInfoPro, bool useSpawnChance, float spawnChance, int spawnSeed)
		{
			_useSpawnChance = useSpawnChance;
			_spawnChance = spawnChance;
			_spawnSeed = spawnSeed;
			_visibleVegetationCellSelector = visibleVegetationCellSelector;
			_vegetationSystemPro = vegetationSystemPro;
			VegetationItemID = vegetationItemInfoPro.VegetationItemID;
			_vegetationItemIndexes = _vegetationSystemPro.GetVegetationItemIndexes(VegetationItemID);
			VisibleVegetationCellSelector visibleVegetationCellSelector2 = _visibleVegetationCellSelector;
			visibleVegetationCellSelector2.OnVegetationCellVisibleDelegate = (VisibleVegetationCellSelector.MultiOnVegetationCellVisibleDelegate)Delegate.Combine(visibleVegetationCellSelector2.OnVegetationCellVisibleDelegate, new VisibleVegetationCellSelector.MultiOnVegetationCellVisibleDelegate(OnVegetationCellVisible));
			VisibleVegetationCellSelector visibleVegetationCellSelector3 = _visibleVegetationCellSelector;
			visibleVegetationCellSelector3.OnVegetationCellInvisibleDelegate = (VisibleVegetationCellSelector.MultiOnVegetationCellInvisibleDelegate)Delegate.Combine(visibleVegetationCellSelector3.OnVegetationCellInvisibleDelegate, new VisibleVegetationCellSelector.MultiOnVegetationCellInvisibleDelegate(OnVegetationCellInvisible));
			VegetationSystemPro vegetationSystemPro2 = _vegetationSystemPro;
			vegetationSystemPro2.OnVegetationCellLoaded = (VegetationSystemPro.MultiOnVegetationCellSpawnedDelegate)Delegate.Combine(vegetationSystemPro2.OnVegetationCellLoaded, new VegetationSystemPro.MultiOnVegetationCellSpawnedDelegate(OnVegetationCellLoaded));
			InstanceList = new NativeList<ItemSelectorInstanceInfo>(512, Allocator.Persistent);
			_removeVegetationCellIndexList = new NativeList<int>(64, Allocator.Persistent);
			_visibilityChangedIndexList = new NativeList<int>(512, Allocator.Persistent);
		}

		public void Dispose()
		{
			VisibleVegetationCellSelector visibleVegetationCellSelector = _visibleVegetationCellSelector;
			visibleVegetationCellSelector.OnVegetationCellVisibleDelegate = (VisibleVegetationCellSelector.MultiOnVegetationCellVisibleDelegate)Delegate.Remove(visibleVegetationCellSelector.OnVegetationCellVisibleDelegate, new VisibleVegetationCellSelector.MultiOnVegetationCellVisibleDelegate(OnVegetationCellVisible));
			VisibleVegetationCellSelector visibleVegetationCellSelector2 = _visibleVegetationCellSelector;
			visibleVegetationCellSelector2.OnVegetationCellInvisibleDelegate = (VisibleVegetationCellSelector.MultiOnVegetationCellInvisibleDelegate)Delegate.Remove(visibleVegetationCellSelector2.OnVegetationCellInvisibleDelegate, new VisibleVegetationCellSelector.MultiOnVegetationCellInvisibleDelegate(OnVegetationCellInvisible));
			VegetationSystemPro vegetationSystemPro = _vegetationSystemPro;
			vegetationSystemPro.OnVegetationCellLoaded = (VegetationSystemPro.MultiOnVegetationCellSpawnedDelegate)Delegate.Remove(vegetationSystemPro.OnVegetationCellLoaded, new VegetationSystemPro.MultiOnVegetationCellSpawnedDelegate(OnVegetationCellLoaded));
			if (InstanceList.IsCreated)
			{
				InstanceList.Dispose();
			}
			if (_removeVegetationCellIndexList.IsCreated)
			{
				_removeVegetationCellIndexList.Dispose();
			}
			if (_visibilityChangedIndexList.IsCreated)
			{
				_visibilityChangedIndexList.Dispose();
			}
		}

		public void OnVegetationCellLoaded(VegetationCell vegetationCell)
		{
			if (LoadedVegetationCellList.Contains(vegetationCell))
			{
				if (!ReadyToUnloadVegetationCellList.Contains(vegetationCell))
				{
					ReadyToUnloadVegetationCellList.Add(vegetationCell);
				}
				if (!ReadyToLoadVegetationCellList.Contains(vegetationCell))
				{
					ReadyToLoadVegetationCellList.Add(vegetationCell);
				}
			}
		}

		public void OnVegetationCellVisible(VegetationCell vegetationCell)
		{
			ReadyToLoadVegetationCellList.Add(vegetationCell);
		}

		public void OnVegetationCellInvisible(VegetationCell vegetationCell)
		{
			ReadyToUnloadVegetationCellList.Add(vegetationCell);
		}

		public void RefreshVegetationCell(VegetationCell vegetationCell)
		{
			if (LoadedVegetationCellList.Contains(vegetationCell))
			{
				if (!ReadyToUnloadVegetationCellList.Contains(vegetationCell))
				{
					ReadyToUnloadVegetationCellList.Add(vegetationCell);
				}
				if (!ReadyToLoadVegetationCellList.Contains(vegetationCell))
				{
					ReadyToLoadVegetationCellList.Add(vegetationCell);
				}
			}
		}

		public void RefreshAllVegetationCells()
		{
			for (int i = 0; i <= LoadedVegetationCellList.Count - 1; i++)
			{
				VegetationCell item = LoadedVegetationCellList[i];
				if (!ReadyToUnloadVegetationCellList.Contains(item))
				{
					ReadyToUnloadVegetationCellList.Add(item);
				}
				if (!ReadyToLoadVegetationCellList.Contains(item))
				{
					ReadyToLoadVegetationCellList.Add(item);
				}
			}
		}

		public JobHandle ProcessVisibleCells(JobHandle processCullingHandle)
		{
			processCullingHandle = LoadVisibleCells(processCullingHandle);
			return processCullingHandle;
		}

		public JobHandle ProcessInvisibleCells(JobHandle processCullingHandle)
		{
			processCullingHandle = RemoveInvisibleCells(processCullingHandle);
			return processCullingHandle;
		}

		public JobHandle ProcessCulling(JobHandle processCullingHandle)
		{
			processCullingHandle = new ResetVisibilityJob
			{
				InstanceList = InstanceList
			}.Schedule(processCullingHandle);
			for (int i = 0; i <= _vegetationSystemPro.VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCamera vegetationStudioCamera = _vegetationSystemPro.VegetationStudioCameraList[i];
				if (vegetationStudioCamera.Enabled && !(vegetationStudioCamera.SelectedCamera == null))
				{
					processCullingHandle = new DistanceCullingJob
					{
						InstanceList = InstanceList,
						CameraPosition = vegetationStudioCamera.SelectedCamera.transform.position - _vegetationSystemPro.FloatingOriginOffset,
						CullingDistance = CullingDistance
					}.Schedule(processCullingHandle);
				}
			}
			_visibilityChangedIndexList.Clear();
			processCullingHandle = new VisibilityChangedFilterManualJob
			{
				InstanceList = InstanceList,
				VisibilityChangedIndexList = _visibilityChangedIndexList
			}.Schedule(processCullingHandle);
			return processCullingHandle;
		}

		public void ProcessEvents()
		{
			for (int i = 0; i <= _visibilityChangedIndexList.Length - 1; i++)
			{
				ItemSelectorInstanceInfo itemSelectorInstanceInfo = InstanceList[_visibilityChangedIndexList[i]];
				if (itemSelectorInstanceInfo.Visible == 1)
				{
					OnVegetationItemVisibleDelegate?.Invoke(itemSelectorInstanceInfo, _vegetationItemIndexes, VegetationItemID);
				}
				else
				{
					OnVegetationItemInvisibleDelegate?.Invoke(itemSelectorInstanceInfo, _vegetationItemIndexes, VegetationItemID);
				}
			}
		}

		private JobHandle LoadVisibleCells(JobHandle processCullingHandle)
		{
			for (int i = 0; i <= ReadyToLoadVegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = ReadyToLoadVegetationCellList[i];
				if (!vegetationCell.Prepared)
				{
					Debug.Log("Unprepared cell" + vegetationCell.Index);
					continue;
				}
				NativeList<MatrixInstance> matrixInstanceList = vegetationCell.VegetationPackageInstancesList[_vegetationItemIndexes.VegetationPackageIndex].VegetationItemMatrixList[_vegetationItemIndexes.VegetationItemIndex];
				processCullingHandle = ((!_useSpawnChance) ? new AddInstancesJob
				{
					InstanceList = InstanceList,
					MatrixInstanceList = matrixInstanceList,
					VegetationCellIndex = vegetationCell.Index
				}.Schedule(processCullingHandle) : new AddInstancesSpawnChanceJob
				{
					InstanceList = InstanceList,
					RandomNumbers = _vegetationSystemPro.VegetationCellSpawner.RandomNumbers,
					SpawnChance = _spawnChance,
					MatrixInstanceList = matrixInstanceList,
					RandomNumberIndex = vegetationCell.Index + _spawnSeed,
					VegetationCellIndex = vegetationCell.Index
				}.Schedule(processCullingHandle));
				LoadedVegetationCellList.Add(vegetationCell);
			}
			ReadyToLoadVegetationCellList.Clear();
			return processCullingHandle;
		}

		private JobHandle RemoveInvisibleCells(JobHandle processCullingHandle)
		{
			_removeVegetationCellIndexList.Clear();
			bool flag = false;
			for (int i = 0; i <= ReadyToUnloadVegetationCellList.Count - 1; i++)
			{
				_removeVegetationCellIndexList.Add(ReadyToUnloadVegetationCellList[i].Index);
				VegetationCell vegetationCell = ReadyToUnloadVegetationCellList[i];
				int num = LoadedVegetationCellList.IndexOf(ReadyToUnloadVegetationCellList[i]);
				if (num > -1)
				{
					LoadedVegetationCellList.RemoveAtSwapBack(num);
				}
				OnVegetationCellInvisibleDelegate?.Invoke(vegetationCell.Index);
				flag = true;
			}
			ReadyToUnloadVegetationCellList.Clear();
			if (flag)
			{
				processCullingHandle = new FlagInstancesForRemovalJob
				{
					InstanceList = InstanceList,
					RemoveCellIndexList = _removeVegetationCellIndexList
				}.Schedule(processCullingHandle);
				processCullingHandle = new RemoveInstancesJob
				{
					InstanceList = InstanceList
				}.Schedule(processCullingHandle);
			}
			return processCullingHandle;
		}
	}
}
