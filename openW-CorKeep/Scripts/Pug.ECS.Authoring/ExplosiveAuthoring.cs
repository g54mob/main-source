using UnityEngine;

public class ExplosiveAuthoring : MonoBehaviour
{
	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int damage;

	public float damageMultiplier = 1f;

	public int miningDamage;

	public float miningDamageMultiplier = 1f;

	public ObjectID explosionID;

	public int explosionVariation;

	public bool ignoreExploding;

	public bool explosionInheritsFaction;

	public bool bombInheritsFaction;

	public bool useSmallNapalmVariant;

	public ExplosionPushbackLevel explosionPushback = ExplosionPushbackLevel.Normal;

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
				miningDamage = LevelToMiningDamage(num, miningDamageMultiplier, isEnemy);
			}
		}
	}

	public static int LevelToExplosionDamage(int level, float multiplier)
	{
		return MeleeAttackStateAuthoring.LevelToDamage(level, multiplier * 3.9f, 10);
	}

	public static int LevelToMiningDamage(int level, float multiplier, bool isEnemy)
	{
		float num = (isEnemy ? 3.9f : 7f);
		return ConditionExtensions.GetConditionValueFromLevel(ConditionEffect.Mining, isNegative: false, level, multiplier * num, 1f, 1f, isTemporary: false, isHeldInHand: true, isArmor: false, isEnemy);
	}
}
