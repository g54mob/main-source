using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Events;

public class TileGeneratorNode : IDebugMapDataProvider
{
	public DebugMapDataProviderType Type => DebugMapDataProviderType.Node;

	public Vector2 Position { get; private set; }

	public Vector3 WorldPosition { get; private set; }

	public TileGeneratorNode Parent { get; private set; }

	public bool Locked { get; private set; }

	public ISpawner Spawner { get; private set; }

	public Sprite Icon
	{
		get
		{
			if (Spawner != null)
			{
				return Spawner.Icon;
			}
			return null;
		}
	}

	public string Label => Position.ToString();

	public bool IsLeaf { get; private set; }

	public int LeafCount { get; private set; }

	public List<TileGeneratorNode> Neighbors { get; private set; }

	public float LeafChance { get; private set; }

	public UnityEvent OnDestroyed { get; private set; }

	public TileGeneratorNode(Vector2 position, TileGeneratorNode parent = null, bool isLeaf = false)
	{
		Position = position;
		WorldPosition = new Vector3(position.x, 0f, position.y);
		Parent = parent;
		OnDestroyed = new UnityEvent();
		if (Parent != null && isLeaf)
		{
			IsLeaf = true;
			Parent.AddLeaf();
		}
	}

	public void Lock()
	{
		Locked = true;
	}

	public void SetSpawner(ISpawner spawner, bool setLocked = true)
	{
		Spawner = spawner;
		Locked = setLocked;
	}

	public void Dispose()
	{
		if (IsLeaf)
		{
			Parent.RemoveLeaf();
		}
	}

	public void Destroy()
	{
		OnDestroyed.Invoke();
		OnDestroyed.RemoveAllListeners();
	}

	public bool TrySetLeafChance(RegionPointOfInterestSettings settings)
	{
		if (!IsLeaf && settings.TryEvaluateLeafChance(LeafCount, out var leafChance))
		{
			LeafChance = leafChance;
			return true;
		}
		LeafChance = 0f;
		return false;
	}

	private void AddLeaf()
	{
		LeafCount++;
	}

	private void RemoveLeaf()
	{
		LeafCount--;
	}

	public GameObject ReturnDebugVisual(DebugMap debugMap)
	{
		DebugMapNode debugMapNode = UnityEngine.Object.Instantiate(debugMap.NodePrefab, debugMap.Ocean);
		debugMapNode.Initialize(this);
		return debugMapNode.gameObject;
	}

	public void AddClosestNeightbor(List<TileGeneratorNode> nodes)
	{
		float num = float.MaxValue;
		TileGeneratorNode tileGeneratorNode = null;
		foreach (TileGeneratorNode node in nodes)
		{
			if (node != this)
			{
				float num2 = Position.DistanceToSquared(node.Position);
				if (num2 < num)
				{
					num = num2;
					tileGeneratorNode = node;
				}
			}
		}
		if (tileGeneratorNode == null)
		{
			throw new NotSupportedException();
		}
		AddNeighbor(tileGeneratorNode);
		tileGeneratorNode.AddNeighbor(this);
	}

	private void AddNeighbor(TileGeneratorNode neighbor)
	{
		if (Neighbors == null)
		{
			Neighbors = new List<TileGeneratorNode>(5);
		}
		Neighbors.AddUnique(neighbor);
	}
}
