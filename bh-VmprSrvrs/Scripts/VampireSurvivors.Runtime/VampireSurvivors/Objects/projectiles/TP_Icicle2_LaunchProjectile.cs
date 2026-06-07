using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Icicle2_LaunchProjectile : Projectile
	{
		private const float Radius = 16f;

		private PhaserSprite _icicleSprite;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetSprite(Sprite sprite)
		{
		}

		private void PlaySfx()
		{
		}
	}
}
