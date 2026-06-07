using UnityEngine;

namespace MalbersAnimations.Weapons
{
	public interface IWeaponManager
	{
		Transform transform { get; }

		MWeapon Weapon { get; }

		void Equip_Weapon();

		void Unequip_Weapon();

		void CheckAim();

		void FreeHandUse();

		void FreeHandRelease();

		void ExitByAnimation(bool value);

		void Aim_Set(bool value);
	}
}
