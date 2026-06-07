using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_BlueFire_Projectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		private ParticleEmitterManager _particleEmitterManager;

		private Sequence _scaleTween;

		private const float Radius = 8f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void AssignRandomColorToGroundFx()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
