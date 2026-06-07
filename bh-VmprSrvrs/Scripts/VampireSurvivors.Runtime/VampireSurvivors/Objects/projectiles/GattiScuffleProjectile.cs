using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GattiScuffleProjectile : Projectile
	{
		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter1;

		private ParticleSystem _pfxEmitter2;

		private Circle _explosionCircle;

		private int _exploRadius;

		private Timer _expireTimer;

		private Timer _hitboxTimer;

		private GattiWeapon _trueWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
