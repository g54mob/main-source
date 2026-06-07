using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class VentoWeapon : Weapon
	{
		private float _walked;

		private Timer _walkedTimer;

		private float _pBonus;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		private const float MUL = 166.66667f;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
