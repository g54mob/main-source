using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyReapperoni : EnemyController
	{
		private bool _legitKill;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void Die()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void HandleLegitKill()
		{
		}
	}
}
