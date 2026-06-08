using System;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfCombatIdle : BaseEnemyState, ICombatState
	{
		private const float LOOK_AT_DELAY = 2f;

		private const float BARK_CHECK_TIME = 10f;

		private const int BARK_CHANCE = 99;

		private const int GROWL_CHANCE = 99;

		private const float WAG_CHECK_TIME = 5f;

		private const int SHORT_WAG_CHANCE = 33;

		private const int LONG_WAG_CHANCE = 66;

		private const float PANT_CHECK_TIME = 10f;

		private const int PANT_CHANCE = 40;

		private ICombatTarget _combatTarget;

		private DbfBrain _dbfBrain;

		private float _idleTimer;

		private float _lookAtTimer;

		private float _barkCheckTimer;

		private float _wagCheckTimer;

		private float _pantCheckTimer;

		private bool _rotateToFace;

		private float _lungeTime;

		private static System.Random _random = new System.Random();

		public override string StateId
		{
			get
			{
				return "DbfCombatIdle";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfCombatIdle(BaseEnemyBrain brain)
			: base(brain)
		{
			_dbfBrain = (DbfBrain)brain;
		}

		public void Initialize(ICombatTarget target)
		{
			_combatTarget = target;
		}

		public override void Update()
		{
			_idleTimer += Time.deltaTime;
			if (_lungeTime != 0f && _idleTimer >= _lungeTime)
			{
				_dbfBrain.StateDbfLunge.Initialize(_combatTarget);
				ChangeState(_dbfBrain.StateDbfLunge);
				return;
			}
			float num = Vector3.Distance(_combatTarget.Position, _brain.ThisEnemy.Position);
			if (num > 3.6f)
			{
				_dbfBrain.StateDbfCombatApproach.Initialize(_combatTarget);
				ChangeState(_dbfBrain.StateDbfCombatApproach);
				return;
			}
			if (num < 2.4f)
			{
				_dbfBrain.StateDbfCombatAvoid.Initialize(_combatTarget);
				ChangeState(_dbfBrain.StateDbfCombatAvoid);
				return;
			}
			_lookAtTimer -= Time.deltaTime;
			if (_lookAtTimer <= 0f)
			{
				_brain.InitializeRotation(_combatTarget.Position);
				_lookAtTimer = 2f;
				_rotateToFace = true;
			}
			if (_rotateToFace && !_brain.RotateWhileNotLookingAtTarget())
			{
				_rotateToFace = false;
			}
			_barkCheckTimer -= Time.deltaTime;
			if (_barkCheckTimer <= 0f)
			{
				_barkCheckTimer = 10f;
				if (_combatTarget is BaseEnemy)
				{
					int num2 = _random.Next(1, 101);
					if (num2 < 99)
					{
						_dbfBrain.Dbf.PlayGrowlSound();
						_pantCheckTimer = 10f;
					}
				}
				else
				{
					int num3 = _random.Next(1, 101);
					if (num3 < 99)
					{
						_dbfBrain.Dbf.PlayBarkSound();
						_pantCheckTimer = 10f;
					}
				}
			}
			_pantCheckTimer -= Time.deltaTime;
			if (_pantCheckTimer <= 0f)
			{
				_pantCheckTimer = 10f;
				int num4 = _random.Next(1, 101);
				if (num4 < 40)
				{
					_dbfBrain.Dbf.PlayPantSound();
					_barkCheckTimer = 10f;
				}
			}
			if (!_dbfBrain.Dbf.IsWagging)
			{
				_wagCheckTimer -= Time.deltaTime;
			}
			if (_wagCheckTimer <= 0f)
			{
				_wagCheckTimer = 5f;
				int num5 = _random.Next(1, 101);
				if (num5 < 33)
				{
					_dbfBrain.Dbf.StartTimedWag(5f);
				}
				else if (num5 < 66)
				{
					_dbfBrain.Dbf.StartTimedWag(15f);
				}
			}
		}

		public override void EnterState()
		{
			if (_combatTarget == null)
			{
				_combatTarget = _brain.CombatTarget;
			}
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null" + _combatTarget);
			}
			_idleTimer = 0f;
			_lookAtTimer = 2f;
			_barkCheckTimer = 10f;
			_pantCheckTimer = 10f;
			_wagCheckTimer = 5f;
			_lungeTime = 0f;
			_rotateToFace = false;
			if (_combatTarget is LureItem)
			{
				_lungeTime = _random.NextFloat(4f, 26f);
			}
			if (_combatTarget is ProbeItem)
			{
				_lungeTime = _random.NextFloat(1f, 13f);
			}
			_brain.StartIdleAnimation();
		}

		public override void ExitState()
		{
			_dbfBrain.Dbf.StopWagging();
		}
	}
}
