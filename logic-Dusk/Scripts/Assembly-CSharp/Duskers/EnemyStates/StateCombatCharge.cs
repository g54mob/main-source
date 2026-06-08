using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateCombatCharge : BaseEnemyState
	{
		public override string StateId
		{
			get
			{
				return "CombatCharge";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateCombatCharge(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public override void Update()
		{
			if (_brain.ChargeCooldownTimer <= 0f)
			{
				bool flag = _brain.ThisEnemy.GetComponent<Collider>().bounds.Intersects(_brain.CombatTarget.ObjectCollider.bounds);
				if (!flag)
				{
					_brain.ThisEnemy.DisconnectOverlay();
					_brain.ThisEnemy.LookAt(_brain.CombatTarget.Position);
					_brain.ThisEnemy.ReconnectOverlay();
					_brain.ThisEnemy.moveForward(_brain.ThisEnemy.ChargeSpeed);
					flag = _brain.ThisEnemy.GetComponent<Collider>().bounds.Intersects(_brain.CombatTarget.ObjectCollider.bounds);
				}
				if (flag)
				{
					_brain.ChargeCooldownTimer = _brain.ThisEnemy.ChargeCooldown;
					_brain.ThisEnemy.AttackTarget(_brain.CombatTarget, _brain.ThisEnemy.ChargeAttackDamage, false);
					if (GlobalSettings.cameraMode == CameraMode.Drone && _brain.ThisEnemy is BruteEnemy)
					{
						((BruteEnemy)_brain.ThisEnemy).bruteHitSound.volume = GameAudio.RemoteVolume * 1f;
						((BruteEnemy)_brain.ThisEnemy).bruteHitSound.Play();
					}
					_brain.CombatTarget.RegisterDirectionalHit(_brain.ThisEnemy.GetVelocity(_brain.ThisEnemy.ChargeSpeed) * 5f);
					if (_brain.ThisEnemy.ChargeStunDuration > 0f)
					{
						_brain.ThisEnemy.Stun(_brain.ThisEnemy.ChargeStunDuration - 0.5f, _brain.ThisEnemy.ChargeStunDuration + 0.5f);
					}
				}
			}
			else
			{
				ChangeState(_brain.StateCombatAttack);
			}
		}

		public override void EnterState()
		{
			if (_brain.CombatTarget == null)
			{
				Debug.LogWarning("CombatTarget must be set before entering " + StateId);
			}
		}

		public override void ExitState()
		{
		}
	}
}
