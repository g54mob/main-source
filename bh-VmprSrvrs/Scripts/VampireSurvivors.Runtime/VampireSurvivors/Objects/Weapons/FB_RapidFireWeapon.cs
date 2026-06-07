using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_RapidFireWeapon : Weapon
	{
		private ParticleEmitterManager _pfxEmitter;

		private float2 _particlesOffset;

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
