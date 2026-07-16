using UnityEngine;

public class E4_B_Idle : StateBaseEnemy
{
	private E4_B_Warlord enemyWarlord;

	private float timer;

	private bool songChosen;

	public override string Key => "Idle";

	public E4_B_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[4] { "Armored", "Aggressive", "Fireborn", "Healer" };
	}

	public E4_B_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyWarlord = enemy as E4_B_Warlord;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemyWarlord.HealthComponent.DamageReductionPercent = enemyWarlord.StartingDamageReductionPercent;
		songChosen = false;
		timer = enemyWarlord.IdleTime;
		enemyWarlord.PlayIdleAnim();
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
		if (!(timer > 0f) && !songChosen)
		{
			enemyWarlord.ChooseSong();
			enemyWarlord.SpawnWave();
			songChosen = true;
			enemyWarlord.PrepareNextSong();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyWarlord.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
