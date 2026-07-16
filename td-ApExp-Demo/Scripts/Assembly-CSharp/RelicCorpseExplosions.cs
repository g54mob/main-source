using UnityEngine;

[CreateAssetMenu(fileName = "RelicCorpseExplosions", menuName = "Upgrade/Relic/CorpseExplosions")]
public class RelicCorpseExplosions : EnhancementUpgrade
{
	[SerializeField]
	private float maxHealthAsDamageMult = 0.25f;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		CombatManager.Instance.ExplosionSpawned += OnExplosionSpawned;
	}

	private void OnExplosionSpawned(Explosion explosion)
	{
		if (explosion.SourceUnit == null || !explosion.SourceUnit.IsEnemy)
		{
			return;
		}
		float num = explosion.SourceUnit.HealthComponent.HealthMax * maxHealthAsDamageMult;
		Debug.DrawRay(explosion.transform.position, Vector3.up * explosion.Radius, Color.yellow, 1f);
		for (int i = 0; i < EnemyManager.Instance.Enemies.Count; i++)
		{
			EnemyBase enemyBase = EnemyManager.Instance.Enemies[i];
			if (!(enemyBase == null))
			{
				float magnitude = (enemyBase.transform.position - explosion.transform.position).magnitude;
				if (magnitude != 0f && !(magnitude > explosion.Radius))
				{
					enemyBase.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(null, enemyBase.HealthComponent, 0f - num, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
				}
			}
		}
	}
}
