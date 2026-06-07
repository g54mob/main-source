using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Elec1_Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private float _radius;

		private PhaserSprite _animatedSprite;

		private Tween _radiusTween;

		private TweenerCore<Vector3, Vector3, VectorOptions> moveTween;

		private Vector3 targetPosition;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Strike()
		{
		}

		public void SetTargetPosition(Vector3 target)
		{
		}

		public override void Despawn()
		{
		}
	}
}
