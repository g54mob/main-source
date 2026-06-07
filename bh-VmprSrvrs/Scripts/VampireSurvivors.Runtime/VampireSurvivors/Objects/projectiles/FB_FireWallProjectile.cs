using Unity.Mathematics;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_FireWallProjectile : Projectile
	{
		private const float Radius = 0.25f;

		private float _spacer;

		private float _timer;

		private int _counter;

		private Timer _flameTimerEvent;

		private Timer _completeTimerEvent;

		private float2 _originalPos;

		private float2 _direction;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void updateFlamePos()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public void manuallySetDirection(float2 direction)
		{
		}

		public void manuallySetOriginalPos(float2 originalPos)
		{
		}

		public override void Despawn()
		{
		}
	}
}
