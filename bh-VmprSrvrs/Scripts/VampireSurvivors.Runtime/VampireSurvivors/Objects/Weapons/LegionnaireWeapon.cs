using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class LegionnaireWeapon : SwordWeapon
	{
		private BulletPool _legionnairePool;

		private float _spawnRadius;

		private PhaserSprite _cursor;

		private Circle _spawnCircle;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _smokeEmitter;

		public ParticleSystem SmokeEmitter => null;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void OnStart()
		{
		}

		public void FireLegionnaire()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected float CalcRadAngle(float x1, float y1, float x2, float y2)
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
