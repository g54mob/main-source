using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KnifeProjectile : Projectile
	{
		[SerializeField]
		private SpriteTrail _Trail;

		private SpriteAnimation _spriteAnimation;

		protected Color[][] _tints;

		protected Color[][] _tints2;

		protected Color[][] _tints3;

		private bool _hasAlreadyBeenRecycled;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _alphaTween;

		private Timer _hitboxTimer;

		protected EME_Knife1Weapon _trueWeapon;

		public virtual bool DoExplosions => false;

		public virtual float DurationMultiplier => 0f;

		public override float ProjectileSpeed => 0f;

		protected override void Awake()
		{
		}

		public virtual Color[][] GetTints()
		{
			return null;
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public virtual void FireSpecialBullets()
		{
		}

		private void StopMoving()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
