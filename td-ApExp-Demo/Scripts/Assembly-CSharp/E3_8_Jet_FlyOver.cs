using UnityEngine;

public class E3_8_Jet_FlyOver : StateBaseEnemy
{
	private E3_8_FighterJet jet;

	private float delayTimer;

	private float delayBeforeDespawn;

	public override string Key => "FlyOver";

	public E3_8_Jet_FlyOver(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Leave" };
	}

	public E3_8_Jet_FlyOver(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		jet = enemy as E3_8_FighterJet;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		jet.flyOverTimer = jet.flyOverDuration;
		delayTimer = 0.5f;
		delayBeforeDespawn = 3.5f;
		jet.PlayFlyOverSound();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		if ((delayTimer -= Time.deltaTime) <= 0f)
		{
			jet.MoveForFlyOver();
		}
		delayBeforeDespawn -= Time.deltaTime;
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return delayBeforeDespawn <= 0f;
	}
}
