using System;
using UnityEngine;

public class E4_1SplitShooter : EnemyBase
{
	[Header("Split Shooter Fields")]
	[SerializeField]
	private float maxWheelAngle = 10f;

	[SerializeField]
	private float wheelSpeed = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private Transform frontWheelTf;

	[SerializeField]
	private Transform handlesTf;

	[SerializeField]
	private Animator gunAnim;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem backWheelTrail;

	[SerializeField]
	private ParticleSystem backWheelTrail2;

	[SerializeField]
	private ParticleSystem backWheelSmoke;

	[field: NonSerialized]
	public Unit TargetUnit1 { get; private set; }

	[field: NonSerialized]
	public Unit TargetUnit2 { get; private set; }

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_1Idle(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		shotTimer = base.TimeBetweenShots;
	}

	private new void Start()
	{
		base.Start();
		Target();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		turretTF.localScale = new Vector3((float)enemyPos, (float)enemyPos, 1f);
		backWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelTrail2.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
			CheckTarget();
		}
	}

	public override void Target()
	{
		if (UnityEngine.Random.value <= 0.3f)
		{
			if (TargetUnit1 == null || TargetUnit1.IsEnemy == base.IsEnemy || TargetUnit1.ignoreProjectiles)
			{
				TargetUnit1 = UnitHelper.GetRandomLiveEnemyUnit(this);
			}
			if (TargetUnit2 == null || TargetUnit2.IsEnemy == base.IsEnemy || TargetUnit2.ignoreProjectiles)
			{
				TargetUnit2 = UnitHelper.GetRandomLiveEnemyUnitExcept(this, TargetUnit2);
			}
		}
		else
		{
			if (TargetUnit1 == null || TargetUnit1.IsEnemy == base.IsEnemy || TargetUnit1.ignoreProjectiles)
			{
				TargetUnit1 = UnitHelper.GetRandomEnemyUnit(this);
			}
			if (TargetUnit2 == null || TargetUnit2.IsEnemy == base.IsEnemy || TargetUnit2.ignoreProjectiles)
			{
				TargetUnit2 = UnitHelper.GetRandomEnemyUnitExcept(this, TargetUnit1);
			}
		}
	}

	protected override void CheckTarget()
	{
		if (TargetUnit1 == null || TargetUnit1.IsEnemy == base.IsEnemy || TargetUnit1.ignoreProjectiles)
		{
			Retarget();
		}
		if (TargetUnit2 == null || TargetUnit2.IsEnemy == base.IsEnemy || TargetUnit2.ignoreProjectiles)
		{
			Retarget();
		}
	}

	public override void Move()
	{
		Vector3 vector = ((TargetUnit1 == null && TargetUnit2 == null) ? Vector3.zero : ((TargetUnit1 != null && TargetUnit2 != null) ? ((TargetUnit1.transform.position + TargetUnit2.transform.position) / 2f) : ((!(TargetUnit1 != null)) ? TargetUnit2.transform.position : TargetUnit1.transform.position)));
		float num = (float)enemyPos;
		float num2 = Train.Instance.Wagons[0].transform.position.y * num;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		float b2 = (Mathf.Lerp(minY + num2, maxY + num2, t) + targetOffsetY) * num;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if ((num == 1f && position.y < minY) || (num == -1f && position.y > minY))
		{
			position.y = minY;
		}
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		base.Move();
		IsInPosition = position.x < vector.x + xVariation && position.x > vector.x - xVariation && position.y * num > minY && position.y * num < maxY;
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
		RotateWheel(rateOfChangeY);
	}

	private void RotateWheel(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxWheelAngle;
		float z2 = Mathf.Lerp(z, b, Time.deltaTime * wheelSpeed);
		Quaternion rotation = Quaternion.Euler(0f, 0f, z2);
		frontWheelTf.rotation = rotation;
		float b2 = num2 * maxWheelAngle / 2f;
		float z3 = Mathf.Lerp(z, b2, Time.deltaTime * wheelSpeed);
		Quaternion.Euler(0f, 0f, z3);
		handlesTf.rotation = rotation;
	}

	public override void Aim()
	{
		Vector3 vector = ((TargetUnit1 == null && TargetUnit2 == null) ? Vector3.zero : ((TargetUnit1 != null && TargetUnit2 != null) ? ((TargetUnit1.transform.position + TargetUnit2.transform.position) / 2f) : ((!(TargetUnit1 != null)) ? TargetUnit2.transform.position : TargetUnit1.transform.position)));
		Vector3 upwards = new Vector3(vector.x, vector.y) - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, to, Time.deltaTime * 60f);
	}

	public override void Shoot()
	{
		if ((!(TargetUnit1 == null) || !(TargetUnit2 == null)) && !(shotTimer > 0f) && IsInPosition)
		{
			shotTimer = base.TimeBetweenShots;
			gunAnim.Play("SplitShooterShooterShoot");
			if (TargetUnit1 != null && TargetUnit2 != null)
			{
				GameObject projGO = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation);
				SetupProjectile(projGO, TargetUnit1);
				GameObject projGO2 = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation);
				SetupProjectile(projGO2, TargetUnit2);
			}
			else if (TargetUnit1 != null)
			{
				GameObject projGO3 = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation);
				SetupProjectile(projGO3, TargetUnit1);
				GameObject projGO4 = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation);
				SetupProjectile(projGO4, TargetUnit1);
			}
			else
			{
				GameObject projGO5 = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation);
				SetupProjectile(projGO5, TargetUnit2);
				GameObject projGO6 = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation);
				SetupProjectile(projGO6, TargetUnit2);
			}
			soundBuilder.Play(shootSound);
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (backWheelSmoke.TryGetComponent<TireSmokeController>(out var component))
		{
			component.Detach();
		}
		if (backWheelTrail.TryGetComponent<TireTrailController>(out var component2))
		{
			component2.Detach();
		}
		if (backWheelTrail2.TryGetComponent<TireTrailController>(out var component3))
		{
			component3.Detach();
		}
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Retarget();
	}

	private void SetupProjectile(GameObject projGO, Unit target)
	{
		if (target != null)
		{
			projGO.transform.up = target.transform.position - projGO.transform.position;
		}
		Projectile component = projGO.GetComponent<Projectile>();
		component.ProjectileHit += base.OnTargetDamaged;
		component.sourceUnit = this;
		component.speed = projSpeed;
		component.isEnemyProjectile = base.IsEnemy;
		component.burn = Burn;
		if (base.IsEnemy)
		{
			component.damage = base.TrainDamage;
		}
		else
		{
			component.damage = base.EnemyDamage;
		}
		component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
		component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
	}
}
