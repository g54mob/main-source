using System.Collections.Generic;
using UnityEngine;

public struct RoomConKey
{
	public readonly PathNode<Vector3> From;

	public readonly PathNode<Vector3> To;

	public RoomConKey(PathNode<Vector3> from, PathNode<Vector3> to)
	{
		From = from;
		To = to;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is RoomConKey))
		{
			return false;
		}
		RoomConKey roomConKey = (RoomConKey)obj;
		if (EqualityComparer<PathNode<Vector3>>.Default.Equals(From, roomConKey.From))
		{
			return EqualityComparer<PathNode<Vector3>>.Default.Equals(To, roomConKey.To);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (-1781160927 * -1521134295 + EqualityComparer<PathNode<Vector3>>.Default.GetHashCode(From)) * -1521134295 + EqualityComparer<PathNode<Vector3>>.Default.GetHashCode(To);
	}

	public override string ToString()
	{
		return string.Concat(From, " -> ", To);
	}
}
