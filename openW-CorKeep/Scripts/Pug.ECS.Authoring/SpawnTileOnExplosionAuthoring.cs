using PugTilemap;
using UnityEngine;

[RequireComponent(typeof(ExplosionAuthoring))]
public class SpawnTileOnExplosionAuthoring : MonoBehaviour
{
	public float duration;

	public TileType tileType;

	public Tileset tileset;

	public bool spawnRequiresWalkable;
}
