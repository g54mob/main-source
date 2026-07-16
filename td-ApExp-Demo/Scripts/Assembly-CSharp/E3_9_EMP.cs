public class E3_9_EMP : BEMPState
{
	public override string Key => "EMP";

	public E3_9_EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_9_EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		enemy.Anim.Play("EMP", 1);
		base.EnterState();
	}
}
