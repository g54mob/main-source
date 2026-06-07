using DG.Tweening;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_DragonWater1Tail_Projectile : Projectile
	{
		private float _radius;

		private TP_DragonWater1Head_Projectile _headProjectile;

		private int _frameCounter;

		private bool _lateInit;

		private PhaserSprite _animatedSprite;

		private const int AnimFPS = 30;

		private Tween _radiusTween;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		public void SetHead(TP_DragonWater1Head_Projectile head)
		{
		}

		public void SetDepth(int depth)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
