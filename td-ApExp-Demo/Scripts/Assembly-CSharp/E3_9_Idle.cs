using UnityEngine;

public class E3_9_Idle : StateBaseEnemy
{
	private E3_9_FlyingSucker sucker;

	public override string Key => "Idle";

	public E3_9_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Expanding" };
	}

	public E3_9_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		sucker.neckHeadGo.SetActive(value: true);
		foreach (SpriteRenderer coalHoseSprite in sucker.coalHoseSprites)
		{
			coalHoseSprite.enabled = false;
		}
		Debug.LogWarning($"{enemy}: {sm.CurrentState}");
		sucker.SetIdleTimer();
		sucker.Hose.IsLocked = true;
		sucker.Hose.ExtensionState = ExtensionState.None;
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
		sucker.DisableInertia();
	}

	public override bool CanExit()
	{
		return sucker.IsInPosition;
	}
}
