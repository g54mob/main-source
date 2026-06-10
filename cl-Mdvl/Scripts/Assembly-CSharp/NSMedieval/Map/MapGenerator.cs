using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Extensions;
using NSMedieval.Manager;
using NSMedieval.Managers;
using NSMedieval.Model.MapNew;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Testing.Autoplay;
using NSMedieval.Tools;
using NSMedieval.Tools.Math;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using NSMedieval.WorldMap;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace NSMedieval.Map
{
	public class MapGenerator : IGameDisposable, IDisposable
	{
		private const int MapGenerationStepsLimit = 64;

		private const string BedrockVoxelType = "Granite";

		private VillageMap villageMap;

		private Vec3Int mapSize;

		private string seed;

		private int seedFromWorldMapPosition;

		private bool hasDisposed;

		private Thread mapGenerationThread;

		private MapGenerationParameters mapGenerationParameters;

		private bool threadFinished = true;

		private bool threadSucceeded = true;

		private System.Random random;

		private System.Random randomUndergroundWater;

		private System.Random randomNonUndergroundWater;

		private float[,] heightMap;

		private float[,] waterHeight;

		private float[,] undergroundWaterCaveHeight;

		private float[,] undergroundWaterHeight;

		private float[,] riverWaterHeight;

		private float[,] brushValues;

		private long[,] propsFlags;

		private int[] voxelFlags;

		private float[] voxelValues;

		private byte[] voxelTypesByte;

		private readonly FastNoise noise = new FastNoise();

		private readonly FastNoise mapEdgeNoise = new FastNoise();

		private VoxelTypeRepository voxelTypeRepository;

		private Texture2D previewTexture;

		private CancellationTokenSource cancelThread;

		private readonly Dictionary<MapGenerationStep2, bool> willSkipStep = new Dictionary<MapGenerationStep2, bool>();

		private readonly Dictionary<MapGenerationStep2, bool> willSkipGroundDataStep = new Dictionary<MapGenerationStep2, bool>();

		public MapGenerationParameters MapGenerationParameters => mapGenerationParameters;

		public bool HasDisposed => hasDisposed;

		public Texture2D PreviewTexture => previewTexture;

		public bool ThreadFinished
		{
			get
			{
				return Volatile.Read(ref threadFinished);
			}
			set
			{
				Volatile.Write(ref threadFinished, value);
			}
		}

		public bool ThreadSucceeded
		{
			get
			{
				return Volatile.Read(ref threadSucceeded);
			}
			set
			{
				Volatile.Write(ref threadSucceeded, value);
			}
		}

		public event Action<IGameDisposable> OnDisposedEvent;

		public void StopMapGenerationThread()
		{
			if (!ThreadFinished && mapGenerationThread != null)
			{
				Log.Info("Canceling map generation thread", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				cancelThread?.Cancel();
			}
		}

		public void ForceStopMapGenerationThread()
		{
			if (mapGenerationThread != null)
			{
				Log.Info("Force stopping map generation thread. This should be called only on application exit.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				mapGenerationThread.Abort();
				mapGenerationThread = null;
			}
			ThreadFinished = true;
			ThreadSucceeded = false;
		}

		private void CacheSkipSteps(NSMedieval.Model.MapNew.Map mapType)
		{
			int num = 0;
			int num2 = 0;
			willSkipStep.Clear();
			willSkipGroundDataStep.Clear();
			int num3 = 0;
			foreach (MapGenerationStep2 mapGenerationStep in mapType.MapGenerationSteps)
			{
				if (mapGenerationStep.Operation != HeightmapOperationType.SetGroundData)
				{
					if (mapGenerationStep.Operation == HeightmapOperationType.UndergroundWater)
					{
						if (mapGenerationStep.PlotData.Length == 0)
						{
							willSkipStep.TryAdd(mapGenerationStep, ShouldSkipStep(mapGenerationStep, num2));
						}
						num2++;
					}
					if (mapGenerationStep.Operation != HeightmapOperationType.UndergroundWater)
					{
						if (mapGenerationStep.PlotData.Length == 0)
						{
							willSkipStep.TryAdd(mapGenerationStep, ShouldSkipStep(mapGenerationStep, num));
						}
						num++;
					}
				}
				else
				{
					if (mapGenerationStep.PlotData.Length != 0)
					{
						willSkipGroundDataStep.TryAdd(mapGenerationStep, ShouldSkipStep(mapGenerationStep, num3));
					}
					num3++;
				}
			}
			bool ShouldSkipStep(MapGenerationStep2 step, int index)
			{
				UnityEngine.Random.InitState(seed.GetHashCode() + index + seedFromWorldMapPosition);
				return UnityEngine.Random.Range(0f, 1f) > step.ExecuteStepChance;
			}
		}

		private void GenerateMapThread()
		{
			CancellationToken token = cancelThread.Token;
			bool isEnabled;
			try
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Map generation thread started for ");
					messageBuilder.AppendFormatted(mapGenerationParameters);
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				randomUndergroundWater = new System.Random(seed.GetHashCode() + seedFromWorldMapPosition);
				randomNonUndergroundWater = new System.Random(seed.GetHashCode() + seedFromWorldMapPosition);
				random = randomNonUndergroundWater;
				NSMedieval.Model.MapNew.Map mapType = mapGenerationParameters.MapType;
				InitPropsFlags();
				CreateFlatGround(mapType.FlatHeight);
				bool createRiver = random.NextDouble() < (double)mapType.RiverCreationChance;
				int num = 0;
				int num2 = 0;
				if (!TestManager.FlattenMap)
				{
					foreach (MapGenerationStep2 mapGenerationStep in mapType.MapGenerationSteps)
					{
						token.ThrowIfCancellationRequested();
						if (mapGenerationStep.Operation == HeightmapOperationType.UndergroundWater)
						{
							random = randomUndergroundWater;
						}
						int stepIndex = ((mapGenerationStep.Operation == HeightmapOperationType.UndergroundWater) ? num2 : num);
						if (mapGenerationStep.PlotData.Length == 0 && mapGenerationStep.Operation != HeightmapOperationType.SetGroundData && !willSkipStep[mapGenerationStep])
						{
							ExecuteStep(token, stepIndex, mapGenerationStep, ref createRiver);
						}
						if (mapGenerationStep.Operation == HeightmapOperationType.UndergroundWater)
						{
							num2++;
						}
						else
						{
							num++;
						}
						if (mapGenerationStep.Operation == HeightmapOperationType.UndergroundWater)
						{
							random = randomNonUndergroundWater;
						}
					}
				}
				InitGroundData(mapType.DefaultVoxelType);
				RoundHeight();
				if (!TestManager.FlattenMap)
				{
					SmoothOutTerrain(ref heightMap, 3);
					SmoothOutTerrain(ref heightMap, 4);
					FillHoles(ref heightMap, 3);
					FillHoles(ref heightMap, 4);
					int num3 = 0;
					foreach (MapGenerationStep2 mapGenerationStep2 in mapType.MapGenerationSteps)
					{
						if (mapGenerationStep2.Operation != HeightmapOperationType.UndergroundWater)
						{
							if (mapGenerationStep2.PlotData.Length != 0 && mapGenerationStep2.Operation == HeightmapOperationType.SetGroundData && !willSkipGroundDataStep[mapGenerationStep2])
							{
								token.ThrowIfCancellationRequested();
								ExecuteStep(token, num3, mapGenerationStep2, ref createRiver);
							}
							num3++;
						}
					}
					SplitDifferentWaterLevels();
					token.ThrowIfCancellationRequested();
					if (createRiver)
					{
						GenerateRiver(token, mapType);
					}
					CreateOutlineAroundWater(waterHeight);
					token.ThrowIfCancellationRequested();
				}
				ApplyVoxelTypes(token, mapType.VoxelTypeDistribution);
				ApplyCustomTiles();
				Log.Info("Map generation thread finished successfully.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				ThreadFinished = true;
				ThreadSucceeded = true;
			}
			catch (OperationCanceledException)
			{
				Log.Info("Map generation thread canceled.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				ThreadSucceeded = false;
				ThreadFinished = true;
			}
			catch (Exception ex2)
			{
				Log.Error("Exception happened on map generation thread!", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Message: ");
					messageBuilder2.AppendFormatted(ex2.Message);
				}
				Log.Error(messageBuilder2);
				messageBuilder2 = new FVLogErrorInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Stack Trace: ");
					messageBuilder2.AppendFormatted(ex2.StackTrace);
				}
				Log.Error(messageBuilder2);
				ThreadSucceeded = false;
				ThreadFinished = true;
			}
		}

		public IEnumerator GenerateMapCoroutine(MapGenerationParameters mapGenerationParameters)
		{
			this.mapGenerationParameters = mapGenerationParameters;
			NSMedieval.Model.MapNew.Map mapType = mapGenerationParameters.MapType;
			if (mapType.MapGenerationSteps.Count > 64)
			{
				while (mapType.MapGenerationSteps.Count > 64)
				{
					MapGenerationStep2 mapGenerationStep = mapType.MapGenerationSteps.Last();
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Map generation steps are limited to 64. ");
						messageBuilder.AppendFormatted(mapGenerationStep.GetID());
						messageBuilder.AppendLiteral(" will be skipped");
					}
					Log.Error(messageBuilder);
					mapType.MapGenerationSteps.RemoveAt(mapType.MapGenerationSteps.Count - 1);
				}
			}
			MapNode.RefreshEnabled = false;
			voxelTypeRepository = Repository<VoxelTypeRepository, VoxelType>.Instance;
			mapSize = this.mapGenerationParameters.MapSize.Vec3Int;
			seed = this.mapGenerationParameters.MapSeed;
			seedFromWorldMapPosition = this.mapGenerationParameters.WorldMapPosition.x + this.mapGenerationParameters.WorldMapPosition.y * MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.WorldMapResolution.x;
			MonoSingleton<MapGenerationController>.Instance.MapGenerationStarted();
			heightMap = ArrayExtensions.InitializeArray(heightMap, mapSize.x, mapSize.z, 0f);
			waterHeight = ArrayExtensions.InitializeArray(waterHeight, mapSize.x, mapSize.z, 0f);
			undergroundWaterCaveHeight = ArrayExtensions.InitializeArray(undergroundWaterCaveHeight, mapSize.x, mapSize.z, 0f);
			undergroundWaterHeight = ArrayExtensions.InitializeArray(undergroundWaterHeight, mapSize.x, mapSize.z, 0f);
			riverWaterHeight = ArrayExtensions.InitializeArray(riverWaterHeight, mapSize.x, mapSize.z, 0f);
			brushValues = ArrayExtensions.InitializeArray(brushValues, mapSize.x, mapSize.z, 0f);
			MonoSingleton<MapGenerationBrushManager>.Instance.TryCacheBrushData(mapType);
			CacheSkipSteps(mapType);
			yield return new WaitForEndOfFrame();
			if (mapGenerationThread == null && ThreadFinished)
			{
				DebugTimer.StartTimer("GenerateMapThread");
				ThreadSucceeded = false;
				ThreadFinished = false;
				cancelThread = new CancellationTokenSource();
				mapGenerationThread = new Thread(GenerateMapThread);
				mapGenerationThread.Name = "MapGenerator.GenerateMapThread()";
				mapGenerationThread.Start();
			}
			while (!ThreadFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			mapGenerationThread = null;
			DebugTimer.EndTimer("GenerateMapThread");
			if (ThreadSucceeded)
			{
				RefreshPreviewTexture();
			}
			MonoSingleton<MapGenerationController>.Instance.MapGenerationFinished(threadSucceeded);
		}

		private void RefreshPreviewTexture()
		{
			Log.Info("Refresh Map Preview", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
			Texture2DHelper.TryCreateTexture(ref previewTexture, mapSize.x, mapSize.z, linear: true);
			previewTexture.filterMode = FilterMode.Point;
			previewTexture.wrapMode = TextureWrapMode.Clamp;
			Color32[] pixels = previewTexture.GetPixels32(0);
			float num = mapGenerationParameters.MapType.GlobalWaterHeight - 1f;
			int i = 0;
			for (int x = mapSize.x; i < x; i++)
			{
				int j = 0;
				for (int z = mapSize.z; j < z; j++)
				{
					float num2 = Math.Clamp(heightMap[i, j], 0f, mapSize.y);
					float num3 = num2 / 16f;
					int num4 = GridDataIndexTools.FastTo1DIndexNoCheck(i, (int)num2, j);
					byte g = (byte)math.clamp(voxelTypesByte[num4] * 8, 0, 255);
					float num5 = Math.Max(waterHeight[i, j], riverWaterHeight[i, j]);
					if (num2 < num)
					{
						num5 = Mathf.Max(num5, num);
					}
					Color32 color = new Color32
					{
						r = (byte)(num3 * 255f),
						g = g,
						b = (byte)((num5 > 0f) ? 255u : 0u),
						a = byte.MaxValue
					};
					pixels[i * mapSize.z + j] = color;
				}
			}
			previewTexture.SetPixels32(pixels);
			previewTexture.Apply();
		}

		public IEnumerator FinalizeMapGenOnEnterScene(VillageMap villageMap)
		{
			this.villageMap = villageMap;
			int i = 0;
			for (int num = this.villageMap.GridSpaceData.Length; i < num; i++)
			{
				MapNode obj = this.villageMap.GridSpaceData[i];
				VoxelType byByteId = voxelTypeRepository.GetByByteId(voxelTypesByte[i]);
				obj.UpdateVoxelType(byByteId, refreshPenalty: false, refreshNeighbours: false);
			}
			yield return new WaitForEndOfFrame();
			TransferHeightToNodes();
			MonoSingleton<Heightmap>.Instance.Init(villageMap, mapSize.x, mapSize.y, mapSize.z);
			MonoSingleton<Heightmap>.Instance.RefreshWholeHeightmap();
			MonoSingleton<FloraRegrowController>.Instance.InitMapSize(villageMap);
			MonoSingleton<FishRegrowController>.Instance.InitMapSize(villageMap);
			yield return new WaitForEndOfFrame();
			SetBedrockAndTopLayer();
			ApplyUndergroundWater();
			yield return new WaitForEndOfFrame();
			this.villageMap.WaterManager.WaterSimLogic.InitVoxelWaterAmount(this.villageMap, mapGenerationParameters.MapType.GlobalWaterHeight, waterHeight, riverWaterHeight);
			this.villageMap.WaterManager.WaterSimLogic.CalculateRiverFlowInFlowOut(this.villageMap, riverWaterHeight);
			this.villageMap.WaterManager.WaterSimLogic.PrepareWaterDisplayData();
			this.villageMap.WaterManager.WaterSimLogic.CalculateWaterDepth();
			this.villageMap.WaterManager.WaterSimLogic.AfterMapGenerated(this.villageMap);
			yield return new WaitForEndOfFrame();
			MapNode.RefreshEnabled = true;
			MapNode[] nodes = villageMap.GridSpaceData;
			MapNode[] array = nodes;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].RefreshIsWalkable();
			}
			yield return new WaitForEndOfFrame();
			array = nodes;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].RefreshOnNewGame();
			}
			MapNode.RefreshEnabled = false;
			yield return new WaitForEndOfFrame();
			this.villageMap.RegionManager.Initialize();
			this.villageMap.RegionAreaManager.Initialize();
			this.villageMap.RoomDetection.Initialize();
			yield return new WaitForEndOfFrame();
			this.villageMap.WaterManager.WaterSimLogic.CalculateCoastDistance();
			PlaceProps(MapGenerationParameters.MapType);
			yield return new WaitForEndOfFrame();
			MapNode.RefreshEnabled = true;
			new SlopeGenerator().PlaceSlopes(this.villageMap, mapSize);
		}

		private void SplitDifferentWaterLevels()
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					float num = waterHeight[i, j];
					if (!(num > 0f))
					{
						continue;
					}
					Vec3Int[] neighborsXZ = MapNodeUtils.NeighborsXZ;
					for (int k = 0; k < neighborsXZ.Length; k++)
					{
						Vec3Int vec3Int = neighborsXZ[k];
						int num2 = vec3Int.x + i;
						int num3 = vec3Int.z + j;
						if (GridDataIndexTools.InRangeXZ(num2, num3))
						{
							float num4 = waterHeight[num2, num3];
							if (num4 > 0f && Math.Abs(num4 - num) > 0.01f)
							{
								waterHeight[i, j] = 0f;
								heightMap[i, j] = Mathf.CeilToInt(Math.Max(num, num4));
							}
						}
					}
				}
			}
		}

		private void GenerateRiver(CancellationToken cancellationToken, NSMedieval.Model.MapNew.Map mapType)
		{
			using PooledList<Vector2Int> pooledList = ListPool<Vector2Int>.GetJanitor();
			for (int i = 0; i < mapSize.x; i++)
			{
				pooledList.Add(new Vector2Int(i, 0));
				pooledList.Add(new Vector2Int(i, mapSize.z - 1));
			}
			for (int j = 0; j < mapSize.z; j++)
			{
				pooledList.Add(new Vector2Int(0, j));
				pooledList.Add(new Vector2Int(mapSize.x - 1, j));
			}
			pooledList.Sort((Vector2Int a, Vector2Int b) => (int)((heightMap[b.x, b.y] - heightMap[a.x, a.y]) * 100f));
			float num = (float)Math.Pow(random.NextDouble(), 3.0);
			Vector2Int startPosition = pooledList[(int)(num * (float)pooledList.Count - 1f)];
			RiverGeneration riverGeneration = new RiverGeneration();
			float inputStartRiverWidth = mapType.RiverStartWidth.Random(random);
			float inputEndRiverWidth = mapType.RiverEndWidth.Random(random);
			float islandFrequency = mapType.RiverIslandAmount.Random(random);
			float terrainCurveInfluence = mapType.RiverTerrainInfluence.Random(random);
			float curveNoiseAmount = mapType.RiverCurveNoiseAmount.Random(random);
			cancellationToken.ThrowIfCancellationRequested();
			riverGeneration.CreateRiver(cancellationToken, startPosition, heightMap, riverWaterHeight, mapSize, inputStartRiverWidth, inputEndRiverWidth, islandFrequency, terrainCurveInfluence, curveNoiseAmount);
			RemoveSingleWaterVoxels();
			ProcessTerrainAroundWater(cancellationToken, riverWaterHeight);
			SplitRiversAndLakes(cancellationToken);
		}

		private void RemoveSingleWaterVoxels()
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					if (!(riverWaterHeight[i, j] > 0f))
					{
						continue;
					}
					float num = riverWaterHeight[i, j];
					int num2 = 0;
					Vec3Int[] neighborsXZNonDiagonal = MapNodeUtils.NeighborsXZNonDiagonal;
					for (int k = 0; k < neighborsXZNonDiagonal.Length; k++)
					{
						Vec3Int vec3Int = neighborsXZNonDiagonal[k];
						int num3 = i + vec3Int.x;
						int num4 = j + vec3Int.z;
						if (GridDataIndexTools.InRangeXZ(num3, num4) && riverWaterHeight[num3, num4] >= num)
						{
							num2++;
						}
					}
					if (num2 <= 1)
					{
						riverWaterHeight[i, j] = 0f;
					}
				}
			}
		}

		private void SplitRiversAndLakes(CancellationToken cancellationToken)
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					if (!(riverWaterHeight[i, j] <= 0f))
					{
						continue;
					}
					float b = waterHeight[i, j];
					float num = Mathf.Max(heightMap[i, j], b);
					bool flag = false;
					Vec3Int[] neighborsXZ = MapNodeUtils.NeighborsXZ;
					for (int k = 0; k < neighborsXZ.Length; k++)
					{
						Vec3Int vec3Int = neighborsXZ[k];
						int num2 = i + vec3Int.x;
						int num3 = j + vec3Int.z;
						if (GridDataIndexTools.InRangeXZ(num2, num3) && riverWaterHeight[num2, num3] > 0f)
						{
							flag = true;
							num = Mathf.Max(num, riverWaterHeight[num2, num3]);
						}
					}
					if (flag && waterHeight[i, j] > 0f)
					{
						heightMap[i, j] = num;
						waterHeight[i, j] = 0f;
					}
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			for (int l = 0; l < mapSize.x; l++)
			{
				for (int m = 0; m < mapSize.z; m++)
				{
					if (riverWaterHeight[l, m] > 0f)
					{
						waterHeight[l, m] = riverWaterHeight[l, m];
					}
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
		}

		public void ProcessTerrainAroundWater(CancellationToken cancellationToken, float[,] waterHeightMap)
		{
			cancellationToken.ThrowIfCancellationRequested();
			float[,] array = new float[waterHeightMap.GetLength(0), waterHeightMap.GetLength(1)];
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					array[i, j] = waterHeightMap[i, j];
					if (waterHeightMap[i, j] <= 0f)
					{
						continue;
					}
					float num = waterHeightMap[i, j];
					for (int k = 0; k < MapNodeUtils.NeighborsXZNonDiagonal.Length; k++)
					{
						Vec3Int vec3Int = MapNodeUtils.NeighborsXZNonDiagonal[k];
						int num2 = i + vec3Int.x;
						int num3 = j + vec3Int.z;
						if (GridDataIndexTools.InRangeX(num2) && GridDataIndexTools.InRangeZ(num3))
						{
							num = MathfUtils.Max(waterHeightMap[num2, num3], num);
						}
					}
					array[i, j] = num;
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			for (int l = 0; l < mapSize.x; l++)
			{
				for (int m = 0; m < mapSize.z; m++)
				{
					waterHeightMap[l, m] = array[l, m];
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			for (int n = 0; n < mapSize.x; n++)
			{
				for (int num4 = 0; num4 < mapSize.z; num4++)
				{
					if (waterHeightMap[n, num4] <= 0f)
					{
						continue;
					}
					float b = waterHeightMap[n, num4];
					for (int num5 = 0; num5 < MapNodeUtils.NeighborsXZNonDiagonal.Length; num5++)
					{
						Vec3Int vec3Int2 = MapNodeUtils.NeighborsXZNonDiagonal[num5];
						int num6 = n + vec3Int2.x;
						int num7 = num4 + vec3Int2.z;
						if (GridDataIndexTools.InRangeX(num6) && GridDataIndexTools.InRangeZ(num7) && waterHeightMap[num6, num7] <= 0f)
						{
							heightMap[num6, num7] = Mathf.Max(heightMap[num6, num7], b);
						}
					}
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
		}

		private void CreateOutlineAroundWater(float[,] waterHeightMap)
		{
			using PooledDictionary<Vector2Int, float> pooledDictionary = DictionaryPool<Vector2Int, float>.GetJanitor();
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					if (!(waterHeightMap[i, j] < heightMap[i, j]))
					{
						continue;
					}
					float num = heightMap[i, j];
					bool flag = false;
					Vec3Int[] neighborsXZRadius = MapNodeUtils.NeighborsXZRadius2;
					for (int k = 0; k < neighborsXZRadius.Length; k++)
					{
						Vec3Int vec3Int = neighborsXZRadius[k];
						int num2 = vec3Int.x + i;
						int num3 = vec3Int.z + j;
						if (GridDataIndexTools.InRangeXZ(num2, num3) && waterHeightMap[num2, num3] > num)
						{
							flag = true;
							num = waterHeightMap[num2, num3];
						}
					}
					if (flag)
					{
						pooledDictionary.Add(new Vector2Int(i, j), num);
					}
				}
			}
			foreach (Vector2Int key in pooledDictionary.Keys)
			{
				heightMap[key.x, key.y] = pooledDictionary[key];
				waterHeightMap[key.x, key.y] = 0f;
			}
		}

		public void PlaceProps(NSMedieval.Model.MapNew.Map mapType)
		{
			StartPositionManager instance = MonoSingleton<StartPositionManager>.Instance;
			ResourceSpawner instance2 = MonoSingleton<ResourceSpawner>.Instance;
			instance.MakeFreeSpace();
			HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
			int num = 0;
			System.Random random = new System.Random(seed.GetHashCode() + seedFromWorldMapPosition);
			List<Vector2Int> list = new List<Vector2Int>();
			foreach (MapGenerationStep2 step in mapType.MapGenerationSteps)
			{
				if (step.Operation == HeightmapOperationType.UndergroundWater)
				{
					continue;
				}
				if (step.Props != null && step.Props.PropsToPlace != null && step.Props.PropsToPlace.Count > 0)
				{
					long num2 = 1L << num;
					list.Clear();
					for (int i = 0; i < mapSize.x; i++)
					{
						for (int j = 0; j < mapSize.z; j++)
						{
							Vector2Int vector2Int = new Vector2Int(i, j);
							if ((propsFlags[i, j] & num2) != 0L && !hashSet.Contains(vector2Int) && !instance.IsPositionUsed(vector2Int))
							{
								VoxelType topVoxelType = GetTopVoxelType(vector2Int);
								if (step.Props.PlaceOnlyOnVoxels.Count <= 0 || step.Props.PlaceOnlyOnVoxels.Contains(topVoxelType))
								{
									list.Add(vector2Int);
								}
							}
						}
					}
					bool brushControlsDensity = step.Props.BrushControlsDensity;
					if (brushControlsDensity)
					{
						list.Sort((Vector2Int m, Vector2Int n) => (!step.Props.InvertBrushDensity) ? brushValues[n.x, n.y].CompareTo(brushValues[m.x, m.y]) : brushValues[m.x, m.y].CompareTo(brushValues[n.x, n.y]));
					}
					int propsCountForStep = GetPropsCountForStep(step.Props);
					int num3 = 0;
					if (list.Count > 0)
					{
						int num4 = 0;
						while (num3 < propsCountForStep)
						{
							float f = (brushControlsDensity ? ((float)random.NextDouble()) : 0f);
							int a = (brushControlsDensity ? ((int)(Mathf.Pow(f, 2f) * (float)list.Count)) : random.Next(list.Count));
							Vector2Int vector2Int2 = list[Mathf.Min(a, list.Count - 1)];
							if (num4 == list.Count)
							{
								break;
							}
							if (!hashSet.Contains(vector2Int2))
							{
								instance2.PlaceProp(step.Props, vector2Int2);
								hashSet.Add(vector2Int2);
								num4++;
								num3++;
							}
						}
					}
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(10, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerator.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Added ");
						messageBuilder.AppendFormatted(num3);
						messageBuilder.AppendLiteral(" of ");
						messageBuilder.AppendFormatted(string.Join(", ", step.Props.PropsToPlace));
					}
					Log.Debug(messageBuilder);
				}
				num++;
			}
		}

		public void LoadMapFromSave(VillageMap villageMap)
		{
			this.villageMap = villageMap;
			mapSize = villageMap.Size;
		}

		public void Dispose()
		{
			villageMap = null;
			heightMap = null;
			waterHeight = null;
			brushValues = null;
			propsFlags = null;
			voxelFlags = null;
			voxelValues = null;
			riverWaterHeight = null;
			undergroundWaterCaveHeight = null;
			undergroundWaterHeight = null;
			voxelTypeRepository = null;
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			hasDisposed = true;
			heightMap = null;
			waterHeight = null;
			undergroundWaterCaveHeight = null;
			undergroundWaterHeight = null;
			riverWaterHeight = null;
			voxelFlags = null;
			voxelValues = null;
			random = null;
			randomUndergroundWater = null;
			randomNonUndergroundWater = null;
			ForceStopMapGenerationThread();
		}

		public void ApplyUndergroundWaterStability()
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					for (int k = 1; k < mapSize.y; k++)
					{
						if (!((float)k >= heightMap[i, j]) && undergroundWaterCaveHeight[i, j] >= (float)k)
						{
							villageMap.StabilityManager.GroundRemoved(i, k, j);
						}
					}
				}
			}
		}

		public VoxelType GetVoxelType(int x, int z)
		{
			float num = heightMap[x, z];
			int num2 = GridDataIndexTools.FastTo1DIndex(x, (int)num, z);
			if (num2 == -1)
			{
				return null;
			}
			return voxelTypeRepository.GetByByteId(voxelTypesByte[num2]);
		}

		public bool IsWaterAt(int x, int z)
		{
			float num = heightMap[x, z];
			return Math.Max(waterHeight[x, z], riverWaterHeight[x, z]) > num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float GetSmoothValue(float[] brush, int brushWidth, int brushHeight, float x, float y, float brushScale = 1f)
		{
			if (Math.Abs(brushScale - 1f) > 0.0001f)
			{
				x -= (float)brushWidth / 2f;
				x /= brushScale;
				x += (float)brushWidth / 2f;
				y -= (float)brushHeight / 2f;
				y /= brushScale;
				y += (float)brushHeight / 2f;
			}
			if (x < 0f || y < 0f || x >= (float)brushWidth || y >= (float)brushHeight)
			{
				return 0f;
			}
			int num = (int)math.floor(x);
			int num2 = (int)math.floor(y);
			int num3 = (int)math.ceil(x);
			int num4 = (int)math.ceil(y);
			if (num3 >= brushWidth)
			{
				num3 = brushWidth - 1;
			}
			if (num4 >= brushHeight)
			{
				num4 = brushHeight - 1;
			}
			float t = x - (float)num;
			float t2 = y - (float)num2;
			float start = math.lerp(GetPixelFromBrush(brush, num, num2, brushWidth, brushHeight), GetPixelFromBrush(brush, num3, num2, brushWidth, brushHeight), t);
			float end = math.lerp(GetPixelFromBrush(brush, num, num4, brushWidth, brushHeight), GetPixelFromBrush(brush, num3, num4, brushWidth, brushHeight), t);
			return math.lerp(start, end, t2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float GetPixelFromBrush(float[] brush, int x, int y, int width, int height)
		{
			return brush[y * width + x];
		}

		private static void SmoothOutTerrain(ref float[,] data, int threshold)
		{
			for (int i = 0; i < data.GetLength(0); i++)
			{
				for (int j = 0; j < data.GetLength(1); j++)
				{
					if (SmoothingLess(i, j, data[i, j], threshold, ref data))
					{
						data[i, j] -= 1f;
					}
				}
			}
		}

		private static void FillHoles(ref float[,] data, int threshold)
		{
			for (int i = 0; i < data.GetLength(0); i++)
			{
				for (int j = 0; j < data.GetLength(1); j++)
				{
					if (SmoothingGreater(i, j, data[i, j], threshold, ref data))
					{
						data[i, j] += 1f;
					}
				}
			}
		}

		private static bool SmoothingLess(int x, int z, float voxelHeight, int threshold, ref float[,] data)
		{
			int num = x - 1;
			int num2 = x + 1;
			int num3 = z - 1;
			int num4 = z + 1;
			int num5 = 0;
			if (num >= 0 && data[num, z] < voxelHeight)
			{
				num5++;
			}
			if (num2 < data.GetLength(0) && data[num2, z] < voxelHeight)
			{
				num5++;
			}
			if (num3 >= 0 && data[x, num3] < voxelHeight)
			{
				num5++;
			}
			if (num4 < data.GetLength(1) && data[x, num4] < voxelHeight)
			{
				num5++;
			}
			return num5 >= threshold;
		}

		private static bool SmoothingGreater(int x, int z, float voxelHeight, int threshold, ref float[,] data)
		{
			int num = x - 1;
			int num2 = x + 1;
			int num3 = z - 1;
			int num4 = z + 1;
			int num5 = 0;
			if (num >= 0 && data[num, z] > voxelHeight)
			{
				num5++;
			}
			if (num2 < data.GetLength(0) && data[num2, z] > voxelHeight)
			{
				num5++;
			}
			if (num3 >= 0 && data[x, num3] > voxelHeight)
			{
				num5++;
			}
			if (num4 < data.GetLength(1) && data[x, num4] > voxelHeight)
			{
				num5++;
			}
			return num5 >= threshold;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool MapFromMapToRelative(int mapX, int mapY, int brushPosX, int brushPosY, Vector2Int brushSize, float rotation, out float outX, out float outY)
		{
			float x = mapX - brushPosX;
			float y = mapY - brushPosY;
			Rotate(x, y, rotation, out outX, out outY);
			outX += (float)brushSize.x / 2f;
			outY += (float)brushSize.y / 2f;
			outX /= brushSize.x;
			outY /= brushSize.y;
			if (outX >= 0f && outX <= 1f && outY >= 0f)
			{
				return outY <= 1f;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Rotate(float x, float y, float rotation, out float newX, out float newY)
		{
			float f = rotation * (MathF.PI / 180f);
			float num = Mathf.Cos(f);
			float num2 = Mathf.Sin(f);
			newX = x * num - y * num2;
			newY = x * num2 + y * num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool MapFromMapToTexture(int mapX, int mapY, int brushPosX, int brushPosY, Vector2Int brushSize, int brushWidth, int brushHeight, float rotation, out float textureSpaceX, out float textureSpaceY)
		{
			float outX;
			float outY;
			bool flag = MapFromMapToRelative(mapX, mapY, brushPosX, brushPosY, brushSize, rotation, out outX, out outY);
			if (brushWidth == 0 || brushHeight == 0)
			{
				textureSpaceX = (textureSpaceY = 0f);
				return flag;
			}
			textureSpaceX = outX * (float)brushWidth;
			textureSpaceY = outY * (float)brushHeight;
			if (!flag)
			{
				return false;
			}
			if (textureSpaceX >= 0f && textureSpaceX < (float)brushWidth && textureSpaceY >= 0f)
			{
				return textureSpaceY < (float)brushHeight;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void CalculateBounds(Vector2Int brushPosition, Vector2Int brushSize, float rotationAngle, out Vector2 boundsMin, out Vector2 boundsMax)
		{
			Vector2 vector = new Vector2((float)brushSize.x / 2f, 0f);
			Vector2 vector2 = new Vector2(0f, (float)brushSize.y / 2f);
			Quaternion obj = Quaternion.Euler(0f, 0f, rotationAngle);
			Vector2 vector3 = obj * vector;
			Vector2 vector4 = obj * vector2;
			Vector2 vector5 = brushPosition + vector3 + vector4;
			Vector2 vector6 = brushPosition + vector3 - vector4;
			Vector2 vector7 = brushPosition - vector3 - vector4;
			Vector2 vector8 = brushPosition - vector3 + vector4;
			boundsMin = new Vector2
			{
				x = Mathf.Min(Mathf.Min(Mathf.Min(vector5.x, vector6.x), vector7.x), vector8.x),
				y = Mathf.Min(Mathf.Min(Mathf.Min(vector5.y, vector6.y), vector7.y), vector8.y)
			};
			boundsMax = new Vector2
			{
				x = Mathf.Max(Mathf.Max(Mathf.Max(vector5.x, vector6.x), vector7.x), vector8.x),
				y = Mathf.Max(Mathf.Max(Mathf.Max(vector5.y, vector6.y), vector7.y), vector8.y)
			};
		}

		private void InitPropsFlags()
		{
			if (propsFlags == null || propsFlags.GetLength(0) != mapSize.x || propsFlags.GetLength(1) != mapSize.z)
			{
				propsFlags = new long[mapSize.x, mapSize.z];
			}
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					propsFlags[i, j] = 0L;
				}
			}
		}

		private List<KeyValuePair<int, float>> GetSortedPositionList()
		{
			System.Random random = new System.Random(seed.GetHashCode() + seedFromWorldMapPosition);
			List<KeyValuePair<int, float>> list = new List<KeyValuePair<int, float>>();
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					for (int k = 0; k < mapSize.y; k++)
					{
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(i, k, j);
						if (!(voxelValues[num] <= 0f) && voxelFlags[num] != 0)
						{
							float value = (float)(int)((float)voxelFlags[num] * 100f) + 99f * (float)random.NextDouble();
							KeyValuePair<int, float> item = new KeyValuePair<int, float>(num, value);
							list.Add(item);
						}
					}
				}
			}
			list.Sort((KeyValuePair<int, float> x, KeyValuePair<int, float> y) => y.Value.CompareTo(x.Value));
			return list;
		}

		private void CreateFlatGround(int flatGroundHeight)
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					heightMap[i, j] = flatGroundHeight;
				}
			}
		}

		private void RoundHeight()
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					heightMap[i, j] = MathfUtils.Min(Mathf.Floor(heightMap[i, j]), mapSize.y - 1);
					waterHeight[i, j] = MathfUtils.Min(Mathf.Floor(waterHeight[i, j]), mapSize.y - 1);
				}
			}
		}

		private void ApplyCustomTiles()
		{
		}

		private void TransferHeightToNodes()
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					float num = heightMap[i, j];
					float num2 = waterHeight[i, j];
					for (int num3 = mapSize.y - 1; num3 >= 0; num3--)
					{
						if (num2 > 0f)
						{
							num = MathfUtils.Min(num, num2 - 1f);
						}
						if ((float)num3 > num)
						{
							villageMap.GetNode(i, num3, j).UpdateVoxelType(null, refreshPenalty: false, refreshNeighbours: false);
						}
					}
				}
			}
		}

		private void SetBedrockAndTopLayer()
		{
			VoxelType byID = voxelTypeRepository.GetByID("Granite");
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					villageMap.GetNode(i, 0, j).UpdateVoxelType(byID, refreshPenalty: false, refreshNeighbours: false);
				}
			}
		}

		private void ApplyUndergroundWater()
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					if (undergroundWaterCaveHeight[i, j] <= 0f)
					{
						continue;
					}
					float num = MonoSingleton<Heightmap>.Instance.GetHeightAt(i, j);
					for (int k = 1; k < mapSize.y; k++)
					{
						if (!((float)k >= num - 1f) && undergroundWaterCaveHeight[i, j] >= (float)k)
						{
							MapNode node = villageMap.GetNode(i, k, j);
							float asWaterVoxel = Mathf.Clamp01(undergroundWaterHeight[i, j] - (float)k);
							node.SetAsWaterVoxel(asWaterVoxel);
						}
					}
				}
			}
		}

		private void InitGroundData(string defaultVoxelID)
		{
			int num = mapSize.x * mapSize.y * mapSize.z;
			if (voxelFlags == null || voxelFlags.Length != num)
			{
				voxelFlags = new int[num];
			}
			if (voxelValues == null || voxelValues.Length != num)
			{
				voxelValues = new float[num];
			}
			if (voxelTypesByte == null || voxelTypesByte.Length != num)
			{
				voxelTypesByte = new byte[num];
			}
			byte byteId = voxelTypeRepository.GetByID(defaultVoxelID).ByteId;
			for (int i = 0; i < num; i++)
			{
				voxelTypesByte[i] = byteId;
				voxelFlags[i] = 0;
				voxelValues[i] = 0f;
			}
		}

		private void ApplyVoxelTypes(CancellationToken cancellationToken, IReadOnlyCollection<VoxelTypeDistribution> voxelTypeDistribution)
		{
			List<KeyValuePair<int, float>> sortedPositionList = GetSortedPositionList();
			HashSet<int> hashSet = new HashSet<int>();
			foreach (KeyValuePair<VoxelTypeDistribution, int> item in GetVoxelTypeCount(voxelTypeDistribution))
			{
				int value = item.Value;
				if (value <= 0)
				{
					continue;
				}
				VoxelTypeDistribution key = item.Key;
				VoxelType byID = voxelTypeRepository.GetByID(key.GetID());
				if (byID == null)
				{
					continue;
				}
				cancellationToken.ThrowIfCancellationRequested();
				byte byteId = byID.ByteId;
				int storeFlags = GetStoreFlags(key);
				int num = 0;
				foreach (KeyValuePair<int, float> item2 in sortedPositionList)
				{
					int key2 = item2.Key;
					if (hashSet.Contains(key2) && storeFlags == 0)
					{
						continue;
					}
					int num2 = key2;
					bool flag = (voxelFlags[num2] & byID.MaskValue) != 0;
					if (!flag && (voxelFlags[num2] & storeFlags) != 0 && (!key.AwayFromEdge || IsAwayFromEdge(GridDataIndexTools.GetX(num2), GridDataIndexTools.GetY(num2), GridDataIndexTools.GetZ(num2), key)))
					{
						flag = true;
					}
					if (flag)
					{
						hashSet.Add(num2);
						voxelTypesByte[num2] = byteId;
						if (++num >= value)
						{
							break;
						}
					}
				}
				if (num >= key.MinCount)
				{
					continue;
				}
				foreach (KeyValuePair<int, float> item3 in sortedPositionList)
				{
					int key3 = item3.Key;
					if (hashSet.Add(key3))
					{
						voxelTypesByte[key3] = byteId;
						if (++num >= key.MinCount)
						{
							break;
						}
					}
				}
			}
		}

		private void ExecuteStep(CancellationToken cancellationToken, int stepIndex, MapGenerationStep2 step, ref bool createRiver)
		{
			if (createRiver && step.SkipRiverOnExecute)
			{
				createRiver = false;
			}
			if (step.NoiseEnabled)
			{
				SetNoiseProperties(step.Noise);
			}
			int num = ((step.RepeatCountMax > step.RepeatCount) ? random.Next(step.RepeatCount, step.RepeatCountMax + 1) : step.RepeatCount);
			bool flag = step.Operation == HeightmapOperationType.SetGroundData;
			long num2 = 1L << stepIndex;
			bool flag2 = step.Props.PropsToPlace != null && step.Props.PropsToPlace.Count > 0;
			bool flag3 = step.Operation == HeightmapOperationType.CarveFillWithWater;
			VoxelType voxelType = (string.IsNullOrEmpty(step.PlotData) ? null : voxelTypeRepository.GetByID(step.PlotData));
			using PooledDictionary<Vector2Int, float> pooledDictionary = DictionaryPool<Vector2Int, float>.GetJanitor();
			for (int i = 0; i < num; i++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				float num3 = 0f;
				pooledDictionary.Clear();
				string randomBrushIdForStep = GetRandomBrushIdForStep(step);
				float[] brushData = MonoSingleton<MapGenerationBrushManager>.Instance.GetBrushData(randomBrushIdForStep);
				Vector2Int brushSize = MonoSingleton<MapGenerationBrushManager>.Instance.GetBrushSize(randomBrushIdForStep);
				int x = brushSize.x;
				int y = brushSize.y;
				noise.SetSeed(seed.GetHashCode() + i - seedFromWorldMapPosition);
				float num4 = step.Rotation + GetRandomValue(step.RandomRotation, randomSign: true);
				Vector2 vector = step.Position + GetRandomVec2(step.RandomPosition.x, step.RandomPosition.y);
				Vector2Int brushPosition = new Vector2Int((int)(vector.x * (float)mapSize.x), (int)(vector.y * (float)mapSize.z));
				int num5 = Math.Max((int)Mathf.Min(brushPosition.x, (float)mapSize.x - 1f), 0);
				int num6 = Math.Max((int)Mathf.Min(brushPosition.y, (float)mapSize.z - 1f), 0);
				float num7 = heightMap[num5, num6];
				float num8 = step.Size.x * step.ScaleXRange.Random(random);
				float num9 = step.Size.y * step.ScaleYRange.Random(random);
				if (step.DontScaleWithMap)
				{
					num8 *= (float)x;
					num9 *= (float)y;
				}
				else
				{
					num8 *= (float)mapSize.x;
					num9 *= (float)mapSize.z;
				}
				Vector2Int brushSize2 = new Vector2Int((int)num8, (int)num9);
				CalculateBounds(brushPosition, brushSize2, num4, out var boundsMin, out var boundsMax);
				boundsMin.x = math.max(0, Mathf.FloorToInt(boundsMin.x));
				boundsMax.x = math.min(mapSize.x - 1, Mathf.CeilToInt(boundsMax.x));
				boundsMin.y = math.max(0, Mathf.FloorToInt(boundsMin.y));
				boundsMax.y = math.min(mapSize.z - 1, Mathf.CeilToInt(boundsMax.y));
				int x2 = brushPosition.x;
				int y2 = brushPosition.y;
				for (int j = (int)boundsMin.x; j <= (int)boundsMax.x; j++)
				{
					for (int k = (int)boundsMin.y; k <= (int)boundsMax.y; k++)
					{
						if (!MapFromMapToTexture(j, k, x2, y2, brushSize2, x, y, num4, out var textureSpaceX, out var textureSpaceY))
						{
							continue;
						}
						if (flag2)
						{
							if (GetPixelFromBrush(brushData, (int)textureSpaceX, (int)textureSpaceY, x, y) <= 0.05f)
							{
								continue;
							}
							float num10 = GetStepNewHeightValue(step, j, k, textureSpaceX, textureSpaceY, brushData, x, y, HeightmapOperationType.Max, 1f) / (float)step.Height;
							if (num10 > 0.05f)
							{
								propsFlags[j, k] |= num2;
								brushValues[j, k] = Mathf.Max(num10, brushValues[j, k]);
							}
							if (step.Operation == HeightmapOperationType.PropsOnly)
							{
								continue;
							}
						}
						if (flag)
						{
							float a = GetStepNewHeightValue(step, j, k, textureSpaceX, textureSpaceY, brushData, x, y, HeightmapOperationType.Add, 1f) / (float)step.Height;
							a = Mathf.Min(a, 1f);
							if (!(a <= 0.1f))
							{
								if (step.PlotOnlyOnTopLayers > 0)
								{
									SetGroundData(j, k, heightMap[j, k] - (float)step.PlotOnlyOnTopLayers + 1f - (float)step.PlotHeightOffsetDown, heightMap[j, k] - (float)step.PlotHeightOffsetDown, voxelType, a);
									continue;
								}
								float num11 = num7 - ((float)step.PlotHeightCenter + ((float)step.PlotHeightBelow * a - (float)step.PlotHeightCenter * a));
								float num12 = num7 - (float)step.PlotHeightCenter;
								SetGroundData(heightTo: ((step.PlotHeightAbove <= 0) ? num12 : (num7 + (float)(step.PlotHeightAbove - 1) * a)) - (float)step.PlotHeightOffsetDown, x: j, z: k, heightFrom: num11 - (float)step.PlotHeightOffsetDown, voxelType: voxelType, valueFromBrush: a);
							}
						}
						else if (!flag3)
						{
							heightMap[j, k] += GetStepNewHeightValue(step, j, k, textureSpaceX, textureSpaceY, brushData, x, y, step.Operation, 1f);
						}
						else
						{
							float num13 = math.ceil(GetStepNewHeightValue(step, j, k, textureSpaceX, textureSpaceY, brushData, x, y, step.Operation, 1f));
							if (num13 > 0f)
							{
								num3 += heightMap[j, k];
								pooledDictionary.Add(new Vector2Int(j, k), num13);
							}
						}
					}
				}
				if (!(num3 > 0f))
				{
					continue;
				}
				float num14 = num3 / (float)pooledDictionary.Count;
				foreach (Vector2Int key in pooledDictionary.Keys)
				{
					int x3 = key.x;
					int y3 = key.y;
					waterHeight[x3, y3] = num14;
					bool flag4 = false;
					Vec3Int[] neighborsXZNonDiagonal = MapNodeUtils.NeighborsXZNonDiagonal;
					for (int l = 0; l < neighborsXZNonDiagonal.Length; l++)
					{
						Vec3Int vec3Int = neighborsXZNonDiagonal[l];
						int num15 = x3 + vec3Int.x;
						int num16 = y3 + vec3Int.z;
						if (GridDataIndexTools.InRangeXZ(num15, num16) && waterHeight[num15, num16] > 0f && Math.Abs(waterHeight[num15, num16] - waterHeight[x3, y3]) > 0.01f)
						{
							waterHeight[num15, num16] = 0f;
							waterHeight[x3, y3] = 0f;
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						float num17 = pooledDictionary[key];
						heightMap[x3, y3] = num14 - num17;
					}
				}
			}
		}

		private void SetGroundData(int x, int z, float heightFrom, float heightTo, VoxelType voxelType, float valueFromBrush)
		{
			mapEdgeNoise.SetSeed(seed.GetHashCode() - seedFromWorldMapPosition);
			for (int i = Mathf.CeilToInt(heightFrom); i <= (int)heightTo; i++)
			{
				if (i < 0 || i >= mapSize.y || (float)i > heightMap[x, z] + 1f)
				{
					continue;
				}
				int num = GridDataIndexTools.FastTo1DIndexNoCheck(x, i, z);
				float num2 = Mathf.Max(valueFromBrush, voxelValues[num]);
				if (voxelType.MustBeInBounds)
				{
					if (x < 3 || z < 3 || x > mapSize.x - 3 || z > mapSize.z - 3)
					{
						num2 = 0f;
					}
					else
					{
						float minDistFromBounds = GetMinDistFromBounds(3, x, z);
						float minDistFromBounds2 = GetMinDistFromBounds(19, x, z);
						float num3 = 1f - (minDistFromBounds2 - minDistFromBounds) / 16f;
						float t = Mathf.Min(num3 * 2f, 1f);
						float t2 = 1f - Mathf.Abs((num3 - 0.5f) * 2f);
						float b = 1f;
						b = Mathf.Lerp(0f, b, t);
						b = Mathf.Lerp(b, b * Mathf.Min(1f, Mathf.Abs(mapEdgeNoise.GetNoise(x * 4, z * 4) * 2.5f)), t2);
						num2 = ((!(b < 0.5f)) ? (num2 * b) : 0f);
					}
				}
				voxelValues[num] = num2;
				int maskValue = voxelType.MaskValue;
				voxelFlags[num] |= maskValue;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float GetMinDistFromBounds(int bounds, int x, int z)
		{
			float num = 0f;
			if (x < bounds)
			{
				num = Mathf.Max(num, bounds - x);
			}
			if (z < bounds)
			{
				num = Mathf.Max(num, bounds - z);
			}
			float num2 = GridDataIndexTools.SizeX - bounds;
			if ((float)x > num2)
			{
				num = Mathf.Max(num, (float)x - num2);
			}
			float num3 = GridDataIndexTools.SizeZ - bounds;
			if ((float)z > num3)
			{
				num = Mathf.Max(num, (float)z - num3);
			}
			return num;
		}

		private float GetStepNewHeightValue(MapGenerationStep2 step, int x, int y, float textureSpaceX, float textureSpaceY, float[] brush, int brushWidth, int brushHeight, HeightmapOperationType operation, float sizeMultiplier)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			bool flag = step.NoiseEnabled && step.Noise.MultiplyWithBrush && brushWidth > 0 && brushHeight > 0;
			bool flag2 = step.Noise.DistortAmplitude != 0f;
			if (brushWidth > 0 && brushHeight > 0)
			{
				num2 = GetSmoothValue(brush, brushWidth, brushHeight, textureSpaceX, textureSpaceY, sizeMultiplier);
				if (!flag)
				{
					num = num2 * (float)step.Height;
				}
			}
			if (step.NoiseEnabled)
			{
				float x2 = (float)x / (float)mapSize.x;
				float y2 = (float)y / (float)mapSize.z;
				if (flag2)
				{
					noise.SetFrequency(step.Noise.DistortFrequency);
					noise.GradientPerturbFractal(ref x2, ref y2);
					noise.SetFrequency(step.Noise.Frequency);
				}
				num3 = noise.GetNoise(x2, y2) * step.Noise.Gain;
				num3 = ((num3 < 0f) ? 0f : num3);
				if (!flag)
				{
					num = num3 * (float)step.Height;
				}
			}
			if (flag)
			{
				num = num2 * num3 * (float)step.Height;
			}
			if (num != 0f)
			{
				return HeightOperation(step, num, operation, x, y);
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float HeightOperation(MapGenerationStep2 step, float value, HeightmapOperationType operation, int x, int y)
		{
			switch (operation)
			{
			case HeightmapOperationType.UndergroundWater:
			{
				float a = Mathf.Floor(heightMap[x, y]);
				undergroundWaterCaveHeight[x, y] = Mathf.Floor(Mathf.Min(a, value));
				undergroundWaterHeight[x, y] = Mathf.Clamp01(step.TopLayerWaterLevel) - 1f + Mathf.Floor(Mathf.Min(a, step.Height));
				return 0f;
			}
			case HeightmapOperationType.Add:
			case HeightmapOperationType.CarveFillWithWater:
				return value;
			case HeightmapOperationType.Subtract:
				return 0f - value;
			case HeightmapOperationType.Max:
				return Math.Max(heightMap[x, y], value) - heightMap[x, y];
			default:
				return 0f;
			}
		}

		private int GetStoreFlags(VoxelTypeDistribution distribution)
		{
			int num = 0;
			foreach (string item in distribution.StoreInside)
			{
				VoxelType byID = voxelTypeRepository.GetByID(item);
				num |= byID.MaskValue;
			}
			return num;
		}

		private IEnumerable<KeyValuePair<VoxelTypeDistribution, int>> GetVoxelTypeCount(IReadOnlyCollection<VoxelTypeDistribution> voxelTypeDistribution)
		{
			int num = 0;
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					for (int k = 0; k < mapSize.y; k++)
					{
						int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(i, k, j);
						if (voxelFlags[num2] != 0)
						{
							num++;
						}
					}
				}
			}
			Dictionary<string, VoxelTypeDistribution> dictionary = new Dictionary<string, VoxelTypeDistribution>();
			foreach (VoxelTypeDistribution item in voxelTypeDistribution)
			{
				dictionary.Add(item.GetID(), item);
			}
			Dictionary<VoxelTypeDistribution, int> dictionary2 = new Dictionary<VoxelTypeDistribution, int>();
			foreach (VoxelTypeDistribution item2 in voxelTypeDistribution)
			{
				int num3 = Math.Max((int)((float)num * item2.Percent / 100f), item2.MinCount);
				if (item2.MaxCount > 0)
				{
					num3 = Math.Min(num3, item2.MaxCount);
				}
				dictionary2.Add(item2, num3);
			}
			foreach (VoxelTypeDistribution item3 in voxelTypeDistribution)
			{
				foreach (string item4 in item3.StoreInside)
				{
					dictionary2[dictionary[item4]] += dictionary2[item3];
				}
			}
			List<KeyValuePair<VoxelTypeDistribution, int>> list = new List<KeyValuePair<VoxelTypeDistribution, int>>();
			foreach (VoxelTypeDistribution item5 in voxelTypeDistribution)
			{
				list.Add(new KeyValuePair<VoxelTypeDistribution, int>(item5, dictionary2[item5]));
			}
			list.Sort((KeyValuePair<VoxelTypeDistribution, int> x, KeyValuePair<VoxelTypeDistribution, int> y) => y.Value.CompareTo(x.Value));
			list.Sort((KeyValuePair<VoxelTypeDistribution, int> m, KeyValuePair<VoxelTypeDistribution, int> n) => m.Key.StoreInside.Count.CompareTo(n.Key.StoreInside.Count));
			return list;
		}

		private bool IsAwayFromEdge(int x, int y, int z, VoxelTypeDistribution voxelTypeDistribution)
		{
			Vec3Int[] array = new Vec3Int[5]
			{
				Vec3Int.up,
				Vec3Int.left,
				Vec3Int.right,
				new Vec3Int(0, 0, 1),
				new Vec3Int(0, 0, -1)
			};
			for (int i = 0; i < array.Length; i++)
			{
				Vec3Int vec3Int = array[i];
				int x2 = vec3Int.x + x;
				if (!GridDataIndexTools.InRangeX(x2))
				{
					return false;
				}
				int z2 = vec3Int.z + z;
				if (!GridDataIndexTools.InRangeZ(z2))
				{
					return false;
				}
				int y2 = vec3Int.y + y;
				if (!GridDataIndexTools.InRangeY(y2))
				{
					return false;
				}
				int nodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(x2, y2, z2);
				if (!CanBePlacedToGroundData(nodeIndex, voxelTypeDistribution))
				{
					return false;
				}
			}
			return true;
		}

		private bool CanBePlacedToGroundData(int nodeIndex, VoxelTypeDistribution voxelTypeDistribution)
		{
			VoxelType byID = voxelTypeRepository.GetByID(voxelTypeDistribution.GetID());
			if (voxelTypesByte[nodeIndex] == byID.ByteId)
			{
				return true;
			}
			byte b = voxelTypesByte[nodeIndex];
			foreach (string item in voxelTypeDistribution.StoreInside)
			{
				VoxelType byID2 = voxelTypeRepository.GetByID(item);
				if (byID2 != null && byID2.ByteId == b)
				{
					return true;
				}
			}
			return false;
		}

		private string GetRandomBrushIdForStep(MapGenerationStep2 step)
		{
			MapSize mapSize = mapGenerationParameters.MapSize;
			if (mapSize != null && !string.IsNullOrEmpty(mapSize.BrushType) && mapSize.BrushType.Equals("large") && step.BrushIDsLarge != null && step.BrushIDsLarge.Count > 0)
			{
				return step.BrushIDsLarge[random.Next(step.BrushIDsLarge.Count)];
			}
			return step.BrushIDs[random.Next(step.BrushIDs.Count)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Vector2 GetRandomVec2(float randomX, float randomY)
		{
			float f = (float)(random.NextDouble() * 2.0 * Math.PI);
			float num = (float)random.NextDouble();
			float x = Mathf.Sin(f) * randomX * num;
			float y = Mathf.Cos(f) * randomY * num;
			return new Vector2(x, y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float GetRandomValue(float maxValue, bool randomSign)
		{
			if (randomSign)
			{
				return (float)(random.NextDouble() - 0.5) * 2f * maxValue;
			}
			return (float)random.NextDouble() * maxValue;
		}

		private void SetNoiseProperties(NoiseProperties properties)
		{
			noise.SetGradientPerturbAmp(properties.DistortAmplitude);
			noise.SetFrequency(properties.Frequency);
			noise.SetFractalOctaves(properties.FractalOctaves);
			noise.SetFractalGain(properties.FractalGain);
			noise.SetFractalLacunarity(1.5f);
			noise.SetFractalType((FastNoise.FractalType)properties.FractalType);
			noise.SetNoiseType((FastNoise.NoiseType)properties.NoiseType);
		}

		private VoxelType GetTopVoxelType(Vector2Int pos)
		{
			for (int num = mapSize.y - 1; num > 0; num--)
			{
				VoxelType voxelType = villageMap.GetNode(pos.x, num, pos.y).VoxelType;
				if (voxelType != null)
				{
					return voxelType;
				}
			}
			return null;
		}

		private int GetPropsCountForStep(PropPlacement propPlacement)
		{
			if (propPlacement.Count > 0)
			{
				return propPlacement.Count;
			}
			return (int)(Mathf.Max(0f, (float)(mapSize.x * mapSize.z) * Mathf.Min(propPlacement.TerrainPercent, 100f)) / 100f);
		}
	}
}
