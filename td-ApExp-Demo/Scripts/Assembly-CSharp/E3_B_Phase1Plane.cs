using System;
using System.Collections;
using UnityEngine;

public class E3_B_Phase1Plane : EnemyBase, iBossController
{
	[Header("Plane Fields")]
	[SerializeField]
	protected float maxTiltAngle = 10f;

	[SerializeField]
	protected float xVariation = 1f;

	[SerializeField]
	protected float yVariation = 0.5f;

	[SerializeField]
	protected float ySpeedMult = 10f;

	[SerializeField]
	protected Transform turret1TF;

	[Header("Shared Fields")]
	[SerializeField]
	protected Rotator rotator;

	[SerializeField]
	protected Transform muzzle1TF;

	[SerializeField]
	protected GameObject paratrooper;

	[SerializeField]
	protected float timeToFixSecondary = 15f;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem[] backSmokes;

	[NonSerialized]
	public bool AttackCompleted;

	[NonSerialized]
	public E3_B_WIP bossController;

	[NonSerialized]
	public Vector2 retreatPosition;

	protected Coroutine fixingSecondaryCoroutine;

	[SerializeField]
	public float startingMoveSpeed;

	[field: SerializeField]
	public E3_B_C_SecondaryWeapon secondary { get; protected set; }

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		retreatPosition = Vector2.zero;
	}

	private new void Start()
	{
		base.Start();
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
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
		base.Move();
	}

	public virtual void Retreat(float moveSpeedMultiplier)
	{
		if (retreatPosition == Vector2.zero)
		{
			retreatPosition = new Vector2(5f, base.transform.position.y);
		}
		if (base.transform.position == (Vector3)retreatPosition)
		{
			base.MoveSpeed = 0f;
		}
		float maxDistanceDelta = base.MoveSpeed * moveSpeedMultiplier * Time.deltaTime;
		base.transform.position = Vector2.MoveTowards(base.transform.position, retreatPosition, maxDistanceDelta);
		if (fixingSecondaryCoroutine != null)
		{
			StopCoroutine(fixingSecondaryCoroutine);
			secondary.Repair();
			fixingSecondaryCoroutine = null;
		}
	}

	protected void TiltPlane(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxTiltAngle;
		Mathf.Lerp(z, b, Time.deltaTime);
	}

	public override void Aim()
	{
	}

	public override void Shoot()
	{
	}

	public void SecondaryShot()
	{
		secondary.Shoot();
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (fixingSecondaryCoroutine != null)
		{
			StopCoroutine(fixingSecondaryCoroutine);
			fixingSecondaryCoroutine = null;
		}
		ParticleSystem[] array = backSmokes;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].TryGetComponent<TireSmokeController>(out var component))
			{
				component.Detach();
			}
		}
		bossController.AlertOfPlaneDeath();
		if (secondary.HealthComponent.HealthCurrent > 0f)
		{
			secondary.Despawn();
		}
		base.OnDeath(info);
	}

	public virtual void OnSecondaryDestroyed()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(explosionPrefab, secondary.transform.position, secondary.transform.rotation);
		gameObject.layer = 30;
		deathExplosion = gameObject.GetComponent<Explosion>();
		deathExplosion.Initialize(this, explosionScale, 0f);
		fixingSecondaryCoroutine = StartCoroutine(FixSecondary());
	}

	private IEnumerator FixSecondary()
	{
		yield return new WaitForSeconds(timeToFixSecondary);
		secondary.Repair();
		fixingSecondaryCoroutine = null;
	}

	public void SetBossController(iBossController boss)
	{
		bossController = boss as E3_B_WIP;
	}

	protected bool IsDamaged()
	{
		if (base.HealthComponent.HealthCurrent < base.HealthComponent.HealthMax)
		{
			return true;
		}
		return false;
	}

	public bool IsValidHealingTarget()
	{
		if (base.IsDead || !IsDamaged())
		{
			return false;
		}
		return true;
	}

	public float GetCurrentTotalHealth()
	{
		return base.HealthComponent.HealthCurrent;
	}

	public float GetTotalMaxHealth()
	{
		return base.HealthComponent.HealthMax;
	}
}
