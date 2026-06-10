using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.RoomDetection;
using NSMedieval.State.Timers;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Water
{
	public class WaterManager
	{
		private VillageMap map;

		private NSMedieval.State.Timers.Timer timerTickWaterSim;

		private readonly Stopwatch stopwatchTickWater = new Stopwatch();

		private WaterSimLogic waterSimLogic;

		private WaterMeshLogic waterMeshLogic;

		private bool isRiverBlocked;

		private readonly int mapSizeX;

		private readonly int mapSizeY;

		private readonly int mapSizeZ;

		private Mesh waterMesh;

		private Mesh[] waterLayerMeshes;

		private GameObject waterObject;

		private MeshFilter waterMeshFilter;

		private MeshCollider[] waterColliders;

		private Mesh[] waterColliderMeshes;

		private MeshFilter waterLayerSliceMeshFilter;

		private bool tickWaterThreadFinished;

		private bool threadTickWater;

		private bool threadCreateMesh;

		private bool threadPrepareWaterDisplayData;

		private readonly Dictionary<WaterDepthLevel, string> waterTextKeyByLevel = new Dictionary<WaterDepthLevel, string>();

		private bool isThreadFinished;

		private bool forceUpdateMesh;

		public bool IsThreadFinished
		{
			get
			{
				return Volatile.Read(ref isThreadFinished);
			}
			private set
			{
				Volatile.Write(ref isThreadFinished, value);
			}
		}

		public WaterSimLogic WaterSimLogic => waterSimLogic;

		public WaterMeshLogic WaterMeshLogic => waterMeshLogic;

		public WaterfallDetection WaterfallDetection { get; }

		public bool WaterSimThreadFinished => tickWaterThreadFinished;

		public bool WaterSimEnabled { get; set; } = true;

		public bool DebugClampWaterLevel { get; set; } = true;

		public bool DebugToggleShowWaterMesh
		{
			get
			{
				return waterObject.activeSelf;
			}
			set
			{
				waterObject.SetActive(value);
			}
		}

		public event Action<HashSet<int>, HashSet<int>> WaterLevelChangedEvent;

		public event Action<List<Waterfall>> WaterfallsChangedEvent;

		public WaterManager(VillageMap villageMap)
		{
			map = villageMap;
			Vec3Int size = villageMap.Size;
			mapSizeX = size.x;
			mapSizeY = size.y;
			mapSizeZ = size.z;
			waterSimLogic = new WaterSimLogic(villageMap.Size.x, villageMap.Size.y, villageMap.Size.z);
			waterMeshLogic = new WaterMeshLogic(villageMap.Size.x, villageMap.Size.y, villageMap.Size.z);
			WaterfallDetection = new WaterfallDetection(waterSimLogic);
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			MonoSingleton<TravelManager>.Instance.BeforeLoadSecondMap += OnBeforeLoadSecondMap;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
			MonoSingleton<LoadingController>.Instance.ApplicationQuitEvent += OnApplicationQuit;
			tickWaterThreadFinished = true;
			IsThreadFinished = true;
			timerTickWaterSim = new NSMedieval.State.Timers.Timer(0.5f, restartOnEnd: true);
			timerTickWaterSim.AddCallback(OnTimerTickWaterSim);
			timerTickWaterSim.Pause();
			waterTextKeyByLevel.Add(WaterDepthLevel.Low, "water_lvl_01");
			waterTextKeyByLevel.Add(WaterDepthLevel.Medium, "water_lvl_02");
			waterTextKeyByLevel.Add(WaterDepthLevel.High, "water_lvl_03");
			forceUpdateMesh = true;
		}

		private void OnBeforeLoadSecondMap()
		{
			timerTickWaterSim?.StopAndDetachCallbacks();
			if (waterSimLogic != null)
			{
				waterSimLogic.StopThread = true;
			}
		}

		private void OnApplicationQuit()
		{
			StopWaterThreadBlocking();
		}

		private void OnMainSceneLeaving()
		{
			StopWaterThreadBlocking();
		}

		private void StopWaterThreadBlocking()
		{
			if (waterSimLogic != null)
			{
				waterSimLogic.StopThread = true;
				while (!IsThreadFinished)
				{
					Thread.Sleep(50);
				}
			}
		}

		public void DrawGizmos()
		{
			waterSimLogic?.DrawGizmos();
			WaterfallDetection?.DrawGizmos();
		}

		public void Dispose()
		{
			timerTickWaterSim.Dispose();
			timerTickWaterSim = null;
			stopwatchTickWater?.Stop();
			if (map != null)
			{
				map.OnNodeVoxelTypeChangedEvent -= OnNodeVoxelTypeChanged;
				map.DrawbridgeOpenedEvent -= OnDrawbridgeOpened;
				map.DrawbridgeClosedEvent -= OnDrawbridgeClosed;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnObjectPlaced;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnObjectRemoved;
				MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent -= OnLockStateChanged;
				MonoSingleton<ConstructionController>.Instance.RefreshLadderFloorEvent -= OnLadderVisualStateChanged;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.LayerChangeEvent -= OnWorldLayerChanged;
			}
			if (MonoSingleton<TravelManager>.IsInstantiated())
			{
				MonoSingleton<TravelManager>.Instance.BeforeLoadSecondMap -= OnBeforeLoadSecondMap;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
				MonoSingleton<LoadingController>.Instance.ApplicationQuitEvent -= OnApplicationQuit;
			}
			waterSimLogic?.Dispose();
			waterMeshLogic?.Dispose();
			map = null;
			waterSimLogic = null;
			waterMeshLogic = null;
			this.WaterfallsChangedEvent = null;
			this.WaterLevelChangedEvent = null;
			Mesh[] array = waterColliderMeshes;
			int num = ((array != null) ? array.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if ((bool)waterColliders[i])
				{
					waterColliders[i].sharedMesh = null;
					UnityEngine.Object.DestroyImmediate(waterColliders[i]);
				}
				if ((bool)waterColliderMeshes[i])
				{
					UnityEngine.Object.DestroyImmediate(waterColliderMeshes[i]);
				}
				if ((bool)waterLayerMeshes[i])
				{
					UnityEngine.Object.DestroyImmediate(waterLayerMeshes[i]);
				}
			}
		}

		public void ForceUpdateMesh()
		{
			forceUpdateMesh = true;
		}

		public string GetTextKeyForWaterLevel(WaterDepthLevel waterLevel)
		{
			if (waterLevel == WaterDepthLevel.None)
			{
				return string.Empty;
			}
			return waterTextKeyByLevel[waterLevel];
		}

		public void SetObstacleFromMap()
		{
			MapNode[] gridSpaceData = map.GridSpaceData;
			int num = gridSpaceData.Length;
			for (int i = 0; i < num; i++)
			{
				if (gridSpaceData[i].Tag != MapNodeTags.None || gridSpaceData[i].VoxelTypeIdByte != 0)
				{
					RefreshMapNodeObstacleNoCheck(gridSpaceData[i]);
				}
			}
			waterSimLogic.SetObstacleStateChanged();
		}

		public void TickWater(bool tickWater, bool createMesh, bool prepareWaterDisplayData)
		{
			if (tickWaterThreadFinished && !LoadingController.IsLeavingMainScene)
			{
				tickWaterThreadFinished = false;
				threadTickWater = tickWater;
				threadCreateMesh = createMesh;
				threadPrepareWaterDisplayData = prepareWaterDisplayData;
				stopwatchTickWater.Restart();
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(TickWaterThread, TickWaterThreadFinished);
			}
		}

		public void RefreshObstacleAt(int x, int y, int z)
		{
			if (GridDataIndexTools.InRange(x, y, z))
			{
				int num = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
				MapNode node = map.GridSpaceData[num];
				RefreshMapNodeObstacle(node);
			}
		}

		public bool IsWaterAt(Vec3Int pos)
		{
			if (!GridDataIndexTools.InRange(pos.x, pos.y, pos.z))
			{
				return false;
			}
			int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(pos.x, pos.y, pos.z);
			return IsWaterAt(nodeIndex);
		}

		public bool IsWaterAt(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return false;
			}
			int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
			return IsWaterAt(nodeIndex);
		}

		public bool IsWaterAt(int nodeIndex)
		{
			return waterSimLogic.IsWaterAt(nodeIndex);
		}

		public WaterDepthLevel GetWaterLevelAsDepth(Vec3Int pos)
		{
			if (!GridDataIndexTools.InRange(pos.x, pos.y, pos.z))
			{
				return WaterDepthLevel.None;
			}
			if (waterSimLogic == null)
			{
				return WaterDepthLevel.None;
			}
			int index = GridDataIndexTools.FastTo1DIndexNoCheck(pos.x, pos.y, pos.z);
			return GetWaterLevelAsDepth(index);
		}

		public WaterDepthLevel GetWaterLevelAsDepth(int index)
		{
			return waterSimLogic.GetWaterLevelAsDepth(index);
		}

		public WaterDepthLevel GetWaterDepthLevel(Vec3Int pos)
		{
			if (!GridDataIndexTools.InRange(pos.x, pos.y, pos.z))
			{
				return WaterDepthLevel.None;
			}
			int index = GridDataIndexTools.FastTo1DIndexNoCheck(pos.x, pos.y, pos.z);
			return GetWaterDepthLevel(index);
		}

		public WaterDepthLevel GetWaterDepthLevel(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return WaterDepthLevel.None;
			}
			int index = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
			return GetWaterDepthLevel(index);
		}

		public WaterDepthLevel GetWaterDepthLevel(int index)
		{
			return waterSimLogic.GetWaterDepthLevel(index);
		}

		public float GetWaterLevel(Vec3Int pos)
		{
			if (!GridDataIndexTools.InRange(pos.x, pos.y, pos.z))
			{
				return 0f;
			}
			int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(pos.x, pos.y, pos.z);
			return GetWaterLevel(nodeIndex);
		}

		public float GetWaterLevel(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return 0f;
			}
			int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
			return GetWaterLevel(nodeIndex);
		}

		public float GetWaterLevel(MapNode node)
		{
			return GetWaterLevel(node.Index);
		}

		public float GetWaterLevel(int nodeIndex)
		{
			return waterSimLogic.GetWaterLevel(nodeIndex);
		}

		public float GetWaterDepth(Vec3Int pos)
		{
			if (!GridDataIndexTools.InRange(pos.x, pos.y, pos.z))
			{
				return 0f;
			}
			int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(pos.x, pos.y, pos.z);
			return GetWaterDepth(nodeIndex);
		}

		public float GetWaterDepth(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return 0f;
			}
			int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
			return GetWaterDepth(nodeIndex);
		}

		public float GetWaterDepth(int nodeIndex)
		{
			return waterSimLogic.WaterDepth[nodeIndex];
		}

		public float GetCoastDistance(int nodeIndex)
		{
			return waterSimLogic.CoastDistance[nodeIndex];
		}

		public float GetWaterDepth(MapNode node)
		{
			return GetWaterDepth(node.Index);
		}

		public bool IsWaterFull(MapNode node)
		{
			return GetWaterLevelAsDepth(node.Index) == WaterDepthLevel.High;
		}

		public bool CanDrown(MapNode node)
		{
			if (GetWaterLevelAsDepth(node.Index) != WaterDepthLevel.High)
			{
				return false;
			}
			MapNode nodeAbove = node.GetNodeAbove();
			if (nodeAbove == null)
			{
				return false;
			}
			if (nodeAbove.WaterLevel == WaterDepthLevel.Low)
			{
				return false;
			}
			if (nodeAbove.IsWater || nodeAbove.IsWalkable || nodeAbove.IsVoxelWall() || nodeAbove.BuildingType.HasFlag(BuildingType.Roof) || !nodeAbove.IsVoxelAir())
			{
				return true;
			}
			return false;
		}

		public bool IsWaterEnclosed(MapNode node)
		{
			using (ProfilerSampleJanitor.Begin("IsWaterEnclosed"))
			{
				bool isWaterEnclosed = true;
				MapNodeUtils.ForEachNonDiagonalNeighbourOnLevel(node, delegate(MapNode nodeToCheck)
				{
					if (node == nodeToCheck)
					{
						return true;
					}
					if (!nodeToCheck.IsWater && !nodeToCheck.IsVoxelWall() && nodeToCheck.IsVoxelAir() && !nodeToCheck.Tag.HasFlag(MapNodeTags.DoorWorkerWalkable) && !nodeToCheck.Tag.HasFlag(MapNodeTags.DoorAlwaysOpen))
					{
						isWaterEnclosed = false;
						return false;
					}
					return true;
				});
				return isWaterEnclosed;
			}
		}

		public bool CanWalkInside(MapNode node)
		{
			MapNode nodeAbove = node.GetNodeAbove();
			if (nodeAbove != null && !nodeAbove.IsVoxelFloor() && nodeAbove.IsWater)
			{
				return false;
			}
			MapNode nodeBelow = node.GetNodeBelow();
			if (nodeBelow.IsWater && !node.IsVoxelFloor() && nodeBelow.IsVoxelAir())
			{
				return false;
			}
			return GetWaterLevelAsDepth(node.Index) == WaterDepthLevel.Low;
		}

		public bool CanClimbOut(MapNode node)
		{
			MapNode nodeAbove = node.GetNodeAbove();
			if (nodeAbove == null)
			{
				return false;
			}
			if ((nodeAbove.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.DoorAlwaysOpen | MapNodeTags.Wall | MapNodeTags.Floor | MapNodeTags.FloorPassthrough)) != MapNodeTags.None || !nodeAbove.IsVoxelAir() || (nodeAbove.IsWater && (GetWaterLevelAsDepth(nodeAbove.Index) & WaterDepthLevel.Low) == 0))
			{
				return false;
			}
			return (GetWaterLevelAsDepth(node.Index) & WaterDepthLevel.High) != 0;
		}

		public int GetObstacle(Vec3Int pos)
		{
			if (!GridDataIndexTools.InRange(pos.x, pos.y, pos.z))
			{
				return 0;
			}
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(pos.x, pos.y, pos.z);
			return waterSimLogic.ObstacleData[num];
		}

		public int GetObstacle(int x, int y, int z)
		{
			if (!GridDataIndexTools.InRange(x, y, z))
			{
				return 0;
			}
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
			return waterSimLogic.ObstacleData[num];
		}

		public int GetObstacle(int nodeIndex)
		{
			return waterSimLogic.ObstacleData[nodeIndex];
		}

		public int GetObstacle(MapNode node)
		{
			return waterSimLogic.ObstacleData[node.Index];
		}

		private bool TickWaterThread()
		{
			IsThreadFinished = false;
			while (!MonoSingleton<Heightmap>.IsInstantiated() || !MonoSingleton<Heightmap>.Instance.IsReady)
			{
				if (LoadingController.IsLeavingMainScene || waterSimLogic == null || waterSimLogic.StopThread)
				{
					IsThreadFinished = true;
					return false;
				}
				Thread.Sleep(10);
			}
			if (threadTickWater)
			{
				waterSimLogic.TickWaterSim();
				if (!waterSimLogic.StopThread)
				{
					WaterfallDetection.TickWaterfallsForAudioSystem();
				}
			}
			if (threadPrepareWaterDisplayData)
			{
				waterSimLogic.PrepareWaterDisplayData();
				waterSimLogic.CalculateWaterDepth();
				waterSimLogic.CheckNodesChanged();
				waterSimLogic.CalculateCoastDistance();
			}
			if (threadCreateMesh && !waterSimLogic.StopThread && (waterSimLogic.NodesChanged.Count > 0 || forceUpdateMesh))
			{
				waterMeshLogic.GenerateWaterMeshData(DebugClampWaterLevel ? waterSimLogic.WaterDataDisplay : waterSimLogic.WaterData, waterSimLogic.ObstacleData, mapSizeX, mapSizeY, mapSizeZ, meshSmoothOn: true);
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(CheckDamBuilt);
				IsThreadFinished = true;
				return true;
			}
			IsThreadFinished = true;
			return false;
		}

		private void TickWaterThreadFinished(bool result)
		{
			if (result)
			{
				forceUpdateMesh = false;
				waterMeshLogic.GetWaterMesh(waterMesh);
				waterMeshFilter.sharedMesh = waterMesh;
				for (int i = 0; i < waterLayerMeshes.Length; i++)
				{
					waterMeshLogic.FillLayerSliceMesh(waterLayerMeshes[i], i);
				}
				for (int j = 0; j < waterColliders.Length; j++)
				{
					waterMeshLogic.FillColliderMesh(waterColliderMeshes[j], j);
					if (waterColliderMeshes[j].triangles.Length != 0)
					{
						waterColliders[j].sharedMesh = waterColliderMeshes[j];
					}
					else
					{
						waterColliders[j].sharedMesh = null;
					}
				}
				map.SnowGrassWetnessManager.RefreshWetnessWater(waterSimLogic.WaterDataDisplay);
				if (waterSimLogic.NodesChanged.Count > 0)
				{
					this.WaterLevelChangedEvent?.Invoke(waterSimLogic.NodesChanged, waterSimLogic.NodesChangedNeighbors);
				}
				CheckWaterfallsChanged();
			}
			tickWaterThreadFinished = true;
			stopwatchTickWater.Stop();
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Water\\WaterManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Water simulation completed in ");
				messageBuilder.AppendFormatted(stopwatchTickWater.Elapsed.Milliseconds);
				messageBuilder.AppendLiteral(" ms");
			}
			Log.Trace(messageBuilder);
		}

		private void CheckWaterfallsChanged()
		{
			if (WaterfallDetection.AddedWaterfalls.Count > 0 || WaterfallDetection.RemovedWaterfalls.Count > 0)
			{
				this.WaterfallsChangedEvent?.Invoke(WaterfallDetection.WaterfallsList);
			}
		}

		private void CheckDamBuilt()
		{
			if (isRiverBlocked != WaterSimLogic.IsRiverBlocked)
			{
				isRiverBlocked = WaterSimLogic.IsRiverBlocked;
				if (isRiverBlocked)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText("dam_built_bbt");
					MonoSingleton<BlackBarMessageController>.Instance?.ShowClickableBlackBarMessage(text, map.GridSpaceData[waterSimLogic.BlockageLocation].WorldPosition);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RefreshMapNodeObstacle(MapNode node)
		{
			int num = waterSimLogic.ObstacleData[node.Index];
			RefreshMapNodeObstacleNoCheck(node);
			if (waterSimLogic.ObstacleData[node.Index] != num)
			{
				waterSimLogic.SetObstacleStateChanged();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RefreshMapNodeObstacleNoCheck(MapNode node)
		{
			int index = node.Index;
			if ((node.Tag & MapNodeTags.OpenWindow) != MapNodeTags.None)
			{
				waterSimLogic.ObstacleData[index] = 2;
			}
			else if (node.HasFakeLadderFloor)
			{
				waterSimLogic.ObstacleData[index] = 3;
			}
			else if (node.DrawbridgePlatform)
			{
				waterSimLogic.ObstacleData[index] = 3;
			}
			else if ((node.Tag & MapNodeTags.Wall) != MapNodeTags.None || node.VoxelTypeIdByte != 0)
			{
				waterSimLogic.ObstacleData[index] = 1;
			}
			else if ((node.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.DoorAlwaysOpen | MapNodeTags.EnemyDoorClosed)) != MapNodeTags.None)
			{
				if ((node.Tag & (MapNodeTags.DoorAlwaysOpen | MapNodeTags.FlowThrough)) != MapNodeTags.None)
				{
					waterSimLogic.ObstacleData[index] = 3;
				}
				else
				{
					waterSimLogic.ObstacleData[index] = 1;
				}
			}
			else if ((node.DataType & GridDataType.Roof) != GridDataType.None)
			{
				bool flag = NSMedieval.RoomDetection.RoomDetection.IsRoofAsWallAt(node);
				waterSimLogic.ObstacleData[index] = (flag ? 1 : 3);
			}
			else if ((node.Tag & MapNodeTags.Floor) != MapNodeTags.None && (node.Tag & MapNodeTags.FlowThrough) == 0)
			{
				waterSimLogic.ObstacleData[index] = 3;
			}
			else
			{
				waterSimLogic.ObstacleData[index] = 0;
			}
		}

		private void OnTimerTickWaterSim()
		{
			TickWater(WaterSimEnabled, createMesh: true, prepareWaterDisplayData: true);
		}

		private void OnMapLoaded(bool loadedFromSave)
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			waterMesh = new Mesh
			{
				indexFormat = IndexFormat.UInt32
			};
			waterMesh.MarkDynamic();
			waterObject = GameObject.Find("WaterObject");
			waterMeshFilter = waterObject.GetComponent<MeshFilter>();
			GameObject gameObject = GameObject.Find("WaterLayerSliceMesh");
			waterLayerSliceMeshFilter = gameObject.GetComponent<MeshFilter>();
			waterMeshFilter.sharedMesh = waterMesh;
			waterColliders = new MeshCollider[mapSizeY];
			waterLayerMeshes = new Mesh[mapSizeY];
			waterColliderMeshes = new Mesh[mapSizeY];
			for (int i = 0; i < mapSizeY; i++)
			{
				waterLayerMeshes[i] = new Mesh
				{
					indexFormat = IndexFormat.UInt32
				};
				waterLayerMeshes[i].MarkDynamic();
				Mesh mesh = new Mesh
				{
					indexFormat = IndexFormat.UInt32
				};
				mesh.MarkDynamic();
				waterColliderMeshes[i] = mesh;
				GameObject gameObject2 = new GameObject($"WaterCollider{i}");
				gameObject2.transform.parent = waterObject.transform;
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.transform.localScale = Vector3.one;
				gameObject2.layer = LayerMask.NameToLayer("Water");
				MeshCollider meshCollider = gameObject2.AddComponent<MeshCollider>();
				meshCollider.sharedMesh = mesh;
				waterColliders[i] = meshCollider;
			}
			SetObstacleFromMap();
			map.OnNodeVoxelTypeChangedEvent += OnNodeVoxelTypeChanged;
			map.DrawbridgeOpenedEvent += OnDrawbridgeOpened;
			map.DrawbridgeClosedEvent += OnDrawbridgeClosed;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnObjectPlaced;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnObjectRemoved;
			MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent += OnLockStateChanged;
			MonoSingleton<ConstructionController>.Instance.RefreshLadderFloorEvent += OnLadderVisualStateChanged;
			MonoSingleton<World>.Instance.LayerChangeEvent += OnWorldLayerChanged;
			TickWater(tickWater: false, createMesh: true, prepareWaterDisplayData: true);
			int num = (int)Mathf.Clamp((float)MonoSingleton<World>.Instance.ElevationLevel - 0.5f, 0f, (float)mapSizeY - 1f);
			SetLayerSliceMesh(num);
			SetColliderMesh(num);
			timerTickWaterSim.Resume();
		}

		private void OnWorldLayerChanged(float layerLevel, int mapSizeY)
		{
			int num = Math.Clamp(Mathf.FloorToInt(layerLevel - 0.5f), 0, mapSizeY - 1);
			SetLayerSliceMesh(num);
			SetColliderMesh(num);
		}

		private void OnNodeVoxelTypeChanged(MapNode mapNode)
		{
			if (!mapNode.IsVoxelAir())
			{
				waterSimLogic.SetWaterAt(mapNode.Index, 0f);
			}
			RefreshMapNodeObstacle(mapNode);
		}

		private void OnDrawbridgeOpened(MapNode mapNode)
		{
			RefreshMapNodeObstacle(mapNode);
		}

		private void OnDrawbridgeClosed(MapNode mapNode)
		{
			RefreshMapNodeObstacle(mapNode);
		}

		private void OnObjectPlaced(BaseBuildingInstance building)
		{
			if ((building.BuildingType & (BuildingType.Wall | BuildingType.Voxel)) != 0)
			{
				waterSimLogic.SetWaterAt(building.GetNode().Index, 0f);
			}
			RefreshObstaclesForBuilding(building);
		}

		private void OnObjectRemoved(BaseBuildingInstance building)
		{
			RefreshObstaclesForBuilding(building);
		}

		private void OnLockStateChanged(BaseBuildingInstance building)
		{
			RefreshObstaclesForBuilding(building);
		}

		private void OnLadderVisualStateChanged(BaseBuildingInstance ladder)
		{
			RefreshObstaclesForBuilding(ladder);
		}

		private void RefreshObstaclesForBuilding(BaseBuildingInstance building)
		{
			if (building?.Positions == null)
			{
				return;
			}
			foreach (Vec3Int position in building.Positions)
			{
				MapNode node = map.GetNode(position);
				if (node != null)
				{
					RefreshMapNodeObstacle(node);
				}
			}
		}

		private void SetLayerSliceMesh(int layerIndex)
		{
			waterLayerSliceMeshFilter.sharedMesh = waterLayerMeshes[layerIndex];
		}

		private void SetColliderMesh(int layerIndex)
		{
			for (int i = 0; i < mapSizeY; i++)
			{
				GameObject gameObject = waterColliders[i].gameObject;
				if (i <= layerIndex)
				{
					if (!gameObject.activeSelf)
					{
						gameObject.SetActive(value: true);
					}
				}
				else if (gameObject.activeSelf)
				{
					gameObject.SetActive(value: false);
				}
			}
		}
	}
}
