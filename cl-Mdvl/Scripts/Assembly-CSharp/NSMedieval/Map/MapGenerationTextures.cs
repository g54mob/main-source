using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model.MapNew;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using Utils;

namespace NSMedieval.Map
{
	public class MapGenerationTextures : MonoBehaviour
	{
		private const int FogChannel = 0;

		private const int WaterChannel = 1;

		private const int CracksChannel = 8;

		private const int HeightChannel = 15;

		private bool applyEffectMaskTexture;

		private Heightmap heightmap;

		private Texture2D effectMaskTexture;

		private NativeArray<Color32> effectMaskTextureData;

		private Texture2D mapMaskTexture;

		private NativeArray<Color32> mapMaskTextureData;

		private bool applyMapMaskTexture;

		private int mapSizeX;

		private int mapSizeY;

		private int mapSizeZ;

		private int mapHeightSqrt;

		private int textureWidth;

		private int textureHeight;

		private VillageMap map;

		private bool texturesInitialized;

		private bool texturesLoadedFromSave;

		public NativeArray<Color32> MapMaskTextureData => mapMaskTextureData;

		public NativeArray<Color32> EffectMaskTextureData => effectMaskTextureData;

		public Texture2D EffectMaskTexture => effectMaskTexture;

		public Texture2D MapMaskTexture => mapMaskTexture;

		public void Init(VillageMap map, Vec3Int mapSize)
		{
			this.map = map;
			mapSizeX = mapSize.x;
			mapSizeZ = mapSize.z;
			mapSizeY = mapSize.y;
			mapHeightSqrt = (int)Math.Ceiling(Math.Sqrt(mapSizeY));
		}

		public void ApplyEffectMaskTexture()
		{
			applyEffectMaskTexture = true;
		}

		public void ApplyMapMaskTexture()
		{
			applyMapMaskTexture = true;
		}

		public static void GetTextureSize(in int mapSizeX, in int mapSizeY, in int mapSizeZ, out int textureWidth, out int textureHeight)
		{
			int num = (int)Math.Ceiling(Math.Sqrt(mapSizeY));
			textureWidth = num * mapSizeX * 2;
			textureHeight = num * mapSizeZ * 2;
		}

