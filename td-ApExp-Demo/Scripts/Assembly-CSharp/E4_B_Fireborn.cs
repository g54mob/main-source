public class E4_B_Fireborn : StateBaseEnemy
{
	private E4_B_Warlord enemyWarlord;

	public override string Key => "Fireborn";

	public E4_B_Fireborn(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Vulnerable" };
	}

	public E4_B_Fireborn(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		CombatManager.Instance.HealthChanged += ApplyChanceForBurnToEnemies;
		enemyWarlord.FirebornPs.Play();
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
		CombatManager.Instance.HealthChanged -= ApplyChanceForBurnToEnemies;
	}

	public override bool CanExit()
	{
		return enemyWarlord.IsWaveDead;
	}

	private void ApplyBurnToEnemies()
	{
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if (!enemy.IsBoss)
			{
				enemy.Burn = enemyWarlord.FirebornStackAmount;
			}
		}
	}

	private void ApplyChanceForBurnToEnemies(HealthChangeInfo info)
	{
		if (info.source is EnemyBase { IsBoss: false } && info.HealthChange < 0f && ProbUtils.CheckWithReverseLuck(enemyWarlord.FirebornBurnChance))
		{
			info.Target.ApplyBurn(enemyWarlord.FirebornStackAmount, info.source);
		}
	}
}
