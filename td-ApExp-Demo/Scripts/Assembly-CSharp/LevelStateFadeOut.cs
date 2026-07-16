using UnityEngine;

public class LevelStateFadeOut : LevelBaseState
{
	public override string Key => "FadeOut";

	public LevelStateFadeOut(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[1] { "FadeIn" };
	}

	public override bool CanEnter()
	{
		return LevelManager.Instance.CurrentLevel != null;
	}

	public override void EnterState()
	{
		Debug.Log("OnFadeOut");
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
		EnemyManager.Instance.InstakillAllEnemies();
		Train.Instance.Brake();
		Train.Instance.MaxHealAllModules(hideHealParticles: true);
	}
}
