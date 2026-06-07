using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Axe1Weapon : EME_Weapon
	{
		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override float FinalGlimmerChance()
		{
			return 0f;
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		protected override void InitGlimmer2BulletPool()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
