using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class Battilia2Weapon : BattiliaWeapon
	{
		protected override BulletPool GetBulletPool()
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}
	}
}
