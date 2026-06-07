using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FixWiringSparkProjectile : Projectile
	{
		private PhaserSprite _pulseSprite;

		private FixWiringWeapon _trueWeapon;

		private MultiTargetTween _pulseTween;

		private Timer _pulseTimer;

		private bool _follow;

		private float radius;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		public void Pulse(float2 from, float2 to, uint color, float speedMultiplier = 1f)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void ClearLine()
		{
		}
	}
}
