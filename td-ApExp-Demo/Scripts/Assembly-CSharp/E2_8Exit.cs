using UnityEngine;

public class E2_8Exit : StateBaseEnemy
{
	private E2_8MedDart medDart;

	private bool canExit;

	public override string Key => "Exit";

	public E2_8Exit(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E2_8Exit(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
	}

	public override void UpdateState()
	{
		if (Mathf.Abs(medDart.transform.position.y) >= 4f)
		{
			medDart.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(medDart, medDart.HealthComponent, -100f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
