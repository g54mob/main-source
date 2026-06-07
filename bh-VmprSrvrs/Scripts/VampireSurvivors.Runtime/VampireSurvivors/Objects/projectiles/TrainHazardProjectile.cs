using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TrainHazardProjectile : Projectile
	{
		private ParticleSystem _pfxEmitter;

		private float _defaultSpeed;

		private Timer _expireTimer;

		private Timer _soundEvent;

		private PhaserSprite _lightSprite;

		protected override void Awake()
		{
		}

		public override void Despawn()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void PlaySounds()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SetDepths()
		{
		}

		private void GeneratePfx()
		{
		}
	}
}
