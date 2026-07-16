using UnityEngine;

public class LevelStateFadeIn : LevelBaseState
{
	public override string Key => "FadeIn";

	public LevelStateFadeIn(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[1] { "Station" };
	}

	public override bool CanEnter()
	{
		return LevelManager.Instance.CurrentLevel != null;
	}

	public override void EnterState()
	{
		Debug.Log("OnFadeIn");
	}

	public override void UpdateState()
	{
		EnemyManager.Instance.DamageRandomEnemy();
	}

	public override bool CanExit()
	{
		return true;
	}

	public override void ExitState()
	{
	}
}
