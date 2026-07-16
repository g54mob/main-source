using System;
using UnityEngine;

public class E3_9_Expanding : StateBaseEnemy
{
	private E3_9_FlyingSucker sucker;

	private float extensionTimer;

	public override string Key => "Expanding";

	public E3_9_Expanding(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Sucking", "Retracting" };
	}

	public E3_9_Expanding(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		sucker = enemy as E3_9_FlyingSucker;
	}

	public override bool CanEnter()
	{
		if (sucker.IsInPosition)
		{
			return sucker.TargetUnit != null;
		}
		return false;
	}

	public override void EnterState()
	{
		sucker.neckHeadGo.SetActive(value: false);
		foreach (SpriteRenderer coalHoseSprite in sucker.coalHoseSprites)
		{
			coalHoseSprite.enabled = true;
		}
		Debug.LogWarning($"{enemy}: {sm.CurrentState}");
		sucker.Hose.PlayExpandingSound();
		sucker.Hose.Retracted = false;
		extensionTimer = 0f;
		sucker.Hose.IsLocked = false;
		sucker.Hose.ExtensionState = ExtensionState.Expanding;
	}

	public override void UpdateState()
	{
		extensionTimer += Time.deltaTime * sucker.Hose.expansionSpeed;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		sucker.Hose.SetExpansion(MathF.Min(extensionTimer, 1f));
	}

	public override void ExitState()
	{
		sucker.Hose.StopAudio();
	}

	public override bool CanExit()
	{
		return sucker.Hose.IsAttached;
	}
}
