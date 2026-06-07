using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;

public class TileGeneratorRegion : IRegion
{
	private IWorldRegion _worldRegion;

	private VoronoiWorldRegion _voronoiWorldRegion;

	private List<TileGeneratorRegion> _neighbors;

	private float _surface;

	public TileGenerator Generator { get; private set; }

	public WorldRegionType Type => _worldRegion.Type;

	public PollutionLevels PollutionLevel => _worldRegion.PollutionLevel;

	public Rect Bounds => _worldRegion.Bounds;

	public List<TileGeneratorNode> Nodes { get; private set; }

	public List<TileGeneratorNode> Landmarks { get; private set; }

	public TileGeneratorRegion(TileGenerator tileGenerator, IWorldRegion worldRegion)
	{
		Generator = tileGenerator;
		_worldRegion = worldRegion;
		_voronoiWorldRegion = worldRegion as VoronoiWorldRegion;
		_surface = _worldRegion.ReturnSurface();
		Nodes = new List<TileGeneratorNode>();
		Landmarks = new List<TileGeneratorNode>();
	}

	public void PopulateNeighbors(IEnumerable<TileGeneratorRegion> generatorRegions)
	{
		if (_voronoiWorldRegion == null)
		{
			return;
		}
		_neighbors = new List<TileGeneratorRegion>();
		foreach (TileGeneratorRegion generatorRegion in generatorRegions)
		{
			if (generatorRegion != this && _voronoiWorldRegion.Neighbors.Contains(generatorRegion._voronoiWorldRegion))
			{
				_neighbors.Add(generatorRegion);
			}
		}
	}

	public void AddNode(TileGeneratorNode node)
	{
		Nodes.Add(node);
		if (node.Spawner != null && node.Spawner.Type == ISpawnerType.Landmark)
		{
			Landmarks.Add(node);
		}
	}

	public bool ReturnIsValidPosition(Vector2 position, float minimumNodeDistance)
	{
		if (_voronoiWorldRegion != null && !_voronoiWorldRegion.ReturnContainsPosition(position))
		{
			return false;
		}
		if (_neighbors.IsNullOrEmpty())
		{
			return Generator.ReturnIsValidPosition(position, minimumNodeDistance);
		}
		if (Generator.ReturnPositionIsInStartingArea(position) || !_voronoiWorldRegion.ReturnContainsPosition(position))
		{
			return false;
		}
		using ListPool<TileGeneratorNode>.List list = ListPool<TileGeneratorNode>.Get(Nodes);
		foreach (TileGeneratorRegion neighbor in _neighbors)
		{
			list.AddRange(neighbor.Nodes);
		}
		foreach (TileGeneratorNode item in list)
		{
			if (item.Position.IsInRange(position, minimumNodeDistance))
			{
				return false;
			}
		}
		return true;
	}

	public float ReturnSurface()
	{
		return _surface;
	}

	public float ReturnOverlap(Polygon2DBase polygon)
	{
		return _worldRegion.ReturnOverlap(polygon);
	}

	public bool ReturnContainsPosition(Vector2 position)
	{
		return _worldRegion.ReturnContainsPosition(position);
	}

	public bool IsRegion(IRegion region)
	{
		if (_worldRegion != region)
		{
			return _worldRegion.IsGeneratedFromDataRegion(region);
		}
		return true;
	}

	public Vector2 ReturnPositionInRegion()
	{
		return Bounds.center;
	}

	public void PopulateNeighorScoutingLandmarkNodes(List<TileGeneratorNode> scoutingLandmarkNodes)
	{
		if (_neighbors.IsNullOrEmpty())
		{
			return;
		}
		foreach (TileGeneratorRegion neighbor in _neighbors)
		{
			foreach (TileGeneratorNode landmark in neighbor.Landmarks)
			{
				if (landmark.Spawner is LandmarkSpawner { LandmarkBehaviour: ActionsBehaviour landmarkBehaviour } && landmarkBehaviour.ReturnHasLandmarkActionReference<LandmarkActionRevealMap>())
				{
					scoutingLandmarkNodes.Add(landmark);
				}
			}
		}
	}
}
