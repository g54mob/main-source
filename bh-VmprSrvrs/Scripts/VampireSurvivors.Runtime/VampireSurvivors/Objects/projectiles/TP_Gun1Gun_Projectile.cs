using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Gun1Gun_Projectile : Projectile
	{
		private float _flipNum;

		private float _rotationInc;

		private float _rotationMultiplier;

		private MultiTargetTween _scaleTween;

		protected Timer _despawnTimer;

		protected float _floorY;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		public override void InternalUpdate()
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
