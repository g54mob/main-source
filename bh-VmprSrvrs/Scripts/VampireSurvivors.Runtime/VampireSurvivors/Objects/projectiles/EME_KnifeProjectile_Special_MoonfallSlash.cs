using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KnifeProjectile_Special_MoonfallSlash : Projectile
	{
		[SerializeField]
		private SpriteAnimation _SpriteAnimation;

		private MultiTargetTween _alphaTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
