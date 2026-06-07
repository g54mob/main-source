using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack_projectile : TowerAutoAttack
{
	[SerializeField]
	private Projectile projectile;

	[SerializeField]
	[Tooltip("Should it shoot the projectile on activate or be driven by an animation event?")]
	private bool shootOnActivate = true;

	private Transform shootTransform;

	private Vector3? lastTargetPosition;

	private Coroutine updateLastTargetPositionCoroutine;

	protected TowerCombatComponent towerCC;

	protected Tower tower;

	private List<Projectile> shotProjectiles;

	public event Action<Projectile> onProjectileShot;

	protected override void Awake()
	{
		base.Awake();
		shotProjectiles = new List<Projectile>();
	}

	protected override void Start()
	{
		base.Start();
		towerCC = abilityManager.CombatComponent as TowerCombatComponent;
		tower = abilityManager.GetComponent<Tower>();
		shootTransform = towerCC.ShootTransform;
		if (!shootOnActivate)
		{
			abilityManager.AnimationComponent.onAnimationShoot += OnAnimationShoot;
		}
	}

	private void OnDestroy()
	{
		foreach (Projectile shotProjectile in shotProjectiles)
		{
			shotProjectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Remove(shotProjectile.onTargetReached, new Action<Projectile, GameObject>(OnTargetReached));
		}
	}

	protected override void OnActivate(FActiveAbilityInputData inputData)
	{
		if (shootOnActivate)
		{
			ShootProjectile(inputData.target);
		}
		else
		{
			this.StartCoroutineCheckingVar(UpdateLastTargetPositionCoroutine(), ref updateLastTargetPositionCoroutine);
		}
		PlayAnimation();
		ApplyCooldown();
		EndAbility();
	}

	protected virtual Projectile PrepareProjectile()
	{
		Projectile projectile = UnityEngine.Object.Instantiate(this.projectile, shootTransform.position, shootTransform.rotation);
		shotProjectiles.Add(projectile);
		projectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Combine(projectile.onTargetReached, new Action<Projectile, GameObject>(OnTargetReached));
		projectile.onDestroy = (Action<Projectile>)Delegate.Combine(projectile.onDestroy, new Action<Projectile>(OnProjectileDestroyed));
		return projectile;
	}

	protected virtual void ShootProjectile(CombatComponent target)
	{
		Projectile projectile = PrepareProjectile();
		projectile.ShootProjectileToTarget(target.TargetObject, base.gameObject);
		this.onProjectileShot?.Invoke(projectile);
	}

	protected virtual void ShootProjectileToPosition(Vector3 position)
	{
		Projectile projectile = PrepareProjectile();
		projectile.ShootProjectileToPosition(position, base.gameObject);
		this.onProjectileShot?.Invoke(projectile);
	}

	private IEnumerator UpdateLastTargetPositionCoroutine()
	{
		while ((bool)tower.Target && tower.Target.CombatComponent.IsAlive())
		{
			lastTargetPosition = tower.Target.transform.position;
			yield return null;
		}
		updateLastTargetPositionCoroutine = null;
	}

	protected virtual void OnTargetReached(Projectile projectile, GameObject target)
	{
		Enemy enemy = null;
		if ((bool)target)
		{
			enemy = target.GetComponentInParent<Enemy>();
		}
		FDamageData damageData = new FDamageData(abilityManager.StatsComponent.GetStat(EStats.BaseDamage), towerCC.HealthMultiplier, towerCC.ArmorMultiplier, towerCC.ShieldMultiplier);
		(abilityManager.CombatComponent as TowerCombatComponent).DoDamageToEnemy(enemy, damageData, projectile.transform.position, isMainDamage: true, projectile);
	}

	private void OnProjectileDestroyed(Projectile projectile)
	{
		shotProjectiles.Remove(projectile);
	}

	protected virtual void OnAnimationShoot()
	{
		if ((bool)tower.Target && tower.Target.CombatComponent.IsAlive())
		{
			ShootProjectile(tower.Target.CombatComponent);
		}
		else if (lastTargetPosition.HasValue)
		{
			ShootProjectileToPosition(lastTargetPosition.Value);
		}
		this.StopCoroutineCheckingVar(ref updateLastTargetPositionCoroutine);
	}
}
