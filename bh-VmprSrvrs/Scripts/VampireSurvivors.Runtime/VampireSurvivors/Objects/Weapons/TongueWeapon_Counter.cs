using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class TongueWeapon_Counter : TongueWeapon
	{
		protected override WeaponType _counterWeaponType => default(WeaponType);

		public override float forwardFacing => 0f;

		public override void CheckArcanas()
		{
		}
	}
}
