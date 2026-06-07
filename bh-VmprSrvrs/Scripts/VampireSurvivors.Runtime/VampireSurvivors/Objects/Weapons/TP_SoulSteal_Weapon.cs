using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SoulSteal_Weapon : Weapon
	{
		private List<PhaserSprite> explosionSprites;

		private int _exploIndex;

		private bool _isManualFire;

		public void SetManualFire()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void Awake()
		{
		}

		public void Hit(EnemyController enemyController)
		{
		}

		public override void ParadoxFire()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void ResetFiringTimer()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
