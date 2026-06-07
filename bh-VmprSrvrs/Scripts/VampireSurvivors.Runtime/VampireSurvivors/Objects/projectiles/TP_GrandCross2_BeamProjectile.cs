using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_GrandCross2_BeamProjectile : Projectile
	{
		private PhaserSprite _beamSprite;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private TP_GrandCross2_Weapon _trueWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void DoTweens()
		{
		}

		private int GetNumActiveBeams()
		{
			return 0;
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateBeamSprite()
		{
		}

		public override void Despawn()
		{
		}
	}
}
