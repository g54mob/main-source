using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class GlassFandangoWeapon : Weapon
	{
		private float _walked;

		private Timer _walkedTimer;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		private const float MUL = 500f;

		[FormerlySerializedAs("sizeee")]
		public float ProjectilePixelSize;

		public override float PArea()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
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
	}
}
