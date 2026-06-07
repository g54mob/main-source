using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AwesomeTechnologies.VegetationSystem;
using DV.Utils;
using JBooth.MicroSplat;
using UnityEngine;
using UnityEngine.Rendering;

namespace DV.TerrainSystem
{
	public class TerrainGrid : SingletonBehaviour<TerrainGrid>
	{
		public enum LoadingStatus
		{
			Unloaded = 0,
			LoadingInProgress = 1,
			Loaded = 2,
			Displayed = 3,
			Errored = 4
		}

		public class GridCell
		{
			public TerrainInfo terrainInfo;

			public Terrain terrain;

			public Vector2Int coord;

			public TerrainInfoLoadWrapper wrapper;

			private TerrainsInfoAssetBundleLoader loader;

			private List<Terrain> terrainPool;

			private bool drawInstanced;

			public GridCell(Vector2Int coord, string worldName, TerrainsInfoAssetBundleLoader loader, List<Terrain> terrainPool, bool drawInstanced)
			{
				this.coord = coord;
				this.terrainPool = terrainPool;
				this.loader = loader;
				this.drawInstanced = drawInstanced;
				terrainInfo = default(TerrainInfo);
			}

			public void Load()
			{
				if (wrapper == null)
				{
					wrapper = loader.Load(coord);
					TerrainInfoLoadWrapper terrainInfoLoadWrapper = wrapper;
					terrainInfoLoadWrapper.LoadingFinished = (Action<TerrainInfo>)Delegate.Combine(terrainInfoLoadWrapper.LoadingFinished, new Action<TerrainInfo>(OnLoadingFinished));
				}
				else
				{
					UnityEngine.Debug.LogWarning($"Already loading '{coord}'");
				}
			}

			public void Unload()
			{
				HideTerrain();
				if (wrapper != null)
				{
					TerrainInfoLoadWrapper terrainInfoLoadWrapper = wrapper;
					terrainInfoLoadWrapper.LoadingFinished = (Action<TerrainInfo>)Delegate.Remove(terrainInfoLoadWrapper.LoadingFinished, new Action<TerrainInfo>(OnLoadingFinished));
					wrapper = null;
				}
				terrainInfo = default(TerrainInfo);
				loader.Unload(coord);
			}

			public void DisplayTerrain(Vector3 worldPosition)
			{
				if ((bool)terrain)
				{
					UnityEngine.Debug.LogWarning("GridCell is already displayed");
					return;
				}
				if (terrainInfo.terrainData == null)
				{
					UnityEngine.Debug.LogError(string.Format("{0} at '{1}' can't be displayed, it's not loaded yet", "GridCell", coord));
					return;
				}
				terrain = terrainPool[terrainPool.Count - 1];
				terrainPool.RemoveAt(terrainPool.Count - 1);
				terrain.transform.position = worldPosition;
				terrain.terrainData = terrainInfo.terrainData;
				terrain.GetComponent<TerrainCollider>().terrainData = terrainInfo.terrainData;
				terrain.drawInstanced = drawInstanced;
				terrain.allowAutoConnect = true;
				terrain.gameObject.SetActive(value: true);
			}

			public LoadingStatus GetStatus()
			{
				if (wrapper == null)
				{
					return LoadingStatus.Unloaded;
				}
				if (wrapper != null && terrainInfo.terrainData == null)
				{
					return LoadingStatus.LoadingInProgress;
				}
				if (wrapper != null && terrainInfo.terrainData != null && terrain == null)
				{
					return LoadingStatus.Loaded;
				}
				if (wrapper != null && terrainInfo.terrainData != null && terrain != null)
				{
					return LoadingStatus.Displayed;
				}
				throw new InvalidOperationException("Unexpected status");
			}

			private void OnLoadingFinished(TerrainInfo info)
			{
				terrainInfo = info;
				TerrainInfoLoadWrapper terrainInfoLoadWrapper = wrapper;
				terrainInfoLoadWrapper.LoadingFinished = (Action<TerrainInfo>)Delegate.Remove(terrainInfoLoadWrapper.LoadingFinished, new Action<TerrainInfo>(OnLoadingFinished));
			}

			private void HideTerrain()
			{
				if ((bool)terrain)
				{
					terrain.gameObject.SetActive(value: false);
					terrainPool.Add(terrain);
					terrain.terrainData = null;
					terrain.GetComponent<TerrainCollider>().terrainData = null;
					terrain = null;
				}
			}
		}

