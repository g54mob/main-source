public class E4_B_Aggressive : StateBaseEnemy
{
	private E4_B_Warlord enemyWarlord;

	public override string Key => "Aggressive";

	public E4_B_Aggressive(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Vulnerable" };
	}

	public E4_B_Aggressive(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		ApplyBuffToEnemies();
		enemyWarlord.AggressivePs.Play();
	}

	public override void UpdateState()
	{
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
		return enemyWarlord.IsWaveDead;
	}

	private void ApplyBuffToEnemies()
	{
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if (!enemy.IsBoss)
			{
				enemy.DamageModifier += enemyWarlord.AggressiveDamageIncrease;
				enemy.RofModifier += enemyWarlord.AggressiveRofIncrease;
			}
		}
	}
}
