using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Crops;
using NSMedieval.Fire;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Tools.Math;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Water;
using Unity.Collections;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public class SnowGrassWetnessManager : IDisposable
	{
		public delegate void GrassChangedDelegate(PooledHashSet<int> added, PooledHashSet<int> removed);

		private const float GrassMaxUnderPlant = 0.5f;

		private const byte SnowMaxUnderPlant = 128;

		private const int SnowMeltSpeedCacheMin = -30;

		private const int SnowMeltSpeedCacheMax = 30;

		private const float GrassGrowTimeHours = 10f;

		private const float GrassDieTimeHours = 16f;

		private const float GrassDieSpeedCreatureWalking = 0.12f;

		private const int SnowValueSubtractWalkingCreature = 50;

		private static NativeArray<uint> data;

		private static NativeArray<uint> dataThreadCopy;

		private static ComputeBuffer computeBuffer;

		private readonly HashSet<int> modifiedDuringUpdate = new HashSet<int>();

		private readonly object modifiedDuringUpdateLock = new object();

		private readonly object dataLock = new object();

		private VillageMap map;

		private WorldDate dateTime;

		private bool isMapLoaded;

		private bool threadFinished;

		private System.Random random;

		private InterpolatedValueList snowMeltSpeed;

		private HashSet<int> grassAddedOrRemovedOnThread = new HashSet<int>();

		private HashSet<int> grassAddedOrRemoved = new HashSet<int>();

		private float[] snowMeltSpeedCache;

		private float[] perlinNoiseGrassGrowth;

		private float[] perlinNoiseHighContrast;

		private int dataLength;

		public event GrassChangedDelegate GrassChangedEvent;

		public static void InitStaticArrays()
		{
			data = ArrayStorage.GetNativeArray<uint>("SnowGrassWetnessManager.data", GridDataIndexTools.MaxDataLength);
			dataThreadCopy = ArrayStorage.GetNativeArray<uint>("SnowGrassWetnessManager.dataThreadCopy", GridDataIndexTools.MaxDataLength);
			computeBuffer = ArrayStorage.GetComputeBuffer("SnowGrassWetnessManager.computeBuffer", GridDataIndexTools.MaxDataLength, 4);
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(data, dataLength);
			ArrayStorage.ClearNativeArray(dataThreadCopy, dataLength);
		}

		public void Initialize(VillageMap villageMap)
		{
			snowMeltSpeed = Repository<SnowMeltSpeedData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			CreateSnowMeltSpeedCache();
			random = new System.Random();
			map = villageMap;
			dateTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourUpdate;
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			MonoSingleton<CreatureManager>.Instance.CreatureChangedNodeEvent += OnCreatureChangedNode;
			MonoSingleton<CropsController>.Instance.CropfieldPlacedEvent += OnCropfieldPlaced;
			MonoSingleton<FloraController>.Instance.OnSpawnPlantMapResourceInstanceEvent += OnSpawnPlantMapResourceInstance;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			map.Effects3dTextureManager.BeforeDispatch += OnBeforeDispatch;
			dataLength = map.Size.x * map.Size.y * map.Size.z;
			isMapLoaded = false;
			InitStaticArrays();
			ClearStaticArrays();
			InitPerlinNoises();
		}

		private void OnTick(float obj)
		{
			if (grassAddedOrRemoved.Count == 0)
			{
				lock (grassAddedOrRemovedOnThread)
				{
					if (grassAddedOrRemovedOnThread.Count == 0)
					{
						return;
					}
				}
			}
			GrassChanged();
		}

		public void DebugSetGrassCheckerboardPattern()
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			for (int i = 0; i < villageMap.Size.x; i++)
			{
				for (int j = 0; j < villageMap.Size.z; j++)
				{
					int heightAt = MonoSingleton<Heightmap>.Instance.GetHeightAt(i, j);
					MapNode node = villageMap.GetNode(i, heightAt, j);
					MapChunk mapChunkAt = MonoSingleton<World>.Instance.ChunkGenerator.GetMapChunkAt(i, j);
					if (node != null)
					{
						int num = mapChunkAt.ChunkX / mapChunkAt.ChunkSize;
						int num2 = mapChunkAt.ChunkZ / mapChunkAt.ChunkSize;
						if ((num + num2) % 2 == 0)
						{
							villageMap.SnowGrassWetnessManager.SetGrassHealth(node.Index, 255f);
						}
						else
						{
							villageMap.SnowGrassWetnessManager.SetGrassHealth(node.Index, 0f);
						}
					}
				}
			}
		}

		public void Dispose()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourUpdate;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<CreatureManager>.IsInstantiated())
			{
				MonoSingleton<CreatureManager>.Instance.CreatureChangedNodeEvent -= OnCreatureChangedNode;
			}
			if (map?.Effects3dTextureManager != null)
			{
				map.Effects3dTextureManager.BeforeDispatch -= OnBeforeDispatch;
			}
			if (map != null)
			{
				map.OnNodeVoxelTypeChangedEvent -= OnNodeVoxelTypeChanged;
			}
			if (MonoSingleton<CropsController>.IsInstantiated())
			{
				MonoSingleton<CropsController>.Instance.CropfieldPlacedEvent -= OnCropfieldPlaced;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnObjectPlaced;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnObjectRemoved;
			}
			if (MonoSingleton<FloraController>.IsInstantiated())
			{
				MonoSingleton<FloraController>.Instance.OnSpawnPlantMapResourceInstanceEvent -= OnSpawnPlantMapResourceInstance;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			map = null;
			dateTime = null;
			modifiedDuringUpdate.Clear();
			random = null;
			snowMeltSpeed = null;
			snowMeltSpeedCache = null;
			perlinNoiseGrassGrowth = null;
			perlinNoiseHighContrast = null;
			this.GrassChangedEvent = null;
		}

		public void CopyData(NativeArray<uint> dest)
		{
			NativeArray<uint>.Copy(data, dest, dataLength);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte GetSnow(int index)
		{
			return (byte)(data[index] & 0xFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetSnow(int index, byte value)
		{
			data[index] = (data[index] & 0xFFFFFF00u) | value;
			if (!threadFinished)
			{
				lock (modifiedDuringUpdateLock)
				{
					modifiedDuringUpdate.Add(index);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte GetWetness(int index)
		{
			return (byte)((data[index] >> 8) & 0xFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetWetness(int index, byte value)
		{
			data[index] = (data[index] & 0xFFFF00FFu) | (uint)(value << 8);
			if (!threadFinished)
			{
				lock (modifiedDuringUpdateLock)
				{
					modifiedDuringUpdate.Add(index);
				}
			}
		}

		public void RefreshWetnessWater(float[] waterData)
		{
			if (!threadFinished)
			{
				return;
			}
			for (int i = 0; i < dataLength; i++)
			{
				if (waterData[i] >= 0.01f)
				{
					data[i] = (data[i] & 0xFFFF0000u) | 0xFF00;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetGrassHealth(int index)
		{
			return (float)(data[index] >> 16) / 65535f;
		}

		public void SetGrassHealth(int index, float value)
		{
			SetGrassValue(index, (uint)(Math.Clamp(value, 0f, 1f) * 65535f));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetGrassValue(int index)
		{
			return (int)((data[index] >> 16) & 0xFFFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetGrassValue(int index, uint grassValue)
		{
			uint num = (grassValue & 0xFFFF) << 16;
			int grassValue2 = GetGrassValue(index);
			data[index] = (data[index] & 0xFFFF) | num;
			if ((grassValue2 != grassValue && grassValue == 0) || grassValue2 == 0)
			{
				grassAddedOrRemoved.Add(index);
			}
			if (threadFinished)
			{
				dataThreadCopy[index] = (data[index] & 0xFFFF) | num;
				return;
			}
			lock (modifiedDuringUpdateLock)
			{
				modifiedDuringUpdate.Add(index);
			}
		}

		private void GrassChanged()
		{
			using PooledHashSet<int> added = HashSetPool<int>.GetJanitor();
			using PooledHashSet<int> removed = HashSetPool<int>.GetJanitor();
			foreach (int item in grassAddedOrRemoved)
			{
				if (GetGrassValue(item) == 0)
				{
					removed.Add(item);
				}
				else
				{
					added.Add(item);
				}
			}
			grassAddedOrRemoved.Clear();
			lock (grassAddedOrRemovedOnThread)
			{
				foreach (int item2 in grassAddedOrRemovedOnThread)
				{
					if (GetGrassValue(item2) == 0)
					{
						removed.Add(item2);
					}
					else
					{
						added.Add(item2);
					}
				}
				grassAddedOrRemovedOnThread.Clear();
			}
			if (added.Count > 0 || removed.Count > 0)
			{
				this.GrassChangedEvent?.Invoke(added, removed);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetGrassValueThread(int index, uint grassValue)
		{
			dataThreadCopy[index] = (dataThreadCopy[index] & 0xFFFF) | ((grassValue & 0xFFFF) << 16);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private byte GetSnowThread(int index)
		{
			return (byte)(dataThreadCopy[index] & 0xFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetSnowThread(int index, byte value)
		{
			dataThreadCopy[index] = (dataThreadCopy[index] & 0xFFFFFF00u) | value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private byte GetWetnessThread(int index)
		{
			return (byte)((dataThreadCopy[index] >> 8) & 0xFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetWetnessThread(int index, byte value)
		{
			dataThreadCopy[index] = (dataThreadCopy[index] & 0xFFFF00FFu) | (uint)(value << 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetGrassValueThread(int index)
		{
			return (int)((dataThreadCopy[index] >> 16) & 0xFFFF);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetGrassHealthThread(int index, float value)
		{
			SetGrassValueThread(index, (uint)(Math.Clamp(value, 0f, 1f) * 65535f));
		}

		private void OnMapLoaded(bool loadedFromSave)
		{
			isMapLoaded = true;
			threadFinished = true;
			if (!loadedFromSave)
			{
				SetInitialGrassValues();
			}
			else
			{
				SetNoGrassWhereVoxelsAre();
			}
			map.OnNodeVoxelTypeChangedEvent += OnNodeVoxelTypeChanged;
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnObjectPlaced;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnObjectRemoved;
			}
		}

		private void OnQuarterHourUpdate()
		{
			if (isMapLoaded)
			{
				TickData();
			}
		}

		private void OnBeforeDispatch(int kernelIndex, ComputeShader computeShader)
		{
			lock (dataLock)
			{
				computeBuffer.SetData(data);
			}
			computeShader.SetBuffer(kernelIndex, "snowWetData", computeBuffer);
		}

		private void OnCreatureChangedNode(CreatureBase creature, MapNode node)
		{
			if (map == null || creature == null || !creature.CanMakeDirtPath || node == null)
			{
				return;
			}
			int index = node.Index;
			int snow = GetSnow(index);
			bool flag = false;
			if (snow > 0)
			{
				SetSnow(index, (byte)Mathf.Clamp(snow - 50, 0, 255));
				flag = true;
			}
			else
			{
				float grassHealth = GetGrassHealth(index);
				if (grassHealth > 0f)
				{
					SetGrassHealth(index, grassHealth - 0.12f);
					flag = true;
				}
			}
			if (flag)
			{
				map.Effects3dTextureManager.ScheduleDispatchComputeShader();
			}
		}

		public byte[] GetBinaryDataToSerialize()
		{
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			lock (dataLock)
			{
				for (int i = 0; i < dataLength; i++)
				{
					binaryWriter.Write(data[i]);
				}
			}
			return memoryStream.GetBuffer();
		}

		public void ReadFromBinaryData(byte[] inputData)
		{
			if (inputData == null || inputData.Length == 0)
			{
				SetInitialGrassValues();
				return;
			}
			using MemoryStream memoryStream = new MemoryStream(inputData);
			using BinaryReader binaryReader = new BinaryReader(memoryStream);
			if (memoryStream.Length < dataLength)
			{
				return;
			}
			uint[] array = new uint[dataLength];
			for (int i = 0; i < dataLength; i++)
			{
				array[i] = binaryReader.ReadUInt32();
			}
			lock (dataLock)
			{
				NativeArray<uint>.Copy(array, data, dataLength);
				NativeArray<uint>.Copy(data, dataThreadCopy, dataLength);
			}
		}

		private void CreateSnowMeltSpeedCache()
		{
			snowMeltSpeedCache = new float[60];
			for (int i = 0; i < 60; i++)
			{
				snowMeltSpeedCache[i] = snowMeltSpeed.GetMultiplierInterpolated(i + -30);
			}
		}

		private void TickData()
		{
			if (threadFinished)
			{
				threadFinished = false;
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(TickSnowWetnessThread, TickSnowWetnessFinishedMain);
			}
		}

		private bool TickSnowWetnessThread()
		{
			MapNode[] gridSpaceData = map.GridSpaceData;
			int x = map.Size.x;
			int z = map.Size.z;
			bool flag = false;
			float snowEffectWeight = MonoSingleton<WeatherManager>.Instance.SnowEffectWeight;
			float rainEffectWeight = MonoSingleton<WeatherManager>.Instance.RainEffectWeight;
			TemperatureManager temperatureManager = map.TemperatureManager;
			int num = snowMeltSpeedCache.Length;
			PooledList<int> walkableNodeIndices = ListPool<int>.GetJanitor();
			try
			{
				map.BeautyManager.WalkableIndicesSafeOperation(delegate(IEnumerable<int> indices)
				{
					walkableNodeIndices.AddRange(indices);
				});
				float num2 = 0.025f * MonoSingleton<WeatherManager>.Instance.CalculateGrassGrowSpeed(dateTime.Season, dateTime.SeasonPercent);
				lock (dataLock)
				{
					NativeArray<uint>.Copy(data, dataThreadCopy, dataLength);
				}
				using PooledHashSet<int> pooledHashSet = HashSetPool<int>.GetJanitor();
				Heightmap instance = MonoSingleton<Heightmap>.Instance;
				WaterSimLogic waterSimLogic = map.WaterManager.WaterSimLogic;
				foreach (int item in walkableNodeIndices)
				{
					MapNode mapNode = gridSpaceData[item];
					bool flag2 = mapNode.Coverage != CoverageType.Roofed;
					if (!flag2 && (mapNode.DataType & GridDataType.SlopeOrStairs) != GridDataType.None && instance.GetHeightAt(mapNode.Position.x, mapNode.Position.z) == mapNode.Position.y)
					{
						flag2 = true;
					}
					if (!flag2 && instance.GetHeightNoPassthroughFloor(mapNode.Position.x, mapNode.Position.z) == mapNode.Position.y)
					{
						flag2 = true;
					}
					float temperature = temperatureManager.GetTemperature(item);
					int num3 = 0;
					bool num4 = waterSimLogic.IsWaterAt(item);
					if (!num4)
					{
						int num5 = 0;
						bool flag3 = mapNode.HasShadowCasterPlants;
						if (!flag3 && flag2)
						{
							int num6 = random.Next(10);
							int num7 = mapNode.Position.z * x + mapNode.Position.x;
							num5 = (int)(snowEffectWeight * ((float)num6 + 15f * perlinNoiseGrassGrowth[num7]));
							if (HasBuildingOrShadowCasterAbove(mapNode))
							{
								flag3 = true;
								num5 /= 2;
							}
						}
						float num8 = snowMeltSpeedCache[Math.Clamp((int)(temperature - -30f), 0, num - 1)];
						if (num8 > 0f)
						{
							num5 -= (int)(num8 * (float)random.Next(10));
						}
						if (flag2 && rainEffectWeight > 0f)
						{
							int num9 = mapNode.Position.x * z + mapNode.Position.z;
							num3 = (int)(1.0 + (double)(rainEffectWeight * 30f) * ((double)perlinNoiseGrassGrowth[num9] * 0.8 + 0.20000000298023224));
						}
						if (num5 != 0)
						{
							int snowThread = GetSnowThread(item);
							int num10 = Math.Clamp(snowThread + num5, 0, flag3 ? 128 : 255);
							if (num10 != snowThread)
							{
								flag = true;
								SetSnowThread(item, (byte)num10);
								if (num5 < 0)
								{
									num3 -= (int)(0.8f * (float)num5);
								}
							}
						}
					}
					byte wetnessThread = GetWetnessThread(item);
					float num11 = 5f + 8f * (Math.Clamp(temperature, 0f, 50f) / 50f);
					if (rainEffectWeight > 0.1f || num3 > 0)
					{
						num11 = 0f;
					}
					int num12 = Math.Clamp(wetnessThread + num3 - (int)num11, 0, 255);
					if (wetnessThread != num12)
					{
						SetWetnessThread(item, (byte)num12);
						flag = true;
					}
					int num13 = mapNode.Position.x * z + mapNode.Position.z;
					int grassValueThread = GetGrassValueThread(item);
					float num14 = (float)grassValueThread / 65535f;
					bool flag4 = CanGrowGrass(mapNode) && num14 < perlinNoiseHighContrast[num13];
					if (num4 && num14 > 0.65f)
					{
						flag4 = false;
					}
					float num15 = MathfUtils.Clamp(perlinNoiseGrassGrowth[num13] + 0.1f, 0f, 1f);
					float num16 = (flag4 ? num2 : (-1f / 64f)) * num15;
					float max = 1f;
					if (mapNode.HasShadowCasterPlants || HasBuildingOrShadowCasterAbove(mapNode))
					{
						max = 0.5f;
					}
					float value = Math.Clamp(num14 + num16, 0f, max);
					SetGrassHealthThread(item, value);
					int grassValueThread2 = GetGrassValueThread(item);
					if (grassValueThread != grassValueThread2)
					{
						if (grassValueThread2 == 0 || grassValueThread == 0)
						{
							pooledHashSet.Add(item);
						}
						flag = true;
					}
				}
				lock (dataLock)
				{
					lock (modifiedDuringUpdateLock)
					{
						foreach (int item2 in modifiedDuringUpdate)
						{
							dataThreadCopy[item2] = data[item2];
						}
						modifiedDuringUpdate.Clear();
					}
					NativeArray<uint>.Copy(dataThreadCopy, data, dataLength);
					lock (grassAddedOrRemovedOnThread)
					{
						grassAddedOrRemovedOnThread.Clear();
						grassAddedOrRemovedOnThread.AddRange(pooledHashSet);
					}
				}
				if (flag)
				{
					map.Effects3dTextureManager.ScheduleDispatchComputeShader();
				}
				return true;
			}
			finally
			{
				((IDisposable)walkableNodeIndices/*cast due to .constrained prefix*/).Dispose();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasBuildingOrShadowCasterAbove(MapNode currentNode)
		{
			if ((currentNode.DataType & (GridDataType.Furniture | GridDataType.ProductionBuilding)) != GridDataType.None)
			{
				return true;
			}
			MapNode nodeAbove = currentNode.GetNodeAbove();
			if (nodeAbove != null && nodeAbove.HasShadowCasterPlants)
			{
				return nodeAbove.HasShadowCasterPlants;
			}
			return false;
		}

		private void TickSnowWetnessFinishedMain(bool result)
		{
			threadFinished = true;
		}

		private void InitPerlinNoises(int fractalOctaves = 3, float freq = 0.06f, float gain = 0.5f)
		{
			int x = map.Size.x;
			int z = map.Size.z;
			perlinNoiseGrassGrowth = new float[x * z];
			perlinNoiseHighContrast = new float[x * z];
			HashCode hashCode = default(HashCode);
			hashCode.Add(map.VillageInstance.Seed);
			FastNoise fastNoise = new FastNoise(hashCode.ToHashCode());
			fastNoise.SetFrequency(freq);
			fastNoise.SetFractalType(FastNoise.FractalType.FBM);
			fastNoise.SetFractalOctaves(fractalOctaves);
			fastNoise.SetFractalLacunarity(2f);
			fastNoise.SetFractalGain(gain);
			float num = 2f;
			float num2 = 3.1f;
			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < z; j++)
				{
					perlinNoiseGrassGrowth[i + j * x] = Mathf.Abs(fastNoise.GetPerlinFractal((float)i * num, (float)j * num) * 1.9f) % 1f;
					perlinNoiseHighContrast[i + j * x] = Mathf.Clamp01((fastNoise.GetPerlinFractal((float)(i + x) * num2, (float)j * num2) + 0.45f) * 4f);
				}
			}
		}

		private static bool CanGrowGrass(MapNode node)
		{
			if (node.Map.FireSimLogic.GetFireData(node.Index) > 0f)
			{
				return false;
			}
			if (node.DataType.HasFlag(GridDataType.Drawbridge))
			{
				return false;
			}
			if (node.VoxelType != null)
			{
				return false;
			}
			bool flag = node.Coverage == CoverageType.Roofed;
			bool flag2 = node.Position.y > 0;
			if (flag2)
			{
				MapNode nodeBelow = node.GetNodeBelow();
				if (nodeBelow == null || !nodeBelow.IsGrass || nodeBelow.VoxelType == null)
				{
					flag2 = false;
				}
			}
			MapNode nodeAbove = node.GetNodeAbove();
			if (nodeAbove != null && nodeAbove.HasShadowCasterPlants)
			{
				return false;
			}
			bool flag3 = (node.DataType & (GridDataType.BuildingFinished | GridDataType.Cropfield | GridDataType.Roof)) == 0 && (node.Tag & (MapNodeTags.Wall | MapNodeTags.Floor)) == 0;
			return !flag && flag2 && flag3;
		}

		private void SetInitialGrassValues()
		{
			int z = map.Size.z;
			MapNode[] gridSpaceData = map.GridSpaceData;
			lock (dataLock)
			{
				for (int i = 0; i < gridSpaceData.Length; i++)
				{
					MapNode mapNode = gridSpaceData[i];
					if (CanGrowGrass(mapNode))
					{
						int num = mapNode.Position.x * z + mapNode.Position.z;
						float num2 = perlinNoiseHighContrast[num];
						SetGrassHealth(mapNode.Index, num2);
						if (num2 > 0f)
						{
							grassAddedOrRemoved.Add(i);
						}
					}
				}
			}
		}

		private void SetNoGrassWhereVoxelsAre()
		{
			MapNode[] gridSpaceData = map.GridSpaceData;
			lock (dataLock)
			{
				for (int i = 0; i < gridSpaceData.Length; i++)
				{
					MapNode mapNode = gridSpaceData[i];
					int grassValue = GetGrassValue(i);
					if (mapNode.VoxelTypeIdByte != 0 && grassValue > 0)
					{
						SetGrassValue(mapNode.Index, 0u);
					}
					if (grassValue > 0)
					{
						grassAddedOrRemoved.Add(i);
					}
				}
			}
		}

		private void ClearSnowGrassForObject(WorldObject obj, byte snowValue, float grassValue)
		{
			if (obj.Positions == null)
			{
				int index = obj.GetNode().Index;
				SetSnow(index, snowValue);
				SetGrassHealth(index, grassValue);
				return;
			}
			VillageMap villageMap = obj.Map;
			if (villageMap == null)
			{
				Log.Info("VillageMap was null. Aborting setting health for snow and grass inside ClearSnowGrassForObject().", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\SnowGrassWetnessManager.cs");
				return;
			}
			foreach (Vec3Int position in obj.Positions)
			{
				if (villageMap.GetNode(position) == null)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\SnowGrassWetnessManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't fetch map node for ");
						messageBuilder.AppendFormatted(position);
						messageBuilder.AppendLiteral(" position.");
					}
					Log.Info(messageBuilder);
				}
				else
				{
					int index2 = villageMap.GetNode(position).Index;
					SetSnow(index2, snowValue);
					SetGrassHealth(index2, grassValue);
				}
			}
		}

		private void LimitSnowGrassForObject(WorldObject obj, byte snowValue, float grassValue)
		{
			if (obj.Positions == null)
			{
				int index = obj.GetNode().Index;
				SetSnow(index, snowValue);
				SetGrassHealth(index, grassValue);
				return;
			}
			VillageMap villageMap = obj.Map;
			foreach (Vec3Int position in obj.Positions)
			{
				int index2 = villageMap.GetNode(position).Index;
				if (GetSnow(index2) > snowValue)
				{
					SetSnow(index2, snowValue);
				}
				if (GetGrassHealth(index2) > grassValue)
				{
					SetGrassHealth(index2, grassValue);
				}
			}
		}

		private void OnNodeVoxelTypeChanged(MapNode node)
		{
			MapNode nodeAbove = node.GetNodeAbove();
			if (nodeAbove != null)
			{
				SetSnow(nodeAbove.Index, 0);
				SetGrassHealth(nodeAbove.Index, 0f);
			}
		}

		private void OnObjectRemoved(WorldObject obj)
		{
			if (!(obj is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Blueprint }))
			{
				ClearSnowGrassForObject(obj, 0, 0f);
			}
		}

		private void OnObjectPlaced(WorldObject obj)
		{
			ClearSnowGrassForObject(obj, 0, 0f);
		}

		private void OnCropfieldPlaced(CropfieldInstance obj)
		{
			ClearSnowGrassForObject(obj, 0, 0f);
		}

		private void OnSpawnPlantMapResourceInstance(PlantMapResourceInstance obj)
		{
			if (obj != null && !obj.HasDisposed)
			{
				LimitSnowGrassForObject(obj, 128, 0.5f);
			}
		}
	}
}
