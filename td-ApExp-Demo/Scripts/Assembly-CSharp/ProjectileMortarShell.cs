using System;
using System.Collections;
using UnityEngine;

public class ProjectileMortarShell : Projectile
{
	[HideInInspector]
	public ModuleMortar mortar;

	private Vector3 spawnPos;

	[HideInInspector]
	public Vector3 targetPos;

	public float speedMult;

	[SerializeField]
	private GameObject explosionPrefab;

	[NonSerialized]
	public bool isMine;

	[NonSerialized]
	public int secondaryCount;

	[NonSerialized]
	public float secondaryMult;

	[NonSerialized]
	public float radius;

	[NonSerialized]
	public bool dropsBurnAOE;

	private Animator anim;

	private Vector3 targetVector;

	private float targetDst;

	private float targetAngle;

	private float timeToTarget;

	private float timer;

	private bool isArmed;

	private bool mineAnimStarted;

	private bool transitionedToIdle;

	[SerializeField]
	private GameObject burnAOEPrefab;

	[SerializeField]
	private GameObject bulletGO;

	public event Delegates.HealthChangeHandler OnExplosionHit;

	public event Delegates.HealthChangeHandler OnExplosionKill;

	private new void Awake()
	{
		base.Awake();
		isArmed = false;
	}

	private void Start()
	{
		anim = GetComponent<Animator>();
		spawnPos = base.transform.position;
		targetVector = targetPos - spawnPos;
		targetDst = targetVector.magnitude;
		targetAngle = Mathf.Atan2(targetVector.y, targetVector.x);
		timeToTarget = targetDst / mortar.TrajectoryIntegral / speedMult;
		anim.SetFloat("Time To Target Mult", 1f / timeToTarget);
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetVector);
	}

	private new void Update()
	{
		timer += Time.deltaTime;
		if (!(timer >= timeToTarget))
		{
			return;
		}
		if (!isMine)
		{
			DestroyProjectile();
		}
		else if (!isArmed)
		{
			isArmed = true;
			base.gameObject.layer = LayerMask.NameToLayer("Mine");
			if (!mineAnimStarted)
			{
				mineAnimStarted = true;
				anim.SetTrigger("ArmMine");
				StartCoroutine(WaitForArmMineAnim());
			}
		}
		else if (transitionedToIdle)
		{
			ApplyMineRepulsion();
			ProximityCheck();
		}
	}

	private new void FixedUpdate()
	{
		if (timer < timeToTarget)
		{
			Move();
		}
	}

	private IEnumerator WaitForArmMineAnim()
	{
		yield return new WaitForSeconds(1f);
		anim.SetBool("IsMineIdle", value: true);
		transitionedToIdle = true;
	}

	private void ApplyMineRepulsion()
	{
		float num = 0.5f;
		float num2 = 1.5f;
		Collider2D[] array = Physics2D.OverlapCircleAll(base.transform.position, num, LayerMask.GetMask("Mine"));
		foreach (Collider2D collider2D in array)
		{
			if (!(collider2D.gameObject == base.gameObject))
			{
				Vector3 normalized = (base.transform.position - collider2D.transform.position).normalized;
				float num3 = Vector3.Distance(base.transform.position, collider2D.transform.position);
				float num4 = (num - num3) / num;
				if (num4 > 0f)
				{
					base.transform.position += normalized * num4 * num2 * Time.deltaTime;
				}
			}
		}
	}

	protected override void RaycastCollide(float speed)
	{
	}

	private void ProximityCheck()
	{
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if ((enemy.transform.position - base.transform.position).magnitude < radius)
			{
				DestroyProjectile();
			}
		}
	}

	protected override void Move()
	{
		float num = timer / timeToTarget;
		float z = (0f - Mathf.Cos(targetAngle)) * 2f * 57.29578f * ((num - 0.5f) / 2f);
		base.transform.position += Quaternion.Euler(0f, 0f, z) * targetVector.normalized * mortar.Trajectory.Evaluate(num) * speedMult * Time.deltaTime;
		base.transform.localScale = Vector3.one * (2f - mortar.Trajectory.Evaluate(num));
	}

	public override void DestroyProjectile()
	{
		Explosion component = UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity, null).GetComponent<Explosion>();
		component.Initialize(sourceUnit, radius, damage);
		component.OnExplosionKill += this.OnExplosionKill;
		SpawnSecondaryShells();
		if ((bool)mortar)
		{
			if (mortar.GetUpgradedStatValueByStatType(StatTypes.sunder) > 0f)
			{
				component.sunder = true;
			}
			if (mortar.splashBullets)
			{
				ShootBullets();
			}
			if (dropsBurnAOE)
			{
				SpawnBurnAOE();
			}
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void SpawnSecondaryShells()
	{
		for (int i = 0; i < secondaryCount; i++)
		{
			GameObject obj = UnityEngine.Object.Instantiate(base.gameObject, base.transform.position, Quaternion.identity);
			obj.layer = LayerMask.NameToLayer("Projectile");
			ProjectileMortarShell component = obj.GetComponent<ProjectileMortarShell>();
			Vector3 vector = UnityEngine.Random.insideUnitCircle.normalized * radius;
			component.targetPos = base.transform.position + vector;
			component.damage = damage * secondaryMult;
			component.radius = radius * secondaryMult;
			component.speedMult = speedMult * secondaryMult;
			component.mortar = mortar;
			component.sourceUnit = mortar;
			component.isMine = isMine;
			component.dropsBurnAOE = dropsBurnAOE;
			component.OnExplosionHit += this.OnExplosionHit;
		}
	}

	private void SpawnBurnAOE()
	{
		BurnAOE component = UnityEngine.Object.Instantiate(burnAOEPrefab, base.transform.position, Quaternion.identity).GetComponent<BurnAOE>();
		component.radius = radius;
		component.duration = 10f;
		component.sourceUnit = mortar;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		this.OnExplosionHit = null;
	}

	public void ShootBullets()
	{
		float[] array = new float[4] { 45f, 135f, 225f, 315f };
		foreach (float z in array)
		{
			UnityEngine.Object.Instantiate(bulletGO, base.transform.position, Quaternion.Euler(0f, 0f, z)).GetComponent<Projectile>().sourceUnit = mortar;
		}
	}
}
