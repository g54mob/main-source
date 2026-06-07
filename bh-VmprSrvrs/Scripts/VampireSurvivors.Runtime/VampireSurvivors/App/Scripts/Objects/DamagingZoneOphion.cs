using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.App.Scripts.Objects
{
	public class DamagingZoneOphion : ArcadeSprite
	{
		private DamagingZonePool_Ophion _pool;

		private PhaserSprite _groundFx;

		private PhaserSprite _snakeSprite;

		private Circle _collider;

		private float _damage;

		private float _duration;

		private float _hitDelay;

		private bool _hasInit;

		private bool _activateDamage;

		private bool _hasHit;

		private Timer _hitboxTimer;

		private Timer _despawnTimer;

		private MultiTargetTween _snakeTween;

		private MultiTargetTween _displayScaleTween;

		private MultiTargetTween _displayScaleTween2;

		private MultiTargetTween _implosionTween;

		private MultiTargetTween _explosionTween;

		private const float EXPLO_1_DURATION = 500f;

		private const float EXPLO_2_DURATION = 100f;

		private const float EXPLO_3_DURATION = 200f;

		protected override void OnUpdate()
		{
		}

		public void Init(DamagingZonePool_Ophion pool)
		{
		}

		public void OnRecycle()
		{
		}

		public void SetExplosionSize(float x, float y, float radius)
		{
		}

		public void SetExplosionDamage(float damage, float duration, float hitDelay)
		{
		}

		public void Despawn()
		{
		}

		private void Explode()
		{
		}

		private void Implode()
		{
		}

		private void Explode2()
		{
		}
	}
}
