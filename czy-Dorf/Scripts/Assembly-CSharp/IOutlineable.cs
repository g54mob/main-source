using UnityEngine;

public interface IOutlineable
{
	IOutlineable[] Neighbors { get; }

	Vector3 WorldPosition { get; }

	IOutlineable GetNeighbor(int edgeIndex, Space space);
}
