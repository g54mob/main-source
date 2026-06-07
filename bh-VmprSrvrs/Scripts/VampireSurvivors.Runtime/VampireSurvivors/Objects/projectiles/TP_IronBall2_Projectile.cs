using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_IronBall2_Projectile : TP_IronBall_Projectile
	{
		private bool _initPfx;

		private ParticleSystem _pfxEmitter;

		private Timer _pfxTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void OnHittingScreenBottom()
		{
		}

		private void InitPfx()
		{
		}

		private void PlayHitPfx()
		{
		}

		public override void Despawn()
		{
		}
	}
}
