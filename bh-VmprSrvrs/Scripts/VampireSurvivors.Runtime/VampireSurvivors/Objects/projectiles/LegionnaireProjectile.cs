using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LegionnaireProjectile : Projectile
	{
		private SpriteAnimation _spriteAnimation;

		private Color[][] _tints;

		private bool _hasAlreadyBeenRecycled;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _alphaTween;

		private LegionnaireWeapon _trueWeapon;

		private bool _isMoving;

		public override float ProjectileSpeed => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
