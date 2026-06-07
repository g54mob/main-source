using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace Motorways
{
	public class CityTilemap : MonoBehaviour, IFeatureSwapObserver
	{
		public List<CityTileTypeDefinition> cityTileDefinitions;

		public Tilemap stationDemandTilemap;

		[FormerlySerializedAs("ferryTerminalTilemap")]
		public Tilemap boatTerminalTilemap;

		public Tilemap spawnDensityTilemap;

		public Tilemap bridgeableTilemap;

		public Tilemap mountainTilemap;

		public Tilemap railTilemap;

		public Tilemap boatPathTilemap;

		public Tilemap unbuildableTilemap;

		public Tilemap unzoneableTilemap;

		public Tilemap treeTilemap;

		public Tilemap bonusTreeTilemap;

		private TileMatrixBool _waterTileData;

		private TileMatrixBool _bridgeTileData;

		private TileMatrixBool _mountainTileData;

		private TileMatrixBool _railTileData;

		private TileMatrixBool _boatPathTileData;

		private TileMatrixBool _buildableTileData;

		private TileMatrixBool _zoneableTileData;

		private TileMatrixBool _driveableTileData;

		private CitySpawningLayerData _tileWeightData;

		public const string RoadSortingLayerName = "Road";

		private static int _roadSortingLayerId;

		public const string RoadOutlineSortingLayerName = "RoadOutline";

		private static int _roadOutlineSortingLayerId;

		private const int InvalidLinearCoordinate = -1;

		public CitySpawningLayerData TileWeightData => _tileWeightData;

		private void Awake()
		{
			_roadSortingLayerId = SortingLayer.NameToID("Road");
			_roadOutlineSortingLayerId = SortingLayer.NameToID("RoadOutline");
		}

		public Color TilemapColorFor(CityTileType type, int groupIndex)
		{
			foreach (CityTileTypeDefinition cityTileDefinition in cityTileDefinitions)
			{
				if (cityTileDefinition.type == type && cityTileDefinition.groupIndex == groupIndex)
				{
					return cityTileDefinition.tiles.color;
				}
			}
			return Color.black;
		}

		public void Compile(RectInt tilemapDimensions)
		{
			CompileTileData(tilemapDimensions);
			_tileWeightData = new CitySpawningLayerData(cityTileDefinitions, stationDemandTilemap, boatTerminalTilemap);
			HideTilemaps();
		}

		private void HideTilemaps(bool ignoreEditorPrefs = false)
		{
			foreach (CityTileTypeDefinition cityTileDefinition in cityTileDefinitions)
			{
				((Component)(object)cityTileDefinition.tiles).GetComponent<Renderer>().enabled = false;
			}
			((Component)(object)spawnDensityTilemap).GetComponent<Renderer>().enabled = false;
			((Component)(object)bridgeableTilemap).GetComponent<Renderer>().enabled = false;
			((Component)(object)mountainTilemap).GetComponent<Renderer>().enabled = false;
			((Component)(object)unbuildableTilemap).GetComponent<Renderer>().enabled = false;
			((Component)(object)unzoneableTilemap).GetComponent<Renderer>().enabled = false;
			((Component)(object)treeTilemap).GetComponent<Renderer>().enabled = false;
			if ((Object)(object)bonusTreeTilemap != null)
			{
				((Component)(object)bonusTreeTilemap).GetComponent<Renderer>().enabled = false;
			}
		}

		public DensityGroup DensityForPosition(Vector3Int position)
		{
			DensityTile densityTile = spawnDensityTilemap.GetTile(position) as DensityTile;
			if (densityTile != null)
			{
				return densityTile.group;
			}
			return DensityGroup.High;
		}

		public bool TileSupportsCircleDestinations(int groupIndex, Vector3Int position)
		{
			foreach (CityTileTypeDefinition cityTileDefinition in cityTileDefinitions)
			{
				if (cityTileDefinition.type == CityTileType.Demand && (cityTileDefinition.groupIndex == groupIndex || groupIndex == -1))
				{
					WeightTile weightTile = cityTileDefinition.tiles.GetTile(position) as WeightTile;
					if (weightTile != null)
					{
						return weightTile.isCircle;
					}
					if (groupIndex != -1)
					{
						return false;
					}
				}
			}
			return false;
		}

		public static int LayerIdFor(CityTileType type, int groupIndex)
		{
			return (int)type * 100 + groupIndex + 1;
		}

		public void OnChosen()
		{
		}

		public void OnNotChosen()
		{
			HideTilemaps(ignoreEditorPrefs: true);
		}

		public bool TileIsBuildable(Vector2Int tileCoordinates)
		{
			return _buildableTileData[tileCoordinates];
		}

		public bool TileIsZoneable(Vector2Int tileCoordinates)
		{
			return _zoneableTileData[tileCoordinates];
		}

		public bool TileIsOverWater(Vector2Int tileCoordinates)
		{
			return _waterTileData[tileCoordinates];
		}

		public bool TileIsUnderAMountain(Vector2Int tileCoordinates)
		{
			return _mountainTileData[tileCoordinates];
		}

		public bool TileIsOverRail(Vector2Int tileCoordinates)
		{
			return _railTileData[tileCoordinates];
		}

		public bool TileIsOverBoatPath(Vector2Int tileCoordinates)
		{
			return _boatPathTileData[tileCoordinates];
		}

		public bool TileIsDriveable(Vector2Int tileCoordinates)
		{
			return _driveableTileData[tileCoordinates];
		}

		private void CompileTileData(RectInt tilemapDimensions)
		{
			_waterTileData = TileMatrixBool.CreateUnscoped(tilemapDimensions, defaultValue: false);
			_waterTileData.FillFromTilemap(bridgeableTilemap, (TileBase tile) => tile != null);
			_mountainTileData = TileMatrixBool.CreateUnscoped(tilemapDimensions, defaultValue: false);
			_mountainTileData.FillFromTilemap(mountainTilemap, (TileBase tile) => tile != null);
			_railTileData = TileMatrixBool.CreateUnscoped(tilemapDimensions, defaultValue: false);
			_railTileData.FillFromTilemap(railTilemap, (TileBase tile) => tile != null);
			_boatPathTileData = TileMatrixBool.CreateUnscoped(tilemapDimensions, defaultValue: false);
			_boatPathTileData.FillFromTilemap(boatPathTilemap, (TileBase tile) => tile != null);
			_buildableTileData = TileMatrixBool.CreateUnscoped(tilemapDimensions, defaultValue: true);
			_buildableTileData.FillFromTilemap(unbuildableTilemap, (TileBase tile) => tile == null);
			_zoneableTileData = TileMatrixBool.CreateUnscoped(tilemapDimensions, defaultValue: true);
			_zoneableTileData.FillFromTilemap(unzoneableTilemap, (TileBase tile) => tile == null);
			_driveableTileData = TileMatrixBool.CreateUnscoped(tilemapDimensions, defaultValue: true);
			_driveableTileData.FillFromCoordinates((Vector2Int tileCoordinates) => _buildableTileData[tileCoordinates] && !_waterTileData[tileCoordinates] && !_mountainTileData[tileCoordinates]);
		}
	}
}
