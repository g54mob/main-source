using System;
using System.Collections.Generic;
using UnityEngine;

public class E4_5Hunter : EnemyBase
{
	[Header("Hunter Fields")]
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
	private Animator gunAnim;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem backWheelTrail;

	[SerializeField]
	private ParticleSystem backWheelTrail2;

	private int petCounter = 3;

	[NonSerialized]
	public bool PetsDead;

	[field: SerializeField]
	public List<E4_5Pet> Pets { get; private set; }

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_5Idle(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		turretTF.localScale = new Vector3((float)enemyPos, (float)enemyPos, 1f);
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

	private new void FixedUpdate()
	{
		base.FixedUpdate();
		if (!PetsDead)
		{
			Move();
		}
		else
		{
			Stay();
		}
		if (PetsDead && base.transform.position.x <= -5f)
		{
			KillSelf();
		}
	}

	public override void Move()
	{
		Vector3 vector = ((!(base.TargetUnit == null)) ? base.TargetUnit.transform.position : Vector3.zero);
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

	public void Stay()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = new Vector3(position.x - Train.Instance.SpeedCurrent * Time.deltaTime, position.y, position.z);
		base.transform.position = position2;
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

	public override void Aim()
	{
		Vector3 position = base.TargetUnit.transform.position;
		Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, position.y) - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, to, Time.deltaTime * 60f);
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f) && IsInPosition)
		{
			shotTimer = base.TimeBetweenShots;
			gunAnim.Play("HunterGunShoot");
			Projectile component = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
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
			soundBuilder.Play(shootSound);
			Retarget();
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (backWheelTrail.TryGetComponent<TireTrailController>(out var component))
		{
			component.Detach();
		}
		if (backWheelTrail2.TryGetComponent<TireTrailController>(out var component2))
		{
			component2.Detach();
		}
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}

	public void AlertOfPetDeath()
	{
		petCounter--;
		if (petCounter == 0)
		{
			PetsDead = true;
		}
	}
}
