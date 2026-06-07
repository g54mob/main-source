using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SpellstrikeProjectile : Projectile
	{
		private ParticleEmitterManager _pfxEmitter;

		private ParticleSystem _emitter2;

		private Circle _emitZone;

		private ParticleSystem _emitter1;

		private MultiTargetTween _strikeTween;

		private MultiTargetTween _emitterTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
