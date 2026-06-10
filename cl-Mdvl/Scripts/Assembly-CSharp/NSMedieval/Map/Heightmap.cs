using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Fire;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.Map
{
	public class Heightmap : MonoSingleton<Heightmap>
	{
		public delegate void HeightChangedHandler(int x, int z, int newHeight);

		private static float edgeFrameDistortIntensity;

		private static float edgeFrameNoiseAdd;

		private static int maxDataLength;

		private static int dataLengthWithEdgeFrame;

		[NonSerialized]
		private static NativeArray<int> edgeFrameCoordsPacked;

		private static NativeArray<int> data;

		private static NativeArray<int> dataNoPassthroughFloors;

		private static ComputeBuffer computeBuffer;

		private static ComputeBuffer noPassthroughFloorsComputeBuffer;

		private static ComputeBuffer edgeFrameCoordsPackedComputeBuffer;

		private int dataLength;

		private bool dataLoadedFromSave;

		private bool dataLoaded;

		private byte[,] heightmapMaxNeighbors;

		private int mapSizeX;

		private int mapSizeY;

		private int mapSizeZ;

		private bool forceApplyTexture;

		private readonly Queue<Vector2Int> modified = new Queue<Vector2Int>();

		[NonSerialized]
		private World world;

		[NonSerialized]
		private VillageMap villageMap;

		private MapGenerationTextures mapGenTexturesCache;

		private bool isGameLoaded;

		public const int EdgeFrameSize = 80;

		[NonSerialized]
		private int edgeDistortSeed;

		[NonSerialized]
		private float edgeDistortSeedXAdd;

		[NonSerialized]
		private float edgeDistortSeedZAdd;

		[NonSerialized]
		private int[,] dataWithEdgeFrame;

		[NonSerialized]
		private int mapSizeXWithFrame;

		[NonSerialized]
		private int mapSizeZWithFrame;

		public bool GizmosHeight { get; set; }

		public bool GizmosFloor { get; set; }

		public ComputeBuffer ComputeBuffer => computeBuffer;

		public ComputeBuffer NoPassthroughFloorsComputeBuffer => noPassthroughFloorsComputeBuffer;

		public byte[,] HeightmapMaxNeighbors => heightmapMaxNeighbors;

		public bool IsReady { get; private set; }

		public ComputeBuffer EdgeFrameCoordsComputeBuffer => edgeFrameCoordsPackedComputeBuffer;

		public event HeightChangedHandler HeightChangedAtEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private new static void OnDomainReload()
		{
			edgeFrameDistortIntensity = 55f;
			edgeFrameNoiseAdd = -0.2f;
		}

		public static void InitStaticArrays()
		{
			data = ArrayStorage.GetNativeArray<int>("Heightmap.data", maxDataLength);
			dataNoPassthroughFloors = ArrayStorage.GetNativeArray<int>("Heightmap.dataNoPassthroughFloors", maxDataLength);
			computeBuffer = ArrayStorage.GetComputeBuffer("Heightmap.computeBuffer", maxDataLength, 4);
			noPassthroughFloorsComputeBuffer = ArrayStorage.GetComputeBuffer("Heightmap.noPassthroughFloorsComputeBuffer", maxDataLength, 4);
			edgeFrameCoordsPacked = ArrayStorage.GetNativeArray<int>("Heightmap.edgeFrameCoordsPacked", dataLengthWithEdgeFrame);
			edgeFrameCoordsPackedComputeBuffer = ArrayStorage.GetComputeBuffer("Heightmap.edgeFrameCoordsPackedComputeBuffer", dataLengthWithEdgeFrame, 4);
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(data, dataLength);
			ArrayStorage.ClearNativeArray(dataNoPassthroughFloors, dataLength);
			ArrayStorage.ClearNativeArray(edgeFrameCoordsPacked, dataLengthWithEdgeFrame);
		}

		public static int ClampEdgeX(int x)
		{
			return math.clamp(x, -80, GridDataIndexTools.SizeX + 80 - 1);
		}

		public static int ClampEdgeZ(int z)
		{
			return math.clamp(z, -80, GridDataIndexTools.SizeZ + 80 - 1);
		}

		public void LateUpdate()
		{
			if (isGameLoaded && !LoadingController.IsLeavingMainScene && !LoadingController.IsSceneTransition)
			{
				CheckApplyTextureChange();
			}
		}

		public void Init(VillageMap villageMap, int mapSizeX, int mapSizeY, int mapSizeZ)
		{
			this.villageMap = villageMap;
			this.mapSizeX = mapSizeX;
			this.mapSizeY = mapSizeY;
			this.mapSizeZ = mapSizeZ;
			dataLength = mapSizeX * mapSizeZ;
			maxDataLength = math.max(maxDataLength, dataLength);
			mapSizeXWithFrame = this.mapSizeX + 160;
			mapSizeZWithFrame = this.mapSizeZ + 160;
			dataLengthWithEdgeFrame = mapSizeXWithFrame * mapSizeZWithFrame;
			InitStaticArrays();
			ClearStaticArrays();
			heightmapMaxNeighbors = new byte[this.mapSizeX, this.mapSizeZ];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHeightAt(int x, int z)
		{
			if (!GridDataIndexTools.InRangeXZ(x, z))
			{
				return -1;
			}
			return data[GridDataIndexTools.Get2dIndexXZ(x, z)];
		}

		public void CacheHeightmapWithEdgeFrame()
		{
			if (dataWithEdgeFrame == null)
			{
				dataWithEdgeFrame = new int[mapSizeX + 160, mapSizeZ + 160];
			}
			int num = mapSizeX + 160;
			int num2 = mapSizeZ + 160;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					CalculateEdgeFrameHeight(i - 80, j - 80, out var height, out var outputX, out var outputZ);
					dataWithEdgeFrame[i, j] = height;
					SetEdgeFrameCoords(i - 80, j - 80, outputX, outputZ);
				}
			}
			edgeFrameCoordsPackedComputeBuffer.SetData(edgeFrameCoordsPacked, 0, 0, edgeFrameCoordsPacked.Length);
		}

		private static void SetEdgeFrameCoords(int xWithFrame, int zWithFrame, int xMapSpace, int zMapSpace)
		{
			int value = (xMapSpace << 16) | (zMapSpace & 0xFFFF);
			edgeFrameCoordsPacked[GridDataIndexTools.Get2dIndexXZEdgeFrame(xWithFrame + 80, zWithFrame + 80)] = value;
		}

		public void MapFromEdgeFrameToMapCoords(int xWithFrame, int zWithFrame, out int xMapSpace, out int zMapSpace)
		{
			int num = edgeFrameCoordsPacked[GridDataIndexTools.Get2dIndexXZEdgeFrame(xWithFrame + 80, zWithFrame + 80)];
			xMapSpace = num >> 16;
			zMapSpace = num & 0xFFFF;
		}

		public void CalculateEdgeFrameHeight(int x, int z, out int height, out short outputX, out short outputZ)
		{
			if (!IsInFrame(x, z))
			{
				height = data[GridDataIndexTools.Get2dIndexXZ(x, z)];
				outputX = (short)x;
				outputZ = (short)z;
				return;
			}
			float num = edgeFrameNoiseAdd + Mathf.PerlinNoise((float)x / 25f + edgeDistortSeedXAdd, (float)z / 25f + edgeDistortSeedZAdd);
			float num2 = edgeFrameNoiseAdd + Mathf.PerlinNoise((float)x / 25f - (float)(mapSizeX * 2) + edgeDistortSeedXAdd, (float)(-z) / 25f + edgeDistortSeedZAdd);
			int num3 = mapSizeX + 80;
			int num4 = mapSizeZ + 80;
			int x2 = (int)math.min(math.distance(x, -80f), math.distance(x, num3));
			int y = (int)math.min(math.distance(z, -80f), math.distance(z, num4));
			float valueToClamp = 1f - math.clamp((float)(1 + math.min(x2, y)) / 80f, 0f, 1f);
			valueToClamp = math.clamp(valueToClamp, 0f, 0.5f);
			int valueToClamp2 = x + (short)(num * valueToClamp * edgeFrameDistortIntensity);
			int valueToClamp3 = z + (short)(num2 * valueToClamp * edgeFrameDistortIntensity);
			outputX = (short)math.clamp(valueToClamp2, 1, mapSizeX - 1);
			outputZ = (short)math.clamp(valueToClamp3, 1, mapSizeZ - 1);
			height = GetHeightAt(outputX, outputZ);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsInFrame(int x, int z)
		{
			bool flag = x >= 0 && z >= 0 && x < mapSizeX && z < mapSizeZ;
			if (x >= -80 && z >= -80 && x < mapSizeX + 80 && z < mapSizeZ + 80)
			{
				return !flag;
			}
			return false;
		}

		public int GetHeightEdgeFrameIncluded(int x, int z)
		{
			return dataWithEdgeFrame[x + 80, z + 80];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHeightNoPassthroughFloor(int x, int z)
		{
			if (!GridDataIndexTools.InRangeXZ(x, z))
			{
				return -1;
			}
			return dataNoPassthroughFloors[GridDataIndexTools.Get2dIndexXZ(x, z)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHeightAt(Vector2Int pos)
		{
			return GetHeightAt(pos.x, pos.y);
		}

		public void SaveHeightmapToZip(VillageSaveData saveData)
		{
			byte[] array = new byte[dataLength];
			for (int i = 0; i < dataLength; i++)
			{
				array[i] = (byte)data[i];
			}
			saveData.ZipWriteBytes("heightmap.bin", array);
			byte[] array2 = new byte[dataLength];
			for (int j = 0; j < dataLength; j++)
			{
				array2[j] = (byte)dataNoPassthroughFloors[j];
			}
			saveData.ZipWriteBytes("heightmapNoPassthroughFloors.bin", array2);
		}

		public void SaveHeightmapToCache(VillageSaveData saveData)
		{
			byte[] array = new byte[dataLength];
			for (int i = 0; i < dataLength; i++)
			{
				array[i] = (byte)data[i];
			}
			saveData.CacheWriteBytes("heightmap.bin", array);
			byte[] array2 = new byte[dataLength];
			for (int j = 0; j < dataLength; j++)
			{
				array2[j] = (byte)dataNoPassthroughFloors[j];
			}
			saveData.CacheWriteBytes("heightmapNoPassthroughFloors.bin", array2);
		}

		private void LoadHeightmapFromSave()
		{
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			if (currentVillageData.HeightmapData == null || currentVillageData.HeightmapDataNoPassthroughFloors == null)
			{
				currentVillageData.HeightmapData = null;
				currentVillageData.HeightmapDataNoPassthroughFloors = null;
				Log.Debug("*** Loading heightmap from save failed - no heightmap data found.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\Heightmap.cs");
				return;
			}
			if (currentVillageData.HeightmapData.Length != dataLength || currentVillageData.HeightmapDataNoPassthroughFloors.Length != dataLength)
			{
				currentVillageData.HeightmapData = null;
				currentVillageData.HeightmapDataNoPassthroughFloors = null;
				Log.Debug("*** Loading heightmap from save failed - data lengths don't match.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\Heightmap.cs");
				return;
			}
			bool flag = true;
			byte[] heightmapData = currentVillageData.HeightmapData;
			for (int i = 0; i < dataLength; i++)
			{
				data[i] = heightmapData[i];
				if (flag && data[i] != 0)
				{
					flag = false;
				}
			}
			heightmapData = currentVillageData.HeightmapDataNoPassthroughFloors;
			for (int j = 0; j < dataLength; j++)
			{
				dataNoPassthroughFloors[j] = heightmapData[j];
			}
			if (ApplicationVersionUtils.CompareVersion(currentVillageData.ModifiedOnGameVersion, "0.26.60") < 0)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(62, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\Heightmap.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Heightmap will be recalculated - save version ");
					messageBuilder.AppendFormatted(currentVillageData.ModifiedOnGameVersion);
					messageBuilder.AppendLiteral(" is older than ");
					messageBuilder.AppendFormatted("0.26.60");
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				dataLoadedFromSave = false;
			}
			else if (flag)
			{
				Log.Info("All data is zero in Heightmap. It will be recalculated after load.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\Heightmap.cs");
				dataLoadedFromSave = false;
			}
			else
			{
				dataLoadedFromSave = true;
				Log.Debug("*** Successfully loaded heightmap from save.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\Heightmap.cs");
			}
			currentVillageData.HeightmapData = null;
			currentVillageData.HeightmapDataNoPassthroughFloors = null;
		}

		public void RefreshWholeHeightmap()
		{
			if (dataLoaded)
			{
				return;
			}
			dataLoaded = true;
			LoadHeightmapFromSave();
			if (!dataLoadedFromSave)
			{
				Debug.Log("*** Re-generate heightmap.");
				for (int i = 0; i < mapSizeX; i++)
				{
					for (int j = 0; j < mapSizeZ; j++)
					{
						int index = GridDataIndexTools.Get2dIndexXZ(i, j);
						data[index] = (byte)CalculateHeight(i, j, checkPassthroughFloors: false);
						dataNoPassthroughFloors[index] = (byte)CalculateHeight(i, j, checkPassthroughFloors: true);
					}
				}
			}
			for (int k = 0; k < mapSizeX; k++)
			{
				for (int l = 0; l < mapSizeZ; l++)
				{
					RefreshHeightMaxNeighbors(k, l);
				}
			}
			computeBuffer.SetData(data, 0, 0, dataLength);
			noPassthroughFloorsComputeBuffer.SetData(dataNoPassthroughFloors, 0, 0, dataLength);
			HeightmapReady();
		}

		private void HeightmapReady()
		{
			edgeDistortSeed = GlobalSaveController.CurrentVillageData.MapSeed.GetHashCodeDeterministic();
			System.Random random = new System.Random(edgeDistortSeed);
			edgeDistortSeedXAdd = (int)((random.NextDouble() - 0.5) * (double)mapSizeX * 25.0);
			edgeDistortSeedZAdd = (int)((random.NextDouble() - 0.5) * (double)mapSizeZ * 25.0);
			CacheHeightmapWithEdgeFrame();
			IsReady = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RefreshHeightMaxNeighbors(int i, int j)
		{
			if (GridDataIndexTools.InRangeXZ(i, j))
			{
				heightmapMaxNeighbors[i, j] = (byte)Math.Max(data[GridDataIndexTools.Get2dIndexXZ(i, j)], Math.Max(data[GridDataIndexTools.Get2dIndexXZ(Math.Max(i - 1, 0), j)], Math.Max(data[GridDataIndexTools.Get2dIndexXZ(Math.Min(i + 1, mapSizeX - 1), j)], Math.Max(data[GridDataIndexTools.Get2dIndexXZ(i, Mathf.Max(j - 1, 0))], data[GridDataIndexTools.Get2dIndexXZ(i, Mathf.Min(j + 1, mapSizeZ - 1))]))));
			}
		}

		public Vector3 GetWorldPosition(Vector2Int gridPosition2D)
		{
			return new Vector3(gridPosition2D.x, GetHeightAt(gridPosition2D.x, gridPosition2D.y) * World.MapBlockHeight, gridPosition2D.y);
		}

		public void EnqueueModifiedPosition(int x, int z)
		{
			if (GridDataIndexTools.InRangeXZ(x, z))
			{
				Vector2Int item = new Vector2Int(x, z);
				if (!modified.Contains(item))
				{
					modified.Enqueue(item);
				}
			}
		}

		internal void OnDataModifiedAt(int x, int y, int z, byte data)
		{
			if (GridDataIndexTools.InRange(x, y, z))
			{
				EnqueueModifiedPosition(x, z);
			}
		}

		private void OnLoadingComplete()
		{
			isGameLoaded = true;
		}

		private void CheckApplyTextureChange()
		{
			if (modified.Count > 0)
			{
				bool flag = false;
				bool flag2 = false;
				while (modified.Count > 0)
				{
					Vector2Int vector2Int = modified.Dequeue();
					int x = vector2Int.x;
					int y = vector2Int.y;
					int index = GridDataIndexTools.Get2dIndexXZ(x, y);
					int num = data[index];
					int num2 = CalculateHeight(x, y, checkPassthroughFloors: false);
					if (num != num2)
					{
						data[index] = num2;
						RefreshHeightMaxNeighbors(x, y);
						RefreshHeightMaxNeighbors(x - 1, y);
						RefreshHeightMaxNeighbors(x + 1, y);
						RefreshHeightMaxNeighbors(x, y - 1);
						RefreshHeightMaxNeighbors(x, y + 1);
						flag = true;
					}
					int num3 = dataNoPassthroughFloors[index];
					num2 = CalculateHeight(x, y, checkPassthroughFloors: true);
					if (num3 != num2)
					{
						dataNoPassthroughFloors[index] = num2;
						flag2 = true;
					}
					if (flag || flag2)
					{
						mapGenTexturesCache.UpdateHeightInEffectMask(x, y);
						if (isGameLoaded)
						{
							this.HeightChangedAtEvent?.Invoke(x, y, num2);
						}
					}
				}
				if (flag)
				{
					computeBuffer?.SetData(data, 0, 0, dataLength);
				}
				if (flag2)
				{
					noPassthroughFloorsComputeBuffer?.SetData(dataNoPassthroughFloors, 0, 0, dataLength);
				}
			}
			else if (forceApplyTexture)
			{
				forceApplyTexture = false;
				computeBuffer?.SetData(data, 0, 0, dataLength);
				noPassthroughFloorsComputeBuffer?.SetData(dataNoPassthroughFloors, 0, 0, dataLength);
			}
		}

		public int CalculateHeight(int positionX, int positionZ, bool checkPassthroughFloors)
		{
			int x = Math.Max(Math.Min(positionX, mapSizeX - 1), 0);
			int z = Math.Max(Math.Min(positionZ, mapSizeZ - 1), 0);
			Vec3Int position = new Vec3Int(x, 0, z);
			BuildingsManagerMain buildingsManagerMain = villageMap.BuildingsManagerMain;
			List<BaseBuildingInstance> list = ListPool<BaseBuildingInstance>.Get();
			MapNode[] gridSpaceData = villageMap.GridSpaceData;
			for (int num = mapSizeY - 1; num >= 0; num--)
			{
				int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(x, num, z);
				MapNode mapNode = gridSpaceData[num2];
				if (mapNode != null)
				{
					if ((mapNode.DataType & GridDataType.Roof) != GridDataType.None)
					{
						ListPool<BaseBuildingInstance>.Return(list);
						return num;
					}
					if (mapNode.VoxelTypeIdByte != 0)
					{
						ListPool<BaseBuildingInstance>.Return(list);
						return num + 1;
					}
					position.y = num;
					if (list.Count > 0)
					{
						list.Clear();
					}
					buildingsManagerMain.GetBasicBuildingsNonAlloc(position, list);
					foreach (BaseBuildingInstance item in list)
					{
						if (item.ConstructionPhase != ConstructionPhase.Finished)
						{
							continue;
						}
						if ((item.Blueprint.BuildingType & BuildingType.Merlon) != 0)
						{
							ListPool<BaseBuildingInstance>.Return(list);
							return num;
						}
						if (!checkPassthroughFloors || !item.Blueprint.PassthroughFloor)
						{
							if ((item.Blueprint.BuildingType & BuildingType.Floor) != 0)
							{
								ListPool<BaseBuildingInstance>.Return(list);
								return num;
							}
							ListPool<BaseBuildingInstance>.Return(list);
							return num + 1;
						}
					}
				}
			}
			ListPool<BaseBuildingInstance>.Return(list);
			return 0;
		}

		private void Start()
		{
			IsReady = false;
			world = MonoSingleton<World>.Instance;
			mapGenTexturesCache = MonoSingleton<GroundManager>.Instance.MapGenerationTextures;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
			MonoSingleton<World>.Instance.OnDataModifiedAt += OnDataModifiedAt;
			MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent += OnDateTimeInitialize;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.OnDataModifiedAt -= OnDataModifiedAt;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent -= OnDateTimeInitialize;
			}
			if (VillageManager.ActiveVillage?.Map != null)
			{
				VillageManager.ActiveVillage.Map.ObjectPlacedEvent -= OnAddRemoveWorldObject;
				VillageManager.ActiveVillage.Map.ObjectRemovedEvent -= OnAddRemoveWorldObject;
			}
			world = null;
			villageMap = null;
			mapGenTexturesCache = null;
			this.HeightChangedAtEvent = null;
			dataWithEdgeFrame = null;
			base.OnDestroy();
		}

		private void OnDateTimeInitialize()
		{
			VillageManager.ActiveVillage.Map.ObjectPlacedEvent += OnAddRemoveWorldObject;
			VillageManager.ActiveVillage.Map.ObjectRemovedEvent += OnAddRemoveWorldObject;
		}

		private void OnAddRemoveWorldObject(WorldObject worldObject)
		{
			if (worldObject.Positions == null || worldObject.Positions.Count == 0)
			{
				EnqueueModifiedPosition(worldObject.GridDataPosition.x, worldObject.GridDataPosition.z);
				return;
			}
			foreach (Vec3Int position in worldObject.Positions)
			{
				EnqueueModifiedPosition(position.x, position.z);
			}
		}

		private void OnDrawGizmos()
		{
			if (!MonoSingleton<World>.IsInstantiated())
			{
				return;
			}
			if (GizmosHeight)
			{
				Color color = new Color(1f, 1f, 1f, 0.9f);
				float num = World.MapBlockHeight;
				Gizmos.color = color;
				Vector3 size = new Vector3(1f, 0.15f, 1f);
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < world.SizeX; i++)
				{
					zero.x = i;
					for (int j = 0; j < world.SizeZ; j++)
					{
						zero.z = j;
						zero.y = (float)data[GridDataIndexTools.Get2dIndexXZ(i, j)] * num;
						Gizmos.DrawCube(zero, size);
					}
				}
			}
			if (!GizmosFloor)
			{
				return;
			}
			Vector3 zero2 = Vector3.zero;
			float num2 = World.MapBlockHeight;
			Vector3 size2 = new Vector3(1f, 0.15f, 1f);
			Gizmos.color = Color.cyan;
			for (int k = 0; k < world.SizeX; k++)
			{
				zero2.x = k;
				for (int l = 0; l < world.SizeZ; l++)
				{
					zero2.z = l;
					for (int m = 1; m < world.SizeY; m++)
					{
						IEnumerable<WorldObject> enumerable = VillageManager.ActiveVillage.Map.GetNode(k, m, l)?.GetWorldObjects(GridDataType.BuildingFinished);
						if (enumerable != null && enumerable.Any((WorldObject item) => item is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.Type.HasFlag(BuildingType.Floor)))
						{
							zero2.y = (float)m * num2;
							Gizmos.DrawCube(zero2, size2);
						}
					}
				}
			}
		}
	}
}
