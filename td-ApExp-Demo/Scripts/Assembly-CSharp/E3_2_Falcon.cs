using System;
using UnityEngine;

public class E3_2_Falcon : EnemyBase
{
	[Header("Falcon Fields")]
	[SerializeField]
	private float maxTiltAngle = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private float distanceToTrain = 1f;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem windPs1;

	[SerializeField]
	private ParticleSystem windPs2;

	private Vector2 targetPos;

	public bool ShotLoaded;

	[field: NonSerialized]
	public Rotator Rotator { get; private set; }

	public Vector3 TargetPos => targetPos;

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		Rotator = GetComponent<Rotator>();
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[5]
		{
			new E3_2_Enter(sm, this),
			new E3_2_Idle(sm, this),
			new E3_2_CrossOver(sm, this),
			new E3_2_GoToStart(sm, this),
			new BEMPState(sm, this, "GoToStart")
		};
		stateMachine.BuildStateDictionary(newStates);
		Target();
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			CheckTarget();
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
			Move();
		}
	}

	public override void Move()
	{
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, t2);
		float b2 = Mathf.Lerp(targetPos.y - yVariation, targetPos.y + yVariation, t) + targetOffsetY;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		IsInPosition = Mathf.Abs(position.x - targetPos.x) < xVariation && Mathf.Abs(position.y - targetPos.y) < yVariation;
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
		TiltPlane(rateOfChangeY);
	}

	private void TiltPlane(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxTiltAngle;
		Mathf.Lerp(z, b, Time.deltaTime);
	}

	public void SetStartingPos()
	{
		targetPos = new Vector2(-1.8f, (base.transform.position.y > 0f) ? distanceToTrain : (0f - distanceToTrain));
	}

	public void SetCrossOverPos()
	{
		targetPos = new Vector2(1.8f, (base.transform.position.y > 0f) ? (0f - distanceToTrain) : distanceToTrain);
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
		Target();
		if (!(base.TargetUnit == null))
		{
			ProjectileThrownBomb component = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<ProjectileThrownBomb>();
			component.SetTarget(base.TargetUnit);
			component.targetPos = base.TargetUnit.transform.position;
			component.speed = 1f;
			component.radius = 0.3f;
			component.explosionSize = 0.5f;
			component.damage = damage;
			component.trainDamage = trainDamage;
			component.sourceUnit = this;
			component.isEnemyProjectile = base.IsEnemy;
			ShotLoaded = false;
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}

	public override void Hack(bool isHacked)
	{
		base.Hack(isHacked);
		Target();
	}

	public void PlayShootSound()
	{
		soundBuilder.Play(shootSound);
	}
}
