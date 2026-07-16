using AudioSystem;
using UnityEngine;

public class E1_2Technical : EnemyBase
{
	[Header("Unique SFX")]
	[SerializeField]
	private SoundData gattlingSpinning;

	[Header("Vehicle Fields")]
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

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem leftWheelTrail;

	[SerializeField]
	private ParticleSystem rightWheelTrail;

	[SerializeField]
	private ParticleSystem leftWheelSmoke;

	[SerializeField]
	private ParticleSystem rightWheelSmoke;

	[Header("Technical")]
	[SerializeField]
	private Animator gatlingAnim;

	[SerializeField]
	private float shootingSpeed = 1f;

	public (Unit, Unit) TargetUnits { get; private set; }

	[field: SerializeField]
	public float AimSpeed { get; private set; } = 15f;

	[field: SerializeField]
	public float SpinUpTime { get; private set; } = 1.3f;

	[field: SerializeField]
	public float CoolTime { get; private set; } = 1f;

	public float RotationProgress { get; set; }

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[5]
		{
			new E1_2Idle(sm, this),
			new E1_2Spinning(sm, this),
			new E1_2Firing(sm, this),
			new E1_2Cooling(sm, this),
			new BEMPState(sm, this, "Idle")
		});
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		turretTF.localScale = new Vector3((float)enemyPos, (float)enemyPos, 1f);
		Target();
		Vector3 upwards = TargetUnits.Item1.transform.position - base.transform.position;
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, upwards);
		turretTF.rotation = rotation;
		leftWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		rightWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		leftWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		rightWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		gatlingAnim.SetFloat("ShootingSpeed", shootingSpeed);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			CheckTarget();
			base.TargetUnit = TargetUnits.Item1;
			base.Update();
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
		}
	}

	protected override void CheckTarget()
	{
		if (TargetUnits.Item1 == null || TargetUnits.Item1.IsEnemy == base.IsEnemy || TargetUnits.Item1.ignoreProjectiles || TargetUnits.Item2 == null || TargetUnits.Item2.IsEnemy == base.IsEnemy || TargetUnits.Item2.ignoreProjectiles)
		{
			Retarget();
		}
	}

	protected override void Retarget()
	{
		base.Retarget();
		sm.ForceState("Idle");
	}

	protected new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
			Move();
		}
	}

	public override void Move()
	{
		Vector3 vector = ((!(TargetUnits.Item1 != null)) ? Vector3.zero : TargetUnits.Item1.transform.position);
		float num = (float)enemyPos;
		float num2 = Train.Instance.Wagons[0].transform.position.y * num;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = (Mathf.Lerp(minY + num2, maxY + num2, t) + targetOffsetY) * num;
		float b2 = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b2, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b, t4);
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
	}

	public override void Target()
	{
		if (base.IsEnemy)
		{
			TargetUnits = UnitHelper.GetTwoModulesByDstApart(3f);
		}
		else
		{
			TargetUnits = (UnitHelper.GetRandomLiveEnemyUnit(this), UnitHelper.GetRandomLiveEnemyUnit(this));
		}
	}

	public void SwapTargets()
	{
		TargetUnits = (TargetUnits.Item2, TargetUnits.Item1);
	}

	public override void Aim()
	{
		if (!(TargetUnits.Item2 == null))
		{
			Debug.DrawLine(turretTF.position, TargetUnits.Item2.transform.position, Color.yellow, 1f);
			Vector3 upwards = TargetUnits.Item2.transform.position - base.transform.position;
			Quaternion b = Quaternion.LookRotation(Vector3.forward, upwards);
			float num = Quaternion.Angle(turretTF.rotation, b);
			RotationProgress = Mathf.Min(1f, AimSpeed * Time.deltaTime / num);
			turretTF.rotation = Quaternion.Lerp(turretTF.rotation, b, RotationProgress);
		}
	}

	public void SpinUp()
	{
		gatlingAnim.SetTrigger("SpinUp");
		soundBuilder.Play(gattlingSpinning);
	}

	public void ShootAnim()
	{
		gatlingAnim.SetTrigger("Shoot");
	}

	public void CoolDown()
	{
		gatlingAnim.SetTrigger("CoolDown");
	}

	public void StopShooting()
	{
		soundBuilder.FindAndStop(gattlingSpinning);
		CoolDown();
	}

	public override void Shoot()
	{
		if (!(TargetUnits.Item1 == null) || !(TargetUnits.Item2 == null))
		{
			SpawnProjectile();
		}
	}

	private void SpawnProjectile()
	{
		Projectile component = Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
		component.ProjectileHit += base.OnTargetDamaged;
		component.sourceUnit = this;
		component.speed = projSpeed;
		component.damage = damage;
		component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
		component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
		soundBuilder.Play(shootSound);
	}

	protected override void OnDeath(HealthChangeInfo healthChangeInfo)
	{
		if (leftWheelSmoke.TryGetComponent<TireSmokeController>(out var component))
		{
			component.Detach();
		}
		if (rightWheelSmoke.TryGetComponent<TireSmokeController>(out var component2))
		{
			component2.Detach();
		}
		if (leftWheelTrail.TryGetComponent<TireTrailController>(out var component3))
		{
			component3.Detach();
		}
		if (rightWheelTrail.TryGetComponent<TireTrailController>(out var component4))
		{
			component4.Detach();
		}
		base.OnDeath(healthChangeInfo);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}
}
