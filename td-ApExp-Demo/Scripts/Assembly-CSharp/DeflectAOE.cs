using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeflectAOE : MonoBehaviour
{
	private ModuleCannon moduleCannon;

	[NonSerialized]
	public float speed;

	[NonSerialized]
	public float damage;

	[NonSerialized]
	public bool deflectCanHack;

	[NonSerialized]
	public float deflectHackProbability;

	[NonSerialized]
	public bool deflectSplitBullet;

	[NonSerialized]
	public int selfDeflectsCount;

	[NonSerialized]
	public bool canRefundCooldown;

	[NonSerialized]
	public float deflectDamageIncrease;

	[SerializeField]
	private Animator animator;

	private BoxCollider2D collider;

	private List<GameObject> enemyBlacklist;

	private void Start()
	{
		moduleCannon = Train.Instance.Modules[2] as ModuleCannon;
		collider = GetComponent<BoxCollider2D>();
		enemyBlacklist = new List<GameObject>();
		selfDeflectsCount = 0;
	}

	private void FixedUpdate()
	{
		Move();
		DeflectNearby();
		DamageEnemies();
	}

	private void DamageEnemies()
	{
		Collider2D[] array = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, LayerMask.GetMask("Unit", "Enemy"));
		if (array == null && array.Length != 0)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if ((bool)array[i].GetComponent<Unit>() && array[i].GetComponent<Unit>().IsEnemy && !enemyBlacklist.Contains(array[i].gameObject))
			{
				if ((bool)array[i].GetComponent<APCMissile>())
				{
					array[i].GetComponent<APCMissile>().DeflectMissile();
					array[i].GetComponent<APCMissile>().damage *= 1f + deflectDamageIncrease;
					enemyBlacklist.Add(array[i].gameObject);
				}
				else if ((bool)array[i].GetComponent<StealthMissile>())
				{
					array[i].GetComponent<StealthMissile>().DeflectMissile();
					array[i].GetComponent<StealthMissile>().damage *= 1f + deflectDamageIncrease;
					enemyBlacklist.Add(array[i].gameObject);
				}
				else if (damage > 0f)
				{
					enemyBlacklist.Add(array[i].gameObject);
					HealthChangeInfo info = new HealthChangeInfo(this, array[i].GetComponent<Unit>().HealthComponent, 0f - damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
					array[i].GetComponent<Unit>().HealthComponent.ChangeHealthWithInfo(info);
				}
			}
		}
	}

	private void DeflectNearby()
	{
		Collider2D[] projs = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, LayerMask.GetMask("PP"));
		if (projs == null || projs.Length == 0)
		{
			return;
		}
		int i;
		for (i = 0; i < projs.Length; i++)
		{
			if (!projs[i].GetComponent<Projectile>() || projs[i].GetComponent<Projectile>().hasBeenDeflected || !projs[i].GetComponent<Projectile>().isEnemyProjectile)
			{
				continue;
			}
			Transform projGO = projs[i].transform;
			Projectile component = projGO.GetComponent<Projectile>();
			if (deflectSplitBullet)
			{
				EnemyBase enemyBase = (from e in EnemyManager.Instance.Enemies
					where e.IsEnemy && e.GetComponent<APCMissile>() == null && e.GetComponent<StealthMissile>() == null && e != projs[i].GetComponent<Projectile>().sourceUnit
					orderby (e.transform.position - projGO.position).sqrMagnitude
					select e).FirstOrDefault();
				if (enemyBase != null && component.GetType() == typeof(Projectile))
				{
					Quaternion rotation = Quaternion.LookRotation(Vector3.forward, enemyBase.transform.position - projGO.transform.position);
					Projectile component2 = UnityEngine.Object.Instantiate(projGO.gameObject, projGO.position, rotation).GetComponent<Projectile>();
					component2.sourceUnit = moduleCannon;
					component2.isEnemyProjectile = false;
					component2.hasBeenDeflected = true;
					component2.damage = component.damage;
					component2.damage *= GlobalFields.Instance.RicochetDmgMult;
					component2.damage *= 1f + deflectDamageIncrease;
					component2.deflectCanHack = deflectCanHack;
					component2.deflectHackProbability = deflectHackProbability;
					component2.speed += speed;
				}
			}
			Vector3 vector = projGO.transform.position - base.transform.position;
			_ = (Mathf.Atan2(vector.y, vector.x) * 57.29578f + 270f) % 360f;
			projGO.eulerAngles += 180f * Vector3.forward;
			if (component is ProjectileMolotov projectileMolotov)
			{
				projectileMolotov.TargetUnit = projectileMolotov.sourceUnit;
				projectileMolotov.DeflectProjectile(moduleCannon, deflectDamageIncrease);
			}
			else if (component is ProjectileGarbage projectileGarbage)
			{
				projectileGarbage.DeflectProjectile(moduleCannon, deflectDamageIncrease);
			}
			else
			{
				component.DeflectProjectile(moduleCannon, deflectDamageIncrease);
				component.deflectCanHack = deflectCanHack;
				component.deflectHackProbability = deflectHackProbability;
				component.speed += speed;
			}
			ModuleDeflect moduleByType = Train.Instance.GetModuleByType<ModuleDeflect>();
			if ((object)moduleByType != null)
			{
				moduleByType.RegisterDeflection();
				moduleByType.UpdateMainStat(1f);
				selfDeflectsCount++;
				if (canRefundCooldown && selfDeflectsCount >= 6)
				{
					moduleByType.ChargeModuleBy(moduleByType.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) / 2f);
					selfDeflectsCount = 0;
				}
			}
		}
	}

	public void Move()
	{
		base.transform.Translate(base.transform.up * speed * Time.deltaTime, Space.World);
		if (base.transform.IsOutsideViewport())
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void SetWidthMedium()
	{
		animator.SetTrigger("Medium");
		GetComponent<BoxCollider2D>().size = new Vector2(0.64f, 0.1f);
	}

	public void SetWidthBig()
	{
		animator.SetTrigger("Big");
		GetComponent<BoxCollider2D>().size = new Vector2(0.96f, 0.1f);
	}
}
