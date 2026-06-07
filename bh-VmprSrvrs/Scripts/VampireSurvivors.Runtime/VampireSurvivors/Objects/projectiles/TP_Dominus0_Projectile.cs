using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Dominus0_Projectile : Projectile
	{
		private PhaserSprite _displaySprite;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _scale2Tween;

		private MultiTargetTween _scale3Tween;

		private MultiTargetTween _scale4Tween;

		private Timer hitBoxTimer;

		private TP_Dominus2_Weapon _trueWeapon;

		private bool inverted;

		private string mainFrameName;

		private string topFrameName;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
