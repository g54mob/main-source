using System;
using System.Collections.Generic;
using UnityEngine;

public class E3_B_C_SecondaryWeapon_DisruptorScrambler : E3_B_C_SecondaryWeapon
{
	[Header("Secondary Fields")]
	private float secondaryTimer;

	private float scrambleTimer;

	[SerializeField]
	private float scrambleDuration;

	[NonSerialized]
	public bool isScrambling;

	[NonSerialized]
	public float scrambleCooldownTimer;

	[SerializeField]
	private List<ParticleSystem> empAoePs;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E3_B_C_Disruptor_Idle(sm, this),
			new E3_B_C_Disruptor_Retreat(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Start()
	{
		base.Start();
		secondaryTimer = FirstIdleTime;
	}

	private new void Update()
	{
		if (Time.timeScale == 0f || Time.deltaTime == 0f)
		{
			return;
		}
		base.Update();
		if (!base.IsDead)
		{
			secondaryTimer -= Time.deltaTime;
		}
		if (secondaryTimer <= 0f && !isScrambling)
		{
			Scramble();
		}
		if (isScrambling)
		{
			scrambleTimer -= Time.deltaTime;
			if (scrambleTimer < 0f)
			{
				Unscramble();
				isScrambling = false;
			}
		}
	}

	public void Scramble()
	{
		if (!EnemyManager.Instance.scramblersAlive.Contains(this))
		{
			EnemyManager.Instance.scramblersAlive.Add(this);
		}
		isScrambling = true;
		EnemyManager.Instance.Scramble();
		scrambleTimer = scrambleDuration;
		base.Anim.Play("CrowBossSecondaryScramble");
		EffectsUtils.PlayMultipleParticles(empAoePs, play: true);
		soundBuilder.Play(shootSound);
	}

	public void Unscramble()
	{
		if (EnemyManager.Instance.scramblersAlive.Contains(this))
		{
			EnemyManager.Instance.scramblersAlive.Remove(this);
		}
		EnemyManager.Instance.Unscramble();
		secondaryTimer = IdleTime;
		isScrambling = false;
		base.Anim.Play("CrowBossSecondaryIdle");
	}

	public override void Activate()
	{
		base.Activate();
		Scramble();
	}

	public override void Deactivate()
	{
		base.Deactivate();
		Unscramble();
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		Deactivate();
		base.OnDeath(info);
	}
}
