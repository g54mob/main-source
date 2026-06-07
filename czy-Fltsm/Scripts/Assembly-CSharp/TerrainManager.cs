using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

public class TerrainManager : SceneBehaviour
{
	private struct RegionTile
	{
		public WorldRegionType RegionType;

		public GameObject Tile;

		public RegionTile(WorldRegionType regionType, GameObject tile)
		{
			RegionType = regionType;
			Tile = tile;
		}
	}

	private readonly Dictionary<WorldRegionType, List<GameObject>> _pooledRegionTiles = new Dictionary<WorldRegionType, List<GameObject>>();

	private RegionTile[,] _tiles = new RegionTile[1, 1];

	private int _gridWidth;

	private int _gridHeight = 1;

	private float _tileWidth;

	private float _tileHeight;

	private float _horizontalGridOffset;

	private float _verticalGridOffset;

	private int _cameraOffsetX;

	private int _cameraOffsetY;

	private Vector3 _townheartWorldPosition;

	private Quaternion _townheartWorldRotation;

	private void Start()
	{
		World world = GameManager.WorldManager.World;
		if (world != null)
		{
			_townheartWorldPosition = world.TownheartWorldPosition;
			_townheartWorldRotation = world.TownheartRotation;
			OnTownheartMoved();
			GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
		}
	}

