using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Rapidus2_Projectile : TP_Rapidus_Projectile
	{
		private ArcadeSprite _ring1;

		private ArcadeSprite _ring2;

		private ArcadeSprite _ring3;

		private MultiTargetTween _tweenRing1;

		private MultiTargetTween _tweenRingAngle;

		protected override void Awake()
		{
		}

		public override void OnRecycle()
		{
		}

		public override void OnDespawn()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
