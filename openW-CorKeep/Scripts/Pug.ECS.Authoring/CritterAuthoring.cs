using System.Collections.Generic;
using NaughtyAttributes;
using PugTilemap;
using UnityEngine;

[DisallowMultipleComponent]
public class CritterAuthoring : MonoBehaviour
{
	public bool isFlying;

	public bool spawnContinuously;

	public SpawnType spawnType;

	[ShowIf("spawnType", SpawnType.Biome)]
	public List<Biome> biomesToSpawnIn;

	[ShowIf("spawnType", SpawnType.Tileset)]
	public List<Tileset> tilesetsToSpawnIn;

	public bool isPersistent;

	public bool allowLargerAmount;
}
