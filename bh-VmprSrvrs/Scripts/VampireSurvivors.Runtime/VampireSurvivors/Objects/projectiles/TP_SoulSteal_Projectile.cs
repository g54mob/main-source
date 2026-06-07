using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SoulSteal_Projectile : Projectile
	{
		private bool _tryAgain;

		private int _tries;

		private List<PhaserSprite> explosionSprites;

		private int _exploIndex;

		private TP_SoulSteal_Weapon _soulStealWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void DoSoulSteal(List<EnemyController> enemies)
		{
		}

		private void DoSoulStealAgain(List<EnemyController> enemies)
		{
		}

		private void CheckForDoSoulStealAgain(List<EnemyController> enemies)
		{
		}

		public bool CheckHeart()
		{
			return false;
		}
	}
}
