using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StatePatrolBotCombat : BaseEnemyState, ICombatState
	{
		private const float COMBAT_INIT_PAUSE = 1.5f;

		private const float POST_COMBAT_DELAY_TIME = 1f;

		private const float TIME_TO_STARE_AT_LURE = 3f;

		private ICombatTarget _combatTarget;

		private float _initialPauseTimer;

		private float _postCombatTimer;

		private float _lureStareTimer;

		private PatrolBotBrain _patrolBotBrain;

		private TargetLocationPlaceholder _lastKnownTargetPosition;

		public override string StateId
		{
			get
			{
				return "PatrolBotCombat";
			}
		}

		public AudioSource asRShot { get; set; }

		public override event ChangeStateDelegate ChangeState;

		public StatePatrolBotCombat(BaseEnemyBrain brain)
			: base(brain)
		{
			_patrolBotBrain = (PatrolBotBrain)brain;
		}

		public void Initialize(ICombatTarget target)
		{
			_combatTarget = target;
		}

		public override void Update()
		{
			if (_combatTarget.IsDead || _brain.ThisEnemy.IsTargetHidden(_combatTarget))
			{
				ChangeState(_brain.StatePatrol);
				return;
			}
			float num = Vector3.Distance(_brain.ThisEnemy.Position, _combatTarget.Position);
			bool flag = _brain.ThisEnemy.TargetIsInSameRoom(_combatTarget);
			if (!flag && _brain.ThisEnemy.CurrentRoom != null && _brain.ThisEnemy.LineOfSightThroughDoor(_combatTarget.Position))
			{
				flag = true;
			}
			if (num <= _brain.ThisEnemy.AttackRadius && flag)
			{
				if (_brain.RotatesBeforeAttack && _brain.RotateWhileNotLookingAtTarget())
				{
					return;
				}
				_postCombatTimer = 1f;
				_lastKnownTargetPosition.Update(_combatTarget);
				_brain.ThisEnemy.DisconnectOverlay();
				_brain.ThisEnemy.LookAt(_combatTarget.Position);
				_brain.ThisEnemy.ReconnectOverlay();
				if (_initialPauseTimer > 0f)
				{
					_initialPauseTimer -= Time.deltaTime;
				}
				else if (_combatTarget is LureItem)
				{
					_lureStareTimer -= Time.deltaTime;
					if (_lureStareTimer <= 0f)
					{
						ChangeState(_brain.StatePatrol);
					}
				}
				else if (Time.time - _brain.LastAttackTimestamp >= _brain.ThisEnemy.AttackSpeed)
				{
					_brain.LastAttackTimestamp = Time.time;
					_brain.ThisEnemy.AttackTarget(_combatTarget, true);
					if (GlobalSettings.cameraMode == CameraMode.Drone && !asRShot.isPlaying)
					{
						asRShot.volume = GameAudio.RemoteVolume * 1f;
						asRShot.Play();
					}
				}
			}
			else
			{
				ICombatTarget combatTarget = _brain.ThisEnemy.SelectBestCombatTarget();
				if (combatTarget != null && combatTarget != _combatTarget)
				{
					InitCombat(combatTarget);
				}
				else if (_postCombatTimer > 0f)
				{
					_postCombatTimer -= Time.deltaTime;
				}
				else if (_brain.MoveTo(_lastKnownTargetPosition, true))
				{
					ChangeState(_brain.StatePatrol);
				}
			}
		}

		public override void EnterState()
		{
			InitCombat(_combatTarget);
		}

		private void InitCombat(ICombatTarget target)
		{
			_combatTarget = target;
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null" + _combatTarget);
			}
			else
			{
				_lastKnownTargetPosition = new TargetLocationPlaceholder(_combatTarget);
			}
			if (!_patrolBotBrain.ThisPatrolBot.LightIsOn)
			{
				_patrolBotBrain.ThisPatrolBot.TurnOnLight(true);
			}
			_initialPauseTimer = 1.5f;
			_lureStareTimer = 3f;
			_postCombatTimer = 1f;
			_brain.ClearRotating();
			_brain.InitializeRotation(_combatTarget.Position);
		}

		public override void ExitState()
		{
			_combatTarget = null;
			_lastKnownTargetPosition = null;
		}
	}
}
