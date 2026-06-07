using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.Variables;
using Events;
using Events.Minimap;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Data.Minimap
{
	public class MinimapManager : MonoBehaviour
	{
		private struct IslandChangeData
		{
			public List<Vector3Int> Positions;

			public List<Vector4> Colors;
		}

		[SerializeField]
		private BaseEvent _startLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private FactoryObjectData _skylineInData;

		[SerializeField]
		private IntVariableSO _skylineLength;

		[SerializeField]
		private MinimapDataCreatedEvent _minimapDataCreatedEvent;

		[SerializeField]
		private ComputeShader _minimapIslandTextureCreator;

		[SerializeField]
		private ComputeShader _minimapFullOverlayTextureCreator;

		[Header("Colors")]
		[SerializeField]
		private MinimapColorSettings _minimapColorSettings;

		private MinimapData _minimapData;

		private Dictionary<IslandObject, int> _islandToIndexMap = new Dictionary<IslandObject, int>();

		private Texture2D[] _terrainTextures = Array.Empty<Texture2D>();

		private RenderTexture[] _minimapTextures = Array.Empty<RenderTexture>();

		private ComputeShader[] _computeShaders = Array.Empty<ComputeShader>();

		private Dictionary<IslandObject, IslandChangeData> _addedToIslandData = new Dictionary<IslandObject, IslandChangeData>();

		private Dictionary<IslandObject, IslandChangeData> _removedFromIslandData = new Dictionary<IslandObject, IslandChangeData>();

		private int _initTerrainKernel;

		private int _addedFactoryObjectsKernel;

		private int _removedFactoryObjectsKernel;

		private int _initEmptyTextureKernel;

		private int _fullMapAddedFactoryObjectsKernel;

		private int _fullMapRemovedFactoryObjectsKernel;

		private RenderTexture _overlayFullMapTexture;

		private Bounds _fullMapBounds;

		private Vector2Int _fullMapSize;

		private static readonly int Center = Shader.PropertyToID("Center");

		private static readonly int IslandPosition = Shader.PropertyToID("IslandPosition");

		private static readonly int TextureSize = Shader.PropertyToID("TextureSize");

		private static readonly int HalfTextureSize = Shader.PropertyToID("HalfTextureSize");

		private static readonly int TerrainTex = Shader.PropertyToID("TerrainTex");

		private static readonly int ResultTex = Shader.PropertyToID("ResultTex");

		private static readonly int PositionsSize = Shader.PropertyToID("PositionsSize");

		private static readonly int Positions = Shader.PropertyToID("Positions");

		private static readonly int Colors = Shader.PropertyToID("Colors");

		private static readonly int TileColor = Shader.PropertyToID("TileColor");

		private static readonly int GrassColor = Shader.PropertyToID("GrassColor");

		private static readonly int WaterColor = Shader.PropertyToID("WaterColor");

		private void Awake()
		{
			_initTerrainKernel = _minimapIslandTextureCreator.FindKernel("InitTerrain");
			_addedFactoryObjectsKernel = _minimapIslandTextureCreator.FindKernel("AddedFactoryObjects");
			_removedFactoryObjectsKernel = _minimapIslandTextureCreator.FindKernel("RemovedFactoryObjects");
			_initEmptyTextureKernel = _minimapFullOverlayTextureCreator.FindKernel("InitEmptyTexture");
			_fullMapAddedFactoryObjectsKernel = _minimapFullOverlayTextureCreator.FindKernel("AddedFactoryObjects");
			_fullMapRemovedFactoryObjectsKernel = _minimapFullOverlayTextureCreator.FindKernel("RemovedFactoryObjects");
			_startLoadingSaveEvent.Register(UnInitMinimap);
			_finishedLoadingSaveEvent.Register(InitMinimap);
		}

		private void OnDestroy()
		{
			_startLoadingSaveEvent.UnRegister(UnInitMinimap);
			_finishedLoadingSaveEvent.UnRegister(InitMinimap);
			UnInitMinimap();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateColors()
		{
			UnInitMinimap();
			InitMinimap();
		}

		private void UnInitMinimap()
		{
			for (int num = _minimapTextures.Length - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(_minimapTextures[num]);
			}
			for (int num2 = _computeShaders.Length - 1; num2 >= 0; num2--)
			{
				UnityEngine.Object.Destroy(_computeShaders[num2]);
			}
			UnityEngine.Object.Destroy(_overlayFullMapTexture);
			foreach (KeyValuePair<IslandObject, int> item in _islandToIndexMap)
			{
				item.Key.OnFactoryObjectAdded -= FactoryObjectAddedToIsland;
				item.Key.OnFactoryObjectRemoved -= FactoryObjectRemovedFromIsland;
			}
			_addedToIslandData.Clear();
			_removedFromIslandData.Clear();
			_islandToIndexMap.Clear();
		}

		private void InitMinimap()
		{
			_fullMapBounds = _islandLayer.CalculateBounds();
			_fullMapSize = new Vector2Int(Mathf.CeilToInt(_fullMapBounds.size.x), Mathf.CeilToInt(_fullMapBounds.size.z));
			CreateOverlayFullMapTexture();
			InitOverlayFullMapComputeShader();
			List<IslandObject> allIslands = _islandLayer.GetAllIslands();
			_terrainTextures = new Texture2D[allIslands.Count];
			_minimapTextures = new RenderTexture[allIslands.Count];
			_computeShaders = new ComputeShader[allIslands.Count];
			for (int i = 0; i < allIslands.Count; i++)
			{
				IslandObject islandObject = allIslands[i];
				_islandToIndexMap.Add(islandObject, i);
				_terrainTextures[i] = islandObject.IslandConfig.Texture;
				_minimapTextures[i] = CreateTextureForIslandCompute(islandObject);
				_computeShaders[i] = CreateComputeShaderForIsland(islandObject, _minimapTextures[i]);
				List<FactoryObject> allDistinctObjects = islandObject.GetAllDistinctObjects(_terrainLayer);
				List<FactoryObject> allDistinctObjects2 = islandObject.GetAllDistinctObjects(_factoryLayer);
				AddFactoryObjectsToTexture(allDistinctObjects, i);
				AddFactoryObjectsToTexture(allDistinctObjects2, i);
				_addedToIslandData.Add(islandObject, new IslandChangeData
				{
					Colors = new List<Vector4>(),
					Positions = new List<Vector3Int>()
				});
				_removedFromIslandData.Add(islandObject, new IslandChangeData
				{
					Colors = new List<Vector4>(),
					Positions = new List<Vector3Int>()
				});
				islandObject.OnFactoryObjectAdded += FactoryObjectAddedToIsland;
				islandObject.OnFactoryObjectRemoved += FactoryObjectRemovedFromIsland;
			}
			_minimapData = new MinimapData(_fullMapBounds, _minimapTextures, allIslands.ToArray(), _overlayFullMapTexture);
			_minimapDataCreatedEvent.Fire(_minimapData);
		}

		private ComputeShader CreateComputeShaderForIsland(IslandObject island, RenderTexture islandTexture)
		{
			ComputeShader computeShader = UnityEngine.Object.Instantiate(_minimapIslandTextureCreator);
			Texture2D texture = island.IslandConfig.Texture;
			computeShader.SetInt(TextureSize, texture.width);
			computeShader.SetInt(HalfTextureSize, texture.width / 2);
			computeShader.SetInts(IslandPosition, island.Position.x, island.Position.y, island.Position.z);
			computeShader.SetVector(TileColor, _minimapColorSettings.TileColor);
			computeShader.SetVector(GrassColor, _minimapColorSettings.GrassColor);
			computeShader.SetVector(WaterColor, _minimapColorSettings.WaterColor);
			computeShader.SetTexture(_initTerrainKernel, TerrainTex, texture);
			computeShader.SetTexture(_initTerrainKernel, ResultTex, islandTexture);
			computeShader.SetTexture(_addedFactoryObjectsKernel, TerrainTex, texture);
			computeShader.SetTexture(_addedFactoryObjectsKernel, ResultTex, islandTexture);
			computeShader.SetTexture(_removedFactoryObjectsKernel, TerrainTex, texture);
			computeShader.SetTexture(_removedFactoryObjectsKernel, ResultTex, islandTexture);
			computeShader.Dispatch(_initTerrainKernel, 8, 8, 1);
			return computeShader;
		}

		private RenderTexture CreateTextureForIslandCompute(IslandObject island)
		{
			Texture2D texture2D = island.IslandView.IslandData.Texture2D;
			return new RenderTexture(texture2D.width, texture2D.height, 0)
			{
				enableRandomWrite = true,
				filterMode = FilterMode.Point,
				antiAliasing = 1
			};
		}

		private void CreateOverlayFullMapTexture()
		{
			_overlayFullMapTexture = new RenderTexture(_fullMapSize.x, _fullMapSize.y, 0)
			{
				enableRandomWrite = true,
				filterMode = FilterMode.Point,
				antiAliasing = 1
			};
		}

		private void InitOverlayFullMapComputeShader()
		{
			_minimapFullOverlayTextureCreator.SetInts(TextureSize, _fullMapSize.x, _fullMapSize.y);
			_minimapFullOverlayTextureCreator.SetInts(HalfTextureSize, _fullMapSize.x / 2, _fullMapSize.y / 2);
			_minimapFullOverlayTextureCreator.SetInts(Center, Mathf.RoundToInt(_fullMapBounds.center.x), Mathf.RoundToInt(_fullMapBounds.center.y), Mathf.RoundToInt(_fullMapBounds.center.z));
			_minimapFullOverlayTextureCreator.SetTexture(_initEmptyTextureKernel, ResultTex, _overlayFullMapTexture);
			_minimapFullOverlayTextureCreator.SetTexture(_fullMapAddedFactoryObjectsKernel, ResultTex, _overlayFullMapTexture);
			_minimapFullOverlayTextureCreator.SetTexture(_fullMapRemovedFactoryObjectsKernel, ResultTex, _overlayFullMapTexture);
			_minimapFullOverlayTextureCreator.Dispatch(_initEmptyTextureKernel, 8, 8, 1);
		}

		private void LateUpdate()
		{
			foreach (KeyValuePair<IslandObject, IslandChangeData> removedFromIslandDatum in _removedFromIslandData)
			{
				int count = removedFromIslandDatum.Value.Positions.Count;
				if (count != 0)
				{
					RemovePositionsFromIslandTexture(removedFromIslandDatum.Value.Positions, _islandToIndexMap[removedFromIslandDatum.Key], count);
					removedFromIslandDatum.Value.Positions.Clear();
				}
			}
			foreach (KeyValuePair<IslandObject, IslandChangeData> addedToIslandDatum in _addedToIslandData)
			{
				int count2 = addedToIslandDatum.Value.Positions.Count;
				if (count2 != 0)
				{
					AddPositionsToIslandTexture(addedToIslandDatum.Value.Positions, addedToIslandDatum.Value.Colors, _islandToIndexMap[addedToIslandDatum.Key], count2);
					addedToIslandDatum.Value.Positions.Clear();
					addedToIslandDatum.Value.Colors.Clear();
				}
			}
		}

		private void FactoryObjectAddedToIsland(FactoryLayer layer, FactoryObject factoryObject, IslandObject islandObject)
		{
			if (_minimapColorSettings.FactoryObjectIgnoreList.Contains(factoryObject.FactoryObjectData))
			{
				return;
			}
			if (factoryObject.FactoryObjectData == _skylineInData)
			{
				AddSkyline(factoryObject);
			}
			Vector4 item = GetColorOfFactoryObject(factoryObject);
			IslandChangeData islandChangeData = _addedToIslandData[islandObject];
			foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
			{
				islandChangeData.Positions.Add(occupiedPosition);
				islandChangeData.Colors.Add(item);
			}
		}

		private void FactoryObjectRemovedFromIsland(FactoryLayer layer, FactoryObject factoryObject, IslandObject islandObject)
		{
			if (_minimapColorSettings.FactoryObjectIgnoreList.Contains(factoryObject.FactoryObjectData))
			{
				return;
			}
			if (factoryObject.FactoryObjectData == _skylineInData)
			{
				RemoveSkyline(factoryObject);
			}
			bool flag = _minimapColorSettings.FactoryObjectsWithTerrainUnderneath.Contains(factoryObject.FactoryObjectData);
			IslandChangeData islandChangeData = _removedFromIslandData[islandObject];
			foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
			{
				islandChangeData.Positions.Add(occupiedPosition);
				if (flag && islandObject.TryGetObjectAt(_terrainLayer, occupiedPosition, out var factoryObject2))
				{
					FactoryObjectAddedToIsland(_terrainLayer, factoryObject2, islandObject);
				}
			}
		}

		private void AddFactoryObjectsToTexture(List<FactoryObject> factoryObjects, int islandIndex)
		{
			if (factoryObjects.Count == 0)
			{
				return;
			}
			List<Vector3Int> list = new List<Vector3Int>();
			List<Vector4> list2 = new List<Vector4>();
			bool flag = false;
			foreach (FactoryObject factoryObject in factoryObjects)
			{
				if (_minimapColorSettings.FactoryObjectIgnoreList.Contains(factoryObject.FactoryObjectData))
				{
					continue;
				}
				if (factoryObject.FactoryObjectData == _skylineInData)
				{
					AddSkyline(factoryObject);
				}
				Vector4 item = GetColorOfFactoryObject(factoryObject);
				foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
				{
					list.Add(occupiedPosition);
					list2.Add(item);
					flag = true;
				}
			}
			if (flag)
			{
				AddPositionsToIslandTexture(list, list2, islandIndex, list.Count);
			}
		}

		private void AddPositionsToIslandTexture(List<Vector3Int> positions, List<Vector4> colors, int islandIndex, int count)
		{
			if (count <= 0)
			{
				_computeShaders[islandIndex].SetInt(PositionsSize, 0);
				return;
			}
			ComputeBuffer computeBuffer = new ComputeBuffer(count, 12);
			computeBuffer.SetData(positions);
			ComputeBuffer computeBuffer2 = new ComputeBuffer(count, 16);
			computeBuffer2.SetData(colors);
			_computeShaders[islandIndex].SetInt(PositionsSize, count);
			_computeShaders[islandIndex].SetBuffer(_addedFactoryObjectsKernel, Positions, computeBuffer);
			_computeShaders[islandIndex].SetBuffer(_addedFactoryObjectsKernel, Colors, computeBuffer2);
			_computeShaders[islandIndex].Dispatch(_addedFactoryObjectsKernel, 1, 1, 1);
			computeBuffer.Dispose();
			computeBuffer2.Dispose();
		}

		private void RemovePositionsFromIslandTexture(List<Vector3Int> positions, int islandIndex, int count)
		{
			ComputeBuffer computeBuffer = new ComputeBuffer(count, 12);
			computeBuffer.SetData(positions);
			_computeShaders[islandIndex].SetInt(PositionsSize, count);
			_computeShaders[islandIndex].SetBuffer(_removedFactoryObjectsKernel, Positions, computeBuffer);
			_computeShaders[islandIndex].Dispatch(_removedFactoryObjectsKernel, 1, 1, 1);
			computeBuffer.Dispose();
		}

		private Color GetColorOfFactoryObject(FactoryObject factoryObject)
		{
			if (_minimapColorSettings.OverrideColor.TryGetValue(factoryObject.FactoryObjectData, out var value))
			{
				return value;
			}
			if (factoryObject.FactoryObjectData is BuildingObjectData buildingObjectData && buildingObjectData.FamilyID < _minimapColorSettings.BuildingFamilyColors.Count)
			{
				return _minimapColorSettings.BuildingFamilyColors[buildingObjectData.FamilyID];
			}
			if (_minimapColorSettings.WaterObjectsList.Contains(factoryObject.FactoryObjectData))
			{
				return _minimapColorSettings.WaterColor;
			}
			if (_minimapColorSettings.GrassObjectsList.Contains(factoryObject.FactoryObjectData))
			{
				return _minimapColorSettings.GrassColor;
			}
			return _minimapColorSettings.DefaultFactoryObjectColor;
		}

		private void AddSkyline(FactoryObject factoryObject)
		{
			Vector4 item = GetColorOfFactoryObject(factoryObject);
			List<Vector3Int> list = new List<Vector3Int>();
			List<Vector4> list2 = new List<Vector4>();
			Vector3Int position = factoryObject.Position;
			Vector3Int directionFromRotation = GridUtils.GetDirectionFromRotation(factoryObject.Rotation);
			for (int i = 0; i < _skylineLength.Value; i++)
			{
				list.Add(position + directionFromRotation * i);
				list2.Add(item);
			}
			AddPositionsToFullOverlayTexture(list, list2, _skylineLength.Value);
		}

		private void RemoveSkyline(FactoryObject factoryObject)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			Vector3Int position = factoryObject.Position;
			Vector3Int directionFromRotation = GridUtils.GetDirectionFromRotation(factoryObject.Rotation);
			for (int i = 0; i < _skylineLength.Value; i++)
			{
				list.Add(position + directionFromRotation * i);
			}
			RemovePositionsFromFullOverlayTexture(list, _skylineLength.Value);
		}

		private void AddPositionsToFullOverlayTexture(List<Vector3Int> positions, List<Vector4> colors, int count)
		{
			ComputeBuffer computeBuffer = new ComputeBuffer(count, 12);
			computeBuffer.SetData(positions);
			ComputeBuffer computeBuffer2 = new ComputeBuffer(count, 16);
			computeBuffer2.SetData(colors);
			_minimapFullOverlayTextureCreator.SetInt(PositionsSize, count);
			_minimapFullOverlayTextureCreator.SetBuffer(_fullMapAddedFactoryObjectsKernel, Positions, computeBuffer);
			_minimapFullOverlayTextureCreator.SetBuffer(_fullMapAddedFactoryObjectsKernel, Colors, computeBuffer2);
			_minimapFullOverlayTextureCreator.Dispatch(_fullMapAddedFactoryObjectsKernel, 1, 1, 1);
			computeBuffer.Dispose();
			computeBuffer2.Dispose();
		}

		private void RemovePositionsFromFullOverlayTexture(List<Vector3Int> positions, int count)
		{
			ComputeBuffer computeBuffer = new ComputeBuffer(count, 12);
			computeBuffer.SetData(positions);
			_minimapFullOverlayTextureCreator.SetInt(PositionsSize, count);
			_minimapFullOverlayTextureCreator.SetBuffer(_fullMapRemovedFactoryObjectsKernel, Positions, computeBuffer);
			_minimapFullOverlayTextureCreator.Dispatch(_fullMapRemovedFactoryObjectsKernel, 1, 1, 1);
			computeBuffer.Dispose();
		}
	}
}
