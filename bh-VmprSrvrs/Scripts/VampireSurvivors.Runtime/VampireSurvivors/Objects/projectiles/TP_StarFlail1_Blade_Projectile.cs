using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_StarFlail1_Blade_Projectile : Projectile
	{
		private MultiTargetTween _posTween;

		private SpriteAnimation _anim;

		private MultiTargetTween _rotTween;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void ManualIntProjectile(float flyAngle, bool isFlipped)
		{
		}

		public void FadeOut()
		{
		}

		public override void Despawn()
		{
		}
	}
}
