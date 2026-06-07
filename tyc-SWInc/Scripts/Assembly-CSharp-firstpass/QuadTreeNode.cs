using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class QuadTreeNode<T> where T : IHasVector
{
	public readonly Rect Bounds;

	public readonly List<T> Contents = new List<T>();

	private readonly List<QuadTreeNode<T>> _nodes = new List<QuadTreeNode<T>>(4);

	public readonly QuadTree<T> Parent;

	public readonly QuadTreeNode<T> NodeParent;

	public readonly int Depth;

	private static float Epsilon = 0.001f;

	public int Count
	{
		get
		{
			int num = 0;
			for (int i = 0; i < _nodes.Count; i++)
			{
				num += _nodes[i].Count;
			}
			return num + Contents.Count;
		}
	}

	public QuadTreeNode(Rect bounds, QuadTree<T> parent, QuadTreeNode<T> nodeParent, int depth)
	{
		Bounds = bounds;
		Parent = parent;
		NodeParent = nodeParent;
		Depth = depth;
	}

	public static bool Intersects(Rect r1, Rect r2)
	{
		if (!(r1.xMax < r2.xMin - Epsilon) && !(r1.yMax < r2.yMin - Epsilon) && !(r1.xMin > r2.xMax + Epsilon))
		{
			return !(r1.yMin > r2.yMax + Epsilon);
		}
		return false;
	}

	public static bool Contains(Rect rect, float x, float y)
	{
		if (x >= rect.xMin - Epsilon && x <= rect.xMax + Epsilon && y >= rect.yMin - Epsilon)
		{
			return y <= rect.yMax + Epsilon;
		}
		return false;
	}

	public static bool Contains(Rect rect, Vector2 v)
	{
		if (v.x >= rect.xMin - Epsilon && v.x <= rect.xMax + Epsilon && v.y >= rect.yMin - Epsilon)
		{
			return v.y <= rect.yMax + Epsilon;
		}
		return false;
	}

	public static bool Contains(Rect r1, Rect r2)
	{
		if (Contains(r1, r2.xMin, r2.yMin))
		{
			return Contains(r1, r2.xMax, r2.yMax);
		}
		return false;
	}

	public void Query(Rect queryArea, List<T> result)
	{
		for (int i = 0; i < Contents.Count; i++)
		{
			if (Contains(queryArea, Contents[i].GetPos()))
			{
				result.Add(Contents[i]);
			}
		}
		for (int j = 0; j < _nodes.Count; j++)
		{
			QuadTreeNode<T> quadTreeNode = _nodes[j];
			if (Contains(quadTreeNode.Bounds, queryArea))
			{
				quadTreeNode.Query(queryArea, result);
				break;
			}
			if (Contains(queryArea, quadTreeNode.Bounds))
			{
				quadTreeNode.SubTreeContents(result);
			}
			else if (Intersects(quadTreeNode.Bounds, queryArea))
			{
				quadTreeNode.Query(queryArea, result);
			}
		}
	}

	public IEnumerable<T> Query(Rect queryArea)
	{
		for (int i = 0; i < Contents.Count; i++)
		{
			if (Contains(queryArea, Contents[i].GetPos()))
			{
				yield return Contents[i];
			}
		}
		for (int i = 0; i < _nodes.Count; i++)
		{
			QuadTreeNode<T> quadTreeNode = _nodes[i];
			if (Contains(quadTreeNode.Bounds, queryArea))
			{
				foreach (T item in quadTreeNode.Query(queryArea))
				{
					yield return item;
				}
				break;
			}
			if (Contains(queryArea, quadTreeNode.Bounds))
			{
				foreach (T item2 in quadTreeNode.SubTreeContents())
				{
					yield return item2;
				}
			}
			else
			{
				if (!Intersects(quadTreeNode.Bounds, queryArea))
				{
					continue;
				}
				foreach (T item3 in quadTreeNode.Query(queryArea))
				{
					yield return item3;
				}
			}
		}
	}

	public void SubTreeContents(List<T> result)
	{
		for (int i = 0; i < Contents.Count; i++)
		{
			result.Add(Contents[i]);
		}
		for (int j = 0; j < _nodes.Count; j++)
		{
			_nodes[j].SubTreeContents(result);
		}
	}

	public IEnumerable<T> SubTreeContents()
	{
		for (int i = 0; i < Contents.Count; i++)
		{
			yield return Contents[i];
		}
		for (int i = 0; i < _nodes.Count; i++)
		{
			foreach (T item in _nodes[i].SubTreeContents())
			{
				yield return item;
			}
		}
	}

	public bool Insert(T item)
	{
		if (!Contains(Bounds, item.GetPos()))
		{
			Debug.LogError("Ignore:Item is out of the bounds of this quadtree node of type: " + typeof(T).ToString());
			return false;
		}
		if (Contents.Count == Parent.MaxNodes)
		{
			CreateSubNodes();
		}
		for (int i = 0; i < _nodes.Count; i++)
		{
			QuadTreeNode<T> quadTreeNode = _nodes[i];
			if (Contains(quadTreeNode.Bounds, item.GetPos()))
			{
				return quadTreeNode.Insert(item);
			}
		}
		if (_nodes.Count > 0)
		{
			Debug.LogError("Feature could not be added to a child of this quadtree node of type: " + typeof(T).ToString());
			StringBuilder stringBuilder = new StringBuilder();
			Vector2 pos = item.GetPos();
			stringBuilder.AppendLine(pos.x + ";" + pos.y);
			stringBuilder.AppendLine(Bounds.xMin + ";" + Bounds.yMin + ";" + Bounds.xMax + ";" + Bounds.yMax);
			foreach (QuadTreeNode<T> node in _nodes)
			{
				stringBuilder.AppendLine(node.Bounds.xMin + ";" + node.Bounds.yMin + ";" + node.Bounds.xMax + ";" + node.Bounds.yMax);
			}
			stringBuilder.AppendLine(Depth.ToString());
			MiscMsg.SendMsg("Quadtree feature", stringBuilder.ToString());
			return false;
		}
		Parent.ItemLocation[item] = this;
		Contents.Add(item);
		return true;
	}

	private void UpdateChildren()
	{
		for (int i = 0; i < _nodes.Count; i++)
		{
			if (_nodes[i].Count > 0)
			{
				return;
			}
		}
		_nodes.Clear();
		if (NodeParent != null)
		{
			NodeParent.UpdateChildren();
		}
	}

	public void Remove(T item)
	{
		Contents.Remove(item);
		if (Contents.Count == 0 && NodeParent != null)
		{
			NodeParent.UpdateChildren();
		}
	}

	public void ForEach(Action<QuadTreeNode<T>> action)
	{
		action(this);
		for (int i = 0; i < _nodes.Count; i++)
		{
			_nodes[i].ForEach(action);
		}
	}

	private void CreateSubNodes()
	{
		if (Depth == Parent.MaxDepth || Bounds.height * Bounds.width <= Parent.MinArea)
		{
			return;
		}
		if (_nodes.Count > 0)
		{
			Debug.LogError("Tried to expand already expanded quadtree node of type: " + typeof(T).ToString());
			return;
		}
		float num = Bounds.width / 2f;
		float num2 = Bounds.height / 2f;
		QuadTreeNode<T> quadTreeNode = new QuadTreeNode<T>(new Rect(Bounds.x, Bounds.y, num + 0.01f, num2 + 0.01f), Parent, this, Depth + 1);
		QuadTreeNode<T> quadTreeNode2 = new QuadTreeNode<T>(new Rect(Bounds.x, Bounds.y + num2, num + 0.01f, num2 + 0.01f), Parent, this, Depth + 1);
		QuadTreeNode<T> quadTreeNode3 = new QuadTreeNode<T>(new Rect(Bounds.x + num, Bounds.y, num + 0.01f, num2 + 0.01f), Parent, this, Depth + 1);
		QuadTreeNode<T> quadTreeNode4 = new QuadTreeNode<T>(new Rect(Bounds.x + num, Bounds.y + num2, num + 0.01f, num2 + 0.01f), Parent, this, Depth + 1);
		_nodes.Add(quadTreeNode);
		_nodes.Add(quadTreeNode2);
		_nodes.Add(quadTreeNode3);
		_nodes.Add(quadTreeNode4);
		for (int i = 0; i < Contents.Count; i++)
		{
			T item = Contents[i];
			Vector2 pos = item.GetPos();
			if (pos.x < Bounds.x + num)
			{
				if (pos.y < Bounds.y + num2)
				{
					quadTreeNode.Insert(item);
				}
				else
				{
					quadTreeNode2.Insert(item);
				}
			}
			else if (pos.y < Bounds.y + num2)
			{
				quadTreeNode3.Insert(item);
			}
			else
			{
				quadTreeNode4.Insert(item);
			}
		}
		Contents.Clear();
	}
}
