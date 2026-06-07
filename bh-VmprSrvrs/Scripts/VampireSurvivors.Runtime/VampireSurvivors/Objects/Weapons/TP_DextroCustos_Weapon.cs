using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_DextroCustos_Weapon : TP_Custos_Weapon
	{
		private const float YOffset = 0.25f;

		private bool _custos2Equipped;

		public float YOffsetFinal => 0f;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
