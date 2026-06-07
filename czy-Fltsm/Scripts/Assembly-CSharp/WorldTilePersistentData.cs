using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[Serializable]
public class WorldTilePersistentData : PersistentReference<WorldTile>
{
	[OptionalField(VersionAdded = 8)]
	private int _index;

	[OptionalField(VersionAdded = 7)]
	private int _tileGeneratorPrefabIndex = -1;

	[OptionalField(VersionAdded = 7)]
	private int _subTileGeneratorPrefabIndex = -1;

	private LandmarkSpawnerPersistentData[] _landmarkSpawners;

	private PointOfInterestSpawner.PersistentData[] _pointOfInterestSpawners;

	[OptionalField(VersionAdded = 8)]
	private WorldRegionFlags[] _regionFlags;

	[OptionalField(VersionAdded = 6)]
	private WorldMapFogOfWar.PersistentData _fogOfWarPersistentData;

	[OptionalField(VersionAdded = 4)]
	private float _scale;

	private int _propertiesIndex = -1;

	[OptionalField(VersionAdded = 2)]
	private byte[] _fogOfWarAlphas;

	[OptionalField(VersionAdded = 3)]
	private int _salvagedItemCount;

	public LandmarkSpawnerPersistentData[] LandmarkSpawners => _landmarkSpawners;

	public PointOfInterestSpawner.PersistentData[] PointOfInterestSpawners => _pointOfInterestSpawners;

	public int SalvagedItemCount => _salvagedItemCount;

	public WorldTilePersistentData(WorldTile tile)
		: base(tile)
	{
		_index = tile.Index;
		if ((bool)tile.Properties)
		{
			_propertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(tile.Properties);
		}
		else
		{
			_tileGeneratorPrefabIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(tile.TileGeneratorPrefab);
			_subTileGeneratorPrefabIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(tile.SubTileGeneratorPrefab);
		}
		_fogOfWarPersistentData = GameManager.WorldMapManager.WorldMap.ReturnFogOfWarPersistentData(tile);
		_salvagedItemCount = tile.SalvagedItemCount;
		_scale = tile.Scale;
		PopulateLandmarkSpawnerData(tile.Landmarks);
		PopulatePointOfInterestSpawnerData(tile.PointsOfInterest);
		PopulateRegionData(tile.Regions);
	}

	private void PopulateLandmarkSpawnerData(IReadOnlyList<LandmarkSpawner> landmarkSpawners)
	{
		_landmarkSpawners = new LandmarkSpawnerPersistentData[landmarkSpawners.Count];
		for (int i = 0; i < _landmarkSpawners.Length; i++)
		{
			_landmarkSpawners[i] = new LandmarkSpawnerPersistentData(landmarkSpawners[i]);
		}
	}

	private void PopulatePointOfInterestSpawnerData(IReadOnlyList<PointOfInterestSpawner> pointOfInterestSpawners)
	{
		List<PointOfInterestSpawner.PersistentData> list = ListPool<PointOfInterestSpawner.PersistentData>.Get(pointOfInterestSpawners.Count);
		foreach (PointOfInterestSpawner pointOfInterestSpawner in pointOfInterestSpawners)
		{
			list.Add(new PointOfInterestSpawner.PersistentData(pointOfInterestSpawner));
		}
		_pointOfInterestSpawners = list.ToArray();
		ListPool<PointOfInterestSpawner.PersistentData>.Add(list);
	}

	private void PopulateRegionData(IReadOnlyList<IWorldRegion> regions)
	{
		int count = regions.Count;
		_regionFlags = new WorldRegionFlags[count];
		for (int i = 0; i < count; i++)
		{
			_regionFlags[i] = regions[i].Flags;
		}
	}

	public void PopulateReferences()
	{
		LandmarkSpawnerPersistentData[] landmarkSpawners = _landmarkSpawners;
		for (int i = 0; i < landmarkSpawners.Length; i++)
		{
			landmarkSpawners[i].PopulateReferences();
		}
	}

	public void Restore(World world)
	{
		base.Restore();
		if (RestoreInstance())
		{
			base.Instance.Restore(_index);
			base.Instance.SalvagedItemCount = _salvagedItemCount;
			base.Instance.Scale = _scale;
			RestoreLandmarkSpawners(base.Instance);
			RestorePointOfInterestSpawners(base.Instance);
			RestoreRegions(base.Instance);
			if (_fogOfWarPersistentData == null)
			{
				base.Instance.RestoreFogOfWar(_fogOfWarAlphas);
			}
			else
			{
				base.Instance.RestoreFogOfWar(_fogOfWarPersistentData);
			}
		}
	}

	private bool RestoreInstance()
	{
		if (-1 < _propertiesIndex && GameManager.PersistenceManager.TryReturnPropertiesReference<TileProperties>(_propertiesIndex, out var reference))
		{
			base.Instance = new WorldTile(reference);
			return true;
		}
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<TileGenerator>(_tileGeneratorPrefabIndex, out var reference2))
		{
			TileGeneratorBase reference3 = null;
			if (-1 < _tileGeneratorPrefabIndex)
			{
				GameManager.PersistenceManager.TryReturnPropertiesReference<TileGeneratorBase>(_subTileGeneratorPrefabIndex, out reference3);
			}
			base.Instance = new WorldTile(reference2, reference3);
			return true;
		}
		return false;
	}

	public override void Restore()
	{
		throw new NotSupportedException();
	}

	private void RestoreLandmarkSpawners(WorldTile tile)
	{
		LandmarkSpawnerPersistentData[] landmarkSpawners = _landmarkSpawners;
		for (int i = 0; i < landmarkSpawners.Length; i++)
		{
			landmarkSpawners[i].Restore(tile);
		}
	}

	private void RestorePointOfInterestSpawners(WorldTile tile)
	{
		PointOfInterestSpawner.PersistentData[] pointOfInterestSpawners = _pointOfInterestSpawners;
		for (int i = 0; i < pointOfInterestSpawners.Length; i++)
		{
			if (pointOfInterestSpawners[i].TryRestore(out var spawner))
			{
				tile.AddPointOfInterestSpawner(spawner, initialize: false);
			}
		}
	}

	private void RestoreRegions(WorldTile tile)
	{
		int count = tile.Regions.Count;
		if (_regionFlags == null)
		{
			return;
		}
		if (_regionFlags.Length != count)
		{
			Debug.LogException(new Exception("Unable to restore region flags, there is a region count mismatch!"));
			return;
		}
		for (int i = 0; i < count; i++)
		{
			tile.Regions[i].Restore(_regionFlags[i]);
		}
	}

	private bool ValidateIndices(int[] indices, int indexCount)
	{
		if (indices == null)
		{
			return false;
		}
		foreach (int num in indices)
		{
			if (0 > num || num >= indexCount)
			{
				return false;
			}
		}
		return true;
	}

	public void RestoreReferences()
	{
		LandmarkSpawnerPersistentData[] landmarkSpawners = _landmarkSpawners;
		for (int i = 0; i < landmarkSpawners.Length; i++)
		{
			landmarkSpawners[i].RestoreReferences();
		}
	}
}
