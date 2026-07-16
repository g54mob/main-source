using UnityEngine;

public class E1_B_OpenAndArm : StateBaseEnemy
{
	private EnemyCentipede part;

	public override string Key => "OpenAndArm";

	public E1_B_OpenAndArm(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "AimAndFire" };
		part = enemy as EnemyCentipede;
	}

	public E1_B_OpenAndArm(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		part = enemy as EnemyCentipede;
	}

	public override bool CanEnter()
	{
		return part.isReadyToOpenAndArm;
	}

	public override void EnterState()
	{
		part.plateAnim.Play("Open");
		part.rustAnim.Play("Open");
		part.PlayOpenPlateSound();
		part.HealthComponent.DamageReductionPercent = 0f;
		enemy.IsHackable = true;
		part.HealthComponent.IsImmune = false;
	}

	public override void UpdateState()
	{
		if (!(part.plateAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f))
		{
			part.arma.Anim.Play("Arm");
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		AnimatorStateInfo currentAnimatorStateInfo = part.arma.Anim.GetCurrentAnimatorStateInfo(0);
		if (currentAnimatorStateInfo.IsName("Arm"))
		{
			return currentAnimatorStateInfo.normalizedTime >= 1f;
		}
		return false;
	}
}
