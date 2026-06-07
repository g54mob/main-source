using System;
using System.Runtime.Serialization;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class GameWorldPersistentData : PersistentReference<World>
{
	[OptionalField(VersionAdded = 3)]
	private WorldTilePersistentData[] _tiles;

	private Vector3 _townheartPosition;

	private Quaternion _townheartRotation;

	[OptionalField(VersionAdded = 2)]
	private int _tilePropertiesIndex;

	[OptionalField(VersionAdded = 4)]
	private int _salvagedItemCount;

	[OptionalField(VersionAdded = 5)]
	private float _firstTileOffsetX;

	private WorldTilePersistentData _tile;

	public GameWorldPersistentData(World world)
		: base(world)
	{
		_tilePropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(world.TileProperties);
		_salvagedItemCount = world.SalvagedItemCount;
		_firstTileOffsetX = 0f;
		if (world.Tiles.IsNullOrEmpty())
		{
			Debug.LogError("Unable to serialized world because there are no WorldTiles to serialize");
			return;
		}
		if (world.Tiles.Count == 1 && (bool)world.Tiles[0].Properties)
		{
			_tile = new WorldTilePersistentData(world.Tiles[0]);
			_townheartPosition = world.TownheartWorldPosition;
			_townheartRotation = world.TownheartRotation;
			return;
		}
		_firstTileOffsetX = world.FirstTileOffsetX + world.Tiles[0].WorldPosition.x;
		_tiles = new WorldTilePersistentData[world.Tiles.Count];
		for (int i = 0; i < world.Tiles.Count; i++)
		{
			_tiles[i] = new WorldTilePersistentData(world.Tiles[i]);
		}
		_townheartPosition = world.TownheartWorldPosition - world.Tiles[0].Offset.Vector3TopDown();
		_townheartRotation = world.TownheartRotation;
	}

	public void PopulateReferences()
	{
		_tile?.PopulateReferences();
		if (!_tiles.IsNullOrEmpty())
		{
			WorldTilePersistentData[] tiles = _tiles;
			for (int i = 0; i < tiles.Length; i++)
			{
				tiles[i].PopulateReferences();
			}
		}
	}

	public override void Restore()
	{
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<TileProperties>(_tilePropertiesIndex, out var reference))
		{
			base.Instance = new World(reference, _salvagedItemCount, _firstTileOffsetX);
		}
		else
		{
			base.Instance = new World(GameSettings.Instance.WorldSettings.DefaultTileProperties, _salvagedItemCount, _firstTileOffsetX);
		}
		if (_tiles.IsNullOrEmpty())
		{
			_tile.Restore(base.Instance);
			base.Instance.RestoreTile(_tile.Instance);
		}
		else
		{
			WorldTilePersistentData[] tiles = _tiles;
			foreach (WorldTilePersistentData worldTilePersistentData in tiles)
			{
				worldTilePersistentData.Restore(base.Instance);
				base.Instance.RestoreTile(worldTilePersistentData.Instance);
			}
		}
		GameManager.WorldManager.SetWorld(base.Instance);
	}

	public void RepositionLandmarks()
	{
		if (base.Instance.RepositionTownheart(_townheartPosition, _townheartRotation))
		{
			return;
		}
		int count = base.Instance.Tiles.Count;
		while (0 < count--)
		{
			if (base.Instance.Tiles[count].TryReturnTownheartResetPosition(out var position) && base.Instance.RepositionTownheart(position, Quaternion.identity))
			{
				Debug.LogException(new Exception("An out of bounds position was persisted for the town, the town position was reset."));
				return;
			}
		}
		Debug.LogException(new Exception("An out of bounds position was persisted for the town, the town position could not be reset!"));
	}

	public void RestoreReferences()
	{
		_tile?.RestoreReferences();
		if (!_tiles.IsNullOrEmpty())
		{
			WorldTilePersistentData[] tiles = _tiles;
			for (int i = 0; i < tiles.Length; i++)
			{
				tiles[i].RestoreReferences();
			}
		}
	}
}
