using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateCombatNavigate : StateNavigatePath
	{
		private ICombatTarget _combatTarget;

		public override string StateId
		{
			get
			{
				return "CombatNavigate";
			}
		}

		public StateCombatNavigate(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public void Initialize(Waypoint destinationWaypoint, ICombatTarget combatTarget)
		{
			Initialize(destinationWaypoint, _brain.StateCombatAttack);
			_combatTarget = combatTarget;
		}

		public void Initialize(Waypoint destinationWaypoint, ICombatTarget combatTarget, IState returnState)
		{
			Initialize(destinationWaypoint, returnState);
			_combatTarget = combatTarget;
		}

		public override void Update()
		{
			base.Update();
			if (_combatTarget != null && _brain.ThisEnemy.TargetIsInSameRoom(_combatTarget))
			{
				ForceReturnToPrevious();
			}
		}

		public override void EnterState()
		{
			base.EnterState();
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null");
			}
		}

		public override void ExitState()
		{
			base.ExitState();
			_combatTarget = null;
		}
	}
}
