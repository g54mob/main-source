using System;
using System.Collections.Generic;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Items;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class TilingTileset : GameMonoBehaviour
	{
		private struct MoongateData
		{
			public Vector2 A;

			public bool HasA;

			public Vector2 B;

			public bool HasB;
		}

		private struct TeleporterData
		{
			public string TeleportKey;

			public Vector2 A;

			public bool HasA;

			public Vector2 B;

			public bool HasB;

			public string DestinationA;

			public string DestinationB;
		}

		private TilesetFactory _tilesetFactory;

		private GameManager _gameManager;

		private PlayerOptions _playerOptions;

		private StageType _stageType;

		private Stage _stage;

		private readonly List<SuperMap> _maps;

		private readonly List<GameObject> _supportMaps;

		private readonly List<PhaserTilemap> _phaserTilemaps;

		private readonly Dictionary<SuperMap, List<SuperTileLayer>> _cachedMapSuperTilesLayers;

		private readonly Dictionary<SuperMap, List<PhaserTilemap>> _cachedCollisionTilemaps;

		private readonly Dictionary<SuperMap, Tilemap> _cachedSpawningTilemap;

		private readonly Dictionary<SuperMap, Tilemap> _cachedFloorLayers;

		private List<Bounds> _bounds;

		private Bounds _currentBounds;

		private Vector3 _previousTilingCenter;

		private bool _hasMoongates;

		private bool _hasTeleporters;

		private readonly Dictionary<string, MoongateData> _moongates;

		private readonly Dictionary<string, TeleporterData> _teleporters;

		private float _sizeX;

		private float _sizeY;

		private AdventureManager _adventureManager;

		public bool _inverted;

		public bool _visuallyInverted;

		public List<SuperObject> SavedScripts;

		private float offset;

		private Bounds _previousFirstMap;

		public Vector2 StartPosition { get; private set; }

		public SuperMap DefaultMap => null;

		public GameObject DefaultSupportMap => null;

		public float SizeX => 0f;

		public float SizeY => 0f;

		public Vector2 DefaultMapPosition => default(Vector2);

		public Bounds CurrentBounds => default(Bounds);

		public List<SuperMap> Tiles => null;

		public List<PickupTeleporter> ListOfTeleporters { get; private set; }

		public Bounds GetTotalBounds()
		{
			return default(Bounds);
		}

		[Inject]
		private void Construct(TilesetFactory tilesetFactory, GameManager gameManager, PlayerOptions playerOptions, AdventureManager adventureManager)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void Init(StageType stageType, Stage stage)
		{
		}

		public void InitPostLoad()
		{
		}

		public void InternalUpdate()
		{
		}

		public List<Vector2> GetSpecialLocations(string scriptName)
		{
			return null;
		}

		public List<SuperObject> GetScriptsFromName(string scriptName, string layerName = "Scripts")
		{
			return null;
		}

		public List<Rectangle> GetScriptRectangularLocations(string objectName, bool autoScaleAndOffset = false)
		{
			return null;
		}

		public Tilemap GetTilemapLayer(string layerName)
		{
			return null;
		}

		public SuperTileLayer GetSuperTileLayer(SuperMap map, string layerName)
		{
			return null;
		}

		public SuperTile GetSpawningLayerTile(float posX, float posY)
		{
			return null;
		}

		public List<Tilemap> GetAllLayers(List<string> excludeLayers = null)
		{
			return null;
		}

		public void SetAllLayersAlpha(float alpha)
		{
		}

		public void FadeAllLayers(float alpha, float durationMillis, Action onComplete = null)
		{
		}

		public void TintAllLayers(Color tint, float durationMillis, Action onComplete = null)
		{
		}

		public bool IsPointWithinCollisionLayer(Vector2 spawnPoint)
		{
			return false;
		}

		public bool IsPointWithinCollisionLayerWrapped(Vector2 spawnPoint)
		{
			return false;
		}

		public bool HasEmptyFloorTile(Vector2 point)
		{
			return false;
		}

		public TileBase GetTileAtPosition(Vector2 point)
		{
			return null;
		}

		public PickupMerchant SpawnMerchant()
		{
			return null;
		}

		public void pianificami()
		{
		}

		public void spianami()
		{
		}

		public List<PhaserTilemap> GetPhaserTilemaps()
		{
			return null;
		}

		public void SetTilemapCollisionsEnabled(bool isEnabled)
		{
		}

		private void UpdateInversionBool()
		{
		}

		private void HandleInversion(SuperMap map, StageType type)
		{
		}

		private void HandleNonInversionTint(List<SuperTileLayer> layers, StageData data)
		{
		}

		private void HandleInversionTint(List<SuperTileLayer> layers, StageData data)
		{
		}

		private void GenerateMaps()
		{
		}

		private static Vector2 GetPosByIndex(int index, SuperMap map)
		{
			return default(Vector2);
		}

		public List<CharacterType> GetCharactersUsed(SuperMap map)
		{
			return null;
		}

		public List<Tuple<SuperObject, SuperCustomProperties>> GetAllMerchants()
		{
			return null;
		}

		private void HandleCustomScriptProperties(SuperMap map)
		{
		}

		private SuperObjectLayer GetObjectLayer(SuperMap map, string layerName)
		{
			return null;
		}

		private void SetPlayerStartFromSuperObject(SuperObject superObject)
		{
		}

		private void SpawnWeaponAt(SuperObject superObject)
		{
		}

		private void SpawnItemAt(SuperObject superObject)
		{
		}

		private void SpawnRelicAt(SuperObject superObject)
		{
		}

		private void SpawnYellowAt(SuperObject superObject)
		{
		}

		private void SpawnArcanaChestAt(SuperObject superObject)
		{
		}

		private void SpawnCoffin(SuperObject superObject)
		{
		}

		private void TrySpawnSpecialCoffin(SuperObject superObject)
		{
		}

		private void GetMoongateData(SuperObject superObject)
		{
		}

		private void LinkTeleporters(SuperObject superObject)
		{
		}

		private void SpawnMoongates()
		{
		}

		private void MakeTeleporters()
		{
		}

		private PickupTeleporter MakeTeleporter(Vector2 gatePosition, ItemType teleporterType)
		{
			return null;
		}

		private void Pianificami(SuperObject superObject)
		{
		}

		public Vector2 GetSpawnPosFromSuperObject(SuperObject superObject, SuperCustomProperties scp)
		{
			return default(Vector2);
		}

		private static void SetGuardedDataForItem(SuperCustomProperties scp, PickupGuarded item)
		{
		}

		private void StoreScript(SuperObject superObject)
		{
		}

		private void SpawnAdventureMerchant(SuperObject superObject)
		{
		}

		private void SpawnCustomMerchant(SuperObject superObject)
		{
		}

		private void HandleSortingOrders(SuperMap map)
		{
		}

		private void SetTilemapLayerSortingOrder(SuperMap map, string layerName, int sortingOrder, bool visible = true)
		{
		}

		private PhaserTilemap AddPhaserTilemap(SuperMap map, string layerName, int setID)
		{
			return null;
		}

		private void HandleArcadePhysics(List<SuperMap> maps)
		{
		}

		private PhaserTilemap GetPhaserTilemapFromLayer(SuperMap map, string layerName)
		{
			return null;
		}

		private void ProcessTiling()
		{
		}

		public void UpdateHorizontalTilesetOnTeleport(Vector2 playerPos, bool processTiling = true)
		{
		}

		public void UpdateVerticalTilesetOnTeleport(Vector2 playerPos, bool processTiling = true)
		{
		}

		public void MoveTilesetForHorizontalRoad(float speedMultiplier)
		{
		}

		private void UpdatePhaserTilemapBounds()
		{
		}
	}
}
