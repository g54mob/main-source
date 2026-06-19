using UnityEngine;

public class ExplodeStateAuthoring : MonoBehaviour
{
	public float distanceToExplode = 1f;

	public float explodeDuration;

	public ObjectID explosionID;

	public int explosionVariation;

	public float minHealthRatioToExplode = 1f;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int damage;

	public float damageMultiplier = 1f;

	public int tileDamage;

	public float tileDamageMultiplier = 1f;

	public bool explodeOnInitialization = true;

	public bool explodeOnDeath;

	public bool dropLootOnDestroy;

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
				damage = LevelToExplosionDamage(num, damageMultiplier);
				bool isEnemy = GetComponent<EnemyAuthoring>() != null;
				tileDamage = LevelToMiningDamage(num, tileDamageMultiplier, isEnemy);
			}
		}
	}

	public static int LevelToExplosionDamage(int level, float multiplier)
	{
		return ExplosiveAuthoring.LevelToExplosionDamage(level, multiplier * 0.5f);
	}

	public static int LevelToMiningDamage(int level, float multiplier, bool isEnemy)
	{
		return ExplosiveAuthoring.LevelToMiningDamage(level, multiplier * 0.5f, isEnemy);
	}
}
