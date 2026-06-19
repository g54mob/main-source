using UnityEngine;

public struct PathPosition
{
	public Vector3 position;

	public ulong? denUID;

	public bool exteriorNode;

	public PathPosition(Vector3 pos, ulong? newDenUID = null, bool exterior = true)
	{
		position = pos;
		denUID = newDenUID;
		exteriorNode = exterior;
	}
}
