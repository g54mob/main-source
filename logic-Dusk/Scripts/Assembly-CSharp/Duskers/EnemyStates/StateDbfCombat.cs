using System;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfCombat : BaseEnemyState, ICombatState
	{
		private const float TARGET_SWAP_CHECK_TIME = 5f;

		private const float TARGET_FORGET_TIME_MIN = 18f;

		private const float TARGET_FORGET_TIME_MAX = 25f;

		private ICombatTarget _combatTarget;

		private StateMachine _subStateMachine;

		private DbfBrain _dbfBrain;

		private float _targetSwapTimer;

		private float _targetForgetTimer;

		private static System.Random _random = new System.Random();

		public override string StateId
		{
			get
			{
				return "DbfCombat";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfCombat(BaseEnemyBrain brain)
			: base(brain)
		{
			_subStateMachine = new StateMachine();
			_dbfBrain = (DbfBrain)brain;
		}

		public void Initialize(ICombatTarget target)
		{
			_combatTarget = target;
		}

		public override void Update()
		{
			if (_brain.ThisEnemy.ShouldLeaveCurrentRoom())
			{
				_brain.StateFlee.Initialize(_dbfBrain.Dbf.RunSpeed);
				ChangeState(_brain.StateFlee);
				return;
			}
			if (_combatTarget == null || _combatTarget.IsDead || _combatTarget.IsHidden || (!(_combatTarget is LureItem) && !_brain.ThisEnemy.TargetIsInSameRoom(_combatTarget)))
			{
				ChangeState(_brain.StatePatrol);
				return;
			}
			if (_combatTarget is LureItem || _combatTarget is ProbeItem)
			{
				_targetForgetTimer -= Time.deltaTime;
				if (_targetForgetTimer <= 0f)
				{
					_dbfBrain.Dbf.IgnoreTarget(_combatTarget, 15f);
					ChangeState(_brain.StatePatrol);
				}
			}
			_targetSwapTimer -= Time.deltaTime;
			if (_targetSwapTimer <= 0f)
			{
				_targetSwapTimer = 5f;
				ICombatTarget combatTarget = _brain.ThisEnemy.SelectBestCombatTarget();
				if (combatTarget != null && combatTarget != _combatTarget)
				{
					_targetForgetTimer = GetRandomForgetTime();
					_combatTarget = combatTarget;
					_brain.SetCombatTarget(_combatTarget);
					_dbfBrain.StateDbfCombatApproach.Initialize(combatTarget);
					_subStateMachine.ChangeState(_dbfBrain.StateDbfCombatApproach);
				}
			}
			_subStateMachine.Update();
		}

		public override void EnterState()
		{
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null" + _combatTarget);
			}
			_dbfBrain.StateDbfCombatApproach.Initialize(_combatTarget);
			_subStateMachine.ChangeState(_dbfBrain.StateDbfCombatApproach);
			_targetSwapTimer = 5f;
			_targetForgetTimer = GetRandomForgetTime();
			_brain.SetCombatTarget(_combatTarget);
			_brain.StartWalkAnimation();
		}

		public override void ExitState()
		{
			_combatTarget = null;
			_brain.SetCombatTarget(null);
			_subStateMachine.EndAllStates();
		}

		private float GetRandomForgetTime()
		{
			return _random.NextFloat(18f, 25f);
		}
	}
}
