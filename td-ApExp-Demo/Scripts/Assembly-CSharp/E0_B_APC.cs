using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E0_B_APC : EnemyBase, iMainBossController, iBossController
{
	[Header("APC Fields")]
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

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem leftWheelTrail;

	[SerializeField]
	private ParticleSystem rightWheelTrail;

	[SerializeField]
	private ParticleSystem leftWheelSmoke;

	[SerializeField]
	private ParticleSystem rightWheelSmoke;

	[Header("Projectile")]
	[SerializeField]
	private GameObject missilePrefab;

	public event Action ControllerDied;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[2]
		{
			new E0_B_Idle(sm, this),
			new E0_B_Launch(sm, this)
		});
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		muzzleTF.rotation = Quaternion.Euler(0f, 0f, 90f);
		Target();
		leftWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		rightWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		leftWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		rightWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f)
		{
			base.Update();
			idleTimer -= Time.deltaTime;
			if (base.TargetUnit == null)
			{
				sm.ForceState("Idle");
			}
			if (base.TargetUnit == null)
			{
				Target();
			}
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f)
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
		if (float.IsNaN(verticalMovement))
		{
			frontWheelTf.rotation = Quaternion.Euler(0f, 0f, 0f);
			return;
		}
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxWheelAngle;
		float z2 = Mathf.Lerp(z, b, Time.deltaTime * wheelSpeed);
		frontWheelTf.rotation = Quaternion.Euler(0f, 0f, z2);
	}

	public override void Shoot()
	{
		SpawnProjectile();
	}

	private void SpawnProjectile()
	{
		APCMissile component = UnityEngine.Object.Instantiate(missilePrefab, muzzleTF.position, muzzleTF.rotation, base.transform).GetComponent<APCMissile>();
		component.IsEnemy = base.IsEnemy;
		component.parentEnemy = this;
		if (!component.IsEnemy)
		{
			component.TargetUnit = (from e in EnemyManager.Instance.Enemies
				where e.IsEnemy && e.GetComponent<APCMissile>() == null && e.gameObject != base.gameObject
				orderby (e.transform.position - base.transform.position).sqrMagnitude
				select e).FirstOrDefault();
		}
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
		LevelManager.Instance.HandleBossBeaten(0, tutorial: true);
	}

	public float GetCurrentTotalHealth()
	{
		return base.HealthComponent.HealthCurrent;
	}

	public float GetTotalMaxHealth()
	{
		return base.HealthComponent.HealthMax;
	}

	public List<iBossController> GetAllControllers()
	{
		return new List<iBossController> { this };
	}
}
