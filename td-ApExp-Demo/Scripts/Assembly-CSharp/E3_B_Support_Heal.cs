using UnityEngine;

public class E3_B_Support_Heal : StateBaseEnemy
{
	private E3_B_Phase1Plane_Support bossPlane;

	public override string Key => "Heal";

	public E3_B_Support_Heal(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_B_Support_Heal(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		bossPlane = enemy as E3_B_Phase1Plane_Support;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Entering Heal State");
		bossPlane.Target();
		bossPlane.HealMode(isOn: true);
	}

	public override void UpdateState()
	{
		if (bossPlane.TargetUnit != null)
		{
			bossPlane.StartHealingParticles();
			bossPlane.Heal();
		}
	}

	public override void FixedUpdateState()
	{
		bossPlane.Move();
		bossPlane.Target();
	}

	public override void ExitState()
	{
		bossPlane.StopHealingParticles();
		bossPlane.TargetUnit = null;
		bossPlane.HealMode(isOn: false);
	}

	public override bool CanExit()
	{
		return bossPlane.FinishedHealing;
	}
}
