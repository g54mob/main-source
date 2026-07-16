using System;
using System.Collections.Generic;
using UnityEngine;

public class E3_3_Helicopter : EnemyBase
{
	[Header("Helicopter Movement Fields")]
	[SerializeField]
	private float posVariationFlying = 0.6f;

	[SerializeField]
	private float distanceToTrainFlying = 1f;

	[SerializeField]
	private float posVariationHovering = 0.2f;

	[SerializeField]
	private float distanceToTrainHovering = 0.5f;

	[Header("Helicopter Attack Fields")]
	[SerializeField]
	private List<ParticleSystem> flameThrowerPs;

	[SerializeField]
	private ParticleSystem extinguishPs;

	[SerializeField]
	private float lightUpTime = 1f;

	[SerializeField]
	private float flameDuration = 3f;

	[SerializeField]
	private float attackSwivelSpeed = 1f;

	[SerializeField]
	private float attackTurnAngle = 20f;

	[SerializeField]
	private float angleLockOnWindow = 3f;

	[SerializeField]
	private float damageTickTime = 0.25f;

	[SerializeField]
	private float burnAmount = 3f;

	[SerializeField]
	private Animator nozzleFireAnim;

	[NonSerialized]
	public bool isFiring;

	private Vector2 targetPos;

	[NonSerialized]
	public bool LockedOn;

	private Vector3 targetEnemyPos;

	[NonSerialized]
	public float turnDirection = 1f;

	private float damageTimer;

	public float FlameDuration => flameDuration;

	public Vector3 TargetPos => targetPos;

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[5]
		{
			new E3_3_Enter(sm, this),
			new E3_3_Idle(sm, this),
			new E3_3_Target(sm, this),
			new E3_3_Attack(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			if ((bool)base.TargetUnit)
			{
				targetEnemyPos = base.TargetUnit.transform.position;
			}
			CheckTarget();
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
		}
	}

	public override void Target()
	{
		if (base.IsEnemy)
		{
			if (UnityEngine.Random.value <= 0.3f)
			{
				base.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
			}
			else
			{
				base.TargetUnit = UnitHelper.GetRandomEnemyUnit(this);
			}
		}
		else
		{
			base.TargetUnit = UnitHelper.GetRandomEnemyUnit(this, sameSide: true);
		}
		if ((bool)base.TargetUnit)
		{
			targetPos = new Vector2(base.TargetUnit.transform.position.x, distanceToTrainHovering * base.posSignTf);
			targetEnemyPos = base.TargetUnit.transform.position;
		}
	}

	public void SetEnterPos()
	{
		targetPos = new Vector2(-2f, distanceToTrainFlying * base.posSignTf);
	}

	public void SetRandomTargetPos()
	{
		targetPos = new Vector2(Mathf.Clamp(base.transform.position.x + UnityEngine.Random.Range(-2f, 2f), -2f, 2f), distanceToTrainFlying * base.posSignTf);
	}

