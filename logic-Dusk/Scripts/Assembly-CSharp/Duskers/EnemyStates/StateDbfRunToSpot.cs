using System;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfRunToSpot : BaseEnemyState
	{
		private static System.Random _random = new System.Random();

		private Vector3 _moveToPosition = Vector3.zero;

		private DbfBrain _dbfBrain;

		private bool _closestWeCanGet;

		private ICombatTarget _combatTarget;

		public override string StateId
		{
			get
			{
				return "DbfRunToSpot";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfRunToSpot(BaseEnemyBrain brain)
			: base(brain)
		{
			_dbfBrain = (DbfBrain)brain;
		}

		public void Initialize(Vector3 moveToPosition, ICombatTarget target)
		{
			_moveToPosition = moveToPosition;
			_combatTarget = target;
		}

		public override void Update()
		{
			if (_moveToPosition == Vector3.zero)
			{
				ChangeState(_dbfBrain.StateDbfPatrolIdle);
			}
			else
			{
				if (_brain.RotateWhileNotLookingAtTarget())
				{
					return;
				}
				float num = Vector3.Distance(_moveToPosition, _brain.ThisEnemy.Position);
				if (!_closestWeCanGet && num > 0.6f)
				{
					_brain.ThisEnemy.moveForward(_dbfBrain.Dbf.RunSpeed);
					float num2 = Vector3.Distance(_moveToPosition, _brain.ThisEnemy.Position);
					if (num2 > num)
					{
						_closestWeCanGet = true;
					}
				}
				else
				{
					_dbfBrain.StateDbfCombatIdle.Initialize(_combatTarget);
					ChangeState(_dbfBrain.StateDbfCombatIdle);
				}
			}
		}

		public override void EnterState()
		{
			if (_moveToPosition == Vector3.zero)
			{
				Debug.LogWarning("move to position not set");
			}
			_closestWeCanGet = false;
			_brain.InitializeRotation(_moveToPosition);
			_brain.StartWalkAnimation();
		}

		public override void ExitState()
		{
			_combatTarget = null;
		}
	}
}
