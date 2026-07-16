using UnityEngine;

public class E4_2MoveIntoTrain : BMoveState
{
	private E4_2HeavyBomber heavyBomber;

	public override string Key => "E4MoveIntoTrain";

	public E4_2MoveIntoTrain(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[0];
	}

	public E4_2MoveIntoTrain(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		heavyBomber = enemy.GetComponent<E4_2HeavyBomber>();
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
		position = ((!(heavyBomber.PushBackOffset() != Vector3.zero)) ? enemy.TargetUnit.transform.position : heavyBomber.PushBackOffset());
		enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, position, enemy.MoveSpeed * enemy.SnotModifier * Time.deltaTime);
		if (Vector3.Distance(enemy.transform.position, position) <= 0.1f)
		{
			if (enemy.IsEnemy)
			{
				heavyBomber.ReachedTrainExplosion();
				return;
			}
			heavyBomber.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(null, enemy.HealthComponent, 0f - heavyBomber.damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
			heavyBomber.KillSelf();
		}
	}
}
