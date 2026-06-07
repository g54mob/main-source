using System.Collections.Generic;
using UnityEngine;

public class PathNode<T>
{
	public T Point;

	private readonly int _hashcode;

	private object _tag2;

	public object Tag;

	private HashList<PathNode<T>> Connections = new HashList<PathNode<T>>();

	public bool NullWeight;

	public bool OutsideAccessible = true;

	public float Weight = 1f;

	public PathNode<T> Parent;

	public object Tag2
	{
		get
		{
			return _tag2 ?? Tag;
		}
		set
		{
			_tag2 = value;
		}
	}

	public int ConnectionCount
	{
		get
		{
			return Connections.Count;
		}
	}

	public PathNode<T> ActualNode
	{
		get
		{
			return Parent ?? this;
		}
	}

	public override int GetHashCode()
	{
		return _hashcode;
	}

	public bool AddConnection(PathNode<T> target)
	{
		return Connections.AddIfNotExists(target);
	}

	public bool RemoveConnection(PathNode<T> target)
	{
		return Connections.Remove(target);
	}

	public bool HasConnection(PathNode<T> target)
	{
		return Connections.Contains(target);
	}

	public List<PathNode<T>> GetConnections()
	{
		return Connections.GetUnderlyingList();
	}

	public void Clear()
	{
		Connections.Clear();
	}

	public PathNode(T p, object t)
	{
		Point = p;
		_hashcode = p.GetHashCode();
		Tag = t;
	}

	public PathNode(PathNode<T> pathNode)
	{
		Point = pathNode.Point;
		Tag = pathNode.Tag;
		Connections.AddRange(pathNode.Connections);
	}

	public override string ToString()
	{
		if (Tag != null)
		{
			return Tag.ToString();
		}
		return base.ToString();
	}

	public bool AllowCaching()
	{
		return false;
	}

	public bool HasCachedPath(PathNode<Vector3> p2)
	{
		PathNode<Vector3> pathNode = ActualNode as PathNode<Vector3>;
		Room room = pathNode.Tag as Room;
		if (room != null)
		{
			return room.RoomConCache.ContainsKey(new RoomConKey(pathNode, p2));
		}
		return false;
	}

	public bool FindCachedPath(PathNode<Vector3> p2, List<PathNode<Vector3>> result)
	{
		PathNode<Vector3> pathNode = ActualNode as PathNode<Vector3>;
		Room room = Tag as Room;
		RoomCon value;
		if (room != null && room.RoomConCache.TryGetValue(new RoomConKey(pathNode, p2), out value))
		{
			result.Add(pathNode);
			result.Add(value.Connection);
			if (value.SubConnection != null)
			{
				result.Add(value.SubConnection);
			}
			if (value.Room == p2)
			{
				result.Add(value.Room);
				return true;
			}
			return value.Room.FindCachedPath(p2, result);
		}
		result.Clear();
		return false;
	}
}
