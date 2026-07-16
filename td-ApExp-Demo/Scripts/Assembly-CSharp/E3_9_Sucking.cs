using UnityEngine;

public class E3_9_Sucking : StateBaseEnemy
{
	private E3_9_FlyingSucker sucker;

	public override string Key => "Sucking";

	public E3_9_Sucking(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Retracting" };
	}

	public E3_9_Sucking(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		sucker = enemy as E3_9_FlyingSucker;
	}

	public override bool CanEnter()
	{
		return sucker.IsInPosition;
	}

	public override void EnterState()
	{
		Debug.LogWarning($"{enemy}: {sm.CurrentState}");
		sucker.isSuckingHoseAttached = true;
		sucker.Hose.StartSuckAnim();
		sucker.Hose.PlaySuckingSound();
		EffectsUtils.PlayMultipleParticles(sucker.coalPoops, play: true);
	}

	public override void UpdateState()
	{
		sucker.shotTimer -= Time.deltaTime;
		sucker.Shoot();
	}

	public override void ExitState()
	{
		sucker.Hose.StopSuckingAnim();
		sucker.Hose.StopAudio();
		sucker.Hose.Retract();
		Train.Instance.RemoveDrainer(sucker);
		EffectsUtils.PlayMultipleParticles(sucker.coalPoops, play: false);
	}

	public override bool CanExit()
	{
		return sucker.LeftRange();
	}
}
