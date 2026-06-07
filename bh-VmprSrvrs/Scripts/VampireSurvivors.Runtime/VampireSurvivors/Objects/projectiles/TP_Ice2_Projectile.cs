using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Ice2_Projectile : Projectile
	{
		private ParticleSystem _rainEmitter1;

		private ParticleSystem _rainEmitter2;

		private Timer rainStopTimer;

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

		private void MakeEmitters()
		{
		}
	}
}
