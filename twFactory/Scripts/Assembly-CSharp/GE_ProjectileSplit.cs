using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GE_ProjectileSplit : GameplayEffect
{
	private GE_ProjectileSplitData projectileSplitData;

	private TowerCombatComponent towerCC;

	private AbilityManager abilityManager;

	private List<Projectile> shotSplitProjectiles;

	protected override void OnInitEffect()
	{
		shotSplitProjectiles = new List<Projectile>();
		projectileSplitData = base.EffectData as GE_ProjectileSplitData;
		towerCC = base.Owner.GetComponent<TowerCombatComponent>();
		abilityManager = base.Owner.GetComponent<AbilityManager>();
		(abilityManager.GetAutoAttackAbility() as AutoAttack_projectile).onProjectileShot += OnMainProjectileShot;
	}

	protected override void OnEndEffect()
	{
		(abilityManager.GetAutoAttackAbility() as AutoAttack_projectile).onProjectileShot -= OnMainProjectileShot;
		foreach (Projectile shotSplitProjectile in shotSplitProjectiles)
		{
			shotSplitProjectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Remove(shotSplitProjectile.onTargetReached, new Action<Projectile, GameObject>(OnSplitProjectileReachTarget));
		}
	}

	private void OnMainProjectileShot(Projectile projectile)
	{
		projectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Combine(projectile.onTargetReached, new Action<Projectile, GameObject>(OnMainProjectileReachTarget));
	}

	private void OnMainProjectileReachTarget(Projectile projectile, GameObject target)
	{
		if (!abilityManager)
		{
			return;
		}
		int num = 0;
		Rigidbody targetRB = null;
		if (target != null)
		{
			targetRB = target.GetComponentInParent<Rigidbody>();
		}
		Collider[] array = (from c in Physics.OverlapSphere(projectile.transform.position, projectileSplitData.SplitRadius, LayerMask.GetMask("Enemy"))
			orderby ((bool)targetRB && c.attachedRigidbody == targetRB) ? float.MaxValue : Vector3.SqrMagnitude(projectile.transform.position - c.transform.position)
			select c).ToArray();
		List<Enemy> list = new List<Enemy>();
		Collider[] array2 = array;
		for (int num2 = 0; num2 < array2.Length; num2++)
		{
			if (array2[num2].TryGetComponent<Enemy>(out var component) && component.CombatComponent.IsAlive() && towerCC.CanTargetEnemy(component))
			{
				list.Add(component);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		while (num < projectileSplitData.SplitAmount)
		{
			foreach (Enemy item in list)
			{
				if (num >= projectileSplitData.SplitAmount)
				{
					break;
				}
				PrepareProjectile(projectile, item).ShootProjectileToTarget(item.CombatComponent.TargetObject, abilityManager.GetAutoAttackAbility().gameObject);
				num++;
			}
		}
	}

	protected virtual Projectile PrepareProjectile(Projectile mainProjectile, Enemy enemy)
	{
		Vector3 vector = mainProjectile.transform.position + UnityEngine.Random.onUnitSphere * UnityEngine.Random.Range(projectileSplitData.MinMaxProjectileStartDistance.x, projectileSplitData.MinMaxProjectileStartDistance.y);
		Projectile projectile = UnityEngine.Object.Instantiate(projectileSplitData.UseCustomProjectile ? projectileSplitData.ProjectilePrefab : mainProjectile, vector, Quaternion.LookRotation(vector - mainProjectile.transform.position));
		projectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Combine(projectile.onTargetReached, new Action<Projectile, GameObject>(OnSplitProjectileReachTarget));
		projectile.onDestroy = (Action<Projectile>)Delegate.Combine(projectile.onDestroy, new Action<Projectile>(OnSplitProjectileDestroyed));
		return projectile;
	}

	private void OnSplitProjectileReachTarget(Projectile projectile, GameObject target)
	{
		Enemy enemy = null;
		if ((bool)target)
		{
			enemy = target.GetComponentInParent<Enemy>();
		}
		FDamageData damageData = new FDamageData(abilityManager.StatsComponent.GetStat(EStats.BaseDamage) * projectileSplitData.SplitDamageMultiplier, towerCC.HealthMultiplier, towerCC.ArmorMultiplier, towerCC.ShieldMultiplier);
		if ((bool)(abilityManager.CombatComponent as TowerCombatComponent))
		{
			(abilityManager.CombatComponent as TowerCombatComponent).DoDamageToEnemy(enemy, damageData, projectile.transform.position, projectile);
		}
	}

	private void OnSplitProjectileDestroyed(Projectile projectile)
	{
		shotSplitProjectiles.Remove(projectile);
	}
}
