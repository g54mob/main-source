public class E2_8Heal : StateBaseEnemy
{
	private E2_8MedDart medDart;

	private bool canExit;

	public override string Key => "Heal";

	public E2_8Heal(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_8Heal(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		medDart = enemy as E2_8MedDart;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		canExit = false;
		medDart.StartHealingParticles();
	}

	public override void UpdateState()
	{
		medDart.TickHeal();
		if (medDart.TargetUnit == null || !medDart.CheckIsTargetHealable())
		{
			canExit = true;
			ExitState();
		}
		else
		{
			medDart.Heal(noTick: true);
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		medDart.Move();
	}

	public override void ExitState()
	{
		medDart.StopHealingParticles();
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
