public class E7Expanding : StateBaseEnemy
{
	public override string Key => "Expanding";

	public E7Expanding(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E7Expanding(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return !(enemy as E7Wall).isExpanded;
	}

	public override void EnterState()
	{
		enemy.Anim.Play("Expand", 0);
		(enemy as E7Wall).isExpanded = true;
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
		if ((enemy as E7Wall).isExpanded)
		{
			enemy.Anim.Play("Expanded", 1);
		}
	}

	public override bool CanExit()
	{
		return enemy.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f;
	}
}
