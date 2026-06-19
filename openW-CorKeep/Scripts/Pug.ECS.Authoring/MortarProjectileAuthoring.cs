using NaughtyAttributes;
using PugTilemap;
using UnityEngine;

[RequireComponent(typeof(BehaviourTagsAuthoring))]
public class MortarProjectileAuthoring : MonoBehaviour
{
	[Header("General")]
	public float radius;

	public bool useDefaultTimings;

	[ShowIf("useDefaultTimings")]
	public float goUpTime;

	[ShowIf("useDefaultTimings")]
	public float airTime;

	[ShowIf("useDefaultTimings")]
	public float goDownTime;

	[ShowIf("useDefaultTimings")]
	public float explodeTime;

	[Header("Airborne Effect")]
	public bool spawnTilesOnGoingDown;

	[ShowIf("spawnTilesOnGoingDown")]
	public TileType tileTypeToSpawnOnGoingDown;

	[ShowIf("spawnTilesOnGoingDown")]
	public Tileset tilesetToSpawnOnGoingDown;

	public float spawnTilesOnGoingDownExtraRadius;

	public bool canSpawnTilesOnWaterOrPits;

	[Header("Damage Effect")]
	public bool bypassMaxDamagePerHit;

	public bool isMagic;

	public float pushback;

	public bool checkVisibility;

	public bool hitTiles;

	public bool spawnTilesOnLand;

	[ShowIf("spawnTilesOnLand")]
	public TileType tileTypeToSpawn;

	[ShowIf("spawnTilesOnLand")]
	public Tileset tilesetToSpawn;

	public bool removeTilesOnLand;

	public bool randomizeEdgeForTilesToSpawn;

	[ShowIf("removeTilesOnLand")]
	public TileType tileTypeToRemove;

	[ShowIf("removeTilesOnLand")]
	public Tileset tilesetToRemove;

	public bool isPredicted;

	public bool skipWallAndRootsLootDropOnDestroy = true;

	public ObjectID spawnNapalmObjectID;

	public int spawnNapalmVariation;
}
