using System;
using UnityEngine;

[Serializable]
public class SerializedMapCell
{
	public Vector2Int position;

	public int type;

	public SerializedMapCell(Vector2Int position, int type = -1)
	{
		this.position = position;
		this.type = type;
	}
}
