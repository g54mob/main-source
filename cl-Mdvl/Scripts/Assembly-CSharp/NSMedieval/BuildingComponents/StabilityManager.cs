using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class StabilityManager
	{
		private readonly int updateEveryFrames = 5;

		private int finishedBuildingsFrameCounter;

		private int finishedBuildingsGridUpdateCounter;

		private int blueprintBuildingsFrameCounter;

		private int blueprintBuildingsGridUpdateCounter;

		private VillageMap map;

		private VillageSaveData villageSaveData;

		private const string GroundVoxelID = "dirt_voxel";

		private BaseBuildingBlueprint groundBaseModel;

		private byte maxStability;

		private int sizeX;

		private int sizeY;

		private int sizeZ;

		private byte[] blueprintStabilityGrid;

		private BaseBuildingBlueprint[] blueprintBuildingsGrid;

		private byte[] finishedStabilityGrid;

		private BaseBuildingBlueprint[] finishedBuildingsGrid;

		private VillageMap Map => VillageManager.ActiveVillage.Map;

		private BuildingsManagerMain BuildingsManagerMain => Map.BuildingsManagerMain;

		public event Action<Vec3Int, int> FinishedStabilityUpdatedEvent;

		public StabilityManager(VillageMap map)
		{
			this.map = map;
			villageSaveData = GlobalSaveController.CurrentVillageData;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
		}

		public void Dispose()
		{
			this.FinishedStabilityUpdatedEvent = null;
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
		}

		public void InitializeStabilityGrid(VillageMap gridData)
		{
			groundBaseModel = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID("dirt_voxel");
			maxStability = Repository<StabilityRepository, Stability>.Instance.GetByID("basic_stability").MaxStability;
			Vec3Int size = gridData.Size;
			sizeX = size.x;
			sizeY = size.y;
			sizeZ = size.z;
			blueprintStabilityGrid = new byte[sizeX * sizeY * sizeZ];
			finishedStabilityGrid = new byte[sizeX * sizeY * sizeZ];
			blueprintBuildingsGrid = new BaseBuildingBlueprint[sizeX * sizeY * sizeZ];
			finishedBuildingsGrid = new BaseBuildingBlueprint[sizeX * sizeY * sizeZ];
			if (villageSaveData.GroundStabilityArray == null)
			{
				villageSaveData.GroundStabilityArray = new byte[sizeX * sizeY * sizeZ];
			}
			MapNode[] gridSpaceData = gridData.GridSpaceData;
			byte[] groundStabilityArray = villageSaveData.GroundStabilityArray;
			for (int i = 0; i < size.y; i++)
			{
				for (int j = 0; j < size.x; j++)
				{
					for (int k = 0; k < size.z; k++)
					{
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(j, i, k);
						MapNode mapNode = gridSpaceData[num];
						if (mapNode == null)
						{
							Debug.LogError("This should never happen");
						}
						else
						{
							if (mapNode.IsVoxelAir())
							{
								continue;
							}
							byte b = groundStabilityArray[num];
							if (b > 0)
							{
								if (b == maxStability)
								{
									villageSaveData.ClearMaxStability(num);
								}
								if (b != byte.MaxValue)
								{
									blueprintStabilityGrid[num] = b;
									finishedStabilityGrid[num] = b;
								}
								else
								{
									blueprintStabilityGrid[num] = maxStability;
									finishedStabilityGrid[num] = maxStability;
								}
							}
							else
							{
								blueprintStabilityGrid[num] = maxStability;
								finishedStabilityGrid[num] = maxStability;
								SaveGroundStability(mapNode.Index, maxStability);
							}
							blueprintBuildingsGrid[num] = groundBaseModel;
							finishedBuildingsGrid[num] = groundBaseModel;
						}
					}
				}
			}
			MonoSingleton<BuildingPlacementManager>.Instance.Setup(new Vector3(size.x, 0.1f, size.z), new Vector3((float)size.x / 2f, 0f, (float)size.z / 2f));
			MonoSingleton<SelectionManager>.Instance.Setup(new Vector3(size.x, 0.1f, size.z), new Vector3((float)size.x / 2f, 0f, (float)size.z / 2f));
		}

		public void BuildingReplaced(BaseBuildingInstance newBuilding)
		{
			if (newBuilding.ConstructionPhase == ConstructionPhase.Finished)
			{
				foreach (Vec3Int position in newBuilding.Positions)
				{
					int num = GridDataIndexTools.FastTo1DIndex(position);
					blueprintBuildingsGrid[num] = newBuilding.Blueprint;
					finishedBuildingsGrid[num] = newBuilding.Blueprint;
				}
				return;
			}
			foreach (Vec3Int position2 in newBuilding.Positions)
			{
				int num2 = GridDataIndexTools.FastTo1DIndex(position2);
				blueprintBuildingsGrid[num2] = newBuilding.Blueprint;
			}
		}

		public byte GetBlueprintStability(Vec3Int gridPos)
		{
			int num = GridDataIndexTools.FastTo1DIndex(gridPos);
			return blueprintStabilityGrid[num];
		}

		public byte GetFinishedStability(Vec3Int gridPos)
		{
			int num = GridDataIndexTools.FastTo1DIndex(gridPos);
			if (num >= 0 && num < finishedStabilityGrid.Length)
			{
				return finishedStabilityGrid[num];
			}
			return 0;
		}

		private BaseBuildingInstance GetBuilding(Vec3Int gridPos, Func<BaseBuildingInstance, bool> condition)
		{
			return BuildingsManagerMain.GetBuilding(gridPos, condition);
		}

		public void ClearBlueprint(Vec3Int gridPos, BaseBuildingBlueprint blueprint)
		{
			if (GetPlacedBlueprintBuilding(gridPos) == blueprint)
			{
				int num = GridDataIndexTools.FastTo1DIndex(gridPos);
				blueprintBuildingsGrid[num] = null;
			}
		}

		public void ClearGroundVoxel(Vec3Int gridPos)
		{
			int num = GridDataIndexTools.FastTo1DIndex(gridPos);
			finishedStabilityGrid[num] = 0;
			finishedBuildingsGrid[num] = null;
			blueprintStabilityGrid[num] = 0;
			blueprintBuildingsGrid[num] = null;
			SaveGroundStability(num, 0);
		}

		public void GroundRemoved(int x, int y, int z)
		{
			if (GridDataIndexTools.InRange(x, y, z))
			{
				int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
				finishedStabilityGrid[num] = 0;
				finishedBuildingsGrid[num] = null;
				blueprintStabilityGrid[num] = 0;
				blueprintBuildingsGrid[num] = null;
				SaveGroundStability(num, 0);
				UpdateFinishedNeighbors(x, y, z);
				RefreshBlueprintNeighbours(x, y, z);
				this.FinishedStabilityUpdatedEvent?.Invoke(new Vec3Int(x, y, z), 0);
			}
		}

		public int GetBeamStabilityInfoCursor(Vec3Int gridPos)
		{
			if (MonoSingleton<World>.Instance.InsideMap(gridPos))
			{
				return Mathf.Max(GetFinishedStability(gridPos), GetBlueprintStability(gridPos));
			}
			return 0;
		}

		public int GetMaxNeighbourStability(Vec3Int gridPos)
		{
			return Mathf.Max(GetMaxNeighbourBlueprintStability(gridPos), GetMaxNeighbourFinishedStability(gridPos));
		}

		public int GetMaxNeighbourFinishedStability(Vec3Int gridPos)
		{
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			pooledList.Add(gridPos + Vec3Int.left);
			pooledList.Add(gridPos + Vec3Int.right);
			pooledList.Add(gridPos + Vec3Int.back);
			pooledList.Add(gridPos + Vec3Int.forward);
			int num = 0;
			foreach (Vec3Int item in pooledList)
			{
				if (MonoSingleton<World>.Instance.InsideMap(item))
				{
					int finishedStability = GetFinishedStability(item);
					if (finishedStability > num)
					{
						num = finishedStability;
					}
				}
			}
			Vec3Int vec3Int = gridPos + Vec3Int.down;
			if (MonoSingleton<World>.Instance.InsideMap(vec3Int))
			{
				return Mathf.Clamp(0, Mathf.Max(num - 1, GetFinishedStability(vec3Int)), maxStability);
			}
			return Mathf.Clamp(0, num - 1, maxStability);
		}

		public int GetMaxNeighbourBlueprintStability(Vec3Int gridPos)
		{
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			pooledList.Add(gridPos + Vec3Int.left);
			pooledList.Add(gridPos + Vec3Int.right);
			pooledList.Add(gridPos + Vec3Int.back);
			pooledList.Add(gridPos + Vec3Int.forward);
			int num = 0;
			foreach (Vec3Int item in pooledList)
			{
				if (MonoSingleton<World>.Instance.InsideMap(item))
				{
					int blueprintStability = GetBlueprintStability(item);
					if (blueprintStability > num)
					{
						num = blueprintStability;
					}
				}
			}
			Vec3Int vec3Int = gridPos + Vec3Int.down;
			if (MonoSingleton<World>.Instance.InsideMap(vec3Int))
			{
				return Mathf.Clamp(0, Mathf.Max(num - 1, GetBlueprintStability(vec3Int)), maxStability);
			}
			return Mathf.Clamp(0, num - 1, maxStability);
		}

		private byte CalculateBlueprintStability(int x, int y, int z)
		{
			if (y == 0)
			{
				return maxStability;
			}
			Vec3Int a = new Vec3Int(x, y, z);
			byte val = 0;
			byte b = 0;
			BaseBuildingBlueprint placedBlueprintBuilding = GetPlacedBlueprintBuilding(x, y - 1, z);
			if (placedBlueprintBuilding != null && placedBlueprintBuilding.HasVerticalStability())
			{
				int num = GridDataIndexTools.FastTo1DIndex(x, y - 1, z);
				b = blueprintStabilityGrid[num];
			}
			BaseBuildingBlueprint placedFinishedBuilding = GetPlacedFinishedBuilding(x, y - 1, z);
			if (placedFinishedBuilding != null && placedFinishedBuilding.HasVerticalStability())
			{
				int num2 = GridDataIndexTools.FastTo1DIndex(x, y - 1, z);
				b = Math.Max(b, finishedStabilityGrid[num2]);
			}
			BeamComponentInstance componentInstance = Map.BeamComponentManager.GetComponentInstance(a + Vec3Int.down);
			if (componentInstance != null)
			{
				b = Math.Max(b, (byte)componentInstance.OwnerBuilding.Stability);
			}
			List<Vec3Int> list = new List<Vec3Int>
			{
				a + Vec3Int.left,
				a + Vec3Int.right,
				a + Vec3Int.back,
				a + Vec3Int.forward
			};
			BeamComponentInstance componentInstance2 = Map.BeamComponentManager.GetComponentInstance(a + Vec3Int.down);
			Vec3Int[] array = list.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				Vec3Int a2 = array[i];
				BeamComponentInstance componentInstance3 = Map.BeamComponentManager.GetComponentInstance(a2 + Vec3Int.down);
				if (componentInstance3 != null && !componentInstance3.HasDisposed && componentInstance2 != componentInstance3 && GetPlacedBlueprintBuilding(a2) == null && GetPlacedFinishedBuilding(a2) == null && !MonoSingleton<GroundManager>.Instance.GroundExists(a2))
				{
					list.Remove(a2);
				}
			}
			foreach (Vec3Int item in list)
			{
				int num3 = GridDataIndexTools.FastTo1DIndex(item);
				if (GetPlacedBlueprintBuilding(item) != null)
				{
					val = (byte)Math.Max(val, Mathf.Clamp(blueprintStabilityGrid[num3] - 1, 0, maxStability));
				}
				if (GetPlacedFinishedBuilding(item) != null)
				{
					val = (byte)Math.Max(val, Mathf.Clamp(finishedStabilityGrid[num3] - 1, 0, maxStability));
				}
			}
			return Math.Max(val, b);
		}

		private void SaveGroundStability(int x, int y, int z, byte stability)
		{
			if (stability != maxStability)
			{
				villageSaveData.SaveGroundStability(new Vec3Int(x, y, z), stability);
			}
		}

		private void SaveGroundStability(Vec3Int gridPos, byte stability)
		{
			if (stability == maxStability)
			{
				villageSaveData.ClearMaxStability(gridPos);
			}
			else
			{
				villageSaveData.SaveGroundStability(gridPos, stability);
			}
		}

		private void SaveGroundStability(int nodeIndex, byte stability)
		{
			if (stability == maxStability)
			{
				villageSaveData.ClearMaxStability(nodeIndex);
			}
			else
			{
				villageSaveData.SaveGroundStability(nodeIndex, stability);
			}
		}

		private byte CalculateFinishedStability(int x, int y, int z)
		{
			if (y == 0)
			{
				return maxStability;
			}
			Vec3Int a = new Vec3Int(x, y, z);
			byte val = 0;
			byte b = 0;
			BaseBuildingBlueprint placedFinishedBuilding = GetPlacedFinishedBuilding(x, y - 1, z);
			if (placedFinishedBuilding != null && placedFinishedBuilding.HasVerticalStability())
			{
				int num = GridDataIndexTools.FastTo1DIndex(x, y - 1, z);
				b = finishedStabilityGrid[num];
			}
			BeamComponentInstance componentInstance = Map.BeamComponentManager.GetComponentInstance(a + Vec3Int.down);
			if (componentInstance != null && componentInstance.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished)
			{
				b = Math.Max(b, (byte)componentInstance.OwnerBuilding.Stability);
			}
			List<Vec3Int> list = new List<Vec3Int>
			{
				a + Vec3Int.left,
				a + Vec3Int.right,
				a + Vec3Int.back,
				a + Vec3Int.forward
			};
			BeamComponentInstance componentInstance2 = Map.BeamComponentManager.GetComponentInstance(a + Vec3Int.down);
			Vec3Int[] array = list.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				Vec3Int a2 = array[i];
				BeamComponentInstance componentInstance3 = Map.BeamComponentManager.GetComponentInstance(a2 + Vec3Int.down);
				if (componentInstance3 != null && !componentInstance3.HasDisposed && componentInstance2 != componentInstance3 && GetPlacedFinishedBuilding(a2) == null && !MonoSingleton<GroundManager>.Instance.GroundExists(a2))
				{
					list.Remove(a2);
				}
			}
			foreach (Vec3Int item in list)
			{
				if (GetPlacedFinishedBuilding(item) != null)
				{
					int num2 = GridDataIndexTools.FastTo1DIndex(item);
					val = (byte)Math.Max(val, Mathf.Clamp(finishedStabilityGrid[num2] - 1, 0, maxStability));
				}
			}
			return Math.Max(val, b);
		}

		public void RemoveBlueprint(int x, int y, int z)
		{
			int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
			blueprintStabilityGrid[num] = 0;
			blueprintBuildingsGrid[num] = null;
			Map.BuildingsManagerMain.DestroyBuildingStabilityZero(x, y, z);
			RefreshBlueprintNeighbours(x, y, z);
		}

		public void RemoveFinished(int x, int y, int z)
		{
			int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
			finishedStabilityGrid[num] = 0;
			finishedBuildingsGrid[num] = null;
			Map.BuildingsManagerMain.DestroyBuildingStabilityZero(x, y, z);
			UpdateFinishedNeighbors(x, y, z);
			RefreshBlueprintNeighbours(x, y, z);
		}

		private void UpdateBlueprintNeighbors(Vec3Int gridPos)
		{
			RefreshBlueprintNeighbours(gridPos.x, gridPos.y, gridPos.z);
		}

		private void UpdateBlueprintNeighborsFast(int x, int y, int z, bool skipGround = false)
		{
			if (GetPlacedFinishedBuilding(x - 1, y, z) == null)
			{
				UpdateBlueprintNeighbor(x - 1, y, z, skipGround);
			}
			if (GetPlacedFinishedBuilding(x + 1, y, z) == null)
			{
				UpdateBlueprintNeighbor(x + 1, y, z, skipGround);
			}
			if (GetPlacedFinishedBuilding(x, y, z - 1) == null)
			{
				UpdateBlueprintNeighbor(x, y, z - 1, skipGround);
			}
			if (GetPlacedFinishedBuilding(x, y, z + 1) == null)
			{
				UpdateBlueprintNeighbor(x, y, z + 1, skipGround);
			}
			if (GetPlacedFinishedBuilding(x, y + 1, z) == null)
			{
				UpdateBlueprintNeighbor(x, y + 1, z, skipGround);
			}
		}

		private void UpdateFinishedNeighbors(Vec3Int gridPos)
		{
			UpdateFinishedNeighbors(gridPos.x, gridPos.y, gridPos.z);
		}

		private void UpdateFinishedNeighbors(int x, int y, int z)
		{
			if (GetPlacedFinishedBuilding(x - 1, y, z) != null)
			{
				villageSaveData.EnqueueFinished(new QueuedStabilityCalculationInfo(new Vec3Int(x - 1, y, z), skipGround: false));
			}
			if (GetPlacedFinishedBuilding(x + 1, y, z) != null)
			{
				villageSaveData.EnqueueFinished(new QueuedStabilityCalculationInfo(new Vec3Int(x + 1, y, z), skipGround: false));
			}
			if (GetPlacedFinishedBuilding(x, y, z - 1) != null)
			{
				villageSaveData.EnqueueFinished(new QueuedStabilityCalculationInfo(new Vec3Int(x, y, z - 1), skipGround: false));
			}
			if (GetPlacedFinishedBuilding(x, y, z + 1) != null)
			{
				villageSaveData.EnqueueFinished(new QueuedStabilityCalculationInfo(new Vec3Int(x, y, z + 1), skipGround: false));
			}
			if (GetPlacedFinishedBuilding(x, y + 1, z) != null)
			{
				villageSaveData.EnqueueFinished(new QueuedStabilityCalculationInfo(new Vec3Int(x, y + 1, z), skipGround: false));
			}
		}

		private void RefreshBlueprintNeighbours(int x, int y, int z)
		{
			if (GetPlacedBlueprintBuilding(x - 1, y, z) != null)
			{
				villageSaveData.EnqueueBlueprint(new QueuedStabilityCalculationInfo(new Vec3Int(x - 1, y, z), skipGround: false));
			}
			if (GetPlacedBlueprintBuilding(x + 1, y, z) != null)
			{
				villageSaveData.EnqueueBlueprint(new QueuedStabilityCalculationInfo(new Vec3Int(x + 1, y, z), skipGround: false));
			}
			if (GetPlacedBlueprintBuilding(x, y, z - 1) != null)
			{
				villageSaveData.EnqueueBlueprint(new QueuedStabilityCalculationInfo(new Vec3Int(x, y, z - 1), skipGround: false));
			}
			if (GetPlacedBlueprintBuilding(x, y, z + 1) != null)
			{
				villageSaveData.EnqueueBlueprint(new QueuedStabilityCalculationInfo(new Vec3Int(x, y, z + 1), skipGround: false));
			}
			if (GetPlacedBlueprintBuilding(x, y + 1, z) != null)
			{
				villageSaveData.EnqueueBlueprint(new QueuedStabilityCalculationInfo(new Vec3Int(x, y + 1, z), skipGround: false));
			}
		}

		private BaseBuildingBlueprint GetPlacedBlueprintBuilding(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return null;
			}
			int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
			return blueprintBuildingsGrid[num];
		}

		private BaseBuildingBlueprint GetPlacedBlueprintBuilding(Vec3Int gridPos)
		{
			if (!GridDataIndexTools.InRange(gridPos))
			{
				return null;
			}
			int num = GridDataIndexTools.FastTo1DIndex(gridPos);
			return blueprintBuildingsGrid[num];
		}

		private BaseBuildingBlueprint GetPlacedFinishedBuilding(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return null;
			}
			int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
			return finishedBuildingsGrid[num];
		}

		private BaseBuildingBlueprint GetPlacedFinishedBuilding(Vec3Int gridPos)
		{
			if (!GridDataIndexTools.InRange(gridPos))
			{
				return null;
			}
			int num = GridDataIndexTools.FastTo1DIndex(gridPos);
			return finishedBuildingsGrid[num];
		}

		private void UpdateBlueprintNeighbor(Vec3Int gridPos)
		{
			UpdateBlueprintNeighbor(gridPos.x, gridPos.y, gridPos.z);
		}

		private void UpdateBlueprintNeighbor(int x, int y, int z, bool skipGround = false)
		{
			BaseBuildingBlueprint placedBlueprintBuilding = GetPlacedBlueprintBuilding(x, y, z);
			if (placedBlueprintBuilding == null || (skipGround && MonoSingleton<GroundManager>.Instance.GroundExists(new Vec3Int(x, y, z))))
			{
				return;
			}
			BaseBuildingBlueprint placedFinishedBuilding = GetPlacedFinishedBuilding(x, y, z);
			if ((placedFinishedBuilding != null && placedFinishedBuilding != placedBlueprintBuilding && placedBlueprintBuilding != groundBaseModel) || x < 0 || x >= sizeX || y < 0 || y >= sizeY || z < 0 || z >= sizeZ)
			{
				return;
			}
			byte b = CalculateBlueprintStability(x, y, z);
			int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
			if (b == blueprintStabilityGrid[num])
			{
				if (b == 0)
				{
					RemoveBlueprint(x, y, z);
				}
				return;
			}
			blueprintStabilityGrid[num] = b;
			Map.BuildingsManagerMain.SetStability(x, y, z, b);
			if (b == 0)
			{
				RemoveBlueprint(x, y, z);
			}
			else
			{
				RefreshBlueprintNeighbours(x, y, z);
			}
		}

		private void UpdateFinishedNeighbor(int x, int y, int z)
		{
			if (GetPlacedFinishedBuilding(x, y, z) == null || x < 0 || x >= sizeX || y < 0 || y >= sizeY || z < 0 || z >= sizeZ)
			{
				return;
			}
			byte b = CalculateFinishedStability(x, y, z);
			int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
			if (b == finishedStabilityGrid[num])
			{
				if (b == 0)
				{
					RemoveFinished(x, y, z);
				}
				return;
			}
			Vec3Int gridPos = new Vec3Int(x, y, z);
			if (GetPlacedFinishedBuilding(gridPos) == groundBaseModel)
			{
				SaveGroundStability(num, b);
			}
			finishedStabilityGrid[num] = b;
			this.FinishedStabilityUpdatedEvent?.Invoke(new Vec3Int(x, y, z), b);
			Map.BuildingsManagerMain.SetStability(x, y, z, b);
			if (b == 0)
			{
				RemoveFinished(x, y, z);
			}
			else
			{
				UpdateFinishedNeighbors(x, y, z);
			}
		}

		public void AddBuildingAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance.Blueprint.BuildingType != BuildingType.Beam)
			{
				int num = GridDataIndexTools.FastTo1DIndex(baseBuildingInstance.GridDataPosition);
				blueprintStabilityGrid[num] = (byte)baseBuildingInstance.Stability;
				blueprintBuildingsGrid[num] = baseBuildingInstance.Blueprint;
				if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished)
				{
					finishedStabilityGrid[num] = (byte)baseBuildingInstance.Stability;
					finishedBuildingsGrid[num] = baseBuildingInstance.Blueprint;
				}
			}
		}

		public void PlaceBlueprints(List<BaseBuildingViewComponent> buildings)
		{
			for (int i = 0; i < buildings.Count; i++)
			{
				AddBlueprintBuilding(buildings[i].BaseBuildingInstance);
			}
			foreach (BaseBuildingViewComponent item in buildings.IterateInReverseDynamic())
			{
				AddBlueprintBuilding(item.BaseBuildingInstance);
			}
		}

		public void PlaceBlueprint(BaseBuildingViewComponent building)
		{
			AddBlueprintBuilding(building.BaseBuildingInstance);
		}

		public void BeamPlaced(BeamComponentInstance beam)
		{
			byte val = ((beam.StartBuilding != null) ? GetBlueprintStability(beam.StartBuilding.GridDataPosition) : GetBlueprintStability(beam.StartSocketGridPosition));
			byte val2 = ((beam.EndBuilding != null) ? GetBlueprintStability(beam.EndBuilding.GridDataPosition) : GetBlueprintStability(beam.EndSocketGridPosition));
			byte b = Math.Min(val, val2);
			beam.OwnerBuilding.SetStability(b);
			foreach (Vec3Int position in beam.Positions)
			{
				int num = GridDataIndexTools.FastTo1DIndex(position);
				blueprintStabilityGrid[num] = b;
				Map.BuildingsManagerMain.SetStability(position.x, position.y, position.z, b);
				RefreshBlueprintNeighbours(position.x, position.y, position.z);
			}
		}

		public void AddBlueprintBuilding(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance.Blueprint.BuildingType != BuildingType.Beam)
			{
				AddBlueprintBuilding(baseBuildingInstance.Blueprint, baseBuildingInstance.GridDataPosition);
			}
		}

		public void AddBlueprintBuilding(BaseBuildingBlueprint baseBuildingBlueprint, Vec3Int gridPos)
		{
			int num = GridDataIndexTools.FastTo1DIndex(gridPos);
			blueprintBuildingsGrid[num] = baseBuildingBlueprint;
			byte b = CalculateBlueprintStability(gridPos.x, gridPos.y, gridPos.z);
			blueprintStabilityGrid[num] = b;
			Map.BuildingsManagerMain.SetStability(gridPos.x, gridPos.y, gridPos.z, b);
			UpdateBlueprintNeighborsFast(gridPos.x, gridPos.y, gridPos.z, skipGround: true);
		}

		private void AddConstructedBuilding(BaseBuildingInstance baseBuildingInstance)
		{
			AddConstructedBuilding(baseBuildingInstance.Blueprint, baseBuildingInstance.GridDataPosition);
		}

		public void AddConstructedBuilding(BaseBuildingBlueprint baseBuildingBlueprint, Vec3Int gridPos)
		{
			if (baseBuildingBlueprint.BuildingType != BuildingType.Beam)
			{
				int num = GridDataIndexTools.FastTo1DIndex(gridPos);
				finishedBuildingsGrid[num] = baseBuildingBlueprint;
				byte b = CalculateFinishedStability(gridPos.x, gridPos.y, gridPos.z);
				finishedStabilityGrid[num] = b;
				Map.BuildingsManagerMain.SetStability(gridPos.x, gridPos.y, gridPos.z, b);
				UpdateFinishedNeighbors(gridPos.x, gridPos.y, gridPos.z);
				RefreshBlueprintNeighbours(gridPos.x, gridPos.y, gridPos.z);
				if (baseBuildingBlueprint == groundBaseModel)
				{
					SaveGroundStability(num, b);
				}
			}
		}

		public void BuildingConstructed(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance.Blueprint.TransfersStability())
			{
				Vec3Int gridDataPosition = baseBuildingInstance.GridDataPosition;
				AddConstructedBuilding(baseBuildingInstance);
				UpdateBlueprintNeighbor(gridDataPosition.x, gridDataPosition.y, gridDataPosition.z);
			}
		}

		public void BeamConstructed(BeamComponentInstance beam, bool afterLoading = false)
		{
			foreach (Vec3Int position in beam.Positions)
			{
				Vec3Int a = position;
				int num = GridDataIndexTools.FastTo1DIndex(a + Vec3Int.up);
				if (num >= 0 && num < finishedStabilityGrid.Length)
				{
					finishedStabilityGrid[num] = (byte)beam.OwnerBuilding.Stability;
					Map.BuildingsManagerMain.SetStability(a.x, a.y + 1, a.z, beam.OwnerBuilding.Stability);
					if (!afterLoading)
					{
						UpdateFinishedNeighbors(a + Vec3Int.up);
						UpdateBlueprintNeighbor(a + Vec3Int.up);
					}
				}
			}
		}

		public void BeamStabilityChanged(BeamComponentInstance beam)
		{
			if (beam.HasDisposed || beam.OwnerBuilding == null || beam.OwnerBuilding.HasDisposed)
			{
				return;
			}
			int val;
			int val2;
			if (beam.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished)
			{
				val = ((beam.StartBuilding != null) ? GetFinishedStability(beam.StartBuilding.GridDataPosition) : GetFinishedStability(beam.StartSocketGridPosition));
				val2 = ((beam.EndBuilding != null) ? GetFinishedStability(beam.EndBuilding.GridDataPosition) : GetFinishedStability(beam.EndSocketGridPosition));
			}
			else
			{
				val = ((beam.StartBuilding != null) ? GetBlueprintStability(beam.StartBuilding.GridDataPosition) : GetBlueprintStability(beam.StartSocketGridPosition));
				val2 = ((beam.EndBuilding != null) ? GetBlueprintStability(beam.EndBuilding.GridDataPosition) : GetBlueprintStability(beam.EndSocketGridPosition));
			}
			int num = Math.Min(val, val2);
			if (beam.OwnerBuilding.Stability == num)
			{
				return;
			}
			beam.OwnerBuilding.SetStability(num);
			if (beam.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished)
			{
				foreach (Vec3Int position in beam.Positions)
				{
					Vec3Int a = position;
					if (beam.OwnerBuilding != null)
					{
						int num2 = GridDataIndexTools.FastTo1DIndex(a);
						finishedStabilityGrid[num2] = (byte)beam.OwnerBuilding.Stability;
						UpdateFinishedNeighbors(a + Vec3Int.up);
						UpdateBlueprintNeighbor(a + Vec3Int.up);
					}
				}
				return;
			}
			foreach (Vec3Int position2 in beam.Positions)
			{
				Vec3Int a2 = position2;
				if (beam.OwnerBuilding != null)
				{
					int num3 = GridDataIndexTools.FastTo1DIndex(a2);
					blueprintStabilityGrid[num3] = (byte)num;
					UpdateBlueprintNeighbors(a2 + Vec3Int.up);
				}
			}
		}

		public void BuildingDestroyed(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance.Blueprint.BuildingType == BuildingType.Beam)
			{
				return;
			}
			foreach (Vec3Int position in baseBuildingInstance.Positions)
			{
				int num = GridDataIndexTools.FastTo1DIndex(position);
				if (GetPlacedFinishedBuilding(position) == baseBuildingInstance.Blueprint)
				{
					finishedStabilityGrid[num] = 0;
					finishedBuildingsGrid[num] = null;
					UpdateFinishedNeighbors(position);
				}
				if (GetPlacedBlueprintBuilding(position) == baseBuildingInstance.Blueprint)
				{
					blueprintStabilityGrid[num] = 0;
					blueprintBuildingsGrid[num] = null;
					UpdateBlueprintNeighbors(position);
				}
			}
		}

		public void BeamDestroyed(BeamComponentInstance beam)
		{
			if (beam.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished)
			{
				foreach (Vec3Int position in beam.Positions)
				{
					Vec3Int a = position;
					if (GetPlacedFinishedBuilding(a + Vec3Int.up) != null)
					{
						villageSaveData.EnqueueFinished(new QueuedStabilityCalculationInfo(a + Vec3Int.up, skipGround: false));
					}
				}
				return;
			}
			foreach (Vec3Int position2 in beam.Positions)
			{
				Vec3Int a2 = position2;
				if (GetPlacedFinishedBuilding(a2 + Vec3Int.up) == null)
				{
					villageSaveData.EnqueueBlueprint(new QueuedStabilityCalculationInfo(a2 + Vec3Int.up, skipGround: true));
				}
			}
		}

		private bool IndexOutOfRange<T>(Vec3Int gridPos, T[,,] grid)
		{
			return IndexOutOfRange(gridPos.x, gridPos.y, gridPos.z, grid);
		}

		private bool IndexOutOfRange<T>(int x, int y, int z, T[,,] grid)
		{
			if (grid == null || x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1) || z < 0 || z >= grid.GetLength(2))
			{
				return true;
			}
			return false;
		}

		private void OnLoadingComplete()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
		}

		private void OnTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("StabilityManager.Tick"))
			{
				if (villageSaveData.DestructionQueue.Count <= 0)
				{
					TickFinishedBuildingsUpdate();
					TickBlueprintBuildingsUpdate();
				}
			}
		}

		private void TickFinishedBuildingsUpdate()
		{
			using (ProfilerSampleJanitor.Begin("StabilityManager.TickFinishedBuildings"))
			{
				if (villageSaveData.GetFinishedStabilityCalculationQueueCount == 0)
				{
					return;
				}
				finishedBuildingsFrameCounter++;
				if (finishedBuildingsFrameCounter != updateEveryFrames)
				{
					return;
				}
				finishedBuildingsFrameCounter = 0;
				while (villageSaveData.GetFinishedStabilityCalculationQueueCount > 0)
				{
					finishedBuildingsGridUpdateCounter++;
					if (finishedBuildingsGridUpdateCounter == 50)
					{
						break;
					}
					QueuedStabilityCalculationInfo queuedStabilityCalculationInfo = villageSaveData.DequeueFinished();
					UpdateFinishedNeighbor(queuedStabilityCalculationInfo.Position.x, queuedStabilityCalculationInfo.Position.y, queuedStabilityCalculationInfo.Position.z);
				}
				finishedBuildingsGridUpdateCounter = 0;
			}
		}

		private void TickBlueprintBuildingsUpdate()
		{
			using (ProfilerSampleJanitor.Begin("StabilityManager.TickBlueprintBuildingsUpdate"))
			{
				if (villageSaveData.GetBlueprintStabilityCalculationQueueCount == 0)
				{
					return;
				}
				blueprintBuildingsFrameCounter++;
				if (blueprintBuildingsFrameCounter != updateEveryFrames)
				{
					return;
				}
				blueprintBuildingsFrameCounter = 0;
				while (villageSaveData.GetBlueprintStabilityCalculationQueueCount > 0)
				{
					blueprintBuildingsGridUpdateCounter++;
					if (blueprintBuildingsGridUpdateCounter == 50)
					{
						break;
					}
					QueuedStabilityCalculationInfo queuedStabilityCalculationInfo = villageSaveData.DequeueBlueprint();
					UpdateBlueprintNeighbor(queuedStabilityCalculationInfo.Position.x, queuedStabilityCalculationInfo.Position.y, queuedStabilityCalculationInfo.Position.z, queuedStabilityCalculationInfo.SkipGround);
				}
				blueprintBuildingsGridUpdateCounter = 0;
			}
		}

		public void UpdateStabilitiesWhileDragging(List<Vec3Int> previewList)
		{
		}
	}
}