		public int loadingRingSize = 1;

		public Transform trackingReference;

		public string worldNameToLoad;

		public bool addToVegetationStudio = true;

		[Header("Use MicroSplat shader (optional)")]
		public Material microSplatMaterialTemplate;

		public MicroSplatPropData microSplatPropData;

		public MicroSplatKeywords microSplatKeywords;

		[NonSerialized]
		public List<GameObject> generatedTerrains;

		[Header("Terrain settings")]
		public float pixelError = 10f;

		public bool drawInstanced;

		[Layer]
		public int terrainLayer;

		[Header("Debug")]
		public int vegetationReloadWaitFrames = 2;

		public int maxConcurrentLoads = 3;

		private TerrainsInfoAssetBundleLoader loader;

		private Vector2Int? currentCoord;

		private Vector2Int? targetCoord;

		private GridCell[] grid;

		private HashSet<GridCell> toLoad = new HashSet<GridCell>();

		private Queue<GridCell> queue = new Queue<GridCell>();

		private List<GridCell> inProgress = new List<GridCell>();

		private HashSet<GridCell> tempCells = new HashSet<GridCell>();

		private List<Terrain> terrainPool;

		private IEnumerator worldUpdateCoro;

		private Dictionary<LoadingStatus, Color> colors = new Dictionary<LoadingStatus, Color>
		{
			{
				LoadingStatus.Unloaded,
				new Color(0.4f, 0.4f, 0.4f, 0.2f)
			},
			{
				LoadingStatus.LoadingInProgress,
				Color.yellow
			},
			{
				LoadingStatus.Loaded,
				Color.cyan
			},
			{
				LoadingStatus.Displayed,
				Color.green
			},
			{
				LoadingStatus.Errored,
				Color.red
			}
		};

		public Vector2Int? currentCenterCoord => currentCoord;

		public int TerrainsPerAxis => loader.TerrainsPerAxis;

		public float TerrainSizeInWorld => loader.TerrainSizeInWorld;

		public int LoadingRegionSize { get; private set; }

		public bool IsInitialized { get; private set; }

		public event Action TerrainsMoved;

		public event Action TerrainsAboutToBeMoved;

		public static event TerrainDataLoadedStateChangedDelegate TerrainDataLoaded;

		public static event TerrainDataLoadedStateChangedDelegate TerrainDataAboutToBeUnloaded;

		public static event Action Initialized;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			Application.backgroundLoadingPriority = ThreadPriority.Low;
			loader = new TerrainsInfoAssetBundleLoader(worldNameToLoad, base.StartCoroutine);
			LoadingRegionSize = 2 * loadingRingSize + 1;
			generatedTerrains = new List<GameObject>(LoadingRegionSize * LoadingRegionSize);
			terrainPool = new List<Terrain>(LoadingRegionSize * LoadingRegionSize);
			grid = new GridCell[TerrainsPerAxis * TerrainsPerAxis];
			for (int i = 0; i < TerrainsPerAxis; i++)
			{
				for (int j = 0; j < TerrainsPerAxis; j++)
				{
					int num = ToIndex(i, j);
					grid[num] = new GridCell(new Vector2Int(i, j), worldNameToLoad, loader, terrainPool, drawInstanced);
				}
			}
			Material materialTemplate = (microSplatMaterialTemplate ? null : new Material(Shader.Find("Nature/Terrain/Standard")));
			for (int k = 0; k < generatedTerrains.Capacity; k++)
			{
				GameObject gameObject = new GameObject($"terrain_{k}");
				gameObject.SetActive(value: false);
				gameObject.transform.SetParent(base.transform);
				gameObject.layer = terrainLayer;
				Terrain terrain = gameObject.AddComponent<Terrain>();
				gameObject.AddComponent<TerrainCollider>();
				terrain.heightmapPixelError = pixelError;
				terrain.basemapDistance = 0f;
				generatedTerrains.Add(gameObject);
				terrainPool.Add(terrain);
				if (addToVegetationStudio)
				{
					UnityTerrain unityTerrain = gameObject.AddComponent<UnityTerrain>();
					unityTerrain.enabled = false;
					unityTerrain.AutoAddToVegegetationSystem = true;
					unityTerrain.TerrainPosition = unityTerrain.transform.localPosition;
				}
				if ((bool)microSplatMaterialTemplate)
				{
					MicroSplatTerrain microSplatTerrain = gameObject.AddComponent<MicroSplatTerrain>();
					microSplatTerrain.templateMaterial = microSplatMaterialTemplate;
					microSplatTerrain.propData = microSplatPropData;
					microSplatTerrain.keywordSO = microSplatKeywords;
					gameObject.AddComponent<MicroSplatVisibilityHack>();
				}
				else
				{
					terrain.materialTemplate = materialTemplate;
				}
			}
			IsInitialized = true;
			TerrainGrid.Initialized?.Invoke();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		public bool IsLoadingInProgress()
		{
			if (queue.Count == 0 && inProgress.Count == 0)
			{
				if (targetCoord.HasValue)
				{
					Vector2Int? vector2Int = currentCoord;
					Vector2Int? vector2Int2 = targetCoord;
					if (vector2Int.HasValue != vector2Int2.HasValue)
					{
						return true;
					}
					if (!vector2Int.HasValue)
					{
						return false;
					}
					return vector2Int.GetValueOrDefault() != vector2Int2.GetValueOrDefault();
				}
				return false;
			}
			return true;
		}

