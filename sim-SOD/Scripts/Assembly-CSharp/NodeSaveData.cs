using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NodeSaveData
{
	public Vector2Int f_c;

	public int f_h;

	public NewNode.FloorTileType f_t;

	public string f_r;

	public List<WallSaveData> w_d;
}
