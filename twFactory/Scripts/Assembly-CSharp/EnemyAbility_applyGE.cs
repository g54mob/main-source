using System;
using System.Collections;
using UnityEngine;

public class EnemyAbility_applyGE : EnemyAbility_targeting
{
	[Serializable]
	private struct FGameplayEffect
	{
		[SerializeField]
		private GameplayEffectData gameplayEffectData;

		[SerializeField]
		private int stacks;

		public GameplayEffectData GameplayEffectData => gameplayEffectData;

		public int Stacks => stacks;

		public FGameplayEffect(GameplayEffectData gameplayEffectData, int stacks)
		{
			this.gameplayEffectData = gameplayEffectData;
			this.stacks = stacks;
		}
	}

	[Header("Apply GE")]
	[SerializeField]
	private FGameplayEffect[] geToApply;

	[SerializeField]
	private bool ignoreAlreadyAffectedTargets;

	[SerializeField]
	private Projectile projectilePrefab;

	[SerializeField]
	private float shootProjectileDelay;

	[SerializeField]
	private bool spawnProjectileAboveTarget;

	[SerializeField]
	private float projectileHeight = 1f;

	[SerializeField]
	private float maxTimeBetweenProjectiles;

	private EnemyCombatComponent enemyCC;

	private WaitForSeconds shootProjectileDelayWFS;

	protected override void Start()
	{
		base.Start();
		enemyCC = abilityManager.CombatComponent as EnemyCombatComponent;
		shootProjectileDelayWFS = new WaitForSeconds(shootProjectileDelay);
	}

	protected override void DoAbilityEffect(FActiveAbilityInputData inputData)
	{
		if ((bool)projectilePrefab)
		{
			StartCoroutine(ShootProjectilesCoroutine());
			return;
		}
		foreach (GameplayEffectsComponent cachedTarget in base.CachedTargets)
		{
			if ((bool)cachedTarget)
			{
				for (int i = 0; i < geToApply.Length; i++)
				{
					cachedTarget.ApplyEffect(geToApply[i].GameplayEffectData, geToApply[i].Stacks);
				}
			}
		}
	}

	private IEnumerator ShootProjectilesCoroutine()
	{
		foreach (GameplayEffectsComponent cachedTarget in base.CachedTargets)
		{
			if (!cachedTarget)
			{
				continue;
			}
			GameObject targetObject = cachedTarget.GetComponent<CombatComponent>().TargetObject;
			Vector3 vector = (spawnProjectileAboveTarget ? (cachedTarget.gameObject.GetComponent<PlacementComponent>().GetCenter() + Vector3.up * projectileHeight) : (enemyCC?.ShootTransform?.position ?? enemyCC.transform.position));
			if ((bool)cachedTarget)
			{
				Projectile auxProjectile = UnityEngine.Object.Instantiate(projectilePrefab, vector, Quaternion.LookRotation(targetObject.transform.position - vector));
				if (shootProjectileDelay > 0f)
				{
					yield return shootProjectileDelayWFS;
				}
				auxProjectile.ShootProjectileToTarget(targetObject, abilityManager.gameObject);
				auxProjectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Combine(auxProjectile.onTargetReached, new Action<Projectile, GameObject>(OnProjectileTargetReached));
				yield return new WaitForSeconds(UnityEngine.Random.Range(0f, maxTimeBetweenProjectiles));
			}
		}
	}

	private void OnProjectileTargetReached(Projectile projectile, GameObject target)
	{
		GameplayEffectsComponent componentInParent = target.GetComponentInParent<GameplayEffectsComponent>();
		if ((bool)componentInParent)
		{
			for (int i = 0; i < geToApply.Length; i++)
			{
				componentInParent.ApplyEffect(geToApply[i].GameplayEffectData, geToApply[i].Stacks);
			}
		}
		projectile.onTargetReached = (Action<Projectile, GameObject>)Delegate.Remove(projectile.onTargetReached, new Action<Projectile, GameObject>(OnProjectileTargetReached));
	}

	protected override bool IsTargetValid(GameplayEffectsComponent geComp)
	{
		if (ignoreAlreadyAffectedTargets)
		{
			for (int i = 0; i < geToApply.Length; i++)
			{
				if (geComp.FindEffect(geToApply[i].GameplayEffectData) == null)
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}
}
