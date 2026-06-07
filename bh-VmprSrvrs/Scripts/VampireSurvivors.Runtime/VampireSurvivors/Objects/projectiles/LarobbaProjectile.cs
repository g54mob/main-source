using Unity.Mathematics;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LarobbaProjectile : Projectile
	{
		private MultiTargetTween _angleTween;

		private MultiTargetTween _movementTween;

		private MultiTargetTween _scaleTween;

		private float _startingAngle;

		private LarobbaWeapon _trueWeapon;

		private Timer _bounceTimer;

		private float _defaultVelocityY;

		public float _moveAngle;

		private float _grav;

		private float2 _initialVelocity;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
