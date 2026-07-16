using UnityEngine;

public class E1_3MoveIntoTrain : BMoveState
{
	public override string Key => "E3MoveIntoTrain";

	public E1_3MoveIntoTrain(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[0];
	}

	public E1_3MoveIntoTrain(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		if (enemy.TargetUnit == null)
		{
			return;
		}
		enemy.Aim();
		Vector3 position = enemy.transform.position;
		position = enemy.TargetUnit.transform.position;
		enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, position, enemy.MoveSpeed * Time.deltaTime);
		if (!(Vector3.Distance(enemy.transform.position, position) <= 0.1f))
		{
			return;
		}
		if (enemy.IsEnemy)
		{
			if (enemy is E1_3Bomber)
			{
				(enemy as E1_3Bomber).ReachedTrainExplosion();
			}
			else if (enemy is E3_4_EjectorSuicider)
			{
				(enemy as E3_4_EjectorSuicider).ReachedTrainExplosion();
			}
			else if (enemy is E4_2HeavyBomber e4_2HeavyBomber)
			{
				e4_2HeavyBomber.ReachedTrainExplosion();
			}
		}
		else if (enemy is E1_3Bomber)
		{
			(enemy as E1_3Bomber).HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(null, enemy.HealthComponent, enemy.damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
		}
		else if (enemy is E3_4_EjectorSuicider)
		{
			(enemy as E3_4_EjectorSuicider).HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(null, enemy.HealthComponent, enemy.damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
		}
		else if (enemy is E4_2HeavyBomber e4_2HeavyBomber2)
		{
			e4_2HeavyBomber2.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(null, enemy.HealthComponent, e4_2HeavyBomber2.damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
		}
	}
}
