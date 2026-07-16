using UnityEngine;

[CreateAssetMenu(fileName = "RelicDoubleExplosions", menuName = "Upgrade/Relic/DoubleExplosions")]
public class RelicDoubleExplosions : EnhancementUpgrade
{
	[SerializeField]
	private float prob = 0.3f;

	public override void ApplyUpgrade()
	{
		CombatManager.Instance.ExplosionDestroyed += OnExplosionDestroyed;
	}

	private void OnExplosionDestroyed(Explosion explosion)
	{
		Unit sourceUnit = explosion.SourceUnit;
		if ((object)sourceUnit != null && !sourceUnit.IsEnemy && ProbUtils.CheckWithLuck(prob))
		{
			Object.Instantiate(explosion.gameObject, explosion.transform.position + (Vector3)Random.insideUnitCircle * explosion.Radius, Quaternion.identity).GetComponent<Explosion>().Initialize(null, explosion.Radius, explosion.EnemyDamage * 0.3f);
		}
	}
}
