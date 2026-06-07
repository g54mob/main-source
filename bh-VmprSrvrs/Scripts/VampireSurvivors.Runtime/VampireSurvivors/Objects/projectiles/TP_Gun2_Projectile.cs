using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Gun2_Projectile : TP_Gun1_Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		private List<Color> colors;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private List<List<string>> sparkFrames;

		protected override void Awake()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}
	}
}
