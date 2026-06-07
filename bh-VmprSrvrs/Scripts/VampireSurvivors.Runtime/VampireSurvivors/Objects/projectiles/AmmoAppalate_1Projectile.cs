using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class AmmoAppalate_1Projectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer mainVisuals;

		[SerializeField]
		private SpriteTrail trail;

		private float _hitboxSize;

		private const float MAX_HOMING_ANGLE_CHANGE_PER_SECOND = 360f;

		private float penetrationAmount;

		protected EnemyController _targetEnemyController;

		private SpriteAnimation _anims;

		private Timer _prefireTimer;

		private Bounds _camBounds;

		private Ex_Ammo1Weapon trueWeapon;

		private float _IndexOffsetScaleFactor;

		public override float ProjectileSpeed => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