		public void SetMasksOnTerrain()
		{
			textureWidth = mapHeightSqrt * mapSizeX * 2;
			textureHeight = mapHeightSqrt * mapSizeZ * 2;
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			if (currentVillageData.EffectMaskTexture != null && currentVillageData.MapMaskTexture != null && currentVillageData.EffectMaskTexture.width == textureWidth && currentVillageData.EffectMaskTexture.height == textureHeight && currentVillageData.MapMaskTexture.width == textureWidth && currentVillageData.MapMaskTexture.height == textureHeight)
			{
				Log.Info("Loading effectMaskTexture and mapMaskTexture from the save", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
				effectMaskTexture = currentVillageData.EffectMaskTexture;
				effectMaskTextureData = effectMaskTexture.GetRawTextureData<Color32>();
				mapMaskTexture = currentVillageData.MapMaskTexture;
				mapMaskTextureData = mapMaskTexture.GetRawTextureData<Color32>();
				MonoSingleton<GlobalShaderVariables>.Instance.SetTerrainMaskTextures(mapMaskTexture, effectMaskTexture);
				texturesInitialized = true;
				texturesLoadedFromSave = true;
				currentVillageData.EffectMaskTexture = null;
				currentVillageData.MapMaskTexture = null;
			}
			else
			{
				Color32[] pixels = new Color32[textureWidth * textureHeight];
				Texture2DHelper.TryCreateTexture(ref mapMaskTexture, textureWidth, textureHeight);
				mapMaskTexture.SetPixels32(pixels);
				mapMaskTextureData = mapMaskTexture.GetRawTextureData<Color32>();
				Texture2DHelper.TryCreateTexture(ref effectMaskTexture, textureWidth, textureHeight);
				effectMaskTexture.SetPixels32(pixels);
				effectMaskTextureData = effectMaskTexture.GetRawTextureData<Color32>();
				MonoSingleton<GlobalShaderVariables>.Instance.SetTerrainMaskTextures(mapMaskTexture, effectMaskTexture);
				texturesInitialized = true;
			}
		}

		public void SaveTexturesToZip(VillageSaveData saveData)
		{
			try
			{
				byte[] rawTextureData = effectMaskTexture.GetRawTextureData();
				saveData.ZipWriteBytes("effectMaskTexture.raw", rawTextureData);
			}
			catch (Exception ex)
			{
				Log.Warning("Exception during writing effectMaskTexture to the save:", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
				Log.Warning(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
			}
			try
			{
				byte[] rawTextureData = mapMaskTexture.GetRawTextureData();
				saveData.ZipWriteBytes("mapMaskTexture.raw", rawTextureData);
			}
			catch (Exception ex2)
			{
				Log.Warning("Exception during writing mapMaskTexture to the save:", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
				Log.Warning(ex2.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
			}
		}

		public void SaveTexturesToCache(VillageSaveData saveData)
		{
			try
			{
				byte[] rawTextureData = effectMaskTexture.GetRawTextureData();
				saveData.CacheWriteBytes("effectMaskTexture.raw", rawTextureData);
			}
			catch (Exception ex)
			{
				Log.Warning("Exception during writing effectMaskTexture to the RAM:", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
				Log.Warning(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
			}
			try
			{
				byte[] rawTextureData = mapMaskTexture.GetRawTextureData();
				saveData.CacheWriteBytes("mapMaskTexture.raw", rawTextureData);
			}
			catch (Exception ex2)
			{
				Log.Warning("Exception during writing mapMaskTexture to the RAM:", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
				Log.Warning(ex2.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
			}
		}

		public void WriteVoxelHealthToEffectMap(Vec3Int position)
		{
			WriteVoxelHealthToEffectMap(map.GetNode(position));
		}

		private void WriteVoxelHealthToEffectMap(MapNode node)
		{
			if (node.VoxelTypeIdByte != 0)
			{
				float value = 1f - (float)node.Health / (float)node.VoxelType.Health;
				WriteIntoEffectMap(8, value, node.Position);
			}
			else if ((node.DataType & GridDataType.Slope) != GridDataType.None)
			{
				SlopeInstance slopeInstance = (SlopeInstance)node.GetWorldObject(WorldObjectType.Slope);
				float value2 = 1f - slopeInstance.Health / (float)slopeInstance.HealthMax;
				WriteIntoEffectMap(8, value2, node.Position);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void UpdateHeightInEffectMask(int x, int z)
		{
			Vec3Int gridPosition = new Vec3Int(x, 0, z);
			int heightNoPassthroughFloor = heightmap.GetHeightNoPassthroughFloor(x, z);
			for (int i = 0; i < mapSizeY - 1; i++)
			{
				gridPosition.y = i;
				float value = ((i + 1 >= heightNoPassthroughFloor) ? 1f : 0f);
				WriteIntoEffectMap(15, value, gridPosition);
			}
			AddHeightToEffectMap(x, z);
		}

		internal void UpdateFog(IEnumerable<Vec3Int> updateAtCoords)
		{
			GroundManager instance = MonoSingleton<GroundManager>.Instance;
			foreach (Vec3Int updateAtCoord in updateAtCoords)
			{
				Vec3Int a = updateAtCoord;
				bool flag = instance.GroundExists(a + Vec3Int.up);
				WriteIntoEffectMap(0, flag ? 1f : 0f, a);
			}
		}

		private void UpdateFog(Vec3Int pos)
		{
			bool flag = MonoSingleton<GroundManager>.Instance.GroundExists(pos + Vec3Int.up);
			WriteIntoEffectMap(0, flag ? 1f : 0f, pos);
		}

		private void Start()
		{
			heightmap = MonoSingleton<Heightmap>.Instance;
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			MonoSingleton<GroundManager>.Instance.DigActionCycleEnd += OnDigActionCycleEnd;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
		}

		private void OnLoadingComplete()
		{
			map.WaterManager.WaterLevelChangedEvent += OnWaterLevelChanged;
			SetMasksOnTerrain();
			FillMapMaskWithGroundData();
			FillEffectMap(map);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			if (MonoSingleton<GroundManager>.IsInstantiated())
			{
				MonoSingleton<GroundManager>.Instance.DigActionCycleEnd -= OnDigActionCycleEnd;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			if (map?.WaterManager != null)
			{
				map.WaterManager.WaterLevelChangedEvent -= OnWaterLevelChanged;
			}
			map = null;
			heightmap = null;
		}

		private void OnWaterLevelChanged(HashSet<int> nodesChanged, HashSet<int> nodesChangedNeighbors)
		{
			if (nodesChanged.Count == 0)
			{
				return;
			}
			foreach (int item in nodesChanged)
			{
				UpdateWaterAt(item);
			}
			applyEffectMaskTexture = true;
		}

		private void UpdateWaterAt(int nodeIndex)
		{
			bool flag = map.WaterManager.IsWaterAt(nodeIndex);
			WriteIntoEffectMap(1, flag ? 1f : 0f, GridDataIndexTools.FastTo3DIndex(nodeIndex));
		}

		private void OnDigActionCycleEnd(Vec3Int position)
		{
			WriteVoxelHealthToEffectMap(position);
		}

		private void OnTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("MapGenerationTextures.Tick"))
			{
				if (applyEffectMaskTexture)
				{
					applyEffectMaskTexture = false;
					effectMaskTexture.Apply();
				}
				if (applyMapMaskTexture)
				{
					applyMapMaskTexture = false;
					mapMaskTexture.Apply();
				}
			}
		}

		public void FillMapMaskWithGroundData()
		{
			if (texturesLoadedFromSave)
			{
				return;
			}
			Log.Info("Re-generating map mask data - it was not found in the save.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapGenerationTextures.cs");
			Vec3Int gridPosition = default(Vec3Int);
			MapNode[] gridSpaceData = map.GridSpaceData;
			for (int i = 0; i < mapSizeX; i++)
			{
				gridPosition.x = i;
				for (int j = 0; j < mapSizeZ; j++)
				{
					gridPosition.z = j;
					for (int k = 0; k < mapSizeY; k++)
					{
						gridPosition.y = k;
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(i, k, j);
						MapNode mapNode = gridSpaceData[num];
						if (mapNode.VoxelTypeIdByte != 0)
						{
							VoxelType voxelType = mapNode.VoxelType;
							ToMapMask(voxelType.MapMaskBlock, gridPosition, out var outputPositionX, out var outputPositionY);
							mapMaskTextureData[GetIndex(outputPositionX, outputPositionY)] = voxelType.ColorForMapMask;
						}
					}
				}
			}
			applyMapMaskTexture = true;
		}

		private void WriteIntoEffectMap(int channel, float value, Vec3Int gridPosition, bool applyTexture = true)
		{
			MapToTexture(channel, gridPosition, out var outputPositionX, out var outputPositionY);
			int index = GetIndex(outputPositionX, outputPositionY);
			WriteIntoTexture(effectMaskTextureData, value, channel, index);
			if (applyTexture)
			{
				applyEffectMaskTexture = true;
			}
		}

		private static void WriteIntoTexture(NativeArray<Color32> data, float value, int channel, int texCoordIndex)
		{
			int num = channel % 4;
			if (texCoordIndex >= 0 && texCoordIndex < data.Length)
			{
				Color32 value2 = data[texCoordIndex];
				switch (num)
				{
				case 0:
					value2.r = (byte)Math.Round(Math.Clamp(value, 0f, 1f) * 255f);
					break;
				case 1:
					value2.g = (byte)Math.Round(Math.Clamp(value, 0f, 1f) * 255f);
					break;
				case 2:
					value2.b = (byte)Math.Round(Math.Clamp(value, 0f, 1f) * 255f);
					break;
				case 3:
					value2.a = (byte)Math.Round(Math.Clamp(value, 0f, 1f) * 255f);
					break;
				}
				data[texCoordIndex] = value2;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		private void MapToTexture(int channel, Vec3Int gridPosition, out int outputPositionX, out int outputPositionY)
		{
			outputPositionX = gridPosition.x;
			outputPositionY = gridPosition.z;
			int num = gridPosition.y % mapHeightSqrt * mapSizeX;
			int num2 = gridPosition.y / mapHeightSqrt * mapSizeZ;
			outputPositionX += num * 2;
			outputPositionY += num2 * 2;
			switch (channel / 4)
			{
			case 1:
				outputPositionY += mapSizeZ;
				break;
			case 2:
				outputPositionX += mapSizeX;
				break;
			case 3:
				outputPositionX += mapSizeX;
				outputPositionY += mapSizeZ;
				break;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetMapMaskMaterial(Vec3Int gridPosition, VoxelType voxelType, bool clear)
		{
			if (!(voxelType == null) && gridPosition.x >= 0 && gridPosition.y >= 0 && gridPosition.z >= 0 && gridPosition.x < mapSizeX && gridPosition.y < mapSizeY && gridPosition.z < mapSizeZ)
			{
				ToMapMask(voxelType.MapMaskBlock, gridPosition, out var outputPositionX, out var outputPositionY);
				if (clear)
				{
					ClearMapMaskMaterial(gridPosition);
				}
				mapMaskTextureData[GetIndex(outputPositionX, outputPositionY)] = voxelType.ColorForMapMask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		private int GetIndex(int x, int y)
		{
			return y * textureWidth + x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		private void ClearMapMaskMaterial(Vec3Int gridPosition)
		{
			Color clear = Color.clear;
			ToMapMask(0, gridPosition, out var outputPositionX, out var outputPositionY);
			int index = GetIndex(outputPositionX, outputPositionY);
			mapMaskTextureData[index] = clear;
			ToMapMask(1, gridPosition, out outputPositionX, out outputPositionY);
			index = GetIndex(outputPositionX, outputPositionY);
			mapMaskTextureData[index] = clear;
			ToMapMask(2, gridPosition, out outputPositionX, out outputPositionY);
			index = GetIndex(outputPositionX, outputPositionY);
			mapMaskTextureData[index] = clear;
			ToMapMask(3, gridPosition, out outputPositionX, out outputPositionY);
			index = GetIndex(outputPositionX, outputPositionY);
			mapMaskTextureData[index] = clear;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ToMapMask(int blockNumber, Vec3Int gridPosition, out int outputPositionX, out int outputPositionY)
		{
			outputPositionX = gridPosition.x;
			outputPositionY = gridPosition.z;
			int num = gridPosition.y % mapHeightSqrt * mapSizeX;
			int num2 = gridPosition.y / mapHeightSqrt * mapSizeZ;
			outputPositionX += num * 2;
			outputPositionY += num2 * 2;
			switch (blockNumber)
			{
			case 1:
				outputPositionY += mapSizeZ;
				break;
			case 2:
				outputPositionX += mapSizeX;
				break;
			case 3:
				outputPositionX += mapSizeX;
				outputPositionY += mapSizeZ;
				break;
			}
		}

		private void AddHeightToEffectMap(int x, int z)
		{
			if (!(effectMaskTexture == null))
			{
				Vec3Int gridPosition = new Vec3Int(x, mapSizeY - 1, z);
				float value = (float)heightmap.GetHeightNoPassthroughFloor(x, z) / (float)mapSizeY;
				WriteIntoEffectMap(15, value, gridPosition);
			}
		}

		public void FillEffectMap(VillageMap villageMap)
		{
			if (texturesLoadedFromSave)
			{
				return;
			}
			Vec3Int gridPosition = default(Vec3Int);
			int x = villageMap.Size.x;
			int y = villageMap.Size.y;
			int z = villageMap.Size.z;
			MapNode[] gridSpaceData = villageMap.GridSpaceData;
			for (int i = 0; i < x; i++)
			{
				gridPosition.x = i;
				for (int j = 0; j < z; j++)
				{
					int heightNoPassthroughFloor = heightmap.GetHeightNoPassthroughFloor(i, j);
					gridPosition.z = j;
					for (int k = 0; k < y - 1; k++)
					{
						gridPosition.y = k;
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(i, k, j);
						int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(i, k + 1, j);
						MapNode node = gridSpaceData[num];
						MapNode mapNode = gridSpaceData[num2];
						bool num3 = mapNode != null && !mapNode.IsVoxelAir();
						bool flag = map.WaterManager.IsWaterAt(num);
						if (num3)
						{
							WriteIntoEffectMap(0, 1f, gridPosition);
						}
						if (flag)
						{
							WriteIntoEffectMap(1, 1f, gridPosition);
						}
						WriteVoxelHealthToEffectMap(node);
						if (k < mapSizeY - 1 && k + 1 >= heightNoPassthroughFloor)
						{
							WriteIntoEffectMap(15, 1f, gridPosition);
						}
					}
					AddHeightToEffectMap(i, j);
				}
			}
			applyEffectMaskTexture = true;
		}

		public void SlopeAdded(SlopeInstance slopeInstance)
		{
			if (!texturesInitialized || slopeInstance == null)
			{
				return;
			}
			foreach (Vec3Int position in slopeInstance.Positions)
			{
				Vec3Int a = position;
				SetMapMaskMaterial(a + Vec3Int.up, slopeInstance.GetVoxelType(), clear: false);
				WriteVoxelHealthToEffectMap(a);
			}
			applyMapMaskTexture = true;
		}

		public void OnVoxelAdded(Vec3Int gridPos, VoxelType voxelType)
		{
			if (texturesInitialized)
			{
				SetMapMaskMaterial(gridPos, voxelType, clear: true);
				WriteVoxelHealthToEffectMap(gridPos);
				UpdateFog(gridPos + ILSpyHelper_AsRefReadOnly(Vector3.down));
				applyMapMaskTexture = true;
			}
			static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
			{
				//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
				return ref temp;
			}
		}
	}
}
