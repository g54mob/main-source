using System;
using System.Collections;
using UnityEngine;

public class E3_6_Chicken : EnemyBase
{
	[Header("Additional Components")]
	[SerializeField]
	private Rotator Rotator;

	[SerializeField]
	private Shadow Shadow;

	[Header("Chicken Dropper Fields")]
	[SerializeField]
	private float decentDamageReduction = 70f;

	[SerializeField]
	private AnimationCurve spiralRadius;

	[SerializeField]
	private float decentRotationSpeed = 120f;

	[SerializeField]
	private float decentRadius = 0.3f;

	[SerializeField]
	private float decentDuration = 2f;

	[SerializeField]
	private float maxWaitUponLanding = 1f;

	private float decentTimer;

	[Header("Ejector Suicider Fields")]
	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 0.5f;

	private float randRange;

	private Vector2 randomOffset;

	private float hitTimer;

	[NonSerialized]
	public bool readyToRetreat;

	[NonSerialized]
	public bool hasLanded;

	private float decentStartSize = 1.5f;

	private Vector3 spiralStartCenter;

	private bool spiralInitialized;

	private Vector2 roofTargetPos;

	public float DecentDamageReduction => decentDamageReduction;

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		hitTimer = timeBetweenShots;
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[4]
		{
			new E3_6_Chicken_Enter(sm, this),
			new E3_6_Chicken_Attack(sm, this),
			new E3_6_Chicken_Despawn(sm, this),
			new E3_6_Chicken_BEMP(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
		randRange = Train.Instance.MODULE_HALF_WIDTH - 0.1f;
		GameManager.Instance.ringMinigame.OnStartMinigame += HandleRingMinigameStarted;
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			if (base.TargetUnit == null)
			{
				readyToRetreat = true;
			}
			else if (base.TargetUnit.HealthComponent.IsDead && IsInPosition)
			{
				KillSelf();
			}
			else if (base.TargetUnit.HealthComponent.IsDead || base.TargetUnit.gameObject.GetComponent<Module>().IsFullyBroken)
			{
				readyToRetreat = true;
			}
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
			if ((bool)base.TargetUnit)
			{
				roofTargetPos = (Vector2)base.TargetUnit.transform.position + randomOffset;
			}
		}
	}

	public override void Move()
	{
		if (!(base.TargetUnit == null))
		{
			Mathf.PerlinNoise(Time.time, noiseSeed);
			Mathf.PerlinNoise(Time.time, noiseSeed);
			Vector3 position = base.transform.position;
			float t = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
			position.x = Mathf.Lerp(position.x, roofTargetPos.x, t);
			float t2 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
			position.y = Mathf.Lerp(position.y, roofTargetPos.y, t2);
			if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
			{
				base.transform.position = position + GetPositionModifiers();
			}
			else
			{
				base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
			}
			IsInPosition = Mathf.Abs(position.x - roofTargetPos.x) < xVariation && Mathf.Abs(position.y) < yVariation;
		}
	}

	public void Decend()
	{
		if (!(base.TargetUnit == null))
		{
			if (!spiralInitialized)
			{
				spiralStartCenter = base.transform.position;
				spiralInitialized = true;
			}
			if (decentTimer >= decentDuration)
			{
				IsInPosition = true;
				spiralInitialized = false;
				return;
			}
			float num = decentTimer / decentDuration;
			Vector3 position = base.transform.position;
			Vector3 vector = new Vector3(Mathf.Lerp(spiralStartCenter.x, roofTargetPos.x, num), Mathf.Lerp(spiralStartCenter.y, roofTargetPos.y, num), position.z);
			float f = decentTimer * decentRotationSpeed * (MathF.PI / 180f);
			float num2 = decentRadius * spiralRadius.Evaluate(num);
			Vector3 position2 = new Vector3(vector.x + Mathf.Cos(f) * num2, vector.y + Mathf.Sin(f) * num2, position.z);
			base.transform.position = position2;
			Rotator.RotateTowardsMovementVector(90f);
			float num3 = Mathf.Lerp(decentStartSize, 1f, num);
			base.transform.localScale = new Vector3(num3, num3, 1f);
			Shadow.height = Mathf.Lerp(0.2f, 0.01f, num);
			decentTimer += Time.deltaTime;
		}
	}

	public void Retreat()
	{
		Rotator.RotateToAngle(base.transform, 90f);
		base.transform.position += base.transform.right * base.MoveSpeed * Time.deltaTime;
		float t = decentTimer / decentDuration;
		float num = Mathf.Lerp(decentStartSize, 1f, t);
		base.transform.localScale = new Vector3(num, num, 1f);
		Shadow.height = Mathf.Lerp(0.2f, 0.01f, t);
		decentTimer += Time.deltaTime;
		if (Math.Abs(base.transform.position.x) > 5f || Math.Abs(base.transform.position.y) > 5f)
		{
			Despawn();
		}
	}

	public override void Target()
	{
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			Rotator.RotateTowardsPosition(base.TargetUnit.transform.position);
		}
	}

	public override void Shoot()
	{
		base.TargetUnit?.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, base.TargetUnit.HealthComponent, 0f - damage));
		soundBuilder.Play(shootSound);
	}

	public void StartPecking()
	{
		StartCoroutine(RandomPeckingStartTime());
	}

	private IEnumerator RandomPeckingStartTime()
	{
		yield return new WaitForSeconds(UnityEngine.Random.Range(0f, maxWaitUponLanding));
		base.Anim.Play("Peck");
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		GameManager.Instance.ringMinigame.OnStartMinigame -= HandleRingMinigameStarted;
		base.OnDeath(info);
	}

	public void HandleRingMinigameStarted()
	{
		KillSelf();
	}
}
