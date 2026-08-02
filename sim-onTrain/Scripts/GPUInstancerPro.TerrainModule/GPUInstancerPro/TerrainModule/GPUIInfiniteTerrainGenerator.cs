using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public class GPUIInfiniteTerrainGenerator : MonoBehaviour
	{
		[Serializable]
		public struct DetailSettings
		{
			public Texture2D texture;

			public GameObject prefab;

			public Color healthyColor;

			public Color dryColor;

			public Vector2 minMaxScale;

			public Vector2 minMaxDensity;
		}

		[BurstCompile]
		private struct CreateHeightmapArrayJob : IJobParallelFor
		{
			public NativeArray<float> heightMap;

			[ReadOnly]
			public int heightMapResolution;

			[ReadOnly]
			public Vector3 terrainPosition;

			public void Execute(int i)
			{
				int num = i % heightMapResolution;
				int num2 = i / heightMapResolution;
				float num3 = Mathf.PerlinNoise(((float)num * 2f + terrainPosition.x + 1000f) / 350f, ((float)num2 * 2f + terrainPosition.z + 1000f) / 350f) * 0.8f;
				num3 += Mathf.PerlinNoise(((float)num * 2f + terrainPosition.x - 1000f) / 100f, ((float)num2 * 2f + terrainPosition.z - 1000f) / 100f) * 0.2f;
				num3 = Mathf.Clamp01(num3);
				heightMap[num2 * heightMapResolution + num] = num3;
			}
		}

		public int seed = 42;

		public Transform centerTransform;

		public float startPosOffset = 10f;

		public float updateDistance = 20f;

		public float terrainVisibilityDistance = 2048f;

		[Space]
		[Header("Terrain Settings")]
		public int terrainSize = 1024;

		public float terrainHeight = 128f;

		public Material terrainMaterial;

		public TerrainLayer[] terrainLayers;

		public TerrainData dummyTerrain;

		[Space]
		[Header("Detail Settings")]
		public GPUIDetailManager detailManager;

		public DetailSettings[] detailSettings;

		public int detailResolution = 512;

		[Range(0f, 1f)]
		public float detailObjectDensity = 1f;

		public bool readDetailLayerFromTerrain;

		[Space]
		[Header("Tree Settings")]
		public GPUITreeManager treeManager;

		public GameObject[] treePrefabs;

		public int treeCountPerTerrain = 100;

		public Vector2 treeSizeRange = Vector2.one;

		private int _baseTextureResolution = 16;

		private int _heightmapResolution;

		private HashSet<int2> _expectedTerrainPositions;

		private Dictionary<int2, Terrain> _activeTerrains;

		private List<int2> _terrainsToDestroy;

		private Vector3 _lastUpdatePosition;

		private Queue<Terrain> _terrainPool;

		private List<int[,]> _detailArrays;

		private NativeArray<float> _heightmapNative;

		private float[] _heightMap1D;

		private float[,] _heightMap;

		private TreePrototype[] _terrainTreePrototypes;

		private TreeInstance[] _treeInstances;

		private float _detailObjectDistance = 750f;

		private void OnEnable()
		{
			UnityEngine.Random.InitState(seed);
			centerTransform.position = new Vector3(0f, terrainHeight, 0f);
			_expectedTerrainPositions = new HashSet<int2>();
			_activeTerrains = new Dictionary<int2, Terrain>();
			_terrainsToDestroy = new List<int2>();
			_terrainPool = new Queue<Terrain>();
			_heightmapResolution = Mathf.FloorToInt((float)terrainSize / 2f + 1f);
			_heightmapNative = new NativeArray<float>(_heightmapResolution * _heightmapResolution, Allocator.Persistent);
			_heightMap1D = new float[_heightmapResolution * _heightmapResolution];
			_heightMap = new float[_heightmapResolution, _heightmapResolution];
			_detailArrays = new List<int[,]>();
			int num = detailSettings.Length;
			for (int i = 0; i < num; i++)
			{
				int[,] array = new int[detailResolution, detailResolution];
				for (int j = 0; j < detailResolution; j++)
				{
					for (int k = 0; k < detailResolution; k++)
					{
						array[j, k] = Mathf.RoundToInt(UnityEngine.Random.Range(detailSettings[i].minMaxDensity.x, detailSettings[i].minMaxDensity.y));
					}
				}
				_detailArrays.Add(array);
			}
			int num2 = treePrefabs.Length;
			_terrainTreePrototypes = new TreePrototype[num2];
			for (int l = 0; l < num2; l++)
			{
				_terrainTreePrototypes[l] = new TreePrototype
				{
					prefab = treePrefabs[l]
				};
			}
			_treeInstances = new TreeInstance[treeCountPerTerrain];
			Update();
			SetCenterTransformStartPosition();
		}

		private void Update()
		{
			if (Vector3.Distance(_lastUpdatePosition, centerTransform.position) > updateDistance)
			{
				_lastUpdatePosition = centerTransform.position;
				GenerateExpectedTerrainPositions();
				GenerateTerrainsFromExpectedPositions();
			}
		}

		private void OnDisable()
		{
			Dispose();
		}

		private void SetCenterTransformStartPosition()
		{
			if (Physics.Raycast(centerTransform.position, Vector3.down, out var hitInfo, terrainHeight * 2f, 64))
			{
				centerTransform.position = new Vector3(0f, hitInfo.point.y + startPosOffset, 0f);
			}
		}

		private void Dispose()
		{
			if (_activeTerrains != null)
			{
				foreach (Terrain value in _activeTerrains.Values)
				{
					if ((bool)value)
					{
						if (Application.isPlaying)
						{
							UnityEngine.Object.Destroy(value.gameObject);
						}
						else
						{
							UnityEngine.Object.DestroyImmediate(value.gameObject);
						}
					}
				}
			}
			if (_heightmapNative.IsCreated)
			{
				_heightmapNative.Dispose();
			}
		}

		private void GenerateExpectedTerrainPositions()
		{
			_expectedTerrainPositions.Clear();
			int num = Mathf.FloorToInt(centerTransform.position.x / (float)terrainSize);
			int num2 = Mathf.FloorToInt(centerTransform.position.z / (float)terrainSize);
			int num3 = Mathf.CeilToInt(terrainVisibilityDistance / (float)terrainSize) + 2;
			for (int i = num - num3; i <= num + num3; i++)
			{
				for (int j = num2 - num3; j <= num2 + num3; j++)
				{
					int2 int5 = new int2(i, j);
					if (Vector3.Distance(GetTerrainIDCenter(int5, terrainSize), centerTransform.position) < terrainVisibilityDistance + (float)terrainSize)
					{
						_expectedTerrainPositions.Add(int5);
					}
				}
			}
		}

		private void GenerateTerrainsFromExpectedPositions()
		{
			_terrainsToDestroy.Clear();
			foreach (int2 key in _activeTerrains.Keys)
			{
				if (!_expectedTerrainPositions.Contains(key))
				{
					_terrainsToDestroy.Add(key);
				}
			}
			foreach (int2 item in _terrainsToDestroy)
			{
				Terrain terrain = _activeTerrains[item];
				_terrainPool.Enqueue(terrain);
				_activeTerrains.Remove(item);
				terrain.gameObject.SetActive(value: false);
			}
			foreach (int2 expectedTerrainPosition in _expectedTerrainPositions)
			{
				if (!_activeTerrains.ContainsKey(expectedTerrainPosition))
				{
					_activeTerrains.Add(expectedTerrainPosition, InitializeTerrainObject(expectedTerrainPosition));
				}
			}
		}

		private Terrain InitializeTerrainObject(int2 tid)
		{
			Vector3 terrainIDPosition = GetTerrainIDPosition(tid, terrainSize);
			Terrain terrain;
			if (_terrainPool.Count == 0)
			{
				int2 int5 = tid;
				GameObject obj = new GameObject("Terrain " + int5.ToString());
				obj.SetActive(value: false);
				obj.transform.SetParent(base.transform);
				terrain = obj.AddComponent<Terrain>();
				TerrainCollider terrainCollider = obj.AddComponent<TerrainCollider>();
				terrain.allowAutoConnect = true;
				terrain.groupingID = 1;
				terrain.drawInstanced = true;
				terrain.materialTemplate = terrainMaterial;
				terrain.gameObject.transform.position = terrainIDPosition;
				SetTerrainNeighbors(tid, terrain);
				terrain.detailObjectDensity = detailObjectDensity;
				TerrainData terrainData = (terrainCollider.terrainData = CreateTerrainData(terrainIDPosition));
				terrain.terrainData = terrainData;
				obj.layer = 6;
				SetDetailLayers(terrain);
			}
			else
			{
				terrain = _terrainPool.Dequeue();
				terrain.gameObject.transform.position = terrainIDPosition;
				GameObject obj2 = terrain.gameObject;
				int2 int5 = tid;
				obj2.name = "Terrain " + int5.ToString();
				terrain.detailObjectDensity = detailObjectDensity;
				terrain.detailObjectDistance = ((detailManager != null && detailManager.IsInitialized) ? 0f : _detailObjectDistance);
				SetTerrainNeighbors(tid, terrain);
			}
			SetHeightmapData(terrainIDPosition, terrain);
			SetTreeInstances(terrain);
			GPUITerrainBuiltin gPUITerrainBuiltin = terrain.AddOrGetComponent<GPUITerrainBuiltin>();
			gPUITerrainBuiltin.LoadTerrainData();
			terrain.gameObject.SetActive(value: true);
			if (!readDetailLayerFromTerrain)
			{
				for (int i = 0; i < detailSettings.Length; i++)
				{
					gPUITerrainBuiltin.SetDetailLayer(i, _detailArrays[i]);
				}
			}
			if (detailManager != null)
			{
				GPUITerrainAPI.AddTerrain(detailManager, gPUITerrainBuiltin);
			}
			if (treeManager != null)
			{
				GPUITerrainAPI.AddTerrain(treeManager, gPUITerrainBuiltin);
			}
			return terrain;
		}

		private TerrainData CreateTerrainData(Vector3 terrainPosition)
		{
			TerrainData obj = ((dummyTerrain != null) ? UnityEngine.Object.Instantiate(dummyTerrain) : new TerrainData());
			obj.heightmapResolution = _heightmapResolution;
			obj.baseMapResolution = _baseTextureResolution;
			obj.alphamapResolution = terrainSize;
			obj.terrainLayers = terrainLayers;
			obj.size = new Vector3(terrainSize, terrainHeight, terrainSize);
			return obj;
		}

		private void SetHeightmapData(Vector3 terrainPosition, Terrain terrain)
		{
			TerrainData terrainData = terrain.terrainData;
			new CreateHeightmapArrayJob
			{
				heightMap = _heightmapNative,
				heightMapResolution = _heightmapResolution,
				terrainPosition = terrainPosition
			}.Schedule(_heightmapResolution * _heightmapResolution, _heightmapResolution).Complete();
			_heightmapNative.CopyTo(_heightMap1D);
			Buffer.BlockCopy(_heightMap1D, 0, _heightMap, 0, 4 * _heightmapResolution * _heightmapResolution);
			terrainData.SetHeights(0, 0, _heightMap);
		}

		private void SetTerrainNeighbors(int2 tid, Terrain terrain)
		{
			_activeTerrains.TryGetValue(new int2(tid.x - 1, tid.y), out var value);
			_activeTerrains.TryGetValue(new int2(tid.x, tid.y + 1), out var value2);
			_activeTerrains.TryGetValue(new int2(tid.x + 1, tid.y), out var value3);
			_activeTerrains.TryGetValue(new int2(tid.x, tid.y - 1), out var value4);
			terrain.SetNeighbors(value, value2, value3, value4);
		}

		private void SetDetailLayers(Terrain terrain)
		{
			int num = detailSettings.Length;
			if (num == 0)
			{
				return;
			}
			TerrainData terrainData = terrain.terrainData;
			terrainData.SetDetailScatterMode(DetailScatterMode.InstanceCountMode);
			terrainData.SetDetailResolution(detailResolution, 16);
			terrain.detailObjectDistance = ((detailManager != null && detailManager.IsInitialized) ? 0f : _detailObjectDistance);
			DetailPrototype[] array = new DetailPrototype[num];
			for (int i = 0; i < num; i++)
			{
				if (detailSettings[i].texture != null)
				{
					array[i] = new DetailPrototype
					{
						noiseSeed = UnityEngine.Random.Range(1, 10000),
						prototypeTexture = detailSettings[i].texture,
						usePrototypeMesh = false,
						renderMode = DetailRenderMode.Grass,
						healthyColor = detailSettings[i].healthyColor,
						dryColor = detailSettings[i].dryColor,
						useInstancing = false,
						alignToGround = 0.5f,
						minWidth = detailSettings[i].minMaxScale.x,
						maxWidth = detailSettings[i].minMaxScale.y,
						minHeight = detailSettings[i].minMaxScale.x,
						maxHeight = detailSettings[i].minMaxScale.y,
						useDensityScaling = true
					};
				}
				else
				{
					array[i] = new DetailPrototype
					{
						noiseSeed = UnityEngine.Random.Range(1, 10000),
						prototype = detailSettings[i].prefab,
						usePrototypeMesh = true,
						renderMode = DetailRenderMode.VertexLit,
						healthyColor = detailSettings[i].healthyColor,
						dryColor = detailSettings[i].dryColor,
						useInstancing = true,
						alignToGround = 0.5f,
						minWidth = detailSettings[i].minMaxScale.x,
						maxWidth = detailSettings[i].minMaxScale.y,
						minHeight = detailSettings[i].minMaxScale.x,
						maxHeight = detailSettings[i].minMaxScale.y,
						useDensityScaling = true
					};
				}
			}
			terrainData.detailPrototypes = array;
			for (int j = 0; j < num; j++)
			{
				terrainData.SetDetailLayer(0, 0, j, _detailArrays[j]);
			}
		}

		private void SetTreeInstances(Terrain terrain)
		{
			int num = treePrefabs.Length;
			if (num != 0 && treeCountPerTerrain > 0)
			{
				TerrainData terrainData = terrain.terrainData;
				Vector3 position = terrain.GetPosition();
				terrainData.treePrototypes = _terrainTreePrototypes;
				for (int i = 0; i < treeCountPerTerrain; i++)
				{
					Vector3 vector = new Vector3(UnityEngine.Random.value, 0f, UnityEngine.Random.value);
					vector.y = terrain.SampleHeight(vector * terrainSize + position) / terrainHeight;
					float num2 = UnityEngine.Random.Range(treeSizeRange.x, treeSizeRange.y);
					_treeInstances[i] = new TreeInstance
					{
						position = vector,
						rotation = UnityEngine.Random.value * 360f,
						heightScale = num2,
						widthScale = num2,
						color = Color.white,
						prototypeIndex = UnityEngine.Random.Range(0, num)
					};
				}
				terrainData.treeInstances = _treeInstances;
			}
		}

		private Vector3 GetTerrainIDPosition(int2 tid, int terrainSize)
		{
			return new Vector3(tid.x * terrainSize, 0f, tid.y * terrainSize);
		}

		private Vector3 GetTerrainIDCenter(int2 tid, int terrainSize)
		{
			return new Vector3((float)(tid.x * terrainSize) + (float)terrainSize / 2f, 0f, (float)(tid.y * terrainSize) + (float)terrainSize / 2f);
		}

		public void SetDetailObjectDensity(float density)
		{
			detailObjectDensity = density;
			if (_activeTerrains != null)
			{
				foreach (Terrain value in _activeTerrains.Values)
				{
					value.detailObjectDensity = density;
				}
			}
			if (detailManager != null)
			{
				detailManager.RequireUpdate();
			}
		}

		public void SetDetailObjectDistance(float distance)
		{
			_detailObjectDistance = distance;
			if (!(detailManager != null))
			{
				return;
			}
			detailManager.SetDetailObjectDistance(distance);
			if (detailManager.IsInitialized || _activeTerrains == null)
			{
				return;
			}
			foreach (Terrain value in _activeTerrains.Values)
			{
				value.detailObjectDistance = distance;
			}
		}
	}
}
