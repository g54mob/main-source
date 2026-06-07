using System;
using System.Collections.Generic;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SilverWind2Projectile : SilverWindProjectile
	{
		[NonSerialized]
		private uint[] _colors;

		[NonSerialized]
		private uint[] _tints;

		[NonSerialized]
		private List<string> _particles;

		protected override uint[] Colors => null;

		protected override uint[] Tints => null;

		protected override List<string> Particles => null;

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}
	}
}
