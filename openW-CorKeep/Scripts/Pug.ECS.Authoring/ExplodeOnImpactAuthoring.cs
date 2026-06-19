using PugTilemap;
using UnityEngine;

public class ExplodeOnImpactAuthoring : MonoBehaviour
{
	public float distanceToExplode;

	public float explodeRadius;

	public int explodeDamage;

	public float explodeDamageMultiplier = 1f;

	public bool spawnTilesOnExplode;

	public TileType tileTypeToSpawn;

	public Tileset tilesetToSpawn;

	[HideInInspector]
	public AreaLevelAuthoring level;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (level != null)
			{
				int num = level.CalculateLevel();
				explodeDamage = MeleeAttackStateAuthoring.LevelToDamage(num, explodeDamageMultiplier);
			}
		}
	}
}