		public Terrain GetLoadedTerrainAt(Vector3 worldPosition)
		{
			return GetLoadedTerrainAt(ToGridCoords(worldPosition));
		}

		public Terrain GetLoadedTerrainAt(Vector2Int gridCoord)
		{
			if (!IsInTargetRegion(gridCoord))
			{
				return null;
			}
			return grid[ToIndex(gridCoord)].terrain;
		}

		public bool IsInLoadedCell(Vector3 worldPosition)
		{
			Vector2Int vector2Int = ToGridCoords(worldPosition);
			if (!IsInTargetRegion(vector2Int))
			{
				return false;
			}
			return grid[ToIndex(vector2Int)].GetStatus() == LoadingStatus.Displayed;
		}

		public bool IsInLoadedRegion(Vector3 worldPosition)
		{
			if (!IsLoadingInProgress())
			{
				return IsInTargetRegion(worldPosition);
			}
			return false;
		}

		public bool IsInTargetRegion(Vector3 worldPosition)
		{
			if (NumberUtil.AnyInfinityMinMaxNaN(worldPosition))
			{
				return false;
			}
			return IsInTargetRegion(ToGridCoords(worldPosition));
		}

		public bool IsInTargetRegion(Vector2Int gridCoord)
		{
			if (gridCoord.x == int.MinValue || gridCoord.x == int.MaxValue || gridCoord.y == int.MinValue || gridCoord.y == int.MaxValue || !targetCoord.HasValue)
			{
				return false;
			}
			if (Math.Abs(gridCoord.x - targetCoord.Value.x) <= loadingRingSize && Math.Abs(gridCoord.y - targetCoord.Value.y) <= loadingRingSize)
			{
				return IsValidCoord(gridCoord);
			}
			return false;
		}

		public Vector2Int ToGridCoords(Vector3 worldPosition)
		{
			Vector3 vector = base.transform.InverseTransformPoint(worldPosition);
			return new Vector2Int(Mathf.FloorToInt(vector.x / TerrainSizeInWorld), Mathf.FloorToInt(vector.z / TerrainSizeInWorld));
		}

		private bool IsValidCoord(Vector2Int coord)
		{
			if (coord.x >= 0 && coord.x < TerrainsPerAxis && coord.y >= 0)
			{
				return coord.y < TerrainsPerAxis;
			}
			return false;
		}

		public Vector3 ToWorldPosition(Vector2Int gridCoord)
		{
			return new Vector3((float)gridCoord.x * TerrainSizeInWorld, 0f, (float)gridCoord.y * TerrainSizeInWorld) + base.transform.position;
		}

		private void SetTargetCoord(int gridX, int gridY)
		{
			SetTargetCoord(new Vector2Int(gridX, gridY));
		}

