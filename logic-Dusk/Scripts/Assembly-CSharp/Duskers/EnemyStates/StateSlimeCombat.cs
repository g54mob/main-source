using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateSlimeCombat : BaseEnemyState
	{
		private SlimeBrain _slimeBrain;

		private ICombatTarget _combatTarget;

		public override string StateId
		{
			get
			{
				return "SlimeCombat";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateSlimeCombat(BaseEnemyBrain brain)
			: base(brain)
		{
			_slimeBrain = (SlimeBrain)brain;
		}

		public void Initialize(ICombatTarget target)
		{
			_combatTarget = target;
		}

		public override void Update()
		{
			if (_combatTarget.IsDead || _combatTarget.IsHidden || _combatTarget.CurrentRoom != _slimeBrain.SlimeEnemy.CurrentRoom)
			{
				ChangeState(_slimeBrain.StateSlimeReplicate);
			}
			else if (_slimeBrain.CombatReplicateTimer <= 0f)
			{
				_slimeBrain.CombatReplicateTimer = 20f;
				Vector3 normalized = (_combatTarget.Position - _slimeBrain.SlimeEnemy.Position).normalized;
				_slimeBrain.SlimeEnemy.ReplicateSlime(normalized);
			}
		}

		public override void EnterState()
		{
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null" + _combatTarget);
			}
		}

		public override void ExitState()
		{
			_combatTarget = null;
		}
	}
}
