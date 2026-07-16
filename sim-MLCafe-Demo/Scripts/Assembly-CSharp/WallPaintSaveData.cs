using System;
using UnityEngine;

[Serializable]
public class WallPaintSaveData
{
	public Vector2Int roomPosition;

	public WallComponent.WallFaceDirection wall;

	public int wallIndex;

	public Color wallColor;
}
