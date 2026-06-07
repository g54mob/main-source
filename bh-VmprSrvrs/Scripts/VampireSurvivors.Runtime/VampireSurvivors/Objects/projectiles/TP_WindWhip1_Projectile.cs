using System.Collections.Generic;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_WindWhip1_Projectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private float hOffset;

		private List<float> vOffsets;

		private uint[] _colors;

		private readonly BlendMode[] _blendModes;

		protected override void Awake()
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