		private void SetTargetCoord(Vector2Int gridCoord)
		{
			if (targetCoord.HasValue && targetCoord.Value == gridCoord)
			{
				return;
			}
			targetCoord = gridCoord;
			toLoad.Clear();
			GetCellsInRegion(targetCoord.Value, toLoad);
			if (currentCoord.HasValue)
			{
				GetCellsInRegion(currentCoord.Value, toLoad);
			}
			GridCell[] array = grid;
			foreach (GridCell gridCell in array)
			{
				if (gridCell.GetStatus() != LoadingStatus.Unloaded && !toLoad.Contains(gridCell))
				{
					gridCell.Unload();
					inProgress.Remove(gridCell);
				}
				if (gridCell.GetStatus() == LoadingStatus.Unloaded && toLoad.Contains(gridCell) && !queue.Contains(gridCell))
				{
					queue.Enqueue(gridCell);
				}
			}
		}

		private void Update()
		{
			if (worldUpdateCoro != null && !worldUpdateCoro.MoveNext())
			{
				worldUpdateCoro = null;
			}
			if (worldUpdateCoro != null || trackingReference == null)
			{
				return;
			}
			SetTargetCoord(ToGridCoords(trackingReference.position));
			if (queue.Count == 0 && currentCoord == targetCoord)
			{
				return;
			}
			for (int num = inProgress.Count - 1; num >= 0; num--)
			{
				if (inProgress[num].terrainInfo.terrainData != null)
				{
					inProgress.RemoveAt(num);
				}
			}
			while (inProgress.Count < maxConcurrentLoads && queue.Count > 0)
			{
				GridCell gridCell = queue.Dequeue();
				if (toLoad.Contains(gridCell))
				{
					inProgress.Add(gridCell);
					gridCell.Load();
				}
			}
			if (queue.Count == 0 && inProgress.Count == 0)
			{
				worldUpdateCoro = UpdateWorld();
			}
		}

		private IEnumerator UpdateWorld()
		{
			if (queue.Count != 0 || inProgress.Count != 0)
			{
				throw new InvalidOperationException("Only call this when loading is not in progress");
			}
			tempCells.Clear();
			GetActiveCellsOutsideRegion(targetCoord.Value, tempCells);
			foreach (GridCell tempCell in tempCells)
			{
				if (tempCell.GetStatus() != LoadingStatus.Displayed)
				{
					continue;
				}
				UnityTerrain component = tempCell.terrain.GetComponent<UnityTerrain>();
				if ((bool)component)
				{
					component.enabled = false;
					for (int i = 0; i < vegetationReloadWaitFrames; i++)
					{
						yield return null;
					}
				}
			}
			this.TerrainsAboutToBeMoved?.Invoke();
			foreach (GridCell tempCell2 in tempCells)
			{
				if (tempCell2.GetStatus() == LoadingStatus.Loaded || tempCell2.GetStatus() == LoadingStatus.Displayed)
				{
					TerrainGrid.TerrainDataAboutToBeUnloaded?.Invoke(tempCell2.terrainInfo.terrainData, tempCell2.coord);
				}
				tempCell2.Unload();
			}
			tempCells.Clear();
			GetCellsInRegion(targetCoord.Value, tempCells);
			foreach (GridCell tempCell3 in tempCells)
			{
				if (tempCell3.GetStatus() != LoadingStatus.Displayed)
				{
					tempCell3.DisplayTerrain(ToWorldPosition(tempCell3.coord));
					TerrainGrid.TerrainDataLoaded?.Invoke(tempCell3.terrainInfo.terrainData, tempCell3.coord);
				}
			}
			currentCoord = targetCoord;
			this.TerrainsMoved?.Invoke();
			foreach (GridCell tempCell4 in tempCells)
			{
				UnityTerrain component2 = tempCell4.terrain.GetComponent<UnityTerrain>();
				if ((bool)component2)
				{
					component2.TerrainPosition = component2.transform.localPosition;
					component2.enabled = true;
					for (int i = 0; i < vegetationReloadWaitFrames; i++)
					{
						yield return null;
					}
				}
			}
			worldUpdateCoro = null;
		}

		private void GetActiveCellsOutsideRegion(Vector2Int ringCenterCoord, HashSet<GridCell> toPopulate)
		{
			GridCell[] array = grid;
			foreach (GridCell gridCell in array)
			{
				bool flag = Math.Abs(gridCell.coord.x - ringCenterCoord.x) <= loadingRingSize && Math.Abs(gridCell.coord.y - ringCenterCoord.y) <= loadingRingSize;
				if (gridCell.wrapper != null && !flag)
				{
					toPopulate.Add(gridCell);
				}
			}
		}

