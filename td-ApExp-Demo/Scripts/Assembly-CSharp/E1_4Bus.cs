using System;
using UnityEngine;

public class E1_4Bus : EnemyBase
{
	[Header("Bus Fields")]
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
	private Transform frontWheelTf;

	[SerializeField]
	private Animator wheelsAnim;

	[SerializeField]
	private Animator bodyAnim;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem leftWheelTrail;

	[SerializeField]
	private ParticleSystem rightWheelTrail;

	[SerializeField]
	private ParticleSystem leftWheelSmoke;

	[SerializeField]
	private ParticleSystem rightWheelSmoke;

	[NonSerialized]
	public bool shooting;

	[SerializeField]
	private GameObject missilePrefab;

	[field: SerializeField]
	public float OpenFireCloseTime { get; set; } = 4f;

	private new void Awake()
	{
		base.Awake();
		bodyAnim.SetFloat("OpenFireCloseTime", 1f / OpenFireCloseTime);
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[3]
		{
			new E1_4Idle(sm, this),
			new E1_4OpenFireClose(sm, this),
			new E1_4EMP(sm, this, "Idle")
		});
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			muzzleTF.rotation = Quaternion.Euler(0f, 0f, 180f);
		}
		Target();
		leftWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		rightWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		leftWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		rightWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			if (base.TargetUnit == null)
			{
				sm.ForceState("Idle");
			}
			wheelsAnim.SetFloat("WheelSpeed", relativeSpeedMult);
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

	public void SetIdleAnim()
	{
		if (bodyAnim != null)
		{
			bodyAnim.Play("Idle");
		}
	}

	public void SetOpenFireAnim()
	{
		if (bodyAnim != null)
		{
			bodyAnim.Play("Open");
			shooting = true;
		}
	}

	public void CompleteOpenFire()
	{
		shooting = false;
	}

	public override void Shoot()
	{
		SpawnProjectile();
	}

	private void SpawnProjectile()
	{
		Missile component = UnityEngine.Object.Instantiate(missilePrefab, muzzleTF.position, muzzleTF.rotation).GetComponent<Missile>();
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
		component.radius = 0.2f;
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
