using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_DraculaHand_Weapon : Weapon
	{
		private TP_DraculaHand_Projectile[] _hands;

		private int _nextHandToMove;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateHands()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
