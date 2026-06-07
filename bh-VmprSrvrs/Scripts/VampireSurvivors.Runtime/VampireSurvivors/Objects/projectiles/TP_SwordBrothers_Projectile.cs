using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SwordBrothers_Projectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private float2 displayOffset;

		private MultiTargetTween _angleTween;

		private Sequence _windSequence;

		private TP_SwordBrothers_Weapon _trueWeapon;

		private List<TP_SwordBrothers_Firing_Projectile> bullets;

		private MultiTargetTween _alphaTween;

		private PhaserSprite _displaySprite;

		private float2 positionOffset;

		private float physOffsetRadius;

		private List<Timer> _bulletTimers;

		private Timer _shootTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void EmitBullets()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void ShootBullets()
		{
		}

		private void FadeOutAndDispose()
		{
		}

		public override void Despawn()
		{
		}
	}
}
