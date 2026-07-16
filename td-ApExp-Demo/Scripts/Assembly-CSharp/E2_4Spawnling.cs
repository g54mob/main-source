using UnityEngine;

public class E2_4Spawnling : EnemyBase
{
	[Header("Movement Fields")]
	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[Header("Spawnling Fields")]
	[SerializeField]
	private Transform bodyTf;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private float enterLeapDistance;

	[SerializeField]
	private Animator gunAnim;

	[Header("Smoke")]
	private Vector3 enterTargetPos;

	private float enterTimer;

	private new void Awake()
	{
		base.Awake();
		shotTimer = timeBetweenShots + 1f;
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E2_4SpawnlingEnter(sm, this),
			new E2_4SpawnlingIdle(sm, this),
			new E2_4SpawnlingEMP(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		if (base.TargetUnit != null)
		{
			turretTF.transform.rotation = Quaternion.LookRotation(Vector3.forward, base.TargetUnit.transform.position);
		}
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

	public override void Move()
	{
		Vector3 vector = ((!(base.TargetUnit == null)) ? base.TargetUnit.transform.position : Vector3.zero);
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
	}

	public void SetEnterPos()
	{
		enterTargetPos = base.transform.position - new Vector3(enterLeapDistance, 0f, 0f);
		enterTimer = 0f;
	}

	public void EnterBattle()
	{
		float num = (float)enemyPos;
		Vector3 vector = GetNeighborAvoidanceVector();
		Vector3 position = base.transform.position;
		enterTimer += Time.deltaTime / 2f;
		position.x = Mathf.Lerp(position.x, enterTargetPos.x, enterTimer);
		if ((num == 1f && position.y < minY) || (num == -1f && position.y > minY))
		{
			position.y = minY;
		}
		base.transform.position = position + vector;
		if (enterTimer >= 0.3f)
		{
			sm.ForceState("Idle");
		}
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			Vector3 position = base.TargetUnit.transform.position;
			Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, position.y) - base.transform.position;
			Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
			turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, to, Time.deltaTime * 60f);
		}
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f) && IsInPosition)
		{
			shotTimer = timeBetweenShots;
			Projectile component = Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
			gunAnim.Play("SpawnlingGunFire");
			soundBuilder.Play(shootSound);
		}
	}

	public void SetTurretScale(Vector3 scale)
	{
		turretTF.localScale = scale;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}
}
