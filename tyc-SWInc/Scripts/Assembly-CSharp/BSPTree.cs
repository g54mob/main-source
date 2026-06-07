using System;
using System.Collections.Generic;
using UnityEngine;

public class BSPTree<T>
{
	public int MaxNodes;

	public int MaxLevels;

	public List<T> Nodes = new List<T>();

	public Func<T, bool, float, int> Comparer;

	public Func<List<T>, bool, float> Median;

	public float Middle;

	public bool Vertical;

	public BSPTree<T> Smaller;

	public BSPTree<T> Larger;

	public BSPTree<T> Parent;

	public BSPTree(int maxNodes, int maxLevels, Func<T, bool, float, int> comp, Func<List<T>, bool, float> med, BSPTree<T> parent = null)
	{
		MaxNodes = maxNodes;
		MaxLevels = maxLevels;
		Comparer = comp;
		Median = med;
		Parent = parent;
	}

	public List<T> GetNodes(Vector2 p)
	{
		lock (this)
		{
			return GetNodesSub(p);
		}
	}

	private List<T> GetNodesSub(Vector2 p)
	{
		if (Smaller != null)
		{
			if (!((Vertical ? p.x : p.y) > Middle))
			{
				return Smaller.GetNodesSub(p);
			}
			return Larger.GetNodesSub(p);
		}
		return Nodes;
	}

	private bool CheckMiddle()
	{
		if (Parent != null && Parent.Parent != null)
		{
			return Parent.Parent.Middle.Appx(Middle, 0.001f);
		}
		return false;
	}

	public void AddNode(T node)
	{
		lock (this)
		{
			AddNodeSub(node);
		}
	}

	private void AddNodeSub(T node)
	{
		if (Smaller != null)
		{
			int num = Comparer(node, Vertical, Middle);
			if (num <= 0)
			{
				Smaller.AddNodeSub(node);
			}
			if (num >= 0)
			{
				Larger.AddNodeSub(node);
			}
			return;
		}
		Nodes.Add(node);
		if (Nodes.Count < MaxNodes || MaxLevels <= 0)
		{
			return;
		}
		Middle = Median(Nodes, Vertical);
		if (CheckMiddle())
		{
			MaxLevels = 0;
			return;
		}
		Smaller = new BSPTree<T>(MaxNodes, MaxLevels - 1, Comparer, Median, this);
		Smaller.Vertical = !Vertical;
		Larger = new BSPTree<T>(MaxNodes, MaxLevels - 1, Comparer, Median, this);
		Larger.Vertical = !Vertical;
		for (int i = 0; i < Nodes.Count; i++)
		{
			AddNodeSub(Nodes[i]);
		}
		Nodes.Clear();
	}
}
