using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;

public abstract class TileGeneratorPass : ScriptableObject
{
	public List<TileGeneratorNode> GeneratedNodes { get; protected set; }

	public List<TileGeneratorConnection> GeneratedConnections { get; protected set; }

	public abstract IEnumerator Run(TileGenerator generator, IRegion dataRegion);

	public virtual void Restore(IWorldTile worldTile)
	{
	}

	protected void InitializeGeneratedNodes(int minimumCapacity)
	{
		if (GeneratedNodes == null)
		{
			GeneratedNodes = new List<TileGeneratorNode>(minimumCapacity);
			return;
		}
		GeneratedNodes.Clear();
		if (GeneratedNodes.Capacity < minimumCapacity)
		{
			GeneratedNodes.Capacity = minimumCapacity;
		}
	}

	protected void GenerateNode(TileGenerator generator, Vector2 position)
	{
		AddGeneratedNode(new TileGeneratorNode(position), generator);
	}

	protected void AddGeneratedNode(TileGeneratorNode node, TileGenerator generator = null)
	{
		if ((bool)generator)
		{
			generator.Nodes.Add(node);
		}
		GeneratedNodes.Add(node);
	}

	protected bool RemoveGeneratedNode(TileGenerator generator, TileGeneratorNode node)
	{
		if (GeneratedNodes.Remove(node))
		{
			generator.Nodes.Remove(node);
			return true;
		}
		return false;
	}

	protected void AddConnection(TileGenerator generator, TileGeneratorNode from, TileGeneratorNode to, int tier)
	{
		TileGeneratorConnection item = new TileGeneratorConnection(from, to, tier);
		if (GeneratedConnections == null)
		{
			GeneratedConnections = new List<TileGeneratorConnection>();
		}
		foreach (TileGeneratorConnection generatedConnection in GeneratedConnections)
		{
			if ((generatedConnection.From == from || generatedConnection.To == from) && (generatedConnection.From == to || generatedConnection.To == to))
			{
				return;
			}
		}
		GeneratedConnections.Add(item);
		generator.Connections.Add(item);
	}

	public virtual bool TryReturnBounds(out Rect bounds)
	{
		bounds = default(Rect);
		return false;
	}

	protected bool HasSampleInRange(List<TileGeneratorNode> samples, Vector2 position, float range)
	{
		foreach (TileGeneratorNode sample in samples)
		{
			if (position.IsInRange(sample.Position, range))
			{
				return true;
			}
		}
		return false;
	}
}
