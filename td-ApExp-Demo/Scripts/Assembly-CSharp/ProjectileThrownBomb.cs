using System;
using System.Collections;
using UnityEngine;

public class ProjectileThrownBomb : Projectile
{
	private Vector3 spawnPos;

	[HideInInspector]
	public Vector3 targetPos;

	public float speedMult;

	[SerializeField]
	private GameObject explosionPrefab;

	[NonSerialized]
	public float radius;

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
	private AnimationCurve Trajectory;

	private bool hitDetected;

	[field: SerializeField]
	public Rotator Rotator { get; private set; }

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
		timeToTarget = targetDst / speedMult;
		anim.SetFloat("Time To Target Mult", 1f / timeToTarget);
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetVector);
	}

	private new void Update()
	{
		timer += Time.deltaTime;
	}

	private new void FixedUpdate()
	{
		ProximityCheck();
		Move();
		Rotator.RotateTowardsMovementVector(90f);
	}

	protected override void RaycastCollide(float speed)
	{
	}

	private void ProximityCheck()
	{
		if ((base.transform.position - targetPos).magnitude < radius && !hitDetected)
		{
			hitDetected = true;
			StartCoroutine(HitCoroutine());
		}
	}

	protected override void Move()
	{
		float num = timer / timeToTarget;
		float z = (0f - Mathf.Cos(targetAngle)) * 2f * 57.29578f * ((num - 0.5f) / 2f);
		base.transform.position += Quaternion.Euler(0f, 0f, z) * targetVector.normalized * speedMult * Time.deltaTime;
		base.transform.localScale = Vector3.one * (1f - Trajectory.Evaluate(num) / 2f);
	}

	public override void DestroyProjectile()
	{
		Explosion component = UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity, null).GetComponent<Explosion>();
		if (isEnemyProjectile)
		{
			component.Initialize(sourceUnit, explosionSize, 0f, trainDamage);
		}
		else
		{
			component.Initialize(sourceUnit, explosionSize, damage);
		}
		component.OnExplosionKill += this.OnExplosionKill;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private IEnumerator HitCoroutine()
	{
		speedMult = 0.5f;
		yield return new WaitForSeconds(0.5f);
		DestroyProjectile();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		this.OnExplosionHit = null;
	}
}
