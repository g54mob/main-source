using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Greatsword1Weapon : EME_Weapon
	{
		[Header("Additional Projectile Prefabs")]
		[SerializeField]
		private Projectile _AbsetzenBeamPrefab;

		private BulletPool _absetzenBeamPool;

		private Timer _glimmerShotTimer;

		private float _absetzenAmount;

		private const float _abzentzenFireDelay = 250f;

		private readonly List<AbsetzenInstance> _absetzenInstances;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		public float AbzentzenFireDelay => 0f;

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override void OnStart()
		{
		}

		protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		private bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}
	}
}
