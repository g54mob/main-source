using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldTileProvider", menuName = "Flotsam/World/World Tile Provider")]
public class WorldTileProvider : WorldTileProviderBase, IWorldTileProvider
{
	[SerializeField]
	private TileGeneratorBase[] _tiles;

	[Header("Optional")]
	[SerializeField]
	[Tooltip("Generator used to generate the tile, when this value is null the current world generator is used")]
	private TileGenerator _generatorOverride;

	[NonSerialized]
	protected List<TileGeneratorBase> _cache = new List<TileGeneratorBase>();

	[NonSerialized]
	private List<TileGeneratorBase> _pickables = new List<TileGeneratorBase>();

	public override WorldTile GetNextWorldTile(World world, ILandmarkPicker landmarkPicker = null)
	{
		if (_cache.Count == 0)
		{
			_cache.AddRange(_tiles);
		}
		if (landmarkPicker == null)
		{
			return GetWorldTile(world, _cache);
		}
		_pickables.Clear();
		foreach (TileGeneratorBase item in _cache)
		{
			if (landmarkPicker.CanPickFrom(item))
			{
				_pickables.Add(item);
			}
		}
		if (0 < _pickables.Count)
		{
			return GetWorldTile(world, _pickables);
		}
		TileGeneratorBase[] tiles = _tiles;
		foreach (TileGeneratorBase tileGeneratorBase in tiles)
		{
			if (landmarkPicker.CanPickFrom(tileGeneratorBase))
			{
				_pickables.Add(tileGeneratorBase);
			}
		}
		if (0 < _pickables.Count)
		{
			return GetWorldTile(world, _pickables);
		}
		return null;
	}

	protected WorldTile GetWorldTile(World world, List<TileGeneratorBase> tiles)
	{
		TileGeneratorBase random = tiles.GetRandom();
		_cache.Remove(random);
		return new WorldTile(world.TileProperties.TileGenerator, random);
	}

	public override bool Contains(TileGeneratorBase tile)
	{
		return _tiles.Contains(tile);
	}
}
