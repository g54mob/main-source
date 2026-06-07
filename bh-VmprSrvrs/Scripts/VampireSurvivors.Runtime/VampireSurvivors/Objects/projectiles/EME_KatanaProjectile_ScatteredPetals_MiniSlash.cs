using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KatanaProjectile_ScatteredPetals_MiniSlash : Projectile
	{
		private const float Radius = 70f;

		private MultiTargetTween _scaleTween;

		private EME_Katana2Weapon _trueWeapon;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
