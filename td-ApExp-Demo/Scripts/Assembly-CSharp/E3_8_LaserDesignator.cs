using System;
using System.Collections;
using UnityEngine;

public class E3_8_LaserDesignator : EnemyBase
{
	[Header("Laser Designator Fields")]
	[SerializeField]
	private Rotator laserRotator;

	[SerializeField]
	private float lockOnTime = 3f;

	[SerializeField]
	private GameObject jetPrefab;

	[SerializeField]
	private float delayBeforeFiring;

	[Header("Laser Fields")]
	[SerializeField]
	private Transform laserTf;

	[SerializeField]
	private LineRenderer laserLr;

	[SerializeField]
	private Transform targetTf;

	[SerializeField]
	public Animator targetAnim;

	[SerializeField]
	private float targetSwayMax = 0.5f;

	[SerializeField]
	private float swaySpeed = 0.5f;

	[SerializeField]
	private float xVariation = 0.6f;

	[SerializeField]
	private float yVariation = 0.6f;

	private Vector2 targetPos;

	private float targetingTimer;

	[NonSerialized]
	public bool IsAiming;

	[NonSerialized]
	public bool shotFired;

	private float allowedPosVariation;

	[NonSerialized]
	public bool LockedOn;

	private bool isTargetImageNearTarget;

	private float targetNoiseSeed;

	private Coroutine shootCoroutine;

	public Vector3 TargetPos => targetPos;

