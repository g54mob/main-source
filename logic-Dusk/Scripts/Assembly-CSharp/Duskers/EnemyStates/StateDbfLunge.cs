using System;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfLunge : BaseEnemyState, ICombatState
	{
		private const float LUNGE_MINIMUM_RANGE = 1.5f;

		private const float LUNGE_DONE_IDLE_TIME = 3f;

		private DbfBrain _dbfBrain;

		private float _lungeDoneTimer;

		private static System.Random _random = new System.Random();

		private ICombatTarget _combatTarget;

		public override string StateId
		{
			get
			{
				return "DbfCombatLunge";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfLunge(BaseEnemyBrain brain)
			: base(brain)
		{
			_dbfBrain = (DbfBrain)brain;
		}

		public void Initialize(ICombatTarget target)
		{
			if (target == null)
			{
				Debug.Log("Initializing w/ null??");
			}
			_combatTarget = target;
		}

		public override void Update()
		{
			if (_lungeDoneTimer > 0f)
			{
				_lungeDoneTimer -= Time.deltaTime;
				if (_lungeDoneTimer <= 0f)
				{
					ChangeState(_dbfBrain.StateDbfCombatIdle);
				}
				return;
			}
			bool flag = _brain.ThisEnemy.CurrentRoom != null && _combatTarget.CurrentRoom == _brain.ThisEnemy.CurrentRoom;
			bool flag2 = _brain.ThisEnemy.CurrentCorridor != null && _combatTarget.CurrentCorridor == _brain.ThisEnemy.CurrentCorridor;
			if (flag || flag2)
			{
				float num = Vector3.Distance(_brain.ThisEnemy.Position, _combatTarget.Position);
				if (num > 1.5f)
				{
					_brain.ThisEnemy.DisconnectOverlay();
					_brain.ThisEnemy.LookAt(_combatTarget.Position);
					_brain.ThisEnemy.ReconnectOverlay();
					_brain.ThisEnemy.moveForward(_brain.ThisEnemy.ChargeSpeed);
					return;
				}
				_lungeDoneTimer = 3f;
				int num2 = _random.Next(1, 101);
				if (num2 <= 33)
				{
					_dbfBrain.Dbf.PlayGrowlSound();
				}
				else if (num2 <= 66)
				{
					_dbfBrain.Dbf.PlayBarkSound();
				}
			}
			else
			{
				ChangeState(_dbfBrain.StateDbfCombatIdle);
			}
		}

		public override void EnterState()
		{
			if (_combatTarget == null)
			{
				Debug.LogWarning("CombatTarget must be set before entering " + StateId);
			}
			_lungeDoneTimer = 0f;
			_brain.StartWalkAnimation();
		}

		public override void ExitState()
		{
		}
	}
}
