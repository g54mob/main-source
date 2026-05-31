using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class MiniGameTileBase
{
	public string nameBlock;

	public int id;

	public int dropID;

	[HideInInspector]
	public bool background;

	public Tile[] tile;
}
