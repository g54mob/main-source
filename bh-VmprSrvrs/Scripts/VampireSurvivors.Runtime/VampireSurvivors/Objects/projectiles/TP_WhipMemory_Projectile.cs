using System.Collections.Generic;
using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_WhipMemory_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _animatedSprite;

		private Tween _radiusTween;

		private bool trailInit;

		private List<SfxType> sfx;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
