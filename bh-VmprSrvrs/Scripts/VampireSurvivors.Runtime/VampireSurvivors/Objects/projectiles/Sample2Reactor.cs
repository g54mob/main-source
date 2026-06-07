using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Sample2Reactor : Projectile
	{
		private ParticleSystem _pfxFireEmitterScreen;

		private ParticleSystem _pfxFireEmitterAdd;

		protected Sample2Weapon _trueWeapon;

		protected float reactorOffsetY;

		protected MultiTargetTween _scaleYTween;

		private float pixelWidth;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void FireProjectile(float totalDuration)
		{
		}

		protected void fireThruster(float duration)
		{
		}

		protected void launchOffScreen()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
