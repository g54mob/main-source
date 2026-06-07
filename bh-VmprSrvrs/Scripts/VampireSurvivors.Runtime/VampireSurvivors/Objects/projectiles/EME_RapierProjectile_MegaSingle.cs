using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_RapierProjectile_MegaSingle : Projectile
	{
		[SerializeField]
		private SpriteRenderer _backgroundSprite;

		private const float RADIUS = 8f;

		private const float INDEX_OFFSET_SCALE_FACTOR = 0.1f;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private readonly List<uint> _tints;

		private readonly List<string> _frameNames;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void GenerateParticleSystem()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
