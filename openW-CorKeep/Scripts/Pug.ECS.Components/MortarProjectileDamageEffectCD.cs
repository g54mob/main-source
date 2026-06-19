using PugTilemap;
using Unity.Entities;
using Unity.NetCode;

public struct MortarProjectileDamageEffectCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int damage;

	[GhostField]
	public int tileDamage;

	public bool spawnTilesOnLand;

	public TileType tileTypeToSpawn;

	public Tileset tilesetToSpawn;

	public bool removeTilesOnLand;

	public TileType tileTypeToRemove;

	public Tileset tilesetToRemove;

	public float pushback;

	public bool hitTiles;

	public bool skipWallAndRootsLootDropOnDestroy;

	public bool checkVisibility;

	public bool bypassMaxDamagePerHit;

	public bool isMagic;

	public bool isPredicted;

	public ObjectID spawnNapalmObjectID;

	public int spawnNapalmVariation;
}