	[field: NonSerialized]
	public Rotator Rotator { get; private set; }

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		targetNoiseSeed = UnityEngine.Random.Range(0, 50000);
		Rotator = base.gameObject.GetComponent<Rotator>();
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[4]
		{
			new E3_8_Enter(sm, this),
			new E3_8_Attack(sm, this),
			new E3_8_Cooldown(sm, this),
			new E3_8_EMPState(sm, this, "Cooldown")
		};
		stateMachine.BuildStateDictionary(newStates);
		allowedPosVariation = (xVariation + yVariation) / 4f;
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			CheckTarget();
		}
	}

	protected override void CheckTarget()
	{
		if (base.TargetUnit == null || base.TargetUnit.IsEnemy == base.IsEnemy || (base.TargetUnit.ignoreProjectiles && !shotFired))
		{
			Retarget();
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
		}
	}

	public override void Target()
	{
		if (base.IsEnemy)
		{
			if (UnityEngine.Random.value <= 0.3f)
			{
				base.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
			}
			else
			{
				base.TargetUnit = UnitHelper.GetRandomEnemyUnit(this);
			}
		}
		else
		{
			base.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
		}
	}

	public void SetTargetPos()
	{
		targetPos = new Vector2(UnityEngine.Random.Range(Train.Instance.TrainBackPosX, Train.Instance.TrainFrontPosX), (UnityEngine.Random.Range(minY, maxY) * (float)UnityEngine.Random.Range(0, 2) > 0f) ? 1 : (-1));
	}

	public override void Move()
	{
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, t2);
		float b2 = Mathf.Lerp(targetPos.y - yVariation, targetPos.y + yVariation, t);
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (base.transform.position.x < Train.Instance.TrainBackPosX)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		IsInPosition = Mathf.Abs(position.x - targetPos.x) < allowedPosVariation && Mathf.Abs(position.y - targetPos.y) < allowedPosVariation;
		previousPos = position;
	}

	public void TurnOnLaser()
	{
		laserTf.gameObject.SetActive(value: true);
		base.Anim.Play("LaserDesignatorLasering");
		Target();
		LockedOn = false;
		targetTf.gameObject.SetActive(value: true);
		laserLr.enabled = true;
		targetAnim.Play("LaserDesignatorLaserTargeting");
		targetingTimer = lockOnTime;
		targetTf.SetParent(EnemyManager.Instance.transform);
		IsAiming = true;
	}

	public void TurnOffLaser()
	{
		laserTf.gameObject.SetActive(value: false);
		base.Anim.Play("LaserDesignatorFlight");
		targetTf.gameObject.SetActive(value: false);
		laserLr.enabled = false;
		IsAiming = false;
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null) && targetTf.gameObject.activeSelf)
		{
			if (isTargetImageNearTarget)
			{
				targetingTimer = Mathf.Clamp(targetingTimer - Time.deltaTime, 0f, lockOnTime);
				LockedOn = targetingTimer == 0f;
			}
			if (!LockedOn)
			{
				float num = Mathf.Lerp(targetSwayMax, 0f, targetingTimer / lockOnTime);
				float t = Mathf.PerlinNoise(Time.time, targetNoiseSeed);
				float t2 = Mathf.PerlinNoise(Time.time, targetNoiseSeed);
				float b = Mathf.Lerp(base.TargetUnit.transform.position.x - num, base.TargetUnit.transform.position.x + num, t2);
				float b2 = Mathf.Lerp(base.TargetUnit.transform.position.y - num, base.TargetUnit.transform.position.y + num, t);
				Vector3 position = targetTf.position;
				float t3 = Time.deltaTime * swaySpeed;
				position.x = Mathf.Lerp(position.x, b, t3);
				float t4 = Time.deltaTime * swaySpeed;
				position.y = Mathf.Lerp(position.y, b2, t4);
				targetTf.position = position;
				isTargetImageNearTarget = (position - base.TargetUnit.transform.position).magnitude < targetSwayMax;
			}
			laserRotator.SnapComponentTowardsPosition(laserTf, targetTf.position);
			SetLr(laserTf.position, targetTf.position);
			Rotator.RotateTowardsPosition(targetTf.position, 60f, 90f);
		}
	}

	public void SetLr(Vector2 startPos, Vector2 endPos)
	{
		StartCoroutine(DrawLaserAndFadeOut(startPos, endPos));
	}

	private IEnumerator DrawLaserAndFadeOut(Vector2 startPos, Vector2 endPos)
	{
		laserLr.enabled = true;
		laserLr.positionCount = 2;
		laserLr.SetPosition(0, startPos);
		laserLr.SetPosition(1, endPos);
		Color startColor = new Color(1f, 0f, 0f, 1f);
		Color endColor = new Color(1f, 0f, 0f, 0.5f);
		laserLr.startColor = startColor;
		laserLr.endColor = endColor;
		yield return new WaitForEndOfFrame();
		laserLr.enabled = false;
	}

	public override void Shoot()
	{
		TryInterruptShoot();
		shootCoroutine = StartCoroutine(SpawnJetCoroutine());
	}

	private IEnumerator SpawnJetCoroutine()
	{
		if (!(base.TargetUnit == null))
		{
			soundBuilder.Play(shootSound);
			targetTf.gameObject.SetActive(value: false);
			yield return new WaitForSeconds(0.25f);
			targetTf.gameObject.SetActive(value: true);
			yield return new WaitForSeconds(0.25f);
			targetTf.gameObject.SetActive(value: false);
			yield return new WaitForSeconds(0.25f);
			targetTf.gameObject.SetActive(value: true);
			yield return new WaitForSeconds(0.25f);
			targetTf.gameObject.SetActive(value: false);
			yield return new WaitForSeconds(0.25f);
			targetTf.gameObject.SetActive(value: true);
			yield return new WaitForSeconds(0.25f);
			targetTf.gameObject.SetActive(value: false);
			laserLr.enabled = false;
			TurnOffLaser();
			yield return new WaitForSeconds(delayBeforeFiring);
			if (!(base.TargetUnit == null))
			{
				float num = 1.5f;
				float num2 = 2f;
				Vector3 vector = new Vector3(base.TargetUnit.transform.position.x - num, base.posSignTf * num2);
				EnemyManager instance = EnemyManager.Instance;
				GameObject enemyPrefab = jetPrefab;
				Vector3? spawnPos = vector;
				instance.SpawnEnemy(enemyPrefab, null, spawnPos).GetComponent<E3_8_FighterJet>().Initialize(base.TargetUnit, vector, new Vector3(vector.x + 2f * num, (0f - base.posSignTf) * num2), base.IsEnemy);
				base.TargetUnit = null;
				shotFired = false;
			}
		}
	}

	public void TryInterruptShoot()
	{
		if (shootCoroutine != null)
		{
			StopCoroutine(shootCoroutine);
			TurnOffLaser();
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		TryInterruptShoot();
		UnityEngine.Object.Destroy(targetTf.gameObject);
		base.OnDeath(info);
	}

	public override void Hack(bool isHacked)
	{
		base.Hack(isHacked);
		if (isHacked)
		{
			if (!IsAiming)
			{
				sm.ForceState("Attack");
			}
			targetingTimer = 4f;
		}
		else
		{
			targetingTimer = lockOnTime;
		}
	}
}
