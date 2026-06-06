using UnityEngine;

namespace MalbersAnimations.Weapons
{
	public enum WeaponOption
	{
		[InspectorName("Weapon/Equip")]
		Equip = 0,
		[InspectorName("Weapon/Unequip")]
		Unequip = 1,
		[InspectorName("Projectile/Equip")]
		EquipProjectile = 2,
		[InspectorName("Projectile/Fire-Release")]
		FireProjectile = 3,
		[InspectorName("Fire Weapon/Reload")]
		Reload = 4,
		[InspectorName("Fire Weapon/Finish Reload")]
		FinishReload = 5,
		[InspectorName("Weapon/Exit By Animation")]
		ExitByAnimation = 6,
		[InspectorName("Weapon/Check Aiming")]
		CheckAim = 7,
		[InspectorName("Weapon/Sound")]
		PlaySound = 8,
		[InspectorName("Weapon/Use Free Hand")]
		UseFreeHand = 9,
		[InspectorName("Weapon/Release Free Hand")]
		ReleaseFreeHand = 10,
		[InspectorName("Weapon/Aim")]
		Aim = 11
	}
}
