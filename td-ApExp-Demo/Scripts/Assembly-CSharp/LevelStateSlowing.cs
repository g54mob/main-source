using UnityEngine;

public class LevelStateSlowing : LevelBaseState
{
	private float damageTime = 0.05f;

	private float timer;

	public override string Key => "Slowing";

	public LevelStateSlowing(StateMachine sm)
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
		Debug.Log("OnLevelCompleted");
		LevelManager.Instance.OnLevelCompleted();
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.canMove = false;
			player.interactor.InteractorState = InteractorStates.Disabled;
		}
		LevelManager.Instance.DelayedBreak();
		Train.Instance.SetRoofVisibilities(visible: false);
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			EnemyManager.Instance.DamageRandomEnemy();
			timer = damageTime;
		}
		Train.Instance.Brake();
	}

	public override bool CanExit()
	{
		return Train.Instance.SpeedCurrent == 0f;
	}

	public override void ExitState()
	{
		EnemyManager.Instance.InstakillAllEnemies();
		Train.Instance.MaxHealAllModules(hideHealParticles: true);
		Debug.Log("Exited LevelStateSlowing");
	}
}
