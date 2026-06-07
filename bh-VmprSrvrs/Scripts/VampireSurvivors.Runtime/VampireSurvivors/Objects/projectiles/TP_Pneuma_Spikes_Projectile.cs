using Unity.Mathematics;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Pneuma_Spikes_Projectile : Projectile
	{
		private const float Radius = 0.25f;

		private float _spacer;

		private float _timer;

		private int _counter;

		private Timer _spikeTimerEvent;

		private Timer _completeTimerEvent;

		private float2 _originalPos;

		private float2 _direction;

		private float _angle;

		private float _iterationScale;

		private float _iterationScaleMultiply;

		private float _iterationAlpha;

		private float _iterationAlphaMultiply;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void updateSpikePos()
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
