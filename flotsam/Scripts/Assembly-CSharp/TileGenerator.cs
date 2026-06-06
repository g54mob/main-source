using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;

[CreateAssetMenu(fileName = "TileGenerator", menuName = "Flotsam/Procedural Generation/Tile Generator", order = 1)]
public class TileGenerator : TileGeneratorBase
{
	public enum PassNodeSelectors
	{
		All = 0,
		Pass = 1
	}

	[SerializeField]
	private TileGeneratorPass[] _passes;

	[SerializeField]
	private float _minimumNodeDistance;

	[SerializeField]
	private float _startAreaRadius;

	[NonSerialized]
	private int _nextPassIndex;

	[NonSerialized]
	private TileGeneratorBase _subTileGeneratorOverride;

	public bool IsStartingTile { get; private set; }

	public List<TileGeneratorNode> Nodes { get; private set; }

	public List<TileGeneratorConnection> Connections { get; private set; }

	public List<TileGeneratorPass> Passes { get; private set; }

	public List<RoadSpawner> Roads { get; private set; }

	public Dictionary<IWorldRegion, TileGeneratorRegion> Regions { get; private set; }

	public override Rect MinimumBounds
	{
		get
		{
			TryReturnBounds(out var bounds);
			return bounds;
		}
	}

	public override float Scale { get; set; } = 1f;

	public TileGeneratorPass[] EDITOR_PassAssetReferences => _passes;

	public override void Initialize(bool isStartingTile)
	{
		IsStartingTile = isStartingTile;
		Nodes = new List<TileGeneratorNode>();
		Connections = new List<TileGeneratorConnection>();
		Passes = new List<TileGeneratorPass>();
		Reset();
	}

	public void OverrideSubTileGenerator(TileGeneratorBase subTileGenerator)
	{
		_subTileGeneratorOverride = subTileGenerator;
	}

	public override IEnumerator Generate(IWorldTile worldTile)
	{
		if (worldTile == null)
		{
			Debug.LogException(new NotSupportedException($"Unable to run TileGenerator {this}, IWorldTile == NULL"));
			yield break;
		}
		yield return Generate();
		if (Regions != null)
		{
			foreach (IWorldRegion key in Regions.Keys)
			{
				worldTile.AddRegion(key);
			}
		}
		foreach (TileGeneratorNode node in Nodes)
		{
			switch (node.Spawner.Type)
			{
			case ISpawnerType.PointOfInterest:
				worldTile.AddPointOfInterestSpawner(node.Spawner as PointOfInterestSpawner);
				break;
			case ISpawnerType.Landmark:
				worldTile.AddLandmarkSpawner(node.Spawner as LandmarkSpawner);
				break;
			}
		}
		if (Roads == null)
		{
			yield break;
		}
		foreach (RoadSpawner road in Roads)
		{
			worldTile.AddRoadSpawner(road);
		}
	}

	public void Editor_Generate(int seed, IRegion dataRegion)
	{
		UnityEngine.Random.InitState(seed);
		CoroutineRunner.RunCoroutine(Generate(dataRegion));
	}

	private IEnumerator Generate(IRegion dataRegion = null)
	{
		base.StartPosition = (TryReturnTownheartStartPosition(out var position) ? position.Vector2TopDown() : default(Vector2));
		foreach (TileGeneratorPass pass in Passes)
		{
			yield return pass.Run(this, dataRegion);
		}
		_nextPassIndex = Passes.Count;
	}

	public override void Restore(IWorldTile worldTile)
	{
		foreach (TileGeneratorPass pass in Passes)
		{
			pass.Restore(worldTile);
		}
	}

	public void AddRoad(RoadSpawner road)
	{
		if (Roads == null)
		{
			Roads = new List<RoadSpawner>(64);
		}
		Roads.Add(road);
	}

	public void AddRegion(IWorldRegion region)
	{
		if (Regions == null)
		{
			Regions = new Dictionary<IWorldRegion, TileGeneratorRegion>(32);
		}
		Regions.Add(region, new TileGeneratorRegion(this, region));
	}

	public void PopulateRegionNeighbors()
	{
		foreach (TileGeneratorRegion value in Regions.Values)
		{
			value.PopulateNeighbors(Regions.Values);
		}
	}

