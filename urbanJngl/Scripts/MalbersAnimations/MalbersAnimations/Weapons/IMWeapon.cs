using System;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	public interface IMWeapon : IMDamager, IMLayer, IObjectCore
	{
		WeaponID WeaponType { get; }

		int WeaponID { get; }

		int HolsterID { get; }

		string Description { get; }

		bool IsRightHanded { get; }

		bool Automatic { get; set; }

		float MinDamage { get; }

		float MaxDamage { get; }

		float MinForce { get; }

		float MaxForce { get; }

		bool IsEquiped { get; set; }

		bool Input { get; set; }

		AimSide AimSide { get; set; }

		Transform AimOrigin { get; }

		IMWeaponOwner CurrentOwner { get; set; }

		Action<int> WeaponAction { get; set; }

		void ResetWeapon();

		void PlaySound(int ID);

		bool TryReload();
	}
}
