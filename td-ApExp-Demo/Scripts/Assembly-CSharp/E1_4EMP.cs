public class E1_4EMP : BEMPState
{
	public override string Key => "EMP";

	public E1_4EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E1_4EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		enemy.Anim.Play("EMP");
		enemy.HealthComponent.IsImmune = false;
		base.EnterState();
	}

	public override void ExitState()
	{
		enemy.HealthComponent.IsImmune = true;
		base.ExitState();
	}
}