		private void GetCellsInRegion(Vector2Int ringCenterCoord, HashSet<GridCell> toPopulate)
		{
			for (int i = ringCenterCoord.x - loadingRingSize; i <= ringCenterCoord.x + loadingRingSize; i++)
			{
				for (int j = ringCenterCoord.y - loadingRingSize; j <= ringCenterCoord.y + loadingRingSize; j++)
				{
					if (i >= 0 && i < TerrainsPerAxis && j >= 0 && j < TerrainsPerAxis)
					{
						toPopulate.Add(grid[ToIndex(i, j)]);
					}
				}
			}
		}

		private int ToIndex(Vector2Int coord)
		{
			return ToIndex(coord.x, coord.y);
		}

		private int ToIndex(int gridX, int gridY)
		{
			return gridY * TerrainsPerAxis + gridX;
		}

		[Conditional("LOGGING")]
		private static void Log(string msg, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.Log(msg, context);
		}

		[Conditional("LOGGING")]
		private static void LogWarning(string msg, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogWarning(msg, context);
		}

		[Conditional("LOGGING")]
		private static void LogError(string msg, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogError(msg, context);
		}

		private void OnDrawGizmos()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			Gizmos.color = Color.cyan;
			float terrainSizeInWorld = TerrainSizeInWorld;
			Vector3 vector = new Vector3(TerrainsPerAxis, 0f, TerrainsPerAxis) * terrainSizeInWorld;
			Gizmos.DrawWireCube(base.transform.position + vector / 2f, vector);
			Vector3 size = new Vector3(terrainSizeInWorld, 0f, terrainSizeInWorld);
			GridCell[] array = grid;
			foreach (GridCell gridCell in array)
			{
				LoadingStatus status = gridCell.GetStatus();
				Gizmos.color = colors[status];
				if (status == LoadingStatus.Unloaded)
				{
					float y = -0.1f;
					Gizmos.DrawWireCube(base.transform.position + new Vector3((float)gridCell.coord.x * terrainSizeInWorld + terrainSizeInWorld / 2f, y, (float)gridCell.coord.y * terrainSizeInWorld + terrainSizeInWorld / 2f), size);
					continue;
				}
				Gizmos.DrawWireCube(base.transform.position + new Vector3((float)gridCell.coord.x * terrainSizeInWorld + terrainSizeInWorld / 2f, 0f, (float)gridCell.coord.y * terrainSizeInWorld + terrainSizeInWorld / 2f), size);
				if (status == LoadingStatus.LoadingInProgress || status == LoadingStatus.Loaded)
				{
					float num = 0.5f * terrainSizeInWorld;
					Gizmos.DrawCube(base.transform.position + new Vector3((float)gridCell.coord.x * terrainSizeInWorld + terrainSizeInWorld / 2f, 0f, (float)gridCell.coord.y * terrainSizeInWorld + num / 2f), new Vector3(terrainSizeInWorld, 0f, num));
				}
			}
			if (currentCoord.HasValue && targetCoord.HasValue && currentCoord.Value == targetCoord.Value)
			{
				DrawLoadRegion(currentCoord.Value, Color.green, base.transform);
				return;
			}
			if (currentCoord.HasValue)
			{
				DrawLoadRegion(currentCoord.Value, Color.yellow, base.transform);
			}
			if (targetCoord.HasValue)
			{
				DrawLoadRegion(targetCoord.Value, Color.red, base.transform);
			}
		}

		private void DrawLoadRegion(Vector2Int gridCoord, Color color, Transform transform)
		{
			Gizmos.color = color;
			float num = loadingRingSize * 2 + 1;
			float terrainSizeInWorld = TerrainSizeInWorld;
			Gizmos.DrawWireCube(size: new Vector3(num * terrainSizeInWorld, 0f, num * terrainSizeInWorld), center: transform.position + new Vector3((float)gridCoord.x * terrainSizeInWorld + terrainSizeInWorld / 2f, 0f, (float)gridCoord.y * terrainSizeInWorld + terrainSizeInWorld / 2f));
		}

		[ContextMenu("Disable shadow casting")]
		public void DisableShadows()
		{
			Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].shadowCastingMode = ShadowCastingMode.Off;
			}
		}

		[ContextMenu("Enable shadow casting")]
		public void EnableShadows()
		{
			Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].shadowCastingMode = ShadowCastingMode.TwoSided;
			}
		}
	}
}
