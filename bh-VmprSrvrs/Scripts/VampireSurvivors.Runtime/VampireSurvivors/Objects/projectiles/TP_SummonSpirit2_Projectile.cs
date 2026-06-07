using UnityEngine;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SummonSpirit2_Projectile : TP_SummonSpirit_Projectile
	{
		private ParticleSystem _pfxHoly;

		protected override uint[] Tints => null;

		protected override void Awake()
		{
		}

		private void GenerateHolyParticleSystem()
		{
		}

		protected override void UpdatePfx()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
