using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StatePatrol : BaseEnemyState
	{
		private const float FLEE_CHECK_COOLDOWN = 0.5f;

		private const float STEALTH_CHECK_COOLDOWN = 0.2f;

		private const float STEALTH_CHECK_LONG_COOLDOWN = 1f;

		private StateMachine _subStateMachine;

		private float _localTargetSelectionTimer;

		private float TargetSelectCooldown = 1f;

		private float _fleeCheckTimer;

		private float _stealthCheckTimer;

		private BaseEnemyState _initialSubState;

		private BaseEnemyState _combatState;

		public override string StateId
		{
			get
			{
				return "Patrol";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StatePatrol(BaseEnemyBrain brain)
			: base(brain)
		{
			_subStateMachine = new StateMachine();
		}

		public void Initialize(BaseEnemyState initialSubState, BaseEnemyState combatState)
		{
			Initialize(initialSubState, combatState, TargetSelectCooldown);
		}

		public void Initialize(BaseEnemyState initialSubState, BaseEnemyState combatState, float targetSelectTime)
		{
			_initialSubState = initialSubState;
			_combatState = combatState;
			TargetSelectCooldown = targetSelectTime;
		}

		public override void Update()
		{
			if (!_brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.ImmuneToSonic))
			{
				_fleeCheckTimer -= Time.deltaTime;
				if (_fleeCheckTimer <= 0f)
				{
					_fleeCheckTimer = 0.5f;
					if (_brain.ThisEnemy.ShouldLeaveCurrentRoom())
					{
						ChangeState(_brain.StateFlee);
						return;
					}
				}
			}
			_localTargetSelectionTimer -= Time.deltaTime;
			if (!_brain.IgnoreCombatWhileNavigating && (_localTargetSelectionTimer <= 0f || _brain.CollisionTarget != null))
			{
				_localTargetSelectionTimer = TargetSelectCooldown;
				ICombatTarget combatTarget = null;
				if (_brain.CollisionTarget != null && (!_brain.CollisionTarget.IsHidden || _brain.CanSeeThroughStealth))
				{
					combatTarget = _brain.CollisionTarget;
				}
				if (combatTarget == null)
				{
					combatTarget = _brain.ThisEnemy.SelectBestCombatTarget();
				}
				if (combatTarget != null && _combatState is ICombatState)
				{
					((ICombatState)_combatState).Initialize(combatTarget);
					ChangeState(_combatState);
					return;
				}
			}
			if (!_brain.IgnoreCombatWhileNavigating && _brain.ThisEnemy != null && _brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.DetectsStealth))
			{
				_stealthCheckTimer -= Time.deltaTime;
				if (_stealthCheckTimer <= 0f || _brain.CollisionTarget != null)
				{
					_stealthCheckTimer = 0.2f;
					ICombatTarget combatTarget2 = null;
					if (_brain.CollisionTarget != null)
					{
						combatTarget2 = _brain.CollisionTarget;
					}
					if (combatTarget2 == null)
					{
						int count = DroneManager.Instance.dronesList.Count;
						for (int i = 0; i < count; i++)
						{
							Drone drone = DroneManager.Instance.dronesList[i];
							if (drone != null && _brain.BumpedIntoStealthDrone(drone))
							{
								combatTarget2 = drone;
							}
						}
					}
					if (combatTarget2 != null)
					{
						_stealthCheckTimer = 1f;
						_brain.StatePatrolCurious.Initialize(combatTarget2, _initialSubState);
						_subStateMachine.ChangeState(_brain.StatePatrolCurious);
						return;
					}
				}
			}
			_subStateMachine.Update();
		}

		public override void EnterState()
		{
			_localTargetSelectionTimer = TargetSelectCooldown;
			_fleeCheckTimer = 0.5f;
			_stealthCheckTimer = 0.2f;
			_subStateMachine.ChangeState(_initialSubState);
		}

		public override void ExitState()
		{
			_localTargetSelectionTimer = 0f;
			_fleeCheckTimer = 0f;
			_stealthCheckTimer = 0f;
			if (_subStateMachine.CurrentState == "Patrol")
			{
				Debug.Log("ExitState: current substate: " + _subStateMachine.CurrentState);
			}
			_subStateMachine.EndAllStates();
		}
	}
}
