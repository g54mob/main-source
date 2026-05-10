using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GE_ProjectileBounce : GameplayEffect
{
	private class FProjectileBounceInfo
	{
		public Projectile projectile;

		public int bounces;

		public List<Enemy> hitEnemies;

		public FProjectileBounceInfo(Projectile projectile)
		{
			this.projectile = projectile;
			bounces = 0;
			hitEnemies = new List<Enemy>();
		}
	}

	private GE_ProjectileBounceData projectileBounceData;

	private TowerCombatComponent towerCombatComponent;

	private AbilityManager abilityManager;

	private List<FProjectileBounceInfo> shotProjectiles;

	protected override void OnInitEffect()
	{
		shotProjectiles = new List<FProjectileBounceInfo>();
		projectileBounceData = base.EffectData as GE_ProjectileBounceData;
		towerCombatComponent = base.Owner.GetComponent<TowerCombatComponent>();
		abilityManager = base.Owner.GetComponent<AbilityManager>();
		towerCombatComponent.onPreDamageEnemy += OnProjectilePreDamageEnemy;
		(abilityManager.GetAutoAttackAbility() as AutoAttack_projectile).onProjectileShot += OnProjectileShot;
	}

	protected override void OnEndEffect()
	{
		towerCombatComponent.onPreDamageEnemy -= OnProjectilePreDamageEnemy;
		(abilityManager.GetAutoAttackAbility() as AutoAttack_projectile).onProjectileShot -= OnProjectileShot;
	}

	private void OnProjectileShot(Projectile projectile)
	{
		shotProjectiles.Add(new FProjectileBounceInfo(projectile));
		projectile.DestroyOnReachTarget = false;
		projectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Combine(projectile.onTargetReached, new Action<Projectile, GameObject>(OnProjectileReachTarget));
		projectile.onDestroy = (Action<Projectile>)Delegate.Combine(projectile.onDestroy, new Action<Projectile>(OnProjectileDestroyed));
	}

	private void OnProjectilePreDamageEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 vector, bool isMainDamage, object auxData)
	{
		if (auxData is Projectile)
		{
			FProjectileBounceInfo fProjectileBounceInfo = shotProjectiles.Find((FProjectileBounceInfo x) => x.projectile == auxData as Projectile);
			if (fProjectileBounceInfo != null && fProjectileBounceInfo.bounces > 0)
			{
				data.damage *= projectileBounceData.BounceDamageMultiplier;
			}
		}
	}

	private void OnProjectileReachTarget(Projectile projectile, GameObject target)
	{
		FProjectileBounceInfo fProjectileBounceInfo = shotProjectiles.Find((FProjectileBounceInfo x) => x.projectile == projectile);
		GameObject gameObject = null;
		if (fProjectileBounceInfo.bounces < projectileBounceData.Bounces)
		{
			fProjectileBounceInfo.bounces++;
			if ((bool)target)
			{
				fProjectileBounceInfo.hitEnemies.Add(target.GetComponentInParent<Enemy>());
			}
			Collider[] array = (from c in Physics.OverlapSphere(projectile.transform.position, projectileBounceData.BounceRadius, LayerMask.GetMask("Enemy"))
				orderby Vector3.SqrMagnitude(projectile.transform.position - c.transform.position)
				select c).ToArray();
			foreach (Collider collider in array)
			{
				if (collider.gameObject.tag == "Enemy" && collider.TryGetComponent<Enemy>(out var component) && !fProjectileBounceInfo.hitEnemies.Contains(component) && towerCombatComponent.CanTargetEnemy(component))
				{
					gameObject = collider.gameObject;
					break;
				}
			}
		}
		if ((bool)gameObject && (bool)abilityManager)
		{
			projectile.transform.rotation = Quaternion.LookRotation(gameObject.transform.position - projectile.transform.position);
			projectile.ShootProjectileToTarget(gameObject.GetComponent<CombatComponent>().TargetObject, abilityManager.GetAutoAttackAbility().gameObject);
		}
		else
		{
			projectile.DestroyProjectile();
		}
	}

	private void OnProjectileDestroyed(Projectile projectile)
	{
		shotProjectiles.Remove(shotProjectiles.Find((FProjectileBounceInfo x) => x.projectile == projectile));
	}
}
