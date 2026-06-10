using System;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Fire;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map.Pathfinding;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace NSMedieval.Village.Map
{
	public class HomeArea : IDisposable
	{
		private const int AnimalAvoidBuildingsRadius = 11;

		private object dataLock = new object();

		private static NativeArray<int> buildingsInRange;

		private bool animalAvoidBuildingsArraysInitialized;

		private NativeArray<int> animalAvoidBuildingsX;

		private NativeArray<int> animalAvoidBuildingsZ;

		private NativeParallelHashSet<int> indicesToRefresh;

		private AddToBuildingsInRangeJob job;

		private JobHandle jobHandle;

		[NonSerialized]
		private VillageMap map;

		private int dataLength;

		public static void InitStaticArrays()
		{
			buildingsInRange = ArrayStorage.GetNativeArray<int>("HomeArea.buildingsInRange", GridDataIndexTools.MaxDataLength);
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(buildingsInRange, dataLength);
		}

		public void Initialize(VillageMap map)
		{
			this.map = map;
			dataLength = this.map.Size.x * this.map.Size.y * this.map.Size.z;
			InitStaticArrays();
			ClearStaticArrays();
			indicesToRefresh = new NativeParallelHashSet<int>(100, Allocator.Persistent);
			CreateAnimalAvoidBuildingsArrays();
			job = new AddToBuildingsInRangeJob
			{
				BuildingsInRange = buildingsInRange,
				AreaX = animalAvoidBuildingsX,
				AreaZ = animalAvoidBuildingsZ,
				IndicesToRefresh = indicesToRefresh,
				StoreRefreshIndices = false,
				SizeXCache = this.map.Size.x,
				SizeYCache = this.map.Size.y,
				SizeZCache = this.map.Size.z
			};
			MonoSingleton<SceneController>.Instance.LateTick += OnTick;
		}

		public void Dispose()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OnTick;
			}
			map = null;
			if (!jobHandle.IsCompleted)
			{
				jobHandle.Complete();
			}
			animalAvoidBuildingsX.Dispose();
			animalAvoidBuildingsZ.Dispose();
			indicesToRefresh.Dispose();
		}

		private void CreateAnimalAvoidBuildingsArrays()
		{
			if (animalAvoidBuildingsArraysInitialized)
			{
				return;
			}
			using PooledList<int> pooledList = ListPool<int>.GetJanitor();
			using PooledList<int> pooledList2 = ListPool<int>.GetJanitor();
			for (int i = -11; i <= 11; i++)
			{
				for (int j = -11; j <= 11; j++)
				{
					if (i * i + j * j < 121)
					{
						pooledList.Add(i);
						pooledList2.Add(j);
					}
				}
			}
			animalAvoidBuildingsX = new NativeArray<int>(pooledList.ToArray(), Allocator.Persistent);
			animalAvoidBuildingsZ = new NativeArray<int>(pooledList2.ToArray(), Allocator.Persistent);
			animalAvoidBuildingsArraysInitialized = true;
		}

		public int GetBuildingsNearbyCount(Vec3Int gridPosition)
		{
			if (!GridDataIndexTools.InRange(gridPosition))
			{
				return 0;
			}
			return GetBuildingsNearbyCount(GridDataIndexTools.FastTo1DIndex(gridPosition));
		}

		[BurstCompile]
		public int GetBuildingsNearbyCount(int nodeIndex)
		{
			lock (dataLock)
			{
				return buildingsInRange[nodeIndex];
			}
		}

		[BurstCompile]
		public bool IsHomeArea(int nodeIndex)
		{
			lock (dataLock)
			{
				return buildingsInRange[nodeIndex] > 0;
			}
		}

		[BurstCompile]
		public bool IsHomeArea(Vec3Int gridPosition)
		{
			int num = GridDataIndexTools.FastTo1DIndex(gridPosition);
			if (num == -1)
			{
				return false;
			}
			lock (dataLock)
			{
				return buildingsInRange[num] > 0;
			}
		}

		public static MapNode GetNodeInHomeArea(bool searchInsideHomeArea, CreatureBase creature, float minRadius = 2f, float maxRadius = 10f)
		{
			if (CombatUtils.IsNullOrDisposed(creature))
			{
				return null;
			}
			using PooledList<MapNode> pooledList = ListPool<MapNode>.GetJanitor();
			MapNode node = creature.GetNode();
			HomeArea homeArea = node.Map.HomeArea;
			foreach (MapNode item in MapNodeUtils.IterateConnectedNodes(node, minRadius, maxRadius, null))
			{
				if (item.Region != null)
				{
					bool flag = homeArea.IsHomeArea(item.Index);
					if ((searchInsideHomeArea ? flag : (!flag)) && (item.Tag & MapNodeTags.IdleTargetForbidden) == 0 && PathfinderUtil.IsPathPossible(creature.WalkableModel, node, item))
					{
						pooledList.Add(item);
					}
				}
			}
			if (pooledList.Count == 0)
			{
				return creature.GetNode();
			}
			return pooledList.PickRandom();
		}

		public void AddToBuildingsInRange(int nodePosX, int nodePosY, int nodePosZ, int valueToAdd, bool forceRefreshPenalty = true)
		{
			job.NodePosX = nodePosX;
			job.NodePosY = nodePosY;
			job.NodePosZ = nodePosZ;
			job.ValueToAdd = valueToAdd;
			job.StoreRefreshIndices = forceRefreshPenalty;
			lock (dataLock)
			{
				jobHandle = IJobExtensions.Schedule(job);
				jobHandle.Complete();
			}
		}

		private void OnTick(float dt)
		{
			using (ProfilerSampleJanitor.Begin("HomeArea.LateTick"))
			{
				if (LoadingController.IsLeavingMainScene || job.IndicesToRefresh.IsEmpty)
				{
					return;
				}
				MapNode[] gridSpaceData = map.GridSpaceData;
				foreach (int item in job.IndicesToRefresh)
				{
					gridSpaceData[item]?.ForceRefreshPenalty();
				}
				job.IndicesToRefresh.Clear();
			}
		}

		public void DrawGizmos()
		{
		}
	}
}
