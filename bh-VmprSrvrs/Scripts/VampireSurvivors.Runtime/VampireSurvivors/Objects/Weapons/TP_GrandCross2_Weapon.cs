using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_GrandCross2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _BeamProjectilePrefab;

		private const float BeamDamageMultiplier = 1.3f;

		private bool _hasSprites;

		private PhaserSprite _lightSprite;

		private Rectangle _pfxRect;

		private ParticleSystem _pfx;

		private EmitZone _pfxEmitZone;

		private BulletPool _beamProjectilePool;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _scaleTween;

		public float BeamWidth => 0f;

		public float BeamHeight => 0f;

		public float2 BeamScale => default(float2);

		public float2 BeamXExtents => default(float2);

		public override float PArea()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void InitSpritesAndPfx()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateLightSprite()
		{
		}

		private void UpdatePfxEmitZone()
		{
		}

		public void TriggerBeam()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}

		private bool OnBulletOverlapsEnemy_Beam(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
