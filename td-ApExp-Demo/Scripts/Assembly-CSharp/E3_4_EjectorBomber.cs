using System;
using System.Collections;
using UnityEngine;

public class E3_4_EjectorBomber : EnemyBase
{
	[Header("Additional Components")]
	[SerializeField]
	private Rotator Rotator;

	[Header("Ejector Bomber Fields")]
	[SerializeField]
	private GameObject suiciderPrefab;

	[SerializeField]
	private Transform rudderTf;

	[SerializeField]
	private float maxRudderAngle = 10f;

	[SerializeField]
	private float rudderSpeed = 10f;

	[SerializeField]
	private int missileCount = 10;

	[Header("Flight Fields")]
	[SerializeField]
	private float maxTiltAngle = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 0.5f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform muzzle1TF;

	[SerializeField]
	private Transform muzzle2TF;

	[SerializeField]
	private Transform turretTF;

	private bool isHovering;

	[NonSerialized]
	public bool finishedShooting;

	[NonSerialized]
	public bool lockHover;

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
		sm.BuildStateDictionary(new StateBase[3]
		{
			new E3_4_Idle(sm, this),
			new E3_4_Attack(sm, this),
			new BEMPState(sm, this, "Idle")
		});
		Target();
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			CheckTarget();
			if (Train.Instance.SpeedCurrent == 0f && !isHovering)
			{
				Hover(enterHover: true);
			}
			else if (Train.Instance.SpeedCurrent > 0f && isHovering)
			{
				Hover(enterHover: false);
			}
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
		}
	}

	public override void Move()
	{
		Vector3 vector = ((!(base.TargetUnit == null)) ? base.TargetUnit.transform.position : (Vector3.zero + Vector3.forward * base.posSignTf));
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float num = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		float b = (Mathf.Lerp(minY, maxY, t) + targetOffsetY) * base.posSignTf;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, num, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b, t4);
		if ((base.posSignTf == 1f && position.y < minY) || (base.posSignTf == -1f && position.y > minY))
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
		IsInPosition = Mathf.Abs(position.x - num) < xVariation;
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
		TiltPlane(rateOfChangeY);
	}

	public void ResetRotation()
	{
		Rotator.RotateToAngle(base.transform, 0f, 90f);
		if (base.transform.rotation == Quaternion.Euler(0f, 0f, 0f))
		{
			MoveRudder(0f - rateOfChangeY);
		}
	}

	private void MoveRudder(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxRudderAngle;
		float z2 = Mathf.Lerp(z, b, Time.deltaTime * rudderSpeed);
		Quaternion rotation = Quaternion.Euler(0f, 0f, z2);
		rudderTf.rotation = rotation;
	}

	private void TiltPlane(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxTiltAngle;
		Mathf.Lerp(z, b, Time.deltaTime);
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			Rotator.RotateComponentTowardsPosition(base.transform, base.TargetUnit.transform.position, 60f, 90f);
		}
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null))
		{
			StartCoroutine(MissileBarrage());
		}
	}

	private IEnumerator MissileBarrage()
	{
		bool firstMuzzle = true;
		soundBuilder.Play(shootSound);
		for (int i = 0; i < missileCount; i++)
		{
			GameObject gameObject;
			if (firstMuzzle)
			{
				Quaternion rotation = Quaternion.Euler(0f, 0f, muzzle1TF.eulerAngles.z - 90f);
				gameObject = UnityEngine.Object.Instantiate(bullet, muzzle1TF.position, rotation);
			}
			else
			{
				Quaternion rotation2 = Quaternion.Euler(0f, 0f, muzzle2TF.eulerAngles.z - 90f);
				gameObject = UnityEngine.Object.Instantiate(bullet, muzzle2TF.position, rotation2);
			}
			Missile component = gameObject.GetComponent<Missile>();
			component.sourceUnit = this;
			if (base.IsEnemy)
			{
				component.trainDamage = damage;
			}
			else
			{
				component.damage = damage;
			}
			component.speed = projSpeed;
			component.trackingSpeed = 120f;
			component.radius = 0.1f;
			component.muteFlightSound = true;
			firstMuzzle = !firstMuzzle;
			yield return new WaitForSeconds(timeBetweenShots);
		}
		finishedShooting = true;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (!base.IsEMPd)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(suiciderPrefab, base.transform.position, Quaternion.identity, EnemyManager.Instance.transform);
			EnemyManager.Instance.RegisterEnemy(gameObject.GetComponent<E3_4_EjectorSuicider>());
		}
		base.OnDeath(info);
	}

	public override void Hack(bool isHacked)
	{
		base.Hack(isHacked);
		Target();
		if (isHacked)
		{
			sm.ForceState("Attack");
		}
	}

	public void Hover(bool enterHover)
	{
		if (!lockHover)
		{
			if (enterHover && !isHovering)
			{
				base.Anim.Play("EjectorPlaneTransitionFromMtoS");
				isHovering = true;
			}
			else if (!enterHover && isHovering)
			{
				base.Anim.Play("EjectorPlaneTransitionFromStoM");
				isHovering = false;
			}
		}
	}
}
