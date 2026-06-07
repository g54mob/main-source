using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class JubileeRaysProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _emitterCounter;

		private int _basePixelSize;

		private Timer _expireTimer;

		private float _yOffset;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