	public void AddNode(TileGeneratorNode node, bool addToRegion = false)
	{
		Nodes.Add(node);
		if (!addToRegion)
		{
			return;
		}
		Dictionary<IWorldRegion, TileGeneratorRegion>.Enumerator enumerator = Regions.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Key.ReturnContainsPosition(node.Position))
			{
				enumerator.Current.Value.AddNode(node);
				break;
			}
		}
	}

	public void Reset()
	{
		Nodes.Clear();
		Connections.Clear();
		ClearPasses();
		if (Regions != null)
		{
			Regions.Clear();
		}
		_nextPassIndex = 0;
	}

	private void ClearPasses()
	{
		foreach (TileGeneratorPass pass in Passes)
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(pass);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(pass);
			}
		}
		Passes.Clear();
		TileGeneratorPass[] passes = _passes;
		for (int i = 0; i < passes.Length; i++)
		{
			TileGeneratorPass tileGeneratorPass = UnityEngine.Object.Instantiate(passes[i]);
			if (tileGeneratorPass is SubTileGeneratorPass subTileGeneratorPass)
			{
				subTileGeneratorPass.OverrideSubTileGenerator(_subTileGeneratorOverride);
			}
			Passes.Add(tileGeneratorPass);
		}
	}

	public bool ReturnHasPass<T>() where T : TileGeneratorPass
	{
		TileGeneratorPass[] passes = _passes;
		for (int i = 0; i < passes.Length; i++)
		{
			if (passes[i] is T)
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnHasNodes()
	{
		if (Nodes != null)
		{
			return Nodes.Count != 0;
		}
		return false;
	}

	public List<TileGeneratorNode> ReturnNodes(PassNodeSelectors selector, int pass = 0)
	{
		if (selector != PassNodeSelectors.All && selector == PassNodeSelectors.Pass)
		{
			return Passes[pass].GeneratedNodes;
		}
		return Nodes;
	}

	public List<TileGeneratorNode> ReturnNodes(IRegion dataRegion)
	{
		Regions.GetEnumerator();
		foreach (TileGeneratorRegion value in Regions.Values)
		{
			if (value.IsRegion(dataRegion))
			{
				return value.Nodes;
			}
		}
		return null;
	}

	public bool TryReturnRegionTileProperties(TileGeneratorNode node, out PointOfInterestProperties pointOfInterestProperties)
	{
		throw new NotImplementedException();
	}

	public bool TryPopulateDebugNodeDataProvider(List<IDebugMapDataProvider> dataProviders)
	{
		if (dataProviders == null)
		{
			throw new NotSupportedException();
		}
		dataProviders.Clear();
		if (dataProviders.Capacity < Nodes.Count)
		{
			dataProviders.Capacity = Nodes.Count;
		}
		if (Nodes != null)
		{
			foreach (TileGeneratorNode node in Nodes)
			{
				dataProviders.Add(node);
			}
		}
		if (Connections != null)
		{
			foreach (TileGeneratorConnection connection in Connections)
			{
				dataProviders.Add(connection);
			}
		}
		return 0 < dataProviders.Count;
	}

	public override bool TryReturnTownheartStartPosition(out Vector3 position)
	{
		foreach (TileGeneratorPass item in ReturnPassesEnumerable())
		{
			if (item is SubTileGeneratorPass subTileGeneratorPass)
			{
				return subTileGeneratorPass.TileGenerator.TryReturnTownheartStartPosition(out position);
			}
		}
		position = default(Vector3);
		return false;
	}

	public override bool TryReturnWorldMapRegionMeshAndBounds(out Mesh mesh, out Rect bounds)
	{
		foreach (TileGeneratorPass item in ReturnPassesEnumerable())
		{
			if (item is SubTileGeneratorPass subTileGeneratorPass)
			{
				return subTileGeneratorPass.TileGenerator.TryReturnWorldMapRegionMeshAndBounds(out mesh, out bounds);
			}
		}
		return base.TryReturnWorldMapRegionMeshAndBounds(out mesh, out bounds);
	}

	public bool TryReturnBounds(out Rect bounds)
	{
		bool result = false;
		bounds = default(Rect);
		foreach (TileGeneratorPass pass in Passes)
		{
			if (pass.TryReturnBounds(out var bounds2))
			{
				bounds = bounds.Add(bounds2);
				result = true;
			}
		}
		return result;
	}

	public bool ReturnIsValidPosition(Vector2 position, float minimumNodeDistance)
	{
		if (IsStartingTile && base.StartPosition.IsInRange(position, _startAreaRadius))
		{
			return false;
		}
		foreach (TileGeneratorNode node in Nodes)
		{
			if (node.Position.IsInRange(position, minimumNodeDistance))
			{
				return false;
			}
		}
		return true;
	}

	public bool ReturnPositionIsInStartingArea(Vector2 position)
	{
		if (IsStartingTile)
		{
			return base.StartPosition.IsInRange(position, _startAreaRadius);
		}
		return false;
	}

	private IEnumerable<TileGeneratorPass> ReturnPassesEnumerable()
	{
		if (Passes.IsNullOrEmpty())
		{
			return _passes;
		}
		return Passes;
	}
}
