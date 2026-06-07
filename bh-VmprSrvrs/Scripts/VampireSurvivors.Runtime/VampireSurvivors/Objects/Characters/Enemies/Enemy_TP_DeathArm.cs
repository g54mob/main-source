using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_DeathArm : EnemyController
	{
		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