	public override void Move()
	{
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - posVariationFlying, targetPos.x + posVariationFlying, t2);
		float b2 = Mathf.Lerp(targetPos.y - posVariationFlying, targetPos.y + posVariationFlying, t) + targetOffsetY;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		IsInPosition = Mathf.Abs(position.x - targetPos.x) < posVariationFlying && Mathf.Abs(position.y - targetPos.y) < posVariationFlying;
		previousPos = position;
	}

	public void Hover()
	{
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - posVariationHovering, targetPos.x + posVariationHovering, t2);
		float b2 = Mathf.Lerp(targetPos.y - posVariationHovering, targetPos.y + posVariationHovering, t) + targetOffsetY;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		IsInPosition = Mathf.Abs(position.x - targetPos.x) < posVariationFlying && Mathf.Abs(position.y - targetPos.y) < posVariationFlying;
		previousPos = position;
	}

	public override void Aim()
	{
		if (base.TargetUnit == null)
		{
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.identity, Time.deltaTime * 60f);
			LockedOn = false;
			targetEnemyPos = base.transform.position + Vector3.right;
			return;
		}
		Vector3 upwards = targetEnemyPos - base.transform.position;
		Vector3 eulerAngles = Quaternion.LookRotation(Vector3.forward, upwards).eulerAngles;
		float z = base.transform.eulerAngles.z;
		float num = Mathf.DeltaAngle(z, eulerAngles.z + 90f);
		float z2 = z + num;
		Quaternion to = Quaternion.Euler(0f, 0f, z2);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * 60f);
		LockedOn = base.transform.rotation.eulerAngles.z - to.eulerAngles.z <= angleLockOnWindow;
	}

	public void Swivel()
	{
		Vector3 upwards = targetEnemyPos - base.transform.position;
		Vector3 eulerAngles = Quaternion.LookRotation(Vector3.forward, upwards).eulerAngles;
		float z = base.transform.eulerAngles.z;
		float num = Mathf.DeltaAngle(z, eulerAngles.z + 90f);
		float num2 = z + num;
		Quaternion to = Quaternion.Euler(0f, 0f, num2 + attackTurnAngle * turnDirection);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * 60f * attackSwivelSpeed);
		if (MathF.Abs(base.transform.rotation.eulerAngles.z - to.eulerAngles.z) <= angleLockOnWindow)
		{
			turnDirection = 0f - turnDirection;
		}
	}

	public void Ignite()
	{
	}

	public override void Shoot()
	{
		isFiring = true;
		EffectsUtils.PlayMultipleParticles(flameThrowerPs, play: true);
		soundBuilder.Play(shootSound);
		nozzleFireAnim.Play("Helicopter Nozzle Fire");
	}

	public void Extinguish()
	{
		EffectsUtils.PlayMultipleParticles(flameThrowerPs, play: false);
		extinguishPs.Play();
		nozzleFireAnim.Play("Helicopter Nozzle Idle");
	}

	public void TickDamage()
	{
		if (!base.TargetUnit)
		{
			return;
		}
		if (damageTimer > 0f)
		{
			damageTimer -= Time.deltaTime;
			return;
		}
		damageTimer = damageTickTime;
		DamageUnit(base.TargetUnit);
		if (base.IsEnemy)
		{
			Module[] array = Train.Instance.FindAdjacentModulesWithoutEmptySlots(base.TargetUnit);
			DamageUnit(array[0]);
			DamageUnit(array[1]);
			return;
		}
		EnemyBase[] enemiesInRadius = EnemyManager.Instance.GetEnemiesInRadius(base.TargetUnit, 1f);
		for (int i = 0; i < enemiesInRadius.Length; i++)
		{
			if (enemiesInRadius[i] != base.TargetUnit && enemiesInRadius[i] != this)
			{
				DamageUnit(enemiesInRadius[i]);
			}
		}
	}

	private void DamageUnit(Unit unit, bool isBurn = false)
	{
		if ((bool)unit)
		{
			if (isBurn)
			{
				unit.HealthComponent.ApplyBurn(burnAmount, this);
				return;
			}
			float num = damage / (flameDuration / damageTickTime - 1f);
			unit.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, unit.HealthComponent, 0f - num));
		}
	}

	public void ApplyBurn()
	{
		isFiring = false;
		if (!base.TargetUnit)
		{
			return;
		}
		DamageUnit(base.TargetUnit, isBurn: true);
		if (base.IsEnemy)
		{
			Module[] array = Train.Instance.FindAdjacentModulesWithoutEmptySlots(base.TargetUnit);
			DamageUnit(array[0], isBurn: true);
			DamageUnit(array[1], isBurn: true);
			return;
		}
		EnemyBase[] enemiesInRadius = EnemyManager.Instance.GetEnemiesInRadius(base.TargetUnit, 1f);
		for (int i = 0; i < enemiesInRadius.Length; i++)
		{
			if (enemiesInRadius[i] != base.TargetUnit && enemiesInRadius[i] != this)
			{
				DamageUnit(enemiesInRadius[i], isBurn: true);
			}
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (isFiring)
		{
			ApplyBurn();
		}
		base.OnDeath(info);
	}

	public override void Hack(bool isHacked)
	{
		base.Hack(isHacked);
		if (isHacked)
		{
			sm.ForceState("Target");
		}
	}
}
