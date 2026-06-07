using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_CustosFireball_Projectile : Projectile
	{
		private SpriteAnimation _anim;

		private ParticleSystem _pfxEmitter;

		private MultiTargetTween _scaleTween;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		public override void Despawn()
		{
		}

		private void StartDespawn()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
