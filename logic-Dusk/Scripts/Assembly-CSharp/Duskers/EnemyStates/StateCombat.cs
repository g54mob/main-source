using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateCombat : BaseEnemyState, ICombatState
	{
		private const float TARGET_SWAP_TIME = 2f;

		private float _targetSwapTimer;

		private StateMachine _subStateMachine;

		private bool _loggedError;

		public override string StateId
		{
			get
			{
				return "Combat";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateCombat(BaseEnemyBrain brain)
			: base(brain)
		{
			_subStateMachine = new StateMachine();
		}

		public void Initialize(ICombatTarget target)
		{
			_brain.SetCombatTarget(target);
		}

		public override void Update()
		{
			if (_brain.ThisEnemy.ShouldLeaveCurrentRoom())
			{
				ChangeState(_brain.StateFlee);
				return;
			}
			MonoBehaviour monoBehaviour = _brain.CombatTarget as MonoBehaviour;
			if (_brain.CombatTarget == null || (monoBehaviour != null && monoBehaviour.gameObject == null))
			{
				if (!_loggedError)
				{
					_loggedError = true;
					Debug.LogWarning("StateCombat - target is null???");
				}
				ChangeState(_brain.StatePatrol);
				return;
			}
			if (_brain.CombatTarget.IsDead || _brain.ThisEnemy.IsTargetHidden(_brain.CombatTarget))
			{
				ChangeState(_brain.StatePatrol);
				return;
			}
			_targetSwapTimer -= Time.deltaTime;
			if (_targetSwapTimer <= 0f)
			{
				_targetSwapTimer = 2f;
				ICombatTarget mostThreateningTarget = _brain.ThisEnemy.GetMostThreateningTarget();
				if (mostThreateningTarget != null && mostThreateningTarget != _brain.CombatTarget)
				{
					_brain.SetCombatTarget(mostThreateningTarget);
				}
			}
			if (!_brain.ThisEnemy.TargetIsInSameRoom(_brain.CombatTarget))
			{
				Waypoint waypoint = null;
				IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom)
					where _brain.ThisEnemy.AdjacentRoomCanBeEntered(x)
					select x;
				foreach (AdjacentRoomData item in enumerable)
				{
					Room room = ((!(item.Room1 == _brain.ThisEnemy.CurrentRoom)) ? item.Room1 : item.Room2);
					if (_brain.CombatTarget.CurrentRoom == room)
					{
						waypoint = NavigationHelper.GetMainRoomWaypoint(room);
						break;
					}
				}
				if (waypoint == null)
				{
					ChangeState(_brain.StatePatrol);
					return;
				}
			}
			_subStateMachine.Update();
		}

		public override void EnterState()
		{
			if (_brain.CombatTarget == null)
			{
				Debug.LogWarning("CombatTarget must be set before entering " + StateId);
			}
			_targetSwapTimer = 2f;
			_loggedError = false;
			_subStateMachine.ChangeState(_brain.StateCombatAttack);
		}

		public override void ExitState()
		{
			_brain.SetCombatTarget(null);
			_targetSwapTimer = 0f;
			_subStateMachine.EndAllStates();
		}
	}
}
