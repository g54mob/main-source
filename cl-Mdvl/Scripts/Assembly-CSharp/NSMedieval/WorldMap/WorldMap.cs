using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap.Caravan;
using Repository.Map;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.SceneManagement;

namespace NSMedieval.WorldMap
{
	public class WorldMap : MonoSingleton<WorldMap>
	{
		private const float MinDistanceBetweenVillages = 3.9f;

		private const float HeightMultiplier = 3.8f;

		private const string HomeSceneName = "HomeScene";

		private const string MainSceneName = "MainScene";

		[SerializeField]
		private Camera mainSceneWorldCamera;

		[SerializeField]
		private Camera homeSceneWorldCamera;

		[SerializeField]
		private GameObject viewPrefab;

		[SerializeField]
		private GameObject heightmapContent;

		[SerializeField]
		private int seed;

		[SerializeField]
		private GameObject homeSceneContent;

		[SerializeField]
		private GameObject mainSceneContent;

		[SerializeField]
		private GameObject homeScenePossibleVillagePlaceMarker;

		[SerializeField]
		private GameObject worldMapBorderObject;

		private System.Random random;

		private WorldMapSettings settings;

		[NonSerialized]
		private WorldMapData data;

		private IEnumerator generateMapHomeSceneCoroutine;

		[NonSerialized]
		private RenderParams renderParams;

		[NonSerialized]
		private readonly List<KeyValuePair<Matrix4x4, Mesh>> terrain = new List<KeyValuePair<Matrix4x4, Mesh>>();

		private bool isWorldMapVisible;

		private List<string> selectableMapTypes;

		private List<string> allowedMapTypes;

		private List<Vector2Int> possibleVillagePositions;

		private Material viewPrefabMaterial;

		private Material terrainBorderMaterial;

		private Texture2D mapTypesTexture;

		private Texture2D heightmapTexture;

		public WorldMapMarkerManager MarkerManager { get; private set; }

		public WorldMapSettings Settings => settings;

		public List<string> SelectableMapTypes => selectableMapTypes;

		private Texture2D HeightmapTexture
		{
			get
			{
				CheckCreateTexture(ref heightmapTexture, Data.WorldMapResolution);
				return heightmapTexture;
			}
		}

		private Texture2D MapTypesTexture
		{
			get
			{
				CheckCreateTexture(ref mapTypesTexture, Data.WorldMapResolution);
				return mapTypesTexture;
			}
		}

		private Material TerrainMaterial => viewPrefabMaterial;

		private Material TerrainBorderMaterial => terrainBorderMaterial;

		public List<Vector2Int> PossibleVillagePositions => possibleVillagePositions;

		public Camera MainSceneWorldCamera => mainSceneWorldCamera;

		public Camera HomeSceneWorldCamera => homeSceneWorldCamera;

		public GameObject HomeScenePossibleVillagePlaceMarker => homeScenePossibleVillagePlaceMarker;

