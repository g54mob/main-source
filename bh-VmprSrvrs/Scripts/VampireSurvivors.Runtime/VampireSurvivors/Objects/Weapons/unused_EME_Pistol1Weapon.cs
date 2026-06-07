using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class unused_EME_Pistol1Weapon : EME_Weapon
	{
		private Timer _prefireTimer;

		private BulletPool _bdShotPool;

		[SerializeField]
		protected Projectile _bdShotPrefsb;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int ComboIndexFinal => 0;

		public override float PSpeed()
		{
			return 0f;
		}

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override void OnStart()
		{
		}

		public void DoBoundingShotExplosionAt(Vector2 position)
		{
		}

		protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		private void FireCrossShotAfterDelay(Vector2 pos, int index, BulletPool pool)
		{
		}

		public override void ParadoxFire()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
