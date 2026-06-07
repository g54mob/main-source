using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDoppleganger : EnemyController
	{
		public EnemyProjectile _knifePrefab;

		public EnemyProjectile _runetracerPrefab;

		private List<EnemyWeapon> _weapons;

		private CharacterController _targetCharacter;

		private float _weaponUsageCooldown;

		private float _reloadSpeed;

		private CharacterController _characterToCopy;

		private bool _hasStartedDeathAnimation;

		private DopplegangerGate _parentGate;

		private PlatformZoneMovement.JumpInfo _jumpInfo;

		private float _jumpTimer;

		[Sync]
		public float WeaponUsageCooldown
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Sync]
		public float ReloadSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync CharacterToCopy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public Vector2 SpritePosition
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[Sync]
		public Vector2 CurrentDirectionSynced
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void SetTargetToNearestCharacter()
		{
		}

		public void SetupDoppleganger(CharacterController toCopy, float reloadSpeed, DopplegangerGate gate)
		{
		}

		public void SetupRemoteDoppleganger(DopplegangerGate gate)
		{
		}

		private void SetupDoppleganger(CharacterController toCopy, DopplegangerGate gate)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void ResetJumpTimer()
		{
		}

		private void HandleWeapons()
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		private void DoDeathAnimation()
		{
		}

		private void DeathAnimationFinished()
		{
		}
	}
}
