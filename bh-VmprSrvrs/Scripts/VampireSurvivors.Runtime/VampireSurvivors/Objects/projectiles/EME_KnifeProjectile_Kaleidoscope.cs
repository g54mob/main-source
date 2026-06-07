using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KnifeProjectile_Kaleidoscope : EME_KnifeProjectile
	{
		private float _saveVelX;

		private float _saveVelY;

		public override bool DoExplosions => false;

		public override float DurationMultiplier => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override Color[][] GetTints()
		{
			return null;
		}

		public override void FireSpecialBullets()
		{
		}
	}
}
