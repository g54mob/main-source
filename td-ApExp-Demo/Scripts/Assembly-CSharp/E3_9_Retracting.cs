using UnityEngine;

public class E3_9_Retracting : StateBaseEnemy
{
	private E3_9_FlyingSucker sucker;

	private float retractTimer;

	public override string Key => "Retracting";

	public E3_9_Retracting(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Expanding" };
	}

	public E3_9_Retracting(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		sucker = enemy as E3_9_FlyingSucker;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning($"{enemy}: {sm.CurrentState}");
		sucker.Hose.PlayExpandingSound();
		retractTimer = 1f;
		sucker.Hose.IsLocked = false;
		sucker.Hose.ExtensionState = ExtensionState.Retracting;
	}

	public override void UpdateState()
	{
		retractTimer -= Time.deltaTime * sucker.Hose.expansionSpeed;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		sucker.Hose.SetExpansion(Mathf.Max(retractTimer, 0f));
	}

	public override void ExitState()
	{
		sucker.Hose.StopAudio();
		sucker.EnableInertia();
	}

	public override bool CanExit()
	{
		return sucker.Hose.Retracted;
	}
}
