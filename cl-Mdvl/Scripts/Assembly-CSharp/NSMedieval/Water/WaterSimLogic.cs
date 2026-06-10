using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Fire;
using NSMedieval.Tools;
using NSMedieval.Tools.Math;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace NSMedieval.Water
{
	public class WaterSimLogic
	{
		public delegate bool NeighborSearchDelegate(int nx, int ny, int nz, int neighborIndex);

		private delegate bool AreaSearchMethod(WaterFlatArea area);

		private delegate void AreaTraverseMethod(WaterFlatArea area);

		private delegate bool NeighborSearchDelegateWithArea(int nx, int ny, int nz, int neighborIndex, WaterFlatArea neighborArea);

		private delegate void NeighborOperationDelegate(int nx, int ny, int nz, int neighborIndex);

		private class WaterFlatArea
		{
			public float HeightAndWaterLevel;

			public int Y;

			public HashSet<int> Nodes;

			public HashSet<int> ExpandedVertically;

			public HashSet<int> ExpandedHorizontally;

			public float WaterAmount;

			public bool ShouldWaterExist;

			public HashSet<WaterFlatArea> ConnectionUp;

			public HashSet<WaterFlatArea> ConnectionDown;

			public bool IsFull;

			public float FlowInAmount;

			public float FlowOutAmount;

			public bool LeadsDownToMapEdge;

			public bool ConnectedDirectlyToMapEdge;

			public bool LeadsDownToOnlyFullAreas;

			public bool ShouldDisappear
			{
				get
				{
					if (!ConnectedDirectlyToMapEdge && ConnectionUp.Count == 0 && ConnectionDown.Count > 0)
					{
						return WaterAmount < (float)Nodes.Count * 0.05f;
					}
					return false;
				}
			}

			public void SetUpConnection(WaterFlatArea connectedArea)
			{
				ConnectionUp.Add(connectedArea);
				connectedArea.ConnectionDown.Add(this);
			}

			public void Reset()
			{
				HeightAndWaterLevel = 0f;
				Y = 0;
				WaterAmount = 0f;
				IsFull = false;
				FlowInAmount = 0f;
				FlowOutAmount = 0f;
				ConnectedDirectlyToMapEdge = false;
				LeadsDownToOnlyFullAreas = true;
				LeadsDownToMapEdge = false;
				ShouldWaterExist = true;
			}
		}

		private static int mapSizeX;

		private static int mapSizeY;

		private static int mapSizeZ;

		private static int[] xAddH;

		private static int[] yAddH;

		private static int[] zAddH;

		private static int[] xAddDown;

		private static int[] yAddDown;

		private static int[] zAddDown;

		private static float[] waterData;

		private static float[] waterDataDisplay;

		private static float[] waterDataDisplayPrev;

		private static int[] obstacleData;

		private static float[] waterDepth;

		private static float[] flowInData;

		private static bool[] flowOutData;

		private static int[] nodeToAreaIndex;

		private static int[] coastDistance;

		private static bool[] processedIndex;

		private static bool[] edgeAccessibleWaterBlocker;

		private static bool[] edgeAccessible;

		private static bool[] waterfalls;

		private static WaterDepthLevel[] waterLevel;

		private static WaterDepthLevel[] waterDepthLevels;

		private static bool[] waterShouldExist;

		private static int[] flowInOutChanged;

		private bool stopThread;

		public const float WindowHeight = 0.35f;

		private float[] riverHeight;

		private readonly Stopwatch stopwatchMove = new Stopwatch();

		private readonly Stopwatch stopwatchEqualize = new Stopwatch();

		private readonly Stopwatch stopwatchMeshGen = new Stopwatch();

		private readonly HashSet<int> nodesChanged = new HashSet<int>();

		private readonly HashSet<int> nodesChangedNeighbors = new HashSet<int>();

		private readonly HashSet<int> waterFlowIn = new HashSet<int>();

		private List<int> mapEdgeNodes;

		private bool isWaterOnMap;

		private object isWaterOnMapLock = new object();

		private int dataLength;

		private bool obstacleStateChanged;

		private bool obstacleStateChangedForRiverBlocked;

		private readonly HashSet<int> depthChanged = new HashSet<int>();

		private static readonly int[] NeighborsX = new int[6] { -1, 1, 0, 0, 0, 0 };

		private static readonly int[] NeighborsY = new int[6] { 0, 0, 1, -1, 0, 0 };

		private static readonly int[] NeighborsZ = new int[6] { 0, 0, 0, 0, 1, -1 };

		private readonly ObjectPool<WaterFlatArea> waterFlatAreaPool = new ObjectPool<WaterFlatArea>(CreateWaterFlatAreaPooledItem, delegate
		{
		}, OnWaterFlatAreaReturnedToPool, delegate
		{
		}, collectionCheck: true, 10, 512);

		public bool WaterFlowInOutEnabled { get; set; } = true;

		public bool IsRiverBlocked { get; private set; }

		public int BlockageLocation { get; private set; } = int.MinValue;

		public ConcurrentHashSet<int> NodesInVolumePublic { get; private set; } = new ConcurrentHashSet<int>();

		public bool StopThread
		{
			get
			{
				return Volatile.Read(ref stopThread);
			}
			set
			{
				Volatile.Write(ref stopThread, value);
			}
		}

		public float[] RiverHeight => riverHeight;

		public int[] FlowInOutChanged => flowInOutChanged;

		public HashSet<int> NodesChanged => nodesChanged;

		public HashSet<int> NodesChangedNeighbors => nodesChangedNeighbors;

		public HashSet<int> WaterFlowIn => waterFlowIn;

		internal int DataLength => dataLength;

		private float TotalWaterAmount { get; set; }

		public bool IsWaterOnMap
		{
			get
			{
				lock (isWaterOnMapLock)
				{
					return isWaterOnMap;
				}
			}
		}

		public int CurrentWaterSurface { get; private set; }

		internal int[] ObstacleData => obstacleData;

		internal float[] WaterDataDisplay => waterDataDisplay;

		internal int[] CoastDistance => coastDistance;

		internal float[] WaterData => waterData;

		internal float[] WaterDepth => waterDepth;

		public float[] FlowInData => flowInData;

		public WaterDepthLevel[] WaterLevel => waterLevel;

		public WaterDepthLevel[] WaterDepthLevels => waterDepthLevels;

		public bool[] FlowOutData => flowOutData;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			mapSizeX = 0;
			mapSizeY = 0;
			mapSizeZ = 0;
			xAddH = new int[4] { 1, -1, 0, 0 };
			yAddH = new int[4];
			zAddH = new int[4] { 0, 0, 1, -1 };
			xAddDown = new int[1];
			yAddDown = new int[1] { -1 };
			zAddDown = new int[1];
		}

		public static void InitStaticArrays()
		{
			waterData = ArrayStorage.GetArray<float>("WaterSimLogic.waterData", GridDataIndexTools.MaxDataLength);
			waterDataDisplay = ArrayStorage.GetArray<float>("WaterSimLogic.waterDataDisplay", GridDataIndexTools.MaxDataLength);
			waterDataDisplayPrev = ArrayStorage.GetArray<float>("WaterSimLogic.waterDataDisplayPrev", GridDataIndexTools.MaxDataLength);
			obstacleData = ArrayStorage.GetArray<int>("WaterSimLogic.obstacleData", GridDataIndexTools.MaxDataLength);
			waterDepth = ArrayStorage.GetArray<float>("WaterSimLogic.waterDepth", GridDataIndexTools.MaxDataLength);
			flowInData = ArrayStorage.GetArray<float>("WaterSimLogic.flowInData", GridDataIndexTools.MaxDataLength);
			flowOutData = ArrayStorage.GetArray<bool>("WaterSimLogic.flowOutData", GridDataIndexTools.MaxDataLength);
			processedIndex = ArrayStorage.GetArray<bool>("WaterSimLogic.processedIndex", GridDataIndexTools.MaxDataLength);
			edgeAccessible = ArrayStorage.GetArray<bool>("WaterSimLogic.edgeAccessible", GridDataIndexTools.MaxDataLength);
			edgeAccessibleWaterBlocker = ArrayStorage.GetArray<bool>("WaterSimLogic.edgeAccessibleWaterBlocker", GridDataIndexTools.MaxDataLength);
			waterfalls = ArrayStorage.GetArray<bool>("WaterSimLogic.waterfalls", GridDataIndexTools.MaxDataLength);
			waterLevel = ArrayStorage.GetArray<WaterDepthLevel>("WaterSimLogic.waterLevel", GridDataIndexTools.MaxDataLength);
			waterDepthLevels = ArrayStorage.GetArray<WaterDepthLevel>("WaterSimLogic.waterDepthLevels", GridDataIndexTools.MaxDataLength);
			nodeToAreaIndex = ArrayStorage.GetArray<int>("WaterSimLogic.nodeToAreaIndex", GridDataIndexTools.MaxDataLength);
			coastDistance = ArrayStorage.GetArray<int>("WaterSimLogic.coastDistance", GridDataIndexTools.MaxDataLength);
			waterShouldExist = ArrayStorage.GetArray<bool>("WaterSimLogic.waterShouldExist", GridDataIndexTools.MaxDataLength);
			flowInOutChanged = ArrayStorage.GetArray<int>("WaterSimLogic.flowInOutChanged", GridDataIndexTools.MaxDataLength);
		}

		private void ClearStaticArrays()
		{
			Array.Clear(waterData, 0, dataLength);
			Array.Clear(waterDataDisplay, 0, dataLength);
			Array.Clear(waterDataDisplayPrev, 0, dataLength);
			Array.Clear(obstacleData, 0, dataLength);
			Array.Clear(waterDepth, 0, dataLength);
			Array.Clear(flowInData, 0, dataLength);
			Array.Clear(flowOutData, 0, dataLength);
			Array.Clear(processedIndex, 0, dataLength);
			Array.Clear(edgeAccessible, 0, dataLength);
			Array.Clear(edgeAccessibleWaterBlocker, 0, dataLength);
			Array.Clear(waterfalls, 0, dataLength);
			Array.Clear(waterLevel, 0, dataLength);
			Array.Clear(waterDepthLevels, 0, dataLength);
			Array.Clear(nodeToAreaIndex, 0, dataLength);
			Array.Clear(coastDistance, 0, dataLength);
			Array.Clear(waterShouldExist, 0, dataLength);
			Array.Clear(flowInOutChanged, 0, dataLength);
		}

		public void CopyWaterDataTo(NativeArray<float> data)
		{
			NativeArray<float>.Copy(waterDataDisplay, data, dataLength);
		}

		public WaterSimLogic(int mapSizeX, int mapSizeY, int mapSizeZ)
		{
			WaterSimLogic.mapSizeX = mapSizeX;
			WaterSimLogic.mapSizeY = mapSizeY;
			WaterSimLogic.mapSizeZ = mapSizeZ;
			dataLength = mapSizeX * mapSizeY * mapSizeZ;
			InitStaticArrays();
			ClearStaticArrays();
			CacheMapEdgeNodes();
			WaterFlowInOutEnabled = GlobalSaveController.CurrentVillageData.MapBlueprint.WaterFlowInOutEnabled;
		}

		public void SetObstacleStateChanged()
		{
			obstacleStateChanged = true;
			obstacleStateChangedForRiverBlocked = true;
		}

		public WaterDepthLevel GetWaterLevelAsDepth(int nodeIndex)
		{
			if (obstacleData[nodeIndex] == 1)
			{
				return WaterDepthLevel.None;
			}
			return waterLevel[nodeIndex];
		}

		public bool IsWaterAt(int nodeIndex)
		{
			if (obstacleData[nodeIndex] == 1)
			{
				return false;
			}
			return waterDataDisplay[nodeIndex] > 0f;
		}

		public WaterDepthLevel GetWaterDepthLevel(int nodeIndex)
		{
			if (obstacleData[nodeIndex] == 1)
			{
				return WaterDepthLevel.None;
			}
			return waterDepthLevels[nodeIndex];
		}

		public void CacheMapEdgeNodes()
		{
			if (mapEdgeNodes != null)
			{
				mapEdgeNodes.Clear();
			}
			else
			{
				mapEdgeNodes = new List<int>();
			}
			for (int i = 0; i < mapSizeY; i++)
			{
				for (int j = 0; j < mapSizeX; j++)
				{
					for (int k = 0; k < mapSizeZ; k++)
					{
						if (IsMapEdge(j, k))
						{
							mapEdgeNodes.Add(GridDataIndexTools.FastTo1DIndexNoCheck(j, i, k));
						}
					}
				}
			}
		}

		private static WaterFlatArea CreateWaterFlatAreaPooledItem()
		{
			WaterFlatArea waterFlatArea = new WaterFlatArea();
			waterFlatArea.Nodes = new HashSet<int>();
			waterFlatArea.ExpandedVertically = new HashSet<int>();
			waterFlatArea.ExpandedHorizontally = new HashSet<int>();
			waterFlatArea.ConnectionDown = new HashSet<WaterFlatArea>();
			waterFlatArea.ConnectionUp = new HashSet<WaterFlatArea>();
			waterFlatArea.Reset();
			return waterFlatArea;
		}

		private static void OnWaterFlatAreaReturnedToPool(WaterFlatArea obj)
		{
			obj.Nodes.Clear();
			obj.ExpandedVertically.Clear();
			obj.ExpandedHorizontally.Clear();
			obj.ConnectionDown.Clear();
			obj.ConnectionUp.Clear();
			obj.Reset();
		}

		private static bool IsMapEdge(int x, int z)
		{
			if (x != 0 && z != 0 && x != mapSizeX - 1)
			{
				return z == mapSizeZ - 1;
			}
			return true;
		}

		private static bool IsMapEdge(int nodeIndex)
		{
			int x = GridDataIndexTools.GetX(nodeIndex);
			int z = GridDataIndexTools.GetZ(nodeIndex);
			if (x != 0 && z != 0 && x != mapSizeX - 1)
			{
				return z == mapSizeZ - 1;
			}
			return true;
		}

		public void CalculateCoastDistance()
		{
			if (StopThread)
			{
				return;
			}
			Queue<int> queue = QueuePool<int>.Get();
			Queue<int> nextQueue = QueuePool<int>.Get();
			HashSet<int> processed = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			int num = 1;
			for (int i = 0; i < dataLength; i++)
			{
				coastDistance[i] = 0;
				if (!(waterData[i] <= 0f) && obstacleData[i] != 1)
				{
					int x = GridDataIndexTools.GetX(i);
					int y = GridDataIndexTools.GetY(i);
					int z = GridDataIndexTools.GetZ(i);
					if (SearchEachNeighbor(x, y, z, IsRiverEdge))
					{
						nextQueue.Enqueue(i);
						processed.Add(i);
					}
				}
			}
			while (nextQueue.Count > 0)
			{
				Queue<int> queue2 = queue;
				Queue<int> queue3 = nextQueue;
				nextQueue = queue2;
				queue = queue3;
				while (queue.Count > 0)
				{
					int num2 = queue.Dequeue();
					coastDistance[num2] = num;
					int x2 = GridDataIndexTools.GetX(num2);
					int y2 = GridDataIndexTools.GetY(num2);
					int z2 = GridDataIndexTools.GetZ(num2);
					ForEachNeighbor(x2, y2, z2, TryAddToQueue);
				}
				num++;
			}
			QueuePool<int>.Return(queue);
			QueuePool<int>.Return(nextQueue);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(processed);
			static bool IsRiverEdge(int nx, int ny, int nz, int neighborIndex)
			{
				if (!(waterData[neighborIndex] <= 0f))
				{
					return obstacleData[neighborIndex] == 1;
				}
				return true;
			}
			void TryAddToQueue(int nx, int ny, int nz, int neighborIndex)
			{
				if (obstacleData[neighborIndex] == 0 && waterData[neighborIndex] > 0f && coastDistance[neighborIndex] == 0 && !processed.Contains(neighborIndex))
				{
					nextQueue.Enqueue(neighborIndex);
					processed.Add(neighborIndex);
				}
			}
		}

		private void FloodfillToFullWaterState()
		{
			for (int i = 0; i < dataLength; i++)
			{
				processedIndex[i] = false;
				waterShouldExist[i] = false;
			}
			using PooledQueue<int> pooledQueue = QueuePool<int>.GetJanitor();
			for (int j = 0; j < dataLength; j++)
			{
				if (obstacleData[j] == 1)
				{
					continue;
				}
				if (!edgeAccessible[j])
				{
					waterShouldExist[j] = true;
				}
				if (processedIndex[j] || flowInData[j] <= 0f)
				{
					continue;
				}
				pooledQueue.Enqueue(j);
				processedIndex[j] = true;
				while (pooledQueue.Count > 0)
				{
					int num = pooledQueue.Dequeue();
					waterShouldExist[num] = true;
					int x = GridDataIndexTools.GetX(num);
					int y = GridDataIndexTools.GetY(num);
					int z = GridDataIndexTools.GetZ(num);
					int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(x, y - 1, z);
					int num3;
					int[] array;
					if (obstacleData[num] != 2 && obstacleData[num] != 3 && num2 != -1 && obstacleData[num2] != 1)
					{
						num3 = ((!edgeAccessible[num2]) ? 1 : 0);
						if (num3 == 0)
						{
							array = xAddDown;
							goto IL_0105;
						}
					}
					else
					{
						num3 = 1;
					}
					array = xAddH;
					goto IL_0105;
					IL_0105:
					int[] array2 = array;
					int[] array3 = ((num3 != 0) ? yAddH : yAddDown);
					int[] array4 = ((num3 != 0) ? zAddH : zAddDown);
					for (int num4 = array2.Length - 1; num4 >= 0; num4--)
					{
						int x2 = x + array2[num4];
						int y2 = y + array3[num4];
						int z2 = z + array4[num4];
						if (GridDataIndexTools.InRange(x2, y2, z2))
						{
							int num5 = GridDataIndexTools.FastTo1DIndexNoCheck(x2, y2, z2);
							if (!processedIndex[num5] && obstacleData[num5] != 1)
							{
								processedIndex[num5] = true;
								pooledQueue.Enqueue(num5);
							}
						}
					}
				}
			}
		}

		public void TickWaterSim()
		{
			for (int i = 0; i < dataLength; i++)
			{
				processedIndex[i] = false;
				nodeToAreaIndex[i] = -1;
			}
			DetectWaterfalls();
			if (obstacleStateChanged)
			{
				DetectEdgeAccessibleAreas();
				FloodfillToFullWaterState();
			}
			if (obstacleStateChanged || nodesChanged.Count > 0)
			{
				DetectEdgeAccessibleAreasWaterBlocker();
			}
			obstacleStateChanged = false;
			if (StopThread)
			{
				return;
			}
			List<WaterFlatArea> areasInVolume = NSMedieval.Utils.Pool.ListPool<WaterFlatArea>.Get();
			HashSet<int> hashSet = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> hashSet2 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> hashSet3 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> hashSet4 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> hashSet5 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> hashSet6 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			int num = mapSizeY - 1;
			while (num >= 0 && !StopThread)
			{
				for (int j = 0; j < mapSizeX; j++)
				{
					for (int k = 0; k < mapSizeZ; k++)
					{
						int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(j, num, k);
						if ((waterData[num2] <= 0f && flowInData[num2] <= 0f) || obstacleData[num2] == 1 || (obstacleData[num2] == 2 && waterData[num2] <= 0.35f) || hashSet4.Contains(num2) || hashSet3.Contains(num2))
						{
							continue;
						}
						hashSet.Clear();
						if (!CollectWaterVolume(num2, ref areasInVolume, hashSet4, hashSet3, hashSet5))
						{
							continue;
						}
						if (StopThread)
						{
							break;
						}
						areasInVolume.Sort((WaterFlatArea a, WaterFlatArea b) => (int)(1000f * (a.HeightAndWaterLevel - b.HeightAndWaterLevel)));
						PopulateAreaUpDownConnections(areasInVolume);
						FillNodeToAreaIndex(areasInVolume);
						CalculateFlowInOutPerNode(areasInVolume);
						CalculateAreaMapEdgeConnections(areasInVolume);
						CollectAreasFull(areasInVolume, hashSet);
						CalculateAreaLeadsDownToFullArea(areasInVolume);
						if (StopThread)
						{
							break;
						}
						CollectExpandPositions(areasInVolume, hashSet, hashSet2, hashSet3, hashSet5);
						hashSet3.UnionWith(hashSet2);
						TickFlowInFlowOutLogic(areasInVolume);
						ExpandWaterToNewNodes(areasInVolume);
						foreach (WaterFlatArea item in areasInVolume)
						{
							hashSet6.UnionWith(item.Nodes);
						}
					}
				}
				num--;
			}
			NodesInVolumePublic.Clear();
			NodesInVolumePublic.AddRange(hashSet6);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Water\\WaterSimLogic.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Releasing ");
				messageBuilder.AppendFormatted(areasInVolume.Count);
				messageBuilder.AppendLiteral(" water flat areas to pool");
			}
			Log.Trace(messageBuilder);
			foreach (WaterFlatArea item2 in areasInVolume)
			{
				waterFlatAreaPool.Release(item2);
			}
			NSMedieval.Utils.Pool.ListPool<WaterFlatArea>.Return(areasInVolume);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet2);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet3);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet4);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet5);
			VillageMap map = VillageManager.ActiveVillage.Map;
			TotalWaterAmount = 0f;
			CurrentWaterSurface = 0;
			for (int num3 = 0; num3 < dataLength; num3++)
			{
				if (waterData[num3] <= 0.05f)
				{
					waterData[num3] = MathfUtils.Max(waterData[num3] - 0.01f, 0f);
					if (!waterShouldExist[num3])
					{
						waterData[num3] = 0f;
					}
				}
				if (waterData[num3] > 1f)
				{
					waterData[num3] = 1f;
				}
				TotalWaterAmount += waterData[num3];
				MapNode mapNode = map.GridSpaceData[num3];
				if (waterData[num3] > 0f && mapNode != null && mapNode.VoxelType == null)
				{
					MapNode nodeAbove = mapNode.GetNodeAbove();
					if (nodeAbove == null || (nodeAbove.IsVoxelAir() && waterData[nodeAbove.Index] <= 0f))
					{
						CurrentWaterSurface++;
					}
				}
			}
			lock (isWaterOnMapLock)
			{
				isWaterOnMap = TotalWaterAmount > 0f;
			}
		}

		public void CalculateRiverFlowInFlowOut(VillageMap map, float[,] riverHeight)
		{
			this.riverHeight = new float[riverHeight.GetLength(0) * riverHeight.GetLength(1)];
			for (int i = 0; i < riverHeight.GetLength(0); i++)
			{
				for (int j = 0; j < riverHeight.GetLength(1); j++)
				{
					int num = GridDataIndexTools.Get2dIndexXZ(i, j);
					this.riverHeight[num] = riverHeight[i, j];
				}
			}
			if (!WaterFlowInOutEnabled)
			{
				return;
			}
			HashSet<int> hashSet = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			GetWaterEdges(hashSet, riverHeight);
			HashSet<int> hashSet2 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> hashSet3 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> hashSet4 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> isEdgeSliceAt = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			List<HashSet<int>> list = new List<HashSet<int>>();
			List<int> list2 = new List<int>(hashSet);
			list2.Sort((int a, int b) => GridDataIndexTools.GetY(b) - GridDataIndexTools.GetY(a));
			GetEdgeSlices(list2, hashSet, list, isEdgeSliceAt);
			HashSet<int> hashSet5 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet);
			hashSet = null;
			HashSet<int> processed = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			Queue<int> queue = QueuePool<int>.Get();
			CollectValidEdgeSlices(list, hashSet5);
			foreach (int startNode in list2)
			{
				if (!processed.Add(startNode))
				{
					continue;
				}
				HashSet<int> flowInSet = list.FirstOrDefault((HashSet<int> set) => set.Contains(startNode));
				if (flowInSet == null)
				{
					continue;
				}
				queue.Clear();
				queue.Enqueue(startNode);
				HashSet<int> flowOutFound = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
				while (queue.Count > 0)
				{
					int index = queue.Dequeue();
					int x = GridDataIndexTools.GetX(index);
					int y = GridDataIndexTools.GetY(index);
					int z = GridDataIndexTools.GetZ(index);
					ForEachNeighborAndDown(x, y, z, delegate(int nx, int ny, int nz, int neighborIndex)
					{
						if (processed.Add(neighborIndex) && !(waterData[neighborIndex] <= 0f) && (obstacleData[neighborIndex] != 1 || map.GridSpaceData[neighborIndex].IsVoxelWall()))
						{
							if (isEdgeSliceAt.Contains(neighborIndex) && !flowInSet.Contains(neighborIndex))
							{
								flowOutFound.Add(neighborIndex);
							}
							queue.Enqueue(neighborIndex);
						}
					});
				}
				if (flowOutFound.Count > 0)
				{
					hashSet3.UnionWith(flowOutFound);
					hashSet2.UnionWith(flowInSet);
				}
				else
				{
					hashSet4.UnionWith(flowInSet);
				}
				NSMedieval.Utils.Pool.HashSetPool<int>.Return(flowOutFound);
			}
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(processed);
			processed = null;
			QueuePool<int>.Return(queue);
			queue = null;
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(isEdgeSliceAt);
			isEdgeSliceAt = null;
			waterFlowIn.Clear();
			for (int num2 = 0; num2 < DataLength; num2++)
			{
				if (!IsMapEdge(num2))
				{
					flowInData[num2] = 0f;
					flowOutData[num2] = false;
				}
				if (hashSet3.Contains(num2))
				{
					SetFlowOutAt(num2, flowOut: true);
					SetFlowInAt(num2, flowIn: false);
				}
				else if (hashSet2.Contains(num2))
				{
					SetFlowInAt(num2, flowIn: true);
					SetFlowOutAt(num2, flowOut: false);
				}
			}
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet4);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet3);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet2);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet5);
		}

		public void WaterTakenUpdateLevel(int nodeIndex)
		{
			float num = Mathf.Clamp(waterData[nodeIndex] - 0.08f, 0f, 1f);
			SetWaterAt(nodeIndex, num);
		}

		private void CollectValidEdgeSlices(List<HashSet<int>> edgeSlices, HashSet<int> edgeValid)
		{
			foreach (HashSet<int> edgeSlice in edgeSlices)
			{
				bool flag = true;
				foreach (int item in edgeSlice)
				{
					int x = GridDataIndexTools.GetX(item);
					int y = GridDataIndexTools.GetY(item);
					int z = GridDataIndexTools.GetZ(item);
					bool flag2 = GridDataIndexTools.InRangeX(x + 1) && GridDataIndexTools.InRangeX(x - 1);
					bool flag3 = GridDataIndexTools.InRangeZ(z + 1) && GridDataIndexTools.InRangeZ(z - 1);
					if (!flag2 && !flag3)
					{
						continue;
					}
					int num = (flag2 ? 1 : 0);
					int num2 = (flag3 ? 1 : 0);
					if (GridDataIndexTools.InRangeXZ(x + num, z + num2))
					{
						int num3 = GridDataIndexTools.FastTo1DIndexNoCheck(x + num, y, z + num2);
						if (waterData[num3] <= 0f && obstacleData[num3] != 1)
						{
							flag = false;
						}
					}
					if (flag && GridDataIndexTools.InRangeXZ(x - num, -num2))
					{
						int num4 = GridDataIndexTools.FastTo1DIndexNoCheck(x - num, y, z - num2);
						if (waterData[num4] <= 0f && obstacleData[num4] != 1)
						{
							flag = false;
						}
					}
					if (!flag && GridDataIndexTools.InRangeY(y - 1))
					{
						int num5 = GridDataIndexTools.FastTo1DIndexNoCheck(x, y - 1, z);
						if (waterData[num5] > 0f)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						break;
					}
				}
				if (flag)
				{
					edgeValid.UnionWith(edgeSlice);
				}
			}
		}

		private void GetEdgeSlices(List<int> edgesSorted, HashSet<int> edges, List<HashSet<int>> edgeSlices, HashSet<int> isEdgeSliceAt)
		{
			HashSet<int> newEdgeSlice = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<int> processed = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			Queue<int> queue = QueuePool<int>.Get();
			foreach (int item in edgesSorted)
			{
				if (processed.Contains(item))
				{
					continue;
				}
				newEdgeSlice.Clear();
				queue.Clear();
				queue.Enqueue(item);
				processed.Add(item);
				newEdgeSlice.Add(item);
				while (queue.Count > 0)
				{
					int index = queue.Dequeue();
					int x = GridDataIndexTools.GetX(index);
					int y = GridDataIndexTools.GetY(index);
					int z = GridDataIndexTools.GetZ(index);
					ForEachNeighborAndDown(x, y, z, delegate(int nx, int ny, int nz, int neighborIndex)
					{
						if (!(waterData[neighborIndex] <= 0f) && obstacleData[neighborIndex] != 1 && !processed.Contains(neighborIndex) && edges.Contains(neighborIndex))
						{
							queue.Enqueue(neighborIndex);
							newEdgeSlice.Add(neighborIndex);
							processed.Add(neighborIndex);
						}
					});
				}
				if (newEdgeSlice.Count > 0)
				{
					edgeSlices.Add(new HashSet<int>(newEdgeSlice));
					isEdgeSliceAt.UnionWith(newEdgeSlice);
				}
			}
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(newEdgeSlice);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(processed);
			QueuePool<int>.Return(queue);
		}

		private void GetWaterEdges(HashSet<int> edges, float[,] riverHeight)
		{
			for (int i = 0; i < DataLength; i++)
			{
				if (waterData[i] > 0f && obstacleData[i] != 1)
				{
					int x = GridDataIndexTools.GetX(i);
					int z = GridDataIndexTools.GetZ(i);
					if ((x <= 0 || x >= mapSizeX - 1 || z <= 0 || z >= mapSizeZ - 1) && !(riverHeight[x, z] <= 0f))
					{
						edges.Add(i);
					}
				}
			}
		}

		private void FillNodeToAreaIndex(List<WaterFlatArea> areasInVolume)
		{
			for (int i = 0; i < areasInVolume.Count; i++)
			{
				foreach (int node in areasInVolume[i].Nodes)
				{
					nodeToAreaIndex[node] = i;
				}
			}
		}

		private void PopulateAreaUpDownConnections(List<WaterFlatArea> areasInVolume)
		{
			Dictionary<int, WaterFlatArea> dictionary = NSMedieval.Utils.Pool.DictionaryPool<int, WaterFlatArea>.Get();
			foreach (WaterFlatArea item in areasInVolume)
			{
				bool flag = true;
				item.ConnectedDirectlyToMapEdge = false;
				foreach (int node in item.Nodes)
				{
					dictionary.Add(node, item);
					if (flag && waterData[node] < 1f)
					{
						flag = false;
					}
					if (flowInData[node] > 0f)
					{
						item.FlowInAmount += flowInData[node];
					}
					else if (IsMapEdge(node))
					{
						item.FlowOutAmount += (flowOutData[node] ? 1f : 0f);
					}
					if (!item.ConnectedDirectlyToMapEdge && IsMapEdge(node) && flowInData[node] <= 0f)
					{
						item.ConnectedDirectlyToMapEdge = true;
					}
				}
				item.IsFull = flag;
			}
			foreach (WaterFlatArea item2 in areasInVolume)
			{
				foreach (int node2 in item2.Nodes)
				{
					int y = GridDataIndexTools.GetY(node2) + 1;
					if (GridDataIndexTools.InRangeY(y))
					{
						int x = GridDataIndexTools.GetX(node2);
						int z = GridDataIndexTools.GetZ(node2);
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
						if (obstacleData[num] == 0 && dictionary.TryGetValue(num, out var value))
						{
							item2.SetUpConnection(value);
						}
					}
				}
			}
			NSMedieval.Utils.Pool.DictionaryPool<int, WaterFlatArea>.Return(dictionary);
		}

		private void CalculateFlowInOutPerNode(List<WaterFlatArea> areasInVolume)
		{
			HashSet<WaterFlatArea> traversed = NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Get();
			HashSet<WaterFlatArea> connected = NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Get();
			for (int num = areasInVolume.Count - 1; num >= 0; num--)
			{
				WaterFlatArea waterFlatArea = areasInVolume[num];
				if (!traversed.Contains(waterFlatArea))
				{
					connected.Clear();
					float totalFlowIn = 0f;
					int connectedAreasNodeCount = 0;
					TraverseAllConnectedLowerAreas(waterFlatArea, delegate(WaterFlatArea area)
					{
						if (traversed.Add(area) && (!(area.FlowInAmount <= 0f) || !(totalFlowIn <= 0f)))
						{
							connected.Add(area);
							totalFlowIn += area.FlowInAmount;
							connectedAreasNodeCount += area.Nodes.Count;
						}
					});
					float flowInAmount = totalFlowIn / (float)connectedAreasNodeCount;
					foreach (WaterFlatArea item in connected)
					{
						item.FlowInAmount = flowInAmount;
					}
				}
			}
			traversed.Clear();
			foreach (WaterFlatArea item2 in areasInVolume)
			{
				if (item2.FlowOutAmount <= 0f || traversed.Contains(item2))
				{
					continue;
				}
				connected.Clear();
				float totalFlowOut = 0f;
				int connectedAreasNodeCount2 = 0;
				TraverseAllConnectedUpperAreas(item2, delegate(WaterFlatArea area)
				{
					if (traversed.Add(area))
					{
						connected.Add(area);
						totalFlowOut += area.FlowOutAmount;
						connectedAreasNodeCount2 += area.Nodes.Count;
					}
				});
				float flowOutAmount = totalFlowOut / (float)connectedAreasNodeCount2;
				foreach (WaterFlatArea item3 in connected)
				{
					item3.FlowOutAmount = flowOutAmount;
				}
			}
			NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Return(traversed);
			NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Return(connected);
		}

		private static void CalculateAreaMapEdgeConnections(IReadOnlyList<WaterFlatArea> areasInVolume)
		{
			HashSet<WaterFlatArea> traversed = NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Get();
			foreach (WaterFlatArea item in areasInVolume)
			{
				if (traversed.Contains(item) || !item.ConnectedDirectlyToMapEdge)
				{
					continue;
				}
				TraverseAllConnectedUpperAreas(item, delegate(WaterFlatArea area)
				{
					if (traversed.Add(area))
					{
						area.LeadsDownToMapEdge = true;
					}
				});
			}
			NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Return(traversed);
		}

		private static void CalculateAreaLeadsDownToFullArea(List<WaterFlatArea> areasInVolume)
		{
			HashSet<WaterFlatArea> traversed = NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Get();
			foreach (WaterFlatArea item in areasInVolume)
			{
				if (traversed.Contains(item) || item.IsFull)
				{
					continue;
				}
				TraverseAllConnectedUpperAreas(item, delegate(WaterFlatArea area)
				{
					if (traversed.Add(area))
					{
						area.LeadsDownToOnlyFullAreas = false;
					}
				});
			}
			NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Return(traversed);
		}

		private void TickFlowInFlowOutLogic(List<WaterFlatArea> areasInVolume)
		{
			if (!WaterFlowInOutEnabled)
			{
				return;
			}
			bool foundWaterFlowout = false;
			foreach (WaterFlatArea item in areasInVolume)
			{
				if (item.FlowInAmount > 0f && item.ShouldWaterExist)
				{
					item.WaterAmount += item.FlowInAmount;
					if (!foundWaterFlowout && item.FlowOutAmount <= 0f != IsRiverBlocked)
					{
						if (IsRiverBlocked)
						{
							if (obstacleStateChangedForRiverBlocked)
							{
								IsRiverBlocked = false;
								obstacleStateChangedForRiverBlocked = false;
							}
						}
						else
						{
							bool tempIsRiverBlocked = true;
							if (item.ConnectionDown.Count == 0)
							{
								SearchUpperConnectedAreas(item, skipStartAreaCheck: true, delegate(WaterFlatArea connectionToTest)
								{
									if (connectionToTest.FlowOutAmount > 0f)
									{
										foundWaterFlowout = true;
										tempIsRiverBlocked = false;
										return true;
									}
									return false;
								});
							}
							IsRiverBlocked = tempIsRiverBlocked;
							obstacleStateChangedForRiverBlocked = false;
							if (IsRiverBlocked)
							{
								BlockageLocation = item.Nodes.PickRandom();
							}
						}
					}
				}
				else if (item.LeadsDownToMapEdge && item.FlowOutAmount > 0f && (item.ConnectionUp.Count == 0 || !item.ShouldWaterExist))
				{
					item.WaterAmount -= 0.05f * (float)item.Nodes.Count;
				}
				item.WaterAmount = MathfUtils.Max(0f, item.WaterAmount);
			}
		}

		private bool CollectWaterVolume(int startIndex, ref List<WaterFlatArea> areasInVolume, HashSet<int> processed, HashSet<int> newWaterNodes, HashSet<int> currentTempVolume)
		{
			Queue<int> queue = QueuePool<int>.Get();
			queue.Enqueue(startIndex);
			currentTempVolume.Clear();
			processed.Add(startIndex);
			areasInVolume.Clear();
			while (queue.Count > 0)
			{
				int num = queue.Dequeue();
				int x = GridDataIndexTools.GetX(num);
				int y = GridDataIndexTools.GetY(num);
				int z = GridDataIndexTools.GetZ(num);
				currentTempVolume.Add(num);
				for (int i = 0; i < NeighborsX.Length; i++)
				{
					int num2 = NeighborsY[i];
					int x2 = x + NeighborsX[i];
					int y2 = y + num2;
					int z2 = z + NeighborsZ[i];
					if (!GridDataIndexTools.InRangeX(x2) || !GridDataIndexTools.InRangeY(y2) || !GridDataIndexTools.InRangeZ(z2))
					{
						continue;
					}
					int num3 = GridDataIndexTools.FastTo1DIndexNoCheck(x2, y2, z2);
					if (obstacleData[num3] == 1)
					{
						continue;
					}
					switch (num2)
					{
					case 1:
						if (obstacleData[num3] == 3 || obstacleData[num3] == 2)
						{
							continue;
						}
						break;
					case -1:
						if (obstacleData[num] == 3 || obstacleData[num] == 2)
						{
							continue;
						}
						break;
					default:
						if (obstacleData[num3] == 2 && (waterData[num3] < 0.35f || waterData[num] < 0.35f))
						{
							continue;
						}
						break;
					}
					if (waterData[num3] > 0f && !processed.Contains(num3) && !newWaterNodes.Contains(num3))
					{
						processed.Add(num3);
						queue.Enqueue(num3);
					}
				}
			}
			HashSet<int> hashSet = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			foreach (int item in currentTempVolume)
			{
				if (hashSet.Contains(item))
				{
					continue;
				}
				float num4 = waterData[item];
				WaterFlatArea waterFlatArea = waterFlatAreaPool.Get();
				waterFlatArea.Y = GridDataIndexTools.GetY(item);
				waterFlatArea.HeightAndWaterLevel = (float)waterFlatArea.Y + num4;
				hashSet.Add(item);
				queue.Clear();
				queue.Enqueue(item);
				bool flag = waterShouldExist[item];
				while (queue.Count > 0)
				{
					int num5 = queue.Dequeue();
					if (flowInData[num5] > 0f)
					{
						waterFlatArea.WaterAmount += MathfUtils.Max(flowInData[num5], waterData[num5]);
					}
					else
					{
						waterFlatArea.WaterAmount += waterData[num5];
					}
					waterFlatArea.Nodes.Add(num5);
					if (!waterShouldExist[num5])
					{
						waterFlatArea.ShouldWaterExist = false;
					}
					int x3 = GridDataIndexTools.GetX(num5);
					int y3 = GridDataIndexTools.GetY(num5);
					int z3 = GridDataIndexTools.GetZ(num5);
					for (int j = 0; j < MapNodeUtils.NeighborsHorizontalX.Length; j++)
					{
						int x4 = x3 + MapNodeUtils.NeighborsHorizontalX[j];
						int z4 = z3 + MapNodeUtils.NeighborsHorizontalZ[j];
						if (GridDataIndexTools.InRangeX(x4) && GridDataIndexTools.InRangeZ(z4))
						{
							int num6 = GridDataIndexTools.FastTo1DIndexNoCheck(x4, y3, z4);
							if (currentTempVolume.Contains(num6) && !hashSet.Contains(num6) && Math.Abs(waterData[num6] - num4) < 0.01f && flag == waterShouldExist[num6])
							{
								hashSet.Add(num6);
								queue.Enqueue(num6);
							}
						}
					}
				}
				areasInVolume.Add(waterFlatArea);
			}
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet);
			QueuePool<int>.Return(queue);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Water\\WaterSimLogic.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Sliced volume into ");
				messageBuilder.AppendFormatted(areasInVolume.Count);
				messageBuilder.AppendLiteral(" flat areas");
			}
			Log.Trace(messageBuilder);
			return currentTempVolume.Count > 0;
		}

		private void CollectAreasFull(IReadOnlyList<WaterFlatArea> areasToCheck, ISet<int> result)
		{
			for (int i = 0; i < areasToCheck.Count; i++)
			{
				bool flag = true;
				foreach (int node in areasToCheck[i].Nodes)
				{
					if (waterData[node] < 1f)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					result.Add(i);
				}
			}
		}

		private bool SearchWaterfallNeighbor(int nx, int ny, int nz, int neighborIndex, WaterFlatArea neighborArea)
		{
			if (neighborArea != null && neighborArea.LeadsDownToMapEdge && waterfalls[neighborIndex])
			{
				int num = GridDataIndexTools.FastTo1DIndexNoCheck(nx, ny - 1, nz);
				if ((ny == 0 || waterData[num] > 0f) && edgeAccessibleWaterBlocker[neighborIndex])
				{
					return true;
				}
			}
			return false;
		}

		private void CollectExpandPositions(List<WaterFlatArea> areasInVolume, HashSet<int> areaFull, ISet<int> expandTo, HashSet<int> newWaterNodes, HashSet<int> currentTempVolume)
		{
			using PooledHashSet<int> pooledHashSet = NSMedieval.Utils.Pool.HashSetPool<int>.GetJanitor();
			foreach (WaterFlatArea item in areasInVolume)
			{
				if (item.ShouldDisappear)
				{
					continue;
				}
				foreach (int node in item.Nodes)
				{
					if (obstacleData[node] == 2 || obstacleData[node] == 3 || newWaterNodes.Contains(node))
					{
						continue;
					}
					int y = GridDataIndexTools.GetY(node);
					if (y > 0)
					{
						int x = GridDataIndexTools.GetX(node);
						int z = GridDataIndexTools.GetZ(node);
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(x, y - 1, z);
						if (obstacleData[num] != 1 && waterData[num] <= 0f && !newWaterNodes.Contains(num))
						{
							expandTo.Add(num);
							item.ExpandedVertically.Add(num);
							pooledHashSet.Add(node);
						}
					}
				}
			}
			for (int i = 0; i < areasInVolume.Count; i++)
			{
				WaterFlatArea waterFlatArea = areasInVolume[i];
				if (waterFlatArea.WaterAmount <= (float)waterFlatArea.Nodes.Count * 0.05f || AnyLowerAreaExpandedOrNotFull(waterFlatArea))
				{
					continue;
				}
				bool flag = SearchUpperConnectedAreas(waterFlatArea, skipStartAreaCheck: false, (WaterFlatArea a) => a.ConnectedDirectlyToMapEdge);
				foreach (int node2 in waterFlatArea.Nodes)
				{
					if (waterData[node2] <= 0.05f)
					{
						continue;
					}
					bool flag2 = edgeAccessibleWaterBlocker[node2];
					bool flag3 = false;
					int indexUnder = GetIndexUnder(node2);
					if (indexUnder != node2 && obstacleData[node2] == 0)
					{
						flag3 = waterData[indexUnder] > 0f && obstacleData[indexUnder] != 1;
						if (obstacleData[indexUnder] == 0 && waterData[indexUnder] > 0f && waterData[indexUnder] < 1f)
						{
							continue;
						}
						int num2 = nodeToAreaIndex[indexUnder];
						WaterFlatArea waterFlatArea2 = ((num2 >= 0) ? areasInVolume[num2] : null);
						if ((obstacleData[indexUnder] != 1 && waterData[indexUnder] > 0f && waterData[node2] > 0f && waterFlatArea.ConnectionDown.Contains(waterFlatArea2) && waterFlatArea2 != null && waterFlatArea2.FlowOutAmount > 0f) || (waterFlatArea2 != null && !waterFlatArea2.LeadsDownToOnlyFullAreas))
						{
							continue;
						}
					}
					int x2 = GridDataIndexTools.GetX(node2);
					int y2 = GridDataIndexTools.GetY(node2);
					int z2 = GridDataIndexTools.GetZ(node2);
					if ((flag && SearchEachNeighbor(x2, y2, z2, areasInVolume, SearchWaterfallNeighbor)) || pooledHashSet.Contains(node2) || (y2 > 0 && !flag2 && waterData[indexUnder] < 1f && obstacleData[indexUnder] != 1 && obstacleData[node2] != 3 && obstacleData[node2] != 2))
					{
						continue;
					}
					for (int num3 = 0; num3 < MapNodeUtils.NeighborsHorizontalX.Length; num3++)
					{
						int x3 = x2 + MapNodeUtils.NeighborsHorizontalX[num3];
						int z3 = z2 + MapNodeUtils.NeighborsHorizontalZ[num3];
						if (!GridDataIndexTools.InRangeX(x3) || !GridDataIndexTools.InRangeZ(z3))
						{
							continue;
						}
						int num4 = GridDataIndexTools.FastTo1DIndexNoCheck(x3, y2, z3);
						if (pooledHashSet.Contains(num4) || expandTo.Contains(num4) || currentTempVolume.Contains(num4) || newWaterNodes.Contains(num4))
						{
							continue;
						}
						bool flag4 = waterData[num4] <= 0f && obstacleData[num4] == 0;
						flag4 |= obstacleData[num4] == 2 && waterData[node2] > 0.35f && waterData[num4] < 0.35f;
						flag4 |= obstacleData[num4] == 3;
						int indexUnder2 = GetIndexUnder(num4);
						if (indexUnder2 != num4 && obstacleData[indexUnder2] != 1)
						{
							bool flag5 = waterData[indexUnder2] > 0f;
							if (flag3 && !flag5)
							{
								flag4 = false;
							}
						}
						if (!flag4)
						{
							continue;
						}
						expandTo.Add(num4);
						waterFlatArea.ExpandedHorizontally.Add(num4);
						if (!IsMapEdge(num4))
						{
							areaFull.Remove(i);
						}
						pooledHashSet.Add(num4);
						pooledHashSet.Add(node2);
						for (int num5 = y2 + 1; num5 < mapSizeY; num5++)
						{
							int num6 = GridDataIndexTools.FastTo1DIndexNoCheck(x3, num5, z3);
							if (obstacleData[num6] != 0 || waterData[num6] > 0f)
							{
								break;
							}
							pooledHashSet.Add(num6);
						}
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool AnyLowerAreaExpandedOrNotFull(WaterFlatArea currentArea)
		{
			return SearchLowerConnectedAreas(currentArea, skipStartAreaCheck: true, (WaterFlatArea area) => area.ExpandedHorizontally.Count > 0 || area.ExpandedVertically.Count > 0);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool SearchUpperConnectedAreas(WaterFlatArea startArea, bool skipStartAreaCheck, AreaSearchMethod areaSearchMethod)
		{
			return SearchConnectedAreas(startArea, skipStartAreaCheck, isUpper: true, areaSearchMethod);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool SearchLowerConnectedAreas(WaterFlatArea startArea, bool skipStartAreaCheck, AreaSearchMethod areaSearchMethod)
		{
			return SearchConnectedAreas(startArea, skipStartAreaCheck, isUpper: false, areaSearchMethod);
		}

		private static bool SearchConnectedAreas(WaterFlatArea startArea, bool skipStartAreaCheck, bool isUpper, AreaSearchMethod areaSearchMethod)
		{
			if (!skipStartAreaCheck && areaSearchMethod(startArea))
			{
				return true;
			}
			Queue<WaterFlatArea> queue = QueuePool<WaterFlatArea>.Get();
			foreach (WaterFlatArea item in isUpper ? startArea.ConnectionUp : startArea.ConnectionDown)
			{
				queue.Enqueue(item);
			}
			while (queue.Count > 0)
			{
				WaterFlatArea waterFlatArea = queue.Dequeue();
				if (areaSearchMethod(waterFlatArea))
				{
					QueuePool<WaterFlatArea>.Return(queue);
					return true;
				}
				foreach (WaterFlatArea item2 in isUpper ? waterFlatArea.ConnectionUp : waterFlatArea.ConnectionDown)
				{
					queue.Enqueue(item2);
				}
			}
			QueuePool<WaterFlatArea>.Return(queue);
			return false;
		}

		private static void TraverseAllConnectedAreas(WaterFlatArea startArea, bool isUpper, AreaTraverseMethod areaProcessMethod)
		{
			Queue<WaterFlatArea> queue = QueuePool<WaterFlatArea>.Get();
			queue.Enqueue(startArea);
			while (queue.Count > 0)
			{
				WaterFlatArea waterFlatArea = queue.Dequeue();
				areaProcessMethod(waterFlatArea);
				foreach (WaterFlatArea item in isUpper ? waterFlatArea.ConnectionUp : waterFlatArea.ConnectionDown)
				{
					queue.Enqueue(item);
				}
			}
			QueuePool<WaterFlatArea>.Return(queue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void TraverseAllConnectedUpperAreas(WaterFlatArea startArea, AreaTraverseMethod areaProcessMethod)
		{
			TraverseAllConnectedAreas(startArea, isUpper: true, areaProcessMethod);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void TraverseAllConnectedLowerAreas(WaterFlatArea startArea, AreaTraverseMethod areaProcessMethod)
		{
			TraverseAllConnectedAreas(startArea, isUpper: false, areaProcessMethod);
		}

		private static int GetIndexUnder(int nodeIndex)
		{
			int y = GridDataIndexTools.GetY(nodeIndex);
			if (y == 0)
			{
				return nodeIndex;
			}
			int x = GridDataIndexTools.GetX(nodeIndex);
			int z = GridDataIndexTools.GetZ(nodeIndex);
			return GridDataIndexTools.FastTo1DIndexNoCheck(x, y - 1, z);
		}

		private static void SortedInsertToAreasInVolume(IList<WaterFlatArea> areasInVolume, WaterFlatArea upperArea)
		{
			int index = 0;
			for (int i = 0; i < areasInVolume.Count; i++)
			{
				if (upperArea.HeightAndWaterLevel < areasInVolume[i].HeightAndWaterLevel)
				{
					index = i;
					break;
				}
			}
			areasInVolume.Insert(index, upperArea);
		}

		private void ExpandWaterToNewNodes(List<WaterFlatArea> volumeFlatAreas)
		{
			if (CheckAllAreasClosed(volumeFlatAreas))
			{
				float num = 0f;
				foreach (WaterFlatArea volumeFlatArea in volumeFlatAreas)
				{
					num += volumeFlatArea.WaterAmount;
				}
				HashSet<int> hashSet = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
				for (int i = 0; i < mapSizeY; i++)
				{
					hashSet.Clear();
					float num2 = 0f;
					foreach (WaterFlatArea volumeFlatArea2 in volumeFlatAreas)
					{
						if (volumeFlatArea2.Y == i && (volumeFlatArea2.ExpandedHorizontally.Count != 0 || volumeFlatArea2.ExpandedVertically.Count != 0 || !(volumeFlatArea2.FlowOutAmount > 0f)))
						{
							hashSet.UnionWith(volumeFlatArea2.Nodes);
							hashSet.UnionWith(volumeFlatArea2.ExpandedHorizontally);
							hashSet.UnionWith(volumeFlatArea2.ExpandedVertically);
							num2 += volumeFlatArea2.WaterAmount;
						}
					}
					if (hashSet.Count <= 0)
					{
						continue;
					}
					float num3 = MathfUtils.Min(num, MathfUtils.Min(hashSet.Count, num2 + (float)hashSet.Count * 0.1f));
					float num4 = num3 / (float)hashSet.Count;
					foreach (int item in hashSet)
					{
						waterData[item] = num4;
					}
					num -= num3;
				}
				NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet);
				return;
			}
			foreach (WaterFlatArea area in volumeFlatAreas)
			{
				float waterToGet = (float)(area.ExpandedHorizontally.Count + area.ExpandedVertically.Count + area.Nodes.Count) - area.WaterAmount;
				if (waterToGet <= 0f)
				{
					continue;
				}
				foreach (int node in area.Nodes)
				{
					GetUppermostArea(node, volumeFlatAreas, delegate(WaterFlatArea fromArea, int nodeIndexUp)
					{
						float num8 = MathfUtils.Min(MathfUtils.Min(waterToGet, fromArea.WaterAmount), 3f);
						area.WaterAmount += num8;
						fromArea.WaterAmount -= num8;
						waterToGet -= num8;
					});
				}
			}
			HashSet<int> allExpandedNodes = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			Dictionary<int, WaterFlatArea> dictionary = NSMedieval.Utils.Pool.DictionaryPool<int, WaterFlatArea>.Get();
			foreach (WaterFlatArea volumeFlatArea3 in volumeFlatAreas)
			{
				if (volumeFlatArea3.ExpandedHorizontally.Count <= 0)
				{
					continue;
				}
				allExpandedNodes.UnionWith(volumeFlatArea3.ExpandedHorizontally);
				foreach (int item2 in volumeFlatArea3.ExpandedHorizontally)
				{
					dictionary.Add(item2, volumeFlatArea3);
				}
			}
			Queue<int> queue = QueuePool<int>.Get();
			HashSet<int> hashSet2 = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			HashSet<WaterFlatArea> hashSet3 = NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Get();
			HashSet<int> processedNeighbors = NSMedieval.Utils.Pool.HashSetPool<int>.Get();
			foreach (int item3 in allExpandedNodes)
			{
				if (processedNeighbors.Contains(item3))
				{
					continue;
				}
				queue.Clear();
				queue.Enqueue(item3);
				hashSet2.Clear();
				hashSet3.Clear();
				while (queue.Count > 0)
				{
					int num5 = queue.Dequeue();
					processedNeighbors.Add(num5);
					hashSet2.Add(num5);
					int x = GridDataIndexTools.GetX(num5);
					int y = GridDataIndexTools.GetY(num5);
					int z = GridDataIndexTools.GetZ(num5);
					ForEachNeighbor(x, y, z, goThroughDiagonal: true, goThroughNonDiagonal: true, delegate(int nx, int ny, int nz, int neighborIndex)
					{
						if (!processedNeighbors.Contains(neighborIndex) && allExpandedNodes.Contains(neighborIndex))
						{
							processedNeighbors.Add(neighborIndex);
							queue.Enqueue(neighborIndex);
						}
					});
				}
				float num6 = 0f;
				int num7 = 0;
				foreach (int item4 in hashSet2)
				{
					WaterFlatArea waterFlatArea = dictionary[item4];
					if (hashSet3.Add(waterFlatArea))
					{
						num6 += waterFlatArea.WaterAmount;
						num7 += waterFlatArea.Nodes.Count + waterFlatArea.ExpandedHorizontally.Count + waterFlatArea.ExpandedVertically.Count;
					}
				}
				float waterPerNode = num6 / (float)num7;
				foreach (WaterFlatArea item5 in hashSet3)
				{
					SetWaterAcrossArea(item5, waterPerNode);
				}
			}
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(hashSet2);
			hashSet2 = null;
			QueuePool<int>.Return(queue);
			queue = null;
			foreach (WaterFlatArea volumeFlatArea4 in volumeFlatAreas)
			{
				if (!hashSet3.Contains(volumeFlatArea4))
				{
					float waterPerNode2 = volumeFlatArea4.WaterAmount / (float)(volumeFlatArea4.Nodes.Count + volumeFlatArea4.ExpandedHorizontally.Count + volumeFlatArea4.ExpandedVertically.Count);
					SetWaterAcrossArea(volumeFlatArea4, waterPerNode2);
				}
			}
			NSMedieval.Utils.Pool.HashSetPool<WaterFlatArea>.Return(hashSet3);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(processedNeighbors);
			NSMedieval.Utils.Pool.HashSetPool<int>.Return(allExpandedNodes);
			NSMedieval.Utils.Pool.DictionaryPool<int, WaterFlatArea>.Return(dictionary);
		}

		private void GetUppermostArea(int nodeIndex, List<WaterFlatArea> volumeFlatAreas, Action<WaterFlatArea, int> callback)
		{
			int x = GridDataIndexTools.GetX(nodeIndex);
			int num = GridDataIndexTools.GetY(nodeIndex);
			int z = GridDataIndexTools.GetZ(nodeIndex);
			WaterFlatArea waterFlatArea = null;
			int arg = -1;
			while (true)
			{
				num++;
				if (num >= mapSizeY)
				{
					break;
				}
				int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(x, num, z);
				if (obstacleData[num2] != 0 || nodeToAreaIndex[num2] == -1 || volumeFlatAreas[nodeToAreaIndex[num2]].WaterAmount <= 0f)
				{
					break;
				}
				waterFlatArea = volumeFlatAreas[nodeToAreaIndex[num2]];
				arg = nodeIndex;
			}
			if (waterFlatArea != null)
			{
				callback?.Invoke(waterFlatArea, arg);
			}
		}

		private void SetWaterAcrossArea(WaterFlatArea area, float waterPerNode)
		{
			foreach (int node in area.Nodes)
			{
				waterData[node] = waterPerNode;
			}
			foreach (int item in area.ExpandedHorizontally)
			{
				waterData[item] = waterPerNode;
			}
			foreach (int item2 in area.ExpandedVertically)
			{
				waterData[item2] = waterPerNode;
			}
		}

		private bool CheckAllAreasClosed(List<WaterFlatArea> volumeFlatAreas)
		{
			bool flag = true;
			foreach (WaterFlatArea volumeFlatArea in volumeFlatAreas)
			{
				foreach (int node in volumeFlatArea.Nodes)
				{
					if (edgeAccessibleWaterBlocker[node] || !volumeFlatArea.ShouldWaterExist)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			return flag;
		}

		private void DetectEdgeAccessibleAreasWaterBlocker()
		{
			for (int i = 0; i < dataLength; i++)
			{
				processedIndex[i] = false;
				edgeAccessibleWaterBlocker[i] = false;
			}
			using PooledQueue<int> queue = QueuePool<int>.GetJanitor();
			foreach (int mapEdgeNode in mapEdgeNodes)
			{
				if (!processedIndex[mapEdgeNode] && obstacleData[mapEdgeNode] != 1 && !(waterData[mapEdgeNode] > 0f))
				{
					EdgeAccessibilityFloodfill(queue, mapEdgeNode, ref edgeAccessibleWaterBlocker, waterIsBlocker: true);
				}
			}
		}

		private void DetectEdgeAccessibleAreas()
		{
			for (int i = 0; i < dataLength; i++)
			{
				processedIndex[i] = false;
				edgeAccessible[i] = false;
			}
			using PooledQueue<int> queue = QueuePool<int>.GetJanitor();
			foreach (int mapEdgeNode in mapEdgeNodes)
			{
				if (!processedIndex[mapEdgeNode] && obstacleData[mapEdgeNode] != 1)
				{
					EdgeAccessibilityFloodfill(queue, mapEdgeNode, ref edgeAccessible, waterIsBlocker: false);
				}
			}
			queue.Clear();
			for (int j = 0; j < dataLength; j++)
			{
				processedIndex[j] = false;
			}
			for (int k = 0; k < dataLength; k++)
			{
				if (edgeAccessible[k])
				{
					continue;
				}
				GridDataIndexTools.FastTo3DIndex(k, out var x, out var y, out var z);
				if (y <= 0)
				{
					continue;
				}
				y--;
				int num = GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z);
				if (obstacleData[num] != 0 || obstacleData[k] != 0 || !edgeAccessible[num])
				{
					continue;
				}
				queue.Clear();
				queue.Enqueue(k);
				processedIndex[k] = true;
				while (queue.Count > 0)
				{
					int num2 = queue.Dequeue();
					edgeAccessible[num2] = true;
					int x2 = GridDataIndexTools.GetX(num2);
					int y2 = GridDataIndexTools.GetY(num2);
					int z2 = GridDataIndexTools.GetZ(num2);
					for (int l = 0; l < MapNodeUtils.NeighborsHorizontalX.Length; l++)
					{
						int x3 = x2 + MapNodeUtils.NeighborsHorizontalX[l];
						if (!GridDataIndexTools.InRangeX(x3))
						{
							continue;
						}
						int z3 = z2 + MapNodeUtils.NeighborsHorizontalZ[l];
						if (GridDataIndexTools.InRangeZ(z3))
						{
							int num3 = GridDataIndexTools.FastTo1DIndexNoCheck(x3, y2, z3);
							if (obstacleData[num3] != 1 && obstacleData[num3] != 2 && !edgeAccessible[num3] && !processedIndex[num3])
							{
								processedIndex[num3] = true;
								queue.Enqueue(num3);
							}
						}
					}
				}
			}
			queue.Clear();
		}

		private void EdgeAccessibilityFloodfill(PooledQueue<int> queue, int startIndex, ref bool[] edgeAccessibleArray, bool waterIsBlocker)
		{
			if (processedIndex[startIndex])
			{
				return;
			}
			queue.Clear();
			queue.Enqueue(startIndex);
			while (queue.Count > 0)
			{
				int num = queue.Dequeue();
				processedIndex[num] = true;
				edgeAccessibleArray[num] = true;
				int x = GridDataIndexTools.GetX(num);
				int y = GridDataIndexTools.GetY(num);
				int z = GridDataIndexTools.GetZ(num);
				for (int i = 0; i < MapNodeUtils.NeighborsHorizontalX.Length; i++)
				{
					int x2 = x + MapNodeUtils.NeighborsHorizontalX[i];
					if (!GridDataIndexTools.InRangeX(x2))
					{
						continue;
					}
					int z2 = z + MapNodeUtils.NeighborsHorizontalZ[i];
					if (GridDataIndexTools.InRangeZ(z2))
					{
						int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(x2, y, z2);
						if (!processedIndex[num2] && obstacleData[num2] != 1 && (!waterIsBlocker || !(waterData[num2] > 0f)))
						{
							processedIndex[num2] = true;
							queue.Enqueue(num2);
						}
					}
				}
			}
		}

		private void DetectWaterfalls()
		{
			for (int i = 0; i < dataLength; i++)
			{
				processedIndex[i] = false;
				waterfalls[i] = false;
			}
			for (int j = 0; j < dataLength; j++)
			{
				if (processedIndex[j] || obstacleData[j] != 0)
				{
					continue;
				}
				int x = GridDataIndexTools.GetX(j);
				int y = GridDataIndexTools.GetY(j);
				int z = GridDataIndexTools.GetZ(j);
				int k = y;
				bool flag = false;
				for (; GridDataIndexTools.InRangeY(k); k++)
				{
					int num = GridDataIndexTools.FastTo1DIndexNoCheck(x, k, z);
					if (obstacleData[num] == 1 || (k > y && obstacleData[num] != 0))
					{
						break;
					}
					if (!flag)
					{
						for (int l = 0; l < MapNodeUtils.NeighborsHorizontalX.Length; l++)
						{
							int x2 = x + MapNodeUtils.NeighborsHorizontalX[l];
							int z2 = z + MapNodeUtils.NeighborsHorizontalZ[l];
							if (GridDataIndexTools.InRangeXZ(x2, z2))
							{
								int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(x2, k, z2);
								if (obstacleData[num2] == 1)
								{
									flag = true;
									break;
								}
							}
						}
					}
					if (flag && k >= y + 1)
					{
						waterfalls[num] = true;
					}
					processedIndex[num] = true;
				}
			}
		}

		public static bool SearchEachNeighbor(int x, int y, int z, NeighborSearchDelegate action)
		{
			for (int i = 0; i < MapNodeUtils.NeighborsHorizontalX.Length; i++)
			{
				int num = x + MapNodeUtils.NeighborsHorizontalX[i];
				int num2 = z + MapNodeUtils.NeighborsHorizontalZ[i];
				if (GridDataIndexTools.InRangeX(num) && GridDataIndexTools.InRangeZ(num2))
				{
					int neighborIndex = GridDataIndexTools.FastTo1DIndexNoCheck(num, y, num2);
					if (action(num, y, num2, neighborIndex))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool SearchEachNeighbor(int x, int y, int z, List<WaterFlatArea> areas, NeighborSearchDelegateWithArea action)
		{
			for (int i = 0; i < MapNodeUtils.NeighborsHorizontalX.Length; i++)
			{
				int num = x + MapNodeUtils.NeighborsHorizontalX[i];
				int num2 = z + MapNodeUtils.NeighborsHorizontalZ[i];
				if (GridDataIndexTools.InRangeX(num) && GridDataIndexTools.InRangeZ(num2))
				{
					int num3 = GridDataIndexTools.FastTo1DIndexNoCheck(num, y, num2);
					int num4 = nodeToAreaIndex[num3];
					WaterFlatArea neighborArea = ((num4 != -1) ? areas[num4] : null);
					if (action(num, y, num2, num3, neighborArea))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static void ForEachNeighbor(int x, int y, int z, NeighborOperationDelegate action)
		{
			for (int i = 0; i < MapNodeUtils.NeighborsHorizontalX.Length; i++)
			{
				int num = x + MapNodeUtils.NeighborsHorizontalX[i];
				int num2 = z + MapNodeUtils.NeighborsHorizontalZ[i];
				if (GridDataIndexTools.InRangeX(num) && GridDataIndexTools.InRangeZ(num2))
				{
					int neighborIndex = GridDataIndexTools.FastTo1DIndexNoCheck(num, y, num2);
					action(num, y, num2, neighborIndex);
				}
			}
		}

		private static void ForEachDiagonalNeighbor(int x, int y, int z, NeighborOperationDelegate action)
		{
			for (int i = 0; i < MapNodeUtils.NeighborsHorizontalDiagonalX.Length; i++)
			{
				int num = x + MapNodeUtils.NeighborsHorizontalDiagonalX[i];
				int num2 = z + MapNodeUtils.NeighborsHorizontalDiagonalZ[i];
				if (GridDataIndexTools.InRangeX(num) && GridDataIndexTools.InRangeZ(num2))
				{
					int neighborIndex = GridDataIndexTools.FastTo1DIndexNoCheck(num, y, num2);
					action(num, y, num2, neighborIndex);
				}
			}
		}

		private static void ForEachNeighbor(int x, int y, int z, bool goThroughDiagonal, bool goThroughNonDiagonal, NeighborOperationDelegate action)
		{
			if (goThroughNonDiagonal)
			{
				ForEachNeighbor(x, y, z, action);
			}
			if (goThroughDiagonal)
			{
				ForEachDiagonalNeighbor(x, y, z, action);
			}
		}

		private static void ForEachNeighborAndDown(int x, int y, int z, NeighborOperationDelegate action)
		{
			if (GridDataIndexTools.InRangeX(x) && GridDataIndexTools.InRangeZ(z) && GridDataIndexTools.InRangeY(y - 1))
			{
				int neighborIndex = GridDataIndexTools.FastTo1DIndexNoCheck(x, y - 1, z);
				action(x, y - 1, z, neighborIndex);
			}
			ForEachNeighbor(x, y, z, action);
		}

		public void SetWaterAt(int x, int y, int z, float waterLevel)
		{
			if (GridDataIndexTools.InRange(x, y, z))
			{
				waterData[GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z)] = waterLevel;
			}
		}

		public void SetWaterAt(int nodeIndex, float waterLevel)
		{
			waterData[nodeIndex] = waterLevel;
		}

		public void SetObstacleAt(int x, int y, int z, int obstacleValue)
		{
			if (GridDataIndexTools.InRange(x, y, z))
			{
				obstacleData[GridDataIndexTools.FastTo1DIndexNoCheck(x, y, z)] = obstacleValue;
				obstacleStateChanged = true;
				obstacleStateChangedForRiverBlocked = true;
			}
		}

		public void SetFlowInAt(int nodeIndex, bool flowIn)
		{
			if (flowIn)
			{
				flowInData[nodeIndex] = 10f;
				waterFlowIn.Add(nodeIndex);
			}
			else
			{
				flowInData[nodeIndex] = 0f;
				waterFlowIn.Remove(nodeIndex);
			}
		}

		public bool IsFlowInAt(int nodeIndex)
		{
			return waterFlowIn.Contains(nodeIndex);
		}

		public void SetFlowOutAt(int nodeIndex, bool flowOut)
		{
			flowOutData[nodeIndex] = flowOut;
		}

		public void CheckNodesChanged()
		{
			if (StopThread)
			{
				return;
			}
			nodesChanged.Clear();
			nodesChanged.UnionWith(depthChanged);
			depthChanged.Clear();
			for (int i = 0; i < dataLength; i++)
			{
				if (Math.Abs(waterDataDisplayPrev[i] - waterDataDisplay[i]) > 0.02f)
				{
					nodesChanged.Add(i);
					waterDataDisplayPrev[i] = waterDataDisplay[i];
				}
			}
			nodesChangedNeighbors.Clear();
			foreach (int item2 in nodesChanged)
			{
				int x = GridDataIndexTools.GetX(item2);
				int y = GridDataIndexTools.GetY(item2);
				int z = GridDataIndexTools.GetZ(item2);
				for (int j = -1; j <= 1; j++)
				{
					int y2 = y + j;
					if (!GridDataIndexTools.InRangeY(y2))
					{
						continue;
					}
					for (int k = -1; k <= 1; k++)
					{
						int x2 = x + k;
						if (!GridDataIndexTools.InRangeX(x2))
						{
							continue;
						}
						for (int l = -1; l <= 1; l++)
						{
							if (l == 0 && k == 0 && j == 0)
							{
								continue;
							}
							int z2 = z + l;
							if (GridDataIndexTools.InRangeZ(z2))
							{
								int item = GridDataIndexTools.FastTo1DIndexNoCheck(x2, y2, z2);
								if (!nodesChanged.Contains(item))
								{
									nodesChangedNeighbors.Add(item);
								}
							}
						}
					}
				}
			}
		}

		public void CalculateWaterDepth()
		{
			for (int i = 0; i < dataLength; i++)
			{
				waterDepth[i] = 0f;
			}
			if (StopThread)
			{
				return;
			}
			for (int j = 0; j < mapSizeX; j++)
			{
				for (int k = 0; k < mapSizeY; k++)
				{
					for (int l = 0; l < mapSizeZ; l++)
					{
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(j, k, l);
						WaterDepthLevel num2 = waterLevel[num];
						WaterDepthLevel waterDepthLevel = waterDepthLevels[num];
						waterLevel[num] = CalculateWaterDepthLevel(waterDataDisplay[num]);
						if (obstacleData[num] != 0)
						{
							waterDepth[num] = waterDataDisplay[num];
							waterDepthLevels[num] = CalculateWaterDepthLevel(waterDepth[num]);
						}
						else if (waterDataDisplay[num] <= 0f)
						{
							waterDepth[num] = 0f;
							waterDepthLevels[num] = CalculateWaterDepthLevel(waterDepth[num]);
						}
						else
						{
							waterDepth[num] += waterDataDisplay[num];
							if (obstacleData[num] == 0 && GridDataIndexTools.InRangeY(k - 1))
							{
								int num3 = GridDataIndexTools.FastTo1DIndexNoCheck(j, k - 1, l);
								if (obstacleData[num3] != 1)
								{
									waterDepth[num] += waterDepth[num3];
								}
							}
							waterDepthLevels[num] = CalculateWaterDepthLevel(waterDepth[num]);
						}
						if (num2 != waterLevel[num] || waterDepthLevel != waterDepthLevels[num])
						{
							depthChanged.Add(num);
						}
					}
				}
			}
		}

		private static WaterDepthLevel CalculateWaterDepthLevel(float waterDepth)
		{
			if (waterDepth <= 0f)
			{
				return WaterDepthLevel.None;
			}
			if (waterDepth < WaterConstants.WaterLevelsStart[0])
			{
				return WaterDepthLevel.Low;
			}
			if (waterDepth < WaterConstants.WaterLevelsStart[1])
			{
				return WaterDepthLevel.Medium;
			}
			return WaterDepthLevel.High;
		}

		public void PrepareWaterDisplayData()
		{
			if (StopThread)
			{
				return;
			}
			for (int num = mapSizeY - 2; num >= 0; num--)
			{
				for (int i = 0; i < mapSizeX; i++)
				{
					for (int j = 0; j < mapSizeZ; j++)
					{
						int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(i, num, j);
						if (waterData[num2] > 0f)
						{
							if (obstacleData[num2] == 2 && waterData[num2] < 0.35f)
							{
								waterDataDisplay[num2] = 0f;
								continue;
							}
							int num3 = GridDataIndexTools.FastTo1DIndexNoCheck(i, num + 1, j);
							if (waterData[num3] > 0f && obstacleData[num3] == 0)
							{
								waterDataDisplay[num2] = 1f;
								continue;
							}
						}
						waterDataDisplay[num2] = waterData[num2];
					}
				}
			}
			for (int k = 0; k < dataLength; k++)
			{
				if (!(waterDataDisplay[k] <= 0f))
				{
					if (waterDataDisplay[k] < WaterConstants.WaterLevelsStart[0])
					{
						waterDataDisplay[k] = WaterConstants.WaterLevelsDisplay[0];
					}
					else if (waterDataDisplay[k] < WaterConstants.WaterLevelsStart[1])
					{
						waterDataDisplay[k] = WaterConstants.WaterLevelsDisplay[1];
					}
					else
					{
						waterDataDisplay[k] = WaterConstants.WaterLevelsDisplay[2];
					}
				}
			}
		}

		public void Dispose()
		{
		}

		public byte[] GetBinaryDataToSerialize()
		{
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(mapSizeX);
			binaryWriter.Write(mapSizeY);
			binaryWriter.Write(mapSizeZ);
			for (int i = 0; i < dataLength; i++)
			{
				binaryWriter.Write(waterData[i]);
			}
			for (int j = 0; j < dataLength; j++)
			{
				binaryWriter.Write(flowInData[j]);
			}
			for (int k = 0; k < dataLength; k++)
			{
				binaryWriter.Write(obstacleData[k]);
			}
			for (int l = 0; l < dataLength; l++)
			{
				binaryWriter.Write((byte)(flowOutData[l] ? 1u : 0u));
			}
			if (riverHeight != null && riverHeight.Length != 0)
			{
				binaryWriter.Write(riverHeight.Length);
				float[] array = riverHeight;
				foreach (float value in array)
				{
					binaryWriter.Write(value);
				}
			}
			return memoryStream.GetBuffer();
		}

		public void ReadFromBinaryData(byte[] inputData)
		{
			if (inputData == null)
			{
				return;
			}
			MemoryStream memoryStream = new MemoryStream(inputData);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			mapSizeX = binaryReader.ReadInt32();
			mapSizeY = binaryReader.ReadInt32();
			mapSizeZ = binaryReader.ReadInt32();
			dataLength = mapSizeX * mapSizeY * mapSizeZ;
			if (memoryStream.Length < dataLength)
			{
				return;
			}
			for (int i = 0; i < dataLength; i++)
			{
				waterData[i] = binaryReader.ReadSingle();
			}
			waterFlowIn.Clear();
			for (int j = 0; j < dataLength; j++)
			{
				flowInData[j] = binaryReader.ReadSingle();
				if (flowInData[j] > 0f)
				{
					waterFlowIn.Add(j);
				}
			}
			if (memoryStream.Position < memoryStream.Length)
			{
				for (int k = 0; k < DataLength; k++)
				{
					obstacleData[k] = binaryReader.ReadInt32();
				}
			}
			for (int l = 0; l < dataLength; l++)
			{
				if (memoryStream.Position >= memoryStream.Length)
				{
					break;
				}
				flowOutData[l] = binaryReader.ReadByte() == 1;
			}
			if (memoryStream.Position >= memoryStream.Length)
			{
				return;
			}
			int num = binaryReader.ReadInt32();
			riverHeight = new float[num];
			for (int m = 0; m < num; m++)
			{
				if (memoryStream.Position >= memoryStream.Length)
				{
					break;
				}
				riverHeight[m] = binaryReader.ReadSingle();
			}
		}

		public void InitVoxelWaterAmount(VillageMap map, float globalWaterHeight, float[,] waterHeightMap, float[,] riverHeight)
		{
			for (int i = 0; i < dataLength; i++)
			{
				MapNode mapNode = map.GridSpaceData[i];
				if (mapNode == null)
				{
					continue;
				}
				if (mapNode.VoxelType == null)
				{
					int x = mapNode.Position.x;
					int z = mapNode.Position.z;
					float num = globalWaterHeight;
					if (waterHeightMap[x, z] > 0f)
					{
						num = MathfUtils.Max(globalWaterHeight, waterHeightMap[x, z] + 1f);
					}
					if ((float)mapNode.Position.y > num)
					{
						if (IsMapEdge(x, z))
						{
							SetFlowOutAt(i, flowOut: true);
						}
					}
					else
					{
						float num2 = MathfUtils.Clamp01(num - (float)mapNode.Position.y);
						waterData[i] = num2;
					}
				}
				else
				{
					waterData[i] = mapNode.VoxelType.SpawnWater;
				}
			}
			int num3 = 0;
			for (int j = 0; j < dataLength; j++)
			{
				MapNode mapNode2 = map.GridSpaceData[j];
				if (mapNode2 != null && !(mapNode2.VoxelType != null) && waterData[j] > 0f)
				{
					MapNode nodeAbove = mapNode2.GetNodeAbove();
					if (nodeAbove == null || (nodeAbove.IsVoxelAir() && waterData[nodeAbove.Index] <= 0f))
					{
						num3++;
					}
				}
			}
			GlobalSaveController.CurrentVillageData.WaterAmountAtNewGame = num3;
		}

		public void DrawGizmos()
		{
		}

		private void DrawGizmoCube(int index)
		{
			int x = GridDataIndexTools.GetX(index);
			int y = GridDataIndexTools.GetY(index);
			int z = GridDataIndexTools.GetZ(index);
			Gizmos.DrawCube(new Vector3(x, y, z), new Vector3(1f, 0.05f, 1f));
		}

		public void GetDebugInfo(Vec3Int pos, StringBuilder stringBuilder)
		{
			stringBuilder.Clear();
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(pos);
			int x = GridDataIndexTools.GetX(num);
			int z = GridDataIndexTools.GetZ(num);
			stringBuilder.AppendLine("[Map] Flow In/Out " + (WaterFlowInOutEnabled ? "Enabled" : "Disabled") + " from map blueprint.");
			stringBuilder.AppendFormat($"Position: {pos}, ");
			stringBuilder.AppendFormat($"Index: {num}, ");
			stringBuilder.AppendFormat($"Obstacle: {obstacleData[num]}, ");
			stringBuilder.AppendFormat($"Water lvl: {waterData[num]}, ");
			stringBuilder.AppendFormat($"Display lvl: {waterDataDisplay[num]}, ");
			stringBuilder.AppendFormat($"Depth: {waterDepth[num]}\n");
			stringBuilder.AppendFormat($"Flow-in: {waterFlowIn.Contains(num)}, ");
			stringBuilder.AppendFormat($"Flow-out: {flowOutData[num]}\n");
			stringBuilder.AppendFormat($"Edge acc: {edgeAccessible[num]}, ");
			stringBuilder.AppendFormat($"WFall: {waterfalls[num]}, ");
			stringBuilder.AppendFormat($"IsMapEdge: {IsMapEdge(x, z)}, ");
			stringBuilder.AppendFormat($"WaterShouldExist: {waterShouldExist[num]}\n");
		}

		public void AfterDeserialize()
		{
			PrepareWaterDisplayData();
			CalculateWaterDepth();
			depthChanged.Clear();
			for (int i = 0; i < dataLength; i++)
			{
				waterDataDisplayPrev[i] = waterDataDisplay[i];
			}
		}

		public void AfterMapGenerated(VillageMap map)
		{
			for (int i = 0; i < DataLength; i++)
			{
				if (waterData[i] > 0f)
				{
					map.GridSpaceData[i].RefreshIsWalkable();
				}
			}
		}

		public float GetWaterLevel(int nodeIndex)
		{
			if (obstacleData[nodeIndex] == 1)
			{
				return 0f;
			}
			return waterDataDisplay[nodeIndex];
		}
	}
}
