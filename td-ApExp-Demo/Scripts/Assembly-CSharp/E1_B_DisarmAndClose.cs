using UnityEngine;

public class E1_B_DisarmAndClose : StateBaseEnemy
{
	private EnemyCentipede part;

	public override string Key => "DisarmAndClose";

	public E1_B_DisarmAndClose(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
		part = enemy as EnemyCentipede;
	}

	public E1_B_DisarmAndClose(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		part = enemy as EnemyCentipede;
	}

	public override bool CanEnter()
	{
		return !part.isReadyToOpenAndArm;
	}

	public override void EnterState()
	{
		enemy.HealthComponent.DamageReductionPercent = 90f;
		part.HealthComponent.IsImmune = true;
	}

	public override void UpdateState()
	{
		if (part.arma.TryDisarm())
		{
			part.arma.Anim.Play("Disarm");
			AnimatorStateInfo currentAnimatorStateInfo = part.arma.Anim.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.IsName("Disarm") && !(currentAnimatorStateInfo.normalizedTime < 1f))
			{
				part.plateAnim.Play("Close");
				part.rustAnim.Play("Close");
			}
		}
	}

	public override void ExitState()
	{
		enemy.IsHackable = false;
		enemy.empDuration = 0f;
	}

	public override bool CanExit()
	{
		AnimatorStateInfo currentAnimatorStateInfo = part.plateAnim.GetCurrentAnimatorStateInfo(0);
		if (currentAnimatorStateInfo.IsName("Close"))
		{
			return currentAnimatorStateInfo.normalizedTime >= 1f;
		}
		return false;
	}
}
