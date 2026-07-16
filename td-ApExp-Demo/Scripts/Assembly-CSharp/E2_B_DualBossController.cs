using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_B_DualBossController : EnemyBase, iMainBossController, iBossController
{
	[Header("Dual Boss")]
	[SerializeField]
	public E2_B_BossAController bossA;

	[SerializeField]
	public E2_B_BossBController bossB;

	[SerializeField]
	private float chainAttackTime;

	[SerializeField]
	private float dualAttackChargeTime;

	public float chainAttackTimer;

	private float dualAttackChargeTimer;

	[NonSerialized]
	public bool ChainsBroke;

	[NonSerialized]
	public bool ChainAttackComplete;

	[NonSerialized]
	public bool HealingComplete;

	[NonSerialized]
	public bool BossesInScreen;

	[SerializeField]
	public int coresToDrop;

	private bool bothDead;

	private bool defeated;

	public bool BothBossesInPosition
	{
		get
		{
			if (bossA.IsInPosition)
			{
				return bossB.IsInPosition;
			}
			return false;
		}
	}

	public bool BothBossesDead
	{
		get
		{
			if (bossA.HealthComponent.IsDead)
			{
				return bossB.HealthComponent.IsDead;
			}
			return false;
		}
	}

	public bool BothBossesChainAttackReady
	{
		get
		{
			if (bossA.ChainAttackCharged)
			{
				return bossB.ChainAttackCharged;
			}
			return false;
		}
	}

	public event Action ControllerDied;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[6]
		{
			new E2_B_DB_Enter(sm, this),
			new E2_B_DB_Exit(sm, this),
			new E2_B_DB_Idle(sm, this),
			new E2_B_DB_Dead(sm, this),
			new E2_B_DB_ChainAttack(sm, this),
			new E2_B_DB_EMP(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
		}
	}

	public void BothDead()
	{
		if (!bothDead)
		{
			this.ControllerDied?.Invoke();
			bossA.OnFullDead();
			bossB.OnFullDead();
			StartCoroutine(bossA.ReleaseChains());
			bothDead = true;
			StartCoroutine(DestroySelf());
		}
	}

	private IEnumerator DestroySelf()
	{
		EnemyManager.Instance.OnDualBossDestroyed();
		yield return new WaitForSeconds(5f);
		LevelManager.Instance.HandleBossBeaten(coresToDrop);
		KillSelf();
	}

	public E2_B_BossController GetOtherBossController(E2_B_BossController boss)
	{
		if (boss is E2_B_BossAController)
		{
			return bossB;
		}
		if (boss is E2_B_BossBController)
		{
			return bossA;
		}
		return null;
	}

	public void TriggerBossDied(E2_B_BossController deadController)
	{
		if (BothBossesDead && !defeated)
		{
			BothDead();
		}
		else
		{
			StartCoroutine(TryStartRevive(deadController));
		}
	}

	private IEnumerator TryStartRevive(E2_B_BossController deadController)
	{
		E2_B_BossController liveBoss = GetOtherBossController(deadController);
		if (liveBoss.sm.CurrentState.ToString() != "E2_B_Reviving")
		{
			while (liveBoss.StateSwitchBlocked)
			{
				yield return new WaitForSeconds(0.1f);
			}
			liveBoss.sm.ForceState("Reviving");
		}
	}

	public bool BossesReadyForChainAttack()
	{
		if (!bossA.StateSwitchBlocked)
		{
			return !bossB.StateSwitchBlocked;
		}
		return false;
	}

	public void StartChainAttack()
	{
		bossA.sm.ForceState("PrepareChainAttack");
		bossB.sm.ForceState("PrepareChainAttack");
	}

	public void StopChainAttack()
	{
		bossA.sm.ForceState("Exit");
		bossB.sm.ForceState("Exit");
	}

	public void CommitChainAttack()
	{
		bossA.ChainAttack();
		bossB.ChainAttack();
	}

	public void Enter()
	{
		bossA.Enter();
		bossB.Enter();
	}

	public void Exit()
	{
		bossA.Exit();
		bossB.Exit();
		bossA.CancelChainAttack();
		bossB.CancelChainAttack();
	}

	public void ResetChainAttackTimer()
	{
		chainAttackTimer = chainAttackTime;
	}

	public bool TickChainAttack()
	{
		return (chainAttackTimer -= Time.deltaTime) <= 0f;
	}

	public void ResetChainChargeTimer()
	{
		dualAttackChargeTimer = dualAttackChargeTime;
	}

	public bool TickChargeTime()
	{
		return (dualAttackChargeTimer -= Time.deltaTime) <= 0f;
	}

	public float GetCurrentTotalHealth()
	{
		return 0f;
	}

	public float GetTotalMaxHealth()
	{
		return 0f;
	}

	public override void EMP(float duration)
	{
	}

	public override void OnEMPEnd()
	{
	}

	public List<iBossController> GetAllControllers()
	{
		return new List<iBossController> { bossA, bossB };
	}
}
