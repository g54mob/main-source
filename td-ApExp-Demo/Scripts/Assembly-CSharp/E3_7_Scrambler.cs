using System;
using System.Collections.Generic;
using UnityEngine;

public class E3_7_Scrambler : EnemyBase
{
	[Header("Scrambler Fields")]
	[SerializeField]
	private float xVariation = 0.3f;

	[SerializeField]
	private float yVariation = 0.3f;

	[SerializeField]
	private Animator scrambleAnim;

	[SerializeField]
	private float enemyDamageReductionPercent;

	[SerializeField]
	private float scrambleDuration;

	[SerializeField]
	private List<ParticleSystem> empAoePs;

	private float angle;

	[Header("Rotation Movement")]
	[SerializeField]
	private float rotationRadius;

	private Transform rotationCenter;

	private Vector2 targetPos;

	private float scrambleTimer;

	[NonSerialized]
	public bool isScrambling;

	public Vector3 TargetPos => targetPos;

	private new void Awake()
	{
		base.Awake();
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E3_7_Enter(sm, this),
			new E3_7_Idle(sm, this),
			new E3_7_EMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		Target();
		rotationCenter = Train.Instance.GetCannonModuleSlot().transform;
	}

	private new void Update()
	{
		if (Time.timeScale == 0f || Time.deltaTime == 0f)
		{
			return;
		}
		base.Update();
		if (!IsHacked)
		{
			scrambleTimer -= Time.deltaTime;
			if (scrambleTimer < 0f && isScrambling)
			{
				Unscramble();
				isScrambling = false;
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

	public override void Target()
	{
		targetPos = new Vector2(UnityEngine.Random.Range(-1.5f, 1.5f), UnityEngine.Random.Range(minY, maxY) * base.posSignTf);
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
		float t4 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
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
		previousPos = position;
	}

	public void Scramble()
	{
		if (!EnemyManager.Instance.scramblersAlive.Contains(this))
		{
			EnemyManager.Instance.scramblersAlive.Add(this);
		}
		EnemyManager.Instance.Scramble();
		isScrambling = true;
		scrambleTimer = scrambleDuration;
		scrambleAnim.Play("E3_7_ScramblerDishScramble");
		EffectsUtils.PlayMultipleParticles(empAoePs, play: true);
		soundBuilder.Play(shootSound);
	}

	public void Unscramble()
	{
		if (EnemyManager.Instance.scramblersAlive.Contains(this))
		{
			EnemyManager.Instance.scramblersAlive.Remove(this);
		}
		SetIdleTimer();
		EnemyManager.Instance.Unscramble();
		isScrambling = false;
		scrambleTimer = 0f;
		scrambleAnim.Play("E3_7_ScramblerDishIdle");
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		Unscramble();
		base.OnDeath(info);
	}

	public override void Despawn()
	{
		Unscramble();
		base.Despawn();
	}

	public override void Hack(bool isHacked)
	{
		base.Hack(isHacked);
		EnemyManager.Instance.scramblerHacked = isHacked;
		if (isHacked)
		{
			Unscramble();
			{
				foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
				{
					if (enemy.IsEnemy != base.IsEnemy)
					{
						enemy.HealthComponent.ApplyWeaken(999f);
					}
				}
				return;
			}
		}
		foreach (EnemyBase enemy2 in EnemyManager.Instance.Enemies)
		{
			enemy2.HealthComponent.RemoveWeaken();
		}
	}
}
