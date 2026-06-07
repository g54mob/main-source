using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Cannon3Weapon : EME_Cannon2Weapon
	{
		[Header("Sunlight Shower Explosion Projectile")]
		[SerializeField]
		private Projectile _sunlightShowerExplosionPrefab;

		private BulletPool _sunlightShower_Explosion_Pool;

		private Timer _sunlightShowerTimer;

		protected override int ComboIndexFinal => 0;

		protected override int GlimmerTier => 0;

		public BulletPool SunlightShowerExplosionPool => null;

		protected override void OnStart()
		{
		}

		public override void Cleanup()
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		public void FireSunlightShower()
		{
		}

		private List<float2> GenerateShowerTargets()
		{
			return null;
		}

		private List<float2> GenerateShowerSpawnPoints(List<float2> targets)
		{
			return null;
		}
	}
}
