using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_WineGlass2_Shard_Projectile : Projectile
	{
		private List<string> frameNames;

		private bool hasHit;

		private PhaserSprite _sunraySprite;

		private Timer cullableTimer;

		private MultiTargetTween sunTween;

		private MultiTargetTween _scaleTween;

		private bool isDespawning;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void BeamHere()
		{
		}
	}
}