		public WorldMapData Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
			}
		}

		public int Seed => seed;

		public GameObject HeightmapContent => heightmapContent;

		public bool IsWorldMapVisible => isWorldMapVisible;

		public void SetHomeSceneContentVisible(bool visible)
		{
			homeSceneContent.SetActive(visible);
		}

		public void SetMainSceneContentVisible(bool visible)
		{
			mainSceneContent.SetActive(visible);
		}

		public Vector3 ToWorldMapSpace(Vector2 gridPosition)
		{
			return new Vector3(gridPosition.x, GetHeightAt((int)gridPosition.x, (int)gridPosition.y), gridPosition.y);
		}

		public Vector3 ToWorldMapSpace(Vector2Int gridPosition)
		{
			return new Vector3(gridPosition.x, GetHeightAt(gridPosition), gridPosition.y);
		}

		private void InitRandom()
		{
			random = new System.Random(seed);
		}

		public void GenerateAll()
		{
			data = new WorldMapData();
			InitRandom();
			CreateHeightmap();
			HeightmapToMapTypes();
			CreatePossibleVillagePositions();
			CreateOutputTexture();
			PrepareTerrainRenderData();
		}

		private void CheckCreateTexture(ref Texture2D texture, Vector2Int resolution)
		{
			if (texture == null)
			{
				texture = new Texture2D(resolution.x, resolution.y, TextureFormat.RGBAHalf, mipChain: false);
			}
			else if (texture.width != resolution.x || texture.height != resolution.y)
			{
				texture.Reinitialize(resolution.x, resolution.y);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (!(this == null))
			{
				MarkerManager = new WorldMapMarkerManager(this);
			}
		}

		private void OnLoaded()
		{
			MarkerManager.OnLoaded();
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			if (!currentVillageData.IsSecondMap || currentVillageData.WorldMapPlace != null)
			{
				return;
			}
			Log.Info("[Autofix] World map place is null while in second map, spawning a new puzzle loot stash marker to try and save the situation", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMap.cs");
			using PooledList<string> mapIds = ListPool<string>.GetJanitor(Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetSaves(SecondMapType.LootStash).First((SecondMapSaveInfo lootStash) => !lootStash.HasHostiles).Id);
			WorldMapMarkerPlace worldMapMarkerPlace = MapPlaceGenerator.SpawnMarker(null, new IntRange(9999998, 9999999), new IntRange(1, 100), mapIds, "general_loot_stash", "StashPlaceMarker");
			if (currentVillageData.WorldMapPlaceReference is WorldMapMarkerReference worldMapMarkerReference && !MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerExists(worldMapMarkerReference.Id))
			{
				worldMapMarkerPlace.DebugSetId(worldMapMarkerReference.Id);
			}
			currentVillageData.SetWorldMapPlaceReference(worldMapMarkerPlace.CreateReference());
			CaravanInstance caravanAtOrTravellingTo = CaravanManager.GetCaravanAtOrTravellingTo(worldMapMarkerPlace);
			if (caravanAtOrTravellingTo != null)
			{
				worldMapMarkerPlace.CaravanId = caravanAtOrTravellingTo.UniqueId;
				worldMapMarkerPlace.Position = new Vector2Int(Mathf.RoundToInt(caravanAtOrTravellingTo.StartGridPosition.x), Mathf.RoundToInt(caravanAtOrTravellingTo.StartGridPosition.y));
				caravanAtOrTravellingTo.ClearEventContext();
				caravanAtOrTravellingTo.StartTripHome();
				caravanAtOrTravellingTo.SetCaravanState(CaravanState.Arrived);
				caravanAtOrTravellingTo.SetEventContext(new LootStashContext(caravanAtOrTravellingTo));
			}
		}

		private void OnSaveLoaded(VillageSaveData saveData)
		{
			data = saveData.WorldMapData;
		}

		private void Start()
		{
			if (MonoSingleton<WorldMap>.IsInstantiated() && !(this != MonoSingleton<WorldMap>.Instance))
			{
				selectableMapTypes = new List<string>();
				possibleVillagePositions = new List<Vector2Int>();
				viewPrefabMaterial = new Material(viewPrefab.GetComponent<MeshRenderer>().sharedMaterial);
				terrainBorderMaterial = new Material(worldMapBorderObject.GetComponent<MeshRenderer>().sharedMaterial);
				if (worldMapBorderObject != null)
				{
					worldMapBorderObject.GetComponent<MeshRenderer>().sharedMaterial = terrainBorderMaterial;
				}
				settings = Repository<WorldMapSettingsData, WorldMapSettings>.Instance.GetData<WorldMapSettings>();
				SetAllowedMapTypes(settings.StartMapTypes);
				SceneManager.activeSceneChanged += ActiveSceneChanged;
				MonoSingleton<WorldMapController>.Instance.FinalizeWorldMapSettingsEvent += OnFinalizeWorldMapSettings;
				MonoSingleton<WorldMapController>.Instance.WorldMapLoadedFromMainSceneEvent += OnLoaded;
				MonoSingleton<GlobalSaveController>.Instance.OnSaveLoaded += OnSaveLoaded;
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			}
		}

		private void SetAllowedMapTypes(List<string> allowedMapTypes)
		{
			this.allowedMapTypes = new List<string>(allowedMapTypes);
		}

		protected override void OnDestroy()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			SceneManager.activeSceneChanged -= ActiveSceneChanged;
			terrain?.Clear();
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.FinalizeWorldMapSettingsEvent -= OnFinalizeWorldMapSettings;
				MonoSingleton<WorldMapController>.Instance.WorldMapLoadedFromMainSceneEvent -= OnLoaded;
				MonoSingleton<GlobalSaveController>.Instance.OnSaveLoaded -= OnSaveLoaded;
			}
			DestroyGeneratedContent();
			if (viewPrefabMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(viewPrefabMaterial);
			}
			if (terrainBorderMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(terrainBorderMaterial);
			}
			MarkerManager?.Dispose();
			MarkerManager = null;
			base.OnDestroy();
		}

		private void OnPreCullCallback(Camera cam)
		{
			if (MonoSingleton<WorldMap>.IsInstantiated() && (!(cam != mainSceneWorldCamera) || !(cam != homeSceneWorldCamera)))
			{
				RenderWorldMap();
			}
		}

		private void ActiveSceneChanged(Scene from, Scene to)
		{
			bool flag = to.name.Equals("HomeScene");
			bool flag2 = to.name.Equals("MainScene");
			homeSceneContent.SetActive(flag);
			mainSceneContent.SetActive(flag2);
			if (flag)
			{
				heightmapContent.SetActive(value: false);
				MonoSingleton<WorldMap>.Instance.SetHomeSceneContentVisible(visible: false);
			}
			if (flag2)
			{
				heightmapContent.SetActive(isWorldMapVisible);
				mainSceneWorldCamera.gameObject.SetActive(isWorldMapVisible);
			}
		}

		public void SetWorldMapVisible(bool isWorldMapVisible)
		{
			this.isWorldMapVisible = isWorldMapVisible;
			heightmapContent.SetActive(this.isWorldMapVisible);
			mainSceneWorldCamera.gameObject.SetActive(this.isWorldMapVisible);
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySet(this.isWorldMapVisible);
			MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false);
			MonoSingleton<SelectionManager>.Instance.ResetSelectionTool();
			MonoSingleton<TooltipController>.Instance.RefreshTooltip(new List<string>());
			if (this.isWorldMapVisible)
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(HideWorldMap, base.gameObject);
			}
			else
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(HideWorldMap, base.gameObject);
			}
		}

		public void JumpToPlace(WorldMapPlace place)
		{
			if (!GlobalSaveController.CurrentVillageData.MapTableBuilt)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("error_build_map_table".ToLocalized());
				return;
			}
			SetWorldMapVisible(isWorldMapVisible: true);
			MonoSingleton<WorldMapController>.Instance.PlaceClicked(place);
		}

		public void JumpToCaravan(CaravanInstance caravan)
		{
			if (!GlobalSaveController.CurrentVillageData.MapTableBuilt)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("error_build_map_table".ToLocalized());
				return;
			}
			SetWorldMapVisible(isWorldMapVisible: true);
			MonoSingleton<WorldMapController>.Instance.CaravanClicked(caravan);
		}

		private void HideWorldMap()
		{
			MonoSingleton<TooltipController>.Instance.Hide();
			SetWorldMapVisible(isWorldMapVisible: false);
		}

		private void HeightmapToMapTypes()
		{
			data.MapTypes = new byte[data.WorldMapResolution.x, data.WorldMapResolution.y];
			for (int i = 0; i < data.WorldMapResolution.x; i++)
			{
				for (int j = 0; j < data.WorldMapResolution.y; j++)
				{
					float height = data.Heightmap[i, j];
					WorldMapCellType cellTypeForHeight = settings.GetCellTypeForHeight(height);
					data.MapTypes[i, j] = (byte)cellTypeForHeight.Id;
				}
			}
		}

		private void OnFinalizeWorldMapSettings()
		{
			data.OnNewGameStarted();
		}

		private void CreatePossibleVillagePositions()
		{
			System.Random random = new System.Random(Seed);
			List<Vector2Int> list = new List<Vector2Int>();
			Vector2 vector = new Vector2((float)data.WorldMapResolution.x / 2f, (float)data.WorldMapResolution.y / 2f);
			float num = data.WorldMapResolution.magnitude * 0.226f;
			Vector2 vector2 = default(Vector2);
			Dictionary<string, List<Vector2Int>> dictionary = allowedMapTypes.ToDictionary((string mapType) => mapType, (string mapType) => new List<Vector2Int>());
			bool flag = false;
			vector2.x = 0f;
			while (vector2.x < (float)data.WorldMapResolution.x)
			{
				vector2.y = 0f;
				while (vector2.y < (float)data.WorldMapResolution.y)
				{
					if ((vector - vector2).magnitude <= num)
					{
						Vector2Int gridPosition = new Vector2Int((int)vector2.x, (int)vector2.y);
						list.Add(gridPosition);
						string mapTypeName = GetMapTypeName(in gridPosition);
						if (dictionary.ContainsKey(mapTypeName))
						{
							dictionary[mapTypeName].Add(gridPosition);
						}
					}
					vector2.y += 1f;
				}
				vector2.x += 1f;
			}
			possibleVillagePositions = new List<Vector2Int>();
			selectableMapTypes.Clear();
			foreach (string allowedMapType in allowedMapTypes)
			{
				Vector2Int selected;
				if (dictionary[allowedMapType].Count == 0)
				{
					if (!flag)
					{
						list.Shuffle();
						flag = true;
					}
					selected = list[random.Next(0, list.Count)];
				}
				else
				{
					selected = dictionary[allowedMapType][random.Next(0, dictionary[allowedMapType].Count)];
					dictionary[allowedMapType].Remove(selected);
				}
				possibleVillagePositions.Add(selected);
				selectableMapTypes.Add(GetMapTypeName(in selected));
				list.Remove(selected);
				list.RemoveAll((Vector2Int item) => Vector2Int.Distance(item, selected) <= 3.9f);
				foreach (string allowedMapType2 in allowedMapTypes)
				{
					dictionary[allowedMapType2].RemoveAll((Vector2Int item) => Vector2.Distance(item, selected) <= 3.9f);
				}
			}
		}

		public float GetHeightAt(int x, int z)
		{
			x = UnityEngine.ProBuilder.Math.Clamp(x, 0, data.Heightmap.GetLength(0) - 1);
			z = UnityEngine.ProBuilder.Math.Clamp(z, 0, data.Heightmap.GetLength(1) - 1);
			return data.Heightmap[x, z] * 3.8f;
		}

		public float GetHeightAt(Vector2Int pos)
		{
			return GetHeightAt(pos.x, pos.y);
		}

		private void CreateOutputTexture()
		{
			for (int i = 0; i < data.WorldMapResolution.x; i++)
			{
				for (int j = 0; j < data.WorldMapResolution.y; j++)
				{
					byte num = data.MapTypes[i, j];
					float r = ((num == 0) ? 1f : 0f);
					float g = ((num == 1) ? 1f : 0f);
					float b = ((num == 2) ? 1f : 0f);
					float a = ((num == 3) ? 1f : 0f);
					MapTypesTexture.SetPixel(i, j, new Color(r, g, b, a));
					float num2 = Data.Heightmap[i, j];
					HeightmapTexture.SetPixel(i, j, new Color(num2, num2, num2, 1f));
				}
			}
			MapTypesTexture.Apply();
			HeightmapTexture.Apply();
			MapTypesTexture.wrapMode = TextureWrapMode.Mirror;
			HeightmapTexture.wrapMode = TextureWrapMode.Mirror;
			TerrainMaterial.SetTexture("_WorldMapType", MapTypesTexture);
			Shader.SetGlobalTexture("_WorldMapType", MapTypesTexture);
			TerrainMaterial.SetTexture("_Heightmap", HeightmapTexture);
			TerrainBorderMaterial.SetTexture("_WorldMapType", MapTypesTexture);
			TerrainBorderMaterial.SetTexture("_Heightmap", HeightmapTexture);
		}

		public string GetMapTypeName(in Vector2Int gridPosition)
		{
			if (gridPosition.x < 0 || gridPosition.y < 0 || gridPosition.x >= data.WorldMapResolution.x || gridPosition.y >= data.WorldMapResolution.y)
			{
				return null;
			}
			return settings.GetCellTypeByID(data.MapTypes[gridPosition.x, gridPosition.y])?.MapType;
		}

		private void PrepareTerrainRenderData()
		{
			settings.Init();
			terrain.Clear();
			InitRandom();
			Vector3 position = heightmapContent.transform.position;
			Vector3 s = Vector3.one * 0.5f;
			for (int i = 0; i < data.WorldMapResolution.x; i++)
			{
				for (int j = 0; j < data.WorldMapResolution.y; j++)
				{
					WorldMapCellType worldMapCellType = settings.GetCellTypeByID(data.MapTypes[i, j]);
					if (worldMapCellType == null)
					{
						worldMapCellType = settings.GetCellTypeForHeight(data.Heightmap[i, j]);
					}
					string text = worldMapCellType.Meshes[random.Next(0, worldMapCellType.Meshes.Count)];
					Mesh meshByAddress = MonoRepository<MeshRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetMeshByAddress(text);
					if (meshByAddress == null)
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMap.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("World map terrain mesh not found: ");
							messageBuilder.AppendFormatted(text);
						}
						Log.Error(messageBuilder);
					}
					else
					{
						int num = random.Next(3) * 90;
						Vector3 pos = new Vector3(i, GetHeightAt(i, j), j) + position;
						Quaternion q = Quaternion.Euler(0f, num, 0f);
						Matrix4x4 key = Matrix4x4.TRS(pos, q, s);
						terrain.Add(new KeyValuePair<Matrix4x4, Mesh>(key, meshByAddress));
					}
				}
			}
		}

		private float SawtoothSignal(float t)
		{
			float num = (t - math.floor(t)) * 2f;
			if (!(num < 1f))
			{
				return 2f - num;
			}
			return num;
		}

		private void CreateHeightmap()
		{
			data.WorldMapResolution = settings.Resolution;
			if (data.Heightmap == null || data.Heightmap.GetLength(0) != data.WorldMapResolution.x || data.Heightmap.GetLength(1) != data.WorldMapResolution.y)
			{
				data.Heightmap = new float[data.WorldMapResolution.x, data.WorldMapResolution.y];
			}
			float num = 15f;
			System.Random random = new System.Random(seed);
			FastNoise fastNoise = new FastNoise(seed);
			fastNoise.SetNoiseType(FastNoise.NoiseType.Cellular);
			fastNoise.SetFrequency((float)(0.004000000189989805 + random.NextDouble() * 0.00800000037997961));
			fastNoise.SetCellularDistanceFunction(FastNoise.CellularDistanceFunction.Euclidean);
			fastNoise.SetCellularReturnType(FastNoise.CellularReturnType.Distance2Add);
			fastNoise.SetCellularJitter(0.75f);
			FastNoise fastNoise2 = new FastNoise(seed);
			fastNoise2.SetNoiseType(FastNoise.NoiseType.PerlinFractal);
			fastNoise2.SetFrequency((float)(0.004000000189989805 + random.NextDouble() * 0.004000000189989805));
			fastNoise2.SetFractalOctaves(2);
			fastNoise2.SetFractalLacunarity(2f);
			fastNoise2.SetFractalGain(0.5f);
			fastNoise2.SetFractalType(FastNoise.FractalType.FBM);
			FastNoise fastNoise3 = new FastNoise(seed);
			fastNoise3.SetNoiseType(FastNoise.NoiseType.CubicFractal);
			fastNoise3.SetFractalOctaves(4);
			fastNoise3.SetFractalLacunarity(2f);
			fastNoise3.SetFractalGain(0.5f);
			fastNoise3.SetFrequency((float)(0.0020000000949949026 + random.NextDouble() * 0.0024999999441206455));
			float z = (float)(random.NextDouble() * 100.0);
			float num2 = (float)(0.4000000059604645 + 0.6000000238418579 * random.NextDouble());
			for (int i = 0; i < data.WorldMapResolution.x; i++)
			{
				for (int j = 0; j < data.WorldMapResolution.y; j++)
				{
					Vector2 vector = new Vector2((float)i * num, (float)j * num);
					float end = math.clamp(SawtoothSignal(fastNoise.GetNoise(vector.x, vector.y) * 0.5f), 0f, 1f);
					float start = math.clamp(Mathf.Abs(num2 * fastNoise2.GetNoise(vector.x, vector.y) * 1.6f) - 0.25f, 0f, 1f);
					float t = math.clamp((fastNoise3.GetNoise(vector.x, vector.y, z) + 0.06f) * 8f, 0f, 1f);
					data.Heightmap[i, j] = math.lerp(start, end, t);
				}
			}
		}

		public static void DestroyContent(Transform contentHolder)
		{
			if (contentHolder.childCount <= 0)
			{
				return;
			}
			int childCount = contentHolder.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = contentHolder.GetChild(0);
				if (child != null)
				{
					if (child.TryGetComponent<MeshFilter>(out var component))
					{
						component.sharedMesh = null;
						UnityEngine.Object.DestroyImmediate(component);
					}
					if (child.TryGetComponent<MeshRenderer>(out var component2))
					{
						component2.sharedMaterial = null;
						UnityEngine.Object.DestroyImmediate(component2);
					}
					UnityEngine.Object.DestroyImmediate(child.gameObject);
				}
			}
		}

		public void DestroyGeneratedContent()
		{
			DestroyContent(heightmapContent.transform);
		}

		public void ChangeScenarioFromHomeScene(Scenario scenario)
		{
			if (scenario.GetAllowedMapTypes(out var list))
			{
				SetAllowedMapTypes(list);
				StartRefreshCoroutine(0.1f);
			}
		}

		public void SetSeedFromHomeScene(int seed, float waitBeforeRefresh)
		{
			if (this.seed != seed)
			{
				this.seed = seed;
				StartRefreshCoroutine(waitBeforeRefresh);
			}
		}

		private void StartRefreshCoroutine(float waitBeforeRefresh = 0f)
		{
			if (generateMapHomeSceneCoroutine != null)
			{
				StopCoroutine(generateMapHomeSceneCoroutine);
			}
			generateMapHomeSceneCoroutine = RegenerateFromHomeScene(waitBeforeRefresh);
			StartCoroutine(generateMapHomeSceneCoroutine);
		}

		public void RegenerateFromHomeScene(int seed)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMap.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Regenerate from seed: ");
				messageBuilder.AppendFormatted(seed);
			}
			Log.Debug(messageBuilder);
			this.seed = seed;
			settings.Init();
			InitRandom();
			StartRefreshCoroutine();
		}

		private IEnumerator RegenerateFromHomeScene(float waitSeconds)
		{
			yield return new WaitForSeconds(waitSeconds);
			DestroyGeneratedContent();
			GenerateAll();
			MonoSingleton<WorldMapController>.Instance.WorldMapGeneratedFromHomeScene();
			generateMapHomeSceneCoroutine = null;
		}

		public void InitFromMainScene()
		{
			DestroyGeneratedContent();
			CreateOutputTexture();
			PrepareTerrainRenderData();
			MonoSingleton<WorldMapController>.Instance.WorldMapLoadedFromMainScene();
		}

		public void OnQuitToMain()
		{
			data.Caravans.Clear();
			data.FactionInstances.Clear();
			data.FactionRelations.Clear();
			data = null;
			MarkerManager?.Dispose();
		}

		private void RenderWorldMap()
		{
			RenderParams rparams = new RenderParams
			{
				material = viewPrefabMaterial
			};
			foreach (KeyValuePair<Matrix4x4, Mesh> item in terrain)
			{
				Matrix4x4 key = item.Key;
				Mesh value = item.Value;
				Graphics.RenderMesh(in rparams, value, 0, key);
			}
		}

		public bool IsPositionFree(in Vector2Int position)
		{
			if (Data.VillagePosition == position)
			{
				return false;
			}
			foreach (VillagePlace villagePlace in Data.VillagePlaces)
			{
				if (villagePlace.Position == position)
				{
					return false;
				}
			}
			foreach (WorldMapMarkerPlace marker in Data.Markers)
			{
				if (marker.Position == position)
				{
					return false;
				}
			}
			return true;
		}
	}
}
