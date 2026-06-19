using PugTilemap;
using UnityEngine;

public class RemoveTileOnDeathAuthoring : MonoBehaviour
{
	public TileType tileType;

	public Tileset tileset;

	[Range(0f, 1f)]
	public float removeChance;
}
