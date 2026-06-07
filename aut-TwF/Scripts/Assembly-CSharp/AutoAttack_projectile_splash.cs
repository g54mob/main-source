using UnityEngine;

public class AutoAttack_projectile_splash : AutoAttack_projectile
{
	private float splashAreaRadius = 1f;

	[Header("Debug")]
	[SerializeField]
	private GameObject debugObject;

	[SerializeField]
	private bool debug;

	protected override void OnTargetReached(Projectile projectile, GameObject target)
	{
		if (debug)
		{
			Object.Destroy(Object.Instantiate(debugObject, projectile.transform.position + Vector3.up * 0.2f, Quaternion.identity), 0.5f);
		}
		Collider[] array = Physics.OverlapSphere(projectile.transform.position, splashAreaRadius, LayerMask.GetMask("Enemy"));
		foreach (Collider collider in array)
		{
			if (collider.gameObject.tag == "Enemy" && collider.TryGetComponent<Enemy>(out var component) && tower.CombatComponent.CanTargetEnemy(component))
			{
				component.CombatComponent.DoDamage(base.gameObject, new FDamageData(abilityManager.StatsComponent.GetStat(EStats.BaseDamage), towerCC.HealthMultiplier, towerCC.ArmorMultiplier, towerCC.ShieldMultiplier));
			}
		}
	}
}
