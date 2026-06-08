using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateSwarmDumbAttack : BaseEnemyState
	{
		public override string StateId
		{
			get
			{
				return "SwarmDumbAttack";
			}
		}

		public StateSwarmDumbAttack(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public override void Update()
		{
			if (_brain.CombatTarget != null)
			{
				float num = Vector3.Distance(_brain.ThisEnemy.transform.position, _brain.CombatTarget.Position);
				if (num < _brain.ThisEnemy.AttackRadius && Time.time - _brain.LastAttackTimestamp >= _brain.ThisEnemy.AttackSpeed)
				{
					_brain.LastAttackTimestamp = Time.time;
					_brain.ThisEnemy.AttackTarget(_brain.CombatTarget);
				}
			}
		}

		public override void EnterState()
		{
		}

		public override void ExitState()
		{
		}
	}
}
