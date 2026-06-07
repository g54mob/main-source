using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SummonSpirit_Weapon : FB_QuantisedAngleWeapon
	{
		private float2 _bulletStartOffset;

		private bool _isManualFire;

		protected PhaserSprite _animatedSprite;

		protected MultiTargetTween _alphaTween;

		private float emissionTime;

		private float emissionDuration;

		protected virtual float2 BulletSpawnPos => default(float2);

		protected virtual SpriteTextureData PortalSprite => default(SpriteTextureData);

		public override float PArea()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public void SetManualFire()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void RefreshTarget(TP_SummonSpirit_Projectile bullet)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		private float GetDegreesPerSecond()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		protected virtual void SetPortalPosition()
		{
		}

		protected virtual void DoPortalTween()
		{
		}

		private void PlayFiringSfx(float detune)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
