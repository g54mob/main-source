using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_LongswordProjectile_GaleSlash : Projectile
	{
		[SerializeField]
		private MeshRenderer galeSlashVFX;

		private const float RADIUS = 50f;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private MultiTargetTween _scaleTween;

		public override float ProjectileSpeed => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVFX()
		{
		}

		public override void Despawn()
		{
		}
	}
}