	private void Update()
	{
		if (!GameManager.Instance.InitializeEnvironment)
		{
			return;
		}
		Vector3 cameraPosition = CameraController.Instance.CameraPosition;
		int num = (int)cameraPosition.x / (int)(_horizontalGridOffset * 0.5f);
		int num2 = (int)cameraPosition.z / (int)(_verticalGridOffset * 0.5f);
		if (num != _cameraOffsetX)
		{
			int cameraOffsetX = _cameraOffsetX;
			_cameraOffsetX = num;
			if (num > cameraOffsetX)
			{
				ShiftTilesLeft();
			}
			else
			{
				ShiftTilesRight();
			}
		}
		if (num2 != _cameraOffsetY)
		{
			int cameraOffsetY = _cameraOffsetY;
			_cameraOffsetY = num2;
			if (num2 > cameraOffsetY)
			{
				ShiftTilesDown();
			}
			else
			{
				ShiftTilesUp();
			}
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
	}

	public void Initialize()
	{
		_tileWidth = GameManager.Settings.GameplaySettings.TerrainProperties.TileWidth;
		_tileHeight = GameManager.Settings.GameplaySettings.TerrainProperties.TileLength;
		_gridWidth = Mathf.CeilToInt(GameManager.Settings.GameplaySettings.TerrainProperties.GridSize / _tileWidth);
		_gridHeight = Mathf.CeilToInt(GameManager.Settings.GameplaySettings.TerrainProperties.GridSize / _tileHeight);
		_horizontalGridOffset = (float)(_gridWidth - 1) * _tileWidth * 0.5f;
		_verticalGridOffset = (float)(_gridHeight - 1) * _tileHeight * 0.5f;
		_tiles = new RegionTile[_gridWidth, _gridHeight];
	}

	private void OnTownheartMoved(GameEvent gameEvent = null)
	{
		if (gameEvent is MovementEvent movementEvent)
		{
			_townheartWorldPosition = movementEvent.PositionTo;
			_townheartWorldRotation = movementEvent.RotationTo;
		}
		for (int i = 0; i < _gridWidth; i++)
		{
			for (int j = 0; j < _gridHeight; j++)
			{
				InitializeTileAtPosition(i, j);
			}
		}
	}

	private void InitializeTileAtPosition(int x, int y)
	{
		Vector3 tileSpawnPosition = GetTileSpawnPosition(x, y);
		WorldRegionType regionFromTileSpawnPositon = GetRegionFromTileSpawnPositon(tileSpawnPosition);
		if (_tiles[x, y].Tile != null)
		{
			PoolTile(_tiles[x, y]);
		}
		_tiles[x, y] = new RegionTile(regionFromTileSpawnPositon, GetNewRegionTile(x, y, tileSpawnPosition, regionFromTileSpawnPositon));
	}

	private Vector3 GetTileSpawnPosition(int x, int y)
	{
		return new Vector3((float)(x + _cameraOffsetX) * _tileWidth - _horizontalGridOffset, 0f, (float)(y + _cameraOffsetY) * _tileHeight - _verticalGridOffset);
	}

	private GameObject GetNewRegionTile(int x, int y, Vector3 worldPosition, WorldRegionType regionType)
	{
		if (!_pooledRegionTiles.ContainsKey(regionType))
		{
			SpawnRegionTiles(regionType);
		}
		if (!_pooledRegionTiles.TryGetValue(regionType, out var value))
		{
			return null;
		}
		System.Random random = new System.Random(x * 10 + y);
		int index = random.Next(value.Count);
		GameObject obj = value[index];
		value.RemoveAt(index);
		obj.transform.SetPositionAndRotation(worldPosition, Quaternion.Euler(0f, (float)random.Next(4) * 90f, 0f));
		obj.SetActive(value: true);
		return obj;
	}

	private void ShiftTilesUp()
	{
		for (int i = 0; i < _gridWidth; i++)
		{
			RegionTile tileToShift = _tiles[i, _gridHeight - 1];
			for (int num = _gridHeight - 1; num > 0; num--)
			{
				_tiles[i, num] = _tiles[i, num - 1];
				UpdateTilePosition(i, num);
			}
			ShiftOrReplaceTile(i, 0, tileToShift);
		}
	}

	private void ShiftTilesDown()
	{
		for (int i = 0; i < _gridWidth; i++)
		{
			RegionTile tileToShift = _tiles[i, 0];
			for (int j = 0; j < _gridHeight - 1; j++)
			{
				_tiles[i, j] = _tiles[i, j + 1];
				UpdateTilePosition(i, j);
			}
			ShiftOrReplaceTile(i, _gridHeight - 1, tileToShift);
		}
	}

	private void ShiftTilesRight()
	{
		for (int i = 0; i < _gridHeight; i++)
		{
			RegionTile tileToShift = _tiles[_gridWidth - 1, i];
			for (int num = _gridWidth - 1; num > 0; num--)
			{
				_tiles[num, i] = _tiles[num - 1, i];
				UpdateTilePosition(num, i);
			}
			ShiftOrReplaceTile(0, i, tileToShift);
		}
	}

	private void ShiftTilesLeft()
	{
		for (int i = 0; i < _gridHeight; i++)
		{
			RegionTile tileToShift = _tiles[0, i];
			for (int j = 0; j < _gridWidth - 1; j++)
			{
				_tiles[j, i] = _tiles[j + 1, i];
				UpdateTilePosition(j, i);
			}
			ShiftOrReplaceTile(_gridWidth - 1, i, tileToShift);
		}
	}

	private void ShiftOrReplaceTile(int x, int y, RegionTile tileToShift)
	{
		Vector3 tileSpawnPosition = GetTileSpawnPosition(x, y);
		WorldRegionType regionFromTileSpawnPositon = GetRegionFromTileSpawnPositon(tileSpawnPosition);
		if (regionFromTileSpawnPositon != tileToShift.RegionType)
		{
			PoolTile(tileToShift);
			_tiles[x, y] = new RegionTile(regionFromTileSpawnPositon, GetNewRegionTile(x, y, tileSpawnPosition, regionFromTileSpawnPositon));
		}
		else
		{
			tileToShift.Tile.transform.position = tileSpawnPosition;
			_tiles[x, y] = tileToShift;
		}
	}

	private void UpdateTilePosition(int x, int y)
	{
		_tiles[x, y].Tile.transform.position = GetTileSpawnPosition(x, y);
	}

	private WorldRegionType GetRegionFromTileSpawnPositon(Vector3 tileSpawnPosition)
	{
		Vector3 worldPosition = _townheartWorldRotation * tileSpawnPosition + _townheartWorldPosition;
		if (!WorldManager.TryReturnRegionContainingWorldPosition(out var region, worldPosition))
		{
			return WorldRegionType.Rural;
		}
		return region.Type;
	}

	private void PoolTile(RegionTile tile)
	{
		tile.Tile.SetActive(value: false);
		_pooledRegionTiles[tile.RegionType].Add(tile.Tile);
	}

	private List<GameObject> SpawnRegionTiles(WorldRegionType regionType)
	{
		IReadOnlyList<GameObject> regionTiles = GetRegionTiles(regionType);
		if (regionTiles.IsNullOrEmpty())
		{
			Debug.LogException(new NullReferenceException("Tiles are improperly setup in TerrainProperties."));
			_pooledRegionTiles.Add(regionType, null);
			return null;
		}
		int num = _gridWidth * _gridHeight;
		List<GameObject> list = new List<GameObject>(num);
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(regionTiles.GetRandom(), GameManager.WorldManager.WorldParent);
			gameObject.SetActive(value: false);
			list.Add(gameObject);
		}
		_pooledRegionTiles.Add(regionType, list);
		return list;
	}

	private IReadOnlyList<GameObject> GetRegionTiles(WorldRegionType regionType)
	{
		IReadOnlyList<TerrainProperties.RegionTiles> tiles = GameManager.Settings.GameplaySettings.TerrainProperties.Tiles;
		foreach (TerrainProperties.RegionTiles item in tiles)
		{
			if (item.RegionType == regionType)
			{
				return item.Prefabs;
			}
		}
		if (tiles.Count > 0)
		{
			Debug.LogException(new ArgumentException($"No terrain tiles found for region type \"{regionType}\", defaulting to \"{tiles[0].RegionType}\"."));
			return tiles[0].Prefabs;
		}
		Debug.LogException(new ArgumentException($"No terrain tiles found for region type \"{regionType}\"."));
		return null;
	}
}
