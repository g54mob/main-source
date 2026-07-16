using UnityEngine;

public class E4OpenShield : StateBaseEnemy
{
	private E4Cocoon coc;

	public override string Key => "OpenShield";

	public E4OpenShield(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "ShootThrice" };
		coc = enemy as E4Cocoon;
	}

	public E4OpenShield(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		coc = enemy as E4Cocoon;
	}

	public override bool CanEnter()
	{
		coc.openShieldCdElapsed += Time.deltaTime;
		if (coc.openShieldCdElapsed >= coc.openShieldCd)
		{
			return enemy.TargetUnit != null;
		}
		return false;
	}

	public override void EnterState()
	{
		enemy.Anim.Play("None", 0, 0f);
		enemy.Anim.Play("Open", 1);
		enemy.HealthComponent.IsImmune = false;
	}

	public override void UpdateState()
	{
		enemy.Aim();
	}

	public override bool CanExit()
	{
		return enemy.Anim.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1f;
	}

	public override void ExitState()
	{
		coc.openShieldCdElapsed = 0f;
	}
}
