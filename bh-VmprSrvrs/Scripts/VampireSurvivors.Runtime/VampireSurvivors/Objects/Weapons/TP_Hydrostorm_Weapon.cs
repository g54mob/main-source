using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Hydrostorm_Weapon : Weapon
	{
		private bool _initialisedParticles;

		private ParticleSystem _rainEmitter1;

		private ParticleSystem _rainEmitter2;

		private ParticleSystem _bottleEmitter;

		private ParticleSystem _groundEmitter1;

		private ParticleSystem _groundEmitter2;

		private Timer _rainStopTimer;

		private bool _groundParticlesActive;

		protected virtual uint RainEmitterTint1 => 0u;

		protected virtual uint RainEmitterTint2 => 0u;

		protected virtual int RainEmitterQuantity => 0;

		protected virtual ParticleSystem.MinMaxCurve RainEmitterAlpha => default(ParticleSystem.MinMaxCurve);

		protected virtual bool EnableBottleEmitters => false;

		protected virtual bool EnableGroundEmitters => false;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected virtual void UpdateFiringInterval()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireProjectiles()
		{
		}

		private void FireOneRainProjectile(Vector2 pos, int index, Transform target)
		{
		}

		protected virtual void PlaySfx()
		{
		}

		private void PlayBottlePfx(bool play)
		{
		}

		private void MakeRainEmitters()
		{
		}

		private void MakeBottleEmitters()
		{
		}

		private void MakeGroundEmitters()
		{
		}

		private void UpdateGroundParticles()
		{
		}

		private Vector2 GetRandomPositionOnScreen()
		{
			return default(Vector2);
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		private void StopEmitters()
		{
		}
	}
}
