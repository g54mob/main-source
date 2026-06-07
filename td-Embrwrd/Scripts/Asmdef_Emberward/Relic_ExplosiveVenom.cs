public class Relic_ExplosiveVenom : RelicTemplate_MonsterHitBased
{
	private int damage;

	private float cooldown;

	private float cooldownTimer;

	private const float explosionRange = 2f;

	protected override void OnMonsterHitProc(AMonsterBase monster, int value, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}
}
