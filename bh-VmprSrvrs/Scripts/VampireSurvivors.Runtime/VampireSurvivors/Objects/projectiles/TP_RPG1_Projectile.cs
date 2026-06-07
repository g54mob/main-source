using DG.Tweening;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_RPG1_Projectile : Projectile
	{
		private Tween _angleTween;

		private MultiTargetTween _moveXTween;

		private MultiTargetTween _moveYTween;

		private MultiTargetTween _moveYTween2;

		private MultiTargetTween _scaleGrenadeTween;

		private TP_RPG1_Weapon _rpgWeapon;

		private Timer _tintTimer;

		private const uint Red = 16711680u;

		private const uint White = 16777215u;

		private float _explosionDelay;

		private Timer _explosionTimer;

		private float _throwSpeed;

		private float _rollSpeed;

		private float _landToTargetPosRatio;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void DoTintCycle()
		{
		}

		protected void Explode()
		{
		}

		public override void Despawn()
		{
		}
	}
}
