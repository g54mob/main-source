using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDiamondTint_Axe : EnemyDiamondTint
	{
		protected override bool IsImmovable => false;

		protected override bool IsAxe => false;

		protected override bool IsSnake => false;

		protected override bool DoBaseUpdate => false;

		protected override uint[] TintProgression => null;

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}
	}
}
