using UnityEngine;

public struct Edge
{
	public Vector2Int a;

	public Vector2Int b;

	public eDoorFlags dirFromA;

	public Edge(Vector2Int a, Vector2Int b, eDoorFlags dirFromA)
	{
		this.a = default(Vector2Int);
		this.b = default(Vector2Int);
		this.dirFromA = default(eDoorFlags);
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}
}
