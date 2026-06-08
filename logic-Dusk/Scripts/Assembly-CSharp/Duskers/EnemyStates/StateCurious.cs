using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateCurious : BaseEnemyState
	{
		private const float TOTAL_MOVE_TIME_HACK = 1f;

		private const float TOTAL_CURIOUS_SEEK_TIME = 5f;

		private const float ROTATION_TIMEOUT = 2f;

		private ICombatTarget _combatTarget;

		private TargetLocationPlaceholder _lastKnownTargetPosition;

		private BaseEnemyState _returnState;

		private float _sitAndStareTimer;

		private float _totalMoveToLastKnownTimer;

		private float _overallCuriousSeekTimer;

		private bool _finishedInitialLookRotation = true;

		private float _lastRotationTimestamp;

		public override string StateId
		{
			get
			{
				return "Curious";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateCurious(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public void Initialize(ICombatTarget target, BaseEnemyState returnState)
		{
			_combatTarget = target;
			_returnState = returnState;
		}

		public override void Update()
		{
			if (_brain.RotatesBeforeAttack && !_finishedInitialLookRotation)
			{
				if (_brain.RotateWhileNotLookingAtTarget())
				{
					return;
				}
				_finishedInitialLookRotation = true;
				_lastRotationTimestamp = 0f;
			}
			if (_sitAndStareTimer > 0f)
			{
				_sitAndStareTimer -= Time.deltaTime;
				if (_sitAndStareTimer <= 0f)
				{
					_brain.SeeStealthedDronesTimer = _brain.STEALTH_REMEMBER_TIME;
					_totalMoveToLastKnownTimer = 1f;
					_overallCuriousSeekTimer = 5f;
					_brain.EndCuriousPause();
				}
				return;
			}
			_overallCuriousSeekTimer -= Time.deltaTime;
			if (_overallCuriousSeekTimer <= 0f)
			{
				ChangeState(_returnState);
				return;
			}
			bool flag = _brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.CuriousSeeker);
			if (flag && _brain.ThisEnemy.TargetIsInSameRoom(_combatTarget))
			{
				_brain.ThisEnemy.LookAt(_combatTarget.Position);
				float num = Vector3.Distance(_brain.ThisEnemy.transform.position, _combatTarget.Position);
				if ((double)num > 0.4)
				{
					_brain.ThisEnemy.moveForward(_brain.ThisEnemy.BaseMoveSpeed / 4f);
				}
			}
			if (!flag || !_brain.ThisEnemy.TargetIsInSameRoom(_combatTarget))
			{
				_totalMoveToLastKnownTimer -= Time.deltaTime;
				if (_totalMoveToLastKnownTimer <= 0f || _brain.MoveTo(_lastKnownTargetPosition, false))
				{
					ChangeState(_returnState);
				}
			}
		}

		public override void EnterState()
		{
			if (_returnState == null)
			{
				Debug.LogWarning("_returnState is NULL!!!");
			}
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null");
			}
			else
			{
				_lastKnownTargetPosition = new TargetLocationPlaceholder(_combatTarget);
			}
			if (_sitAndStareTimer <= 0f)
			{
				_sitAndStareTimer = _brain.CURIOUS_PAUSE_TIME;
			}
			_totalMoveToLastKnownTimer = 0f;
			float num = Time.time - _lastRotationTimestamp;
			if (_finishedInitialLookRotation || num >= 2f)
			{
				_finishedInitialLookRotation = false;
				_lastRotationTimestamp = Time.time;
				_brain.InitializeRotation(_lastKnownTargetPosition.Position);
			}
			_brain.BeginCuriousPause();
		}

		public override void ExitState()
		{
			if (_sitAndStareTimer > 0f)
			{
				_brain.EndCuriousPause();
			}
		}
	}
}
