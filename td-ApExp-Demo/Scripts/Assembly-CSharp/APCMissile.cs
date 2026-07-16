using System;
using System.Linq;
using UnityEngine;

public class APCMissile : EnemyBase
{
	protected float randomNormalize;

	protected float flyStraightTimer;

	protected float flyStraightDuration = 1f;

	protected bool hasPlayedCruiseSound;

	[NonSerialized]
	public Unit parentEnemy;

	public float lifetime = 10f;

	[NonSerialized]
	public float TimeToWaitForTarget;

	public bool CanWaitForTarget;

	private float speedMult;

	[NonSerialized]
	public bool muteCruiseSfx;

	public event Action<HealthChangeInfo> OnHit;

	public event Action<HealthChangeInfo> OnKill;

	public new event Action OnDeathEvent;

	private new void Awake()
	{
		base.Awake();
		randomNormalize = ((UnityEngine.Random.Range(0, 2) != 0) ? 1 : (-1));
		base.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
		flyStraightTimer = flyStraightDuration;
		speedMult = 1f;
		if (base.IsEnemy)
		{
			speedMult = EnemyManager.Instance.EnemyMissileSpeedMult;
		}
	}

	private new void Update()
	{
		if (!base.IsEnemy && (base.TargetUnit == null || base.TargetUnit.IsEnemy == base.IsEnemy || base.TargetUnit.ignoreProjectiles))
		{
			base.TargetUnit = (from e in EnemyManager.Instance.Enemies
				where e.IsEnemy && e.GetComponent<APCMissile>() == null && !e.ignoreProjectiles
				orderby (e.transform.position - base.transform.position).sqrMagnitude
				select e).FirstOrDefault();
		}
		if (CanWaitForTarget && base.TargetUnit == null && TimeToWaitForTarget > 0f)
		{
			TimeToWaitForTarget -= Time.deltaTime;
		}
		else if (!base.IsEnemy)
		{
			lifetime -= Time.deltaTime;
		}
		if (lifetime < 0f)
		{
			HitDeath();
		}
		if (base.IsEnemy && parentEnemy != null && !(parentEnemy is E4_B_Rocketeer))
		{
			AnimatorStateInfo currentAnimatorStateInfo = base.Anim.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.IsName("MissileLaunching") && currentAnimatorStateInfo.normalizedTime < 1f)
			{
				return;
			}
			base.transform.parent = null;
			base.transform.localScale = Vector3.one;
			if (!hasPlayedCruiseSound)
			{
				base.Anim.Play("Cruising");
				if (!muteCruiseSfx)
				{
					soundBuilder.Play(engineSound);
				}
				hasPlayedCruiseSound = true;
			}
		}
		if (!hasPlayedCruiseSound)
		{
			base.Anim.Play("Cruising");
			if (!muteCruiseSfx)
			{
				soundBuilder.Play(engineSound);
			}
			hasPlayedCruiseSound = true;
		}
	}

	private new void FixedUpdate()
	{
		if (base.IsEnemy)
		{
			AnimatorStateInfo currentAnimatorStateInfo = base.Anim.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.IsName("MissileLaunching") && currentAnimatorStateInfo.normalizedTime < 1f)
			{
				return;
			}
			if (flyStraightTimer > 0f)
			{
				flyStraightTimer -= Time.deltaTime;
				base.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
				base.transform.position += base.transform.up * base.MoveSpeed * speedMult * Time.deltaTime;
				return;
			}
		}
		Move();
		Raycast();
	}

	public override void Move()
	{
		Vector3 upwards = base.transform.up;
		if ((bool)base.TargetUnit)
		{
			upwards = base.TargetUnit.transform.position - base.transform.position;
		}
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, base.TurnSpeed * Time.deltaTime);
		base.transform.position += base.transform.up * base.MoveSpeed * speedMult * Time.deltaTime;
		if (base.TargetUnit == null && CanWaitForTarget)
		{
			float angle = Mathf.Sin(Time.time) * randomNormalize * 10f;
			base.transform.Rotate(Vector3.forward, angle);
		}
	}

	public void Raycast()
	{
		RaycastHit2D[] array = Physics2D.RaycastAll(base.transform.position, base.transform.up, 0.02f, LayerMask.GetMask("Unit", "Enemy"));
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit2D raycastHit2D = array[i];
			if (!base.IsEnemy && raycastHit2D.collider.TryGetComponent<Unit>(out var component) && component.IsEnemy && (component is E3_5_StealthBomber || !component.ignoreProjectiles))
			{
				HitDeath();
			}
			if (raycastHit2D.collider == null || !base.IsEnemy)
			{
				continue;
			}
			if (raycastHit2D.collider.TryGetComponent<Unit>(out var component2) && component2.isShieldPlate)
			{
				HealthChangeInfo info = new HealthChangeInfo(this, component2.HealthComponent, trainDamage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				component2.HealthComponent.ChangeHealthWithInfo(info);
				trainDamage = 0f;
				HitDeath();
			}
			if (raycastHit2D.collider.TryGetComponent<ModuleSlot>(out var component3))
			{
				Unit componentInChildren = component3.GetComponentInChildren<Unit>();
				if (!componentInChildren || componentInChildren.IsEnemy != base.IsEnemy)
				{
					HitDeath();
				}
			}
		}
	}

	protected virtual void HitDeath()
	{
		Explosion component = UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>();
		component.OnExplosionHit += Hit;
		component.OnExplosionKill += Kill;
		if (!base.IsEnemy)
		{
			component.Initialize(this, explosionScale, damage);
		}
		else
		{
			component.Initialize(this, explosionScale, 0f, trainDamage);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		this.OnDeathEvent?.Invoke();
		Explosion component = UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>();
		component.OnExplosionHit += Hit;
		component.OnExplosionKill += Kill;
		float num = 0f;
		float enemyDamage = 0f;
		if (base.IsEnemy)
		{
			num = trainDamage;
		}
		else
		{
			enemyDamage = damage;
		}
		component.Initialize(this, explosionScale, enemyDamage, num);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void Hit(HealthChangeInfo info)
	{
		this.OnHit?.Invoke(info);
	}

	private void Kill(HealthChangeInfo info)
	{
		this.OnKill?.Invoke(info);
	}

	public override void EMP(float duration)
	{
	}

	public void DeflectMissile()
	{
		base.IsEnemy = false;
		base.TargetUnit = parentEnemy;
		base.HealthComponent.IsImmune = true;
		base.transform.Rotate(0f, 0f, 180f);
		base.MoveSpeed *= 1.5f;
		base.TurnSpeed *= 1.5f;
		damage *= GlobalFields.Instance.RicochetDmgMult;
	}

	public void RemoveFlyStraightTimer()
	{
		flyStraightDuration = 0f;
		flyStraightTimer = 0f;
	}
}
