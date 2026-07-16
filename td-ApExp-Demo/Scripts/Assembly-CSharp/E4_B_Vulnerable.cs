using UnityEngine;

public class E4_B_Vulnerable : StateBaseEnemy
{
	private E4_B_Warlord enemyWarlord;

	private float timer;

	public override string Key => "Vulnerable";

	public E4_B_Vulnerable(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E4_B_Vulnerable(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		enemyWarlord.IsVulnerable = true;
		if ((bool)enemyWarlord.ShieldGo)
		{
			enemyWarlord.ShieldGo.SetActive(value: false);
		}
		enemyWarlord.PlayStunnedAnim();
		timer = enemyWarlord.VulnerabilityDuration;
		enemyWarlord.HealthComponent.DamageReductionPercent = 0f;
		enemyWarlord.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(enemyWarlord, enemyWarlord.HealthComponent, 0f - enemyWarlord.PercentDamageOnWaveCleared, isPercent: true));
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyWarlord.Move();
	}

	public override void ExitState()
	{
		enemyWarlord.IsVulnerable = false;
		if ((bool)enemyWarlord.ShieldGo)
		{
			enemyWarlord.ShieldGo.SetActive(value: true);
		}
	}

	public override bool CanExit()
	{
		return timer <= 0f;
	}
}
