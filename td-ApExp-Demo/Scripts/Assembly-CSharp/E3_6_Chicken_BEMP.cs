public class E3_6_Chicken_BEMP : BEMPState
{
	private E3_6_Chicken chicken;

	public override string Key => "EMP";

	public E3_6_Chicken_BEMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		chicken = enemy as E3_6_Chicken;
		transitionStates = new string[2] { "Enter", "Attack" };
	}

	public E3_6_Chicken_BEMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		chicken = enemy as E3_6_Chicken;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		base.EnterState();
	}

	public override void FixedUpdateState()
	{
		if ((bool)chicken.TargetUnit && !chicken.hasLanded)
		{
			chicken.Decend();
		}
		else if (chicken.hasLanded)
		{
			chicken.Anim.Play("Confused");
		}
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override bool CanExit()
	{
		return base.CanExit();
	}
}
