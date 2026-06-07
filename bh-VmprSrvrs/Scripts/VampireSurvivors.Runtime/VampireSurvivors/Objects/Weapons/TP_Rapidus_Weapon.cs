using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Rapidus_Weapon : Weapon
	{
		private ArcadeSprite sprite;

		private Timer spriteTimer;

		private bool _initialisedParticles;

		protected ParticleEmitterManager _pfxEmitterManager;

		protected ParticleSystem _pfxEmitter;

		private const float Radius = 16f;

		private float _currentMovespeedBonus;

		protected virtual float _perLevelBonus => 0f;

		protected virtual int _maxCharges => 0;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void OnStart()
		{
		}

		public void UpdateSprite()
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		protected override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
