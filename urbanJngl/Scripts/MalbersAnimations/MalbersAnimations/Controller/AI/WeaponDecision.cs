using MalbersAnimations.Weapons;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Arrived to Target", order = -100)]
	public class WeaponDecision : MAIDecision
	{
		public enum WeaponDecisionOptions
		{
			WeaponEquipped = 0,
			WeaponIs = 1,
			IsReloading = 2,
			IsAiming = 3,
			IsAttacking = 4,
			AmmoInChamber = 5,
			TotalAmmo = 6,
			ChamberSize = 7
		}

		public Affected CheckOn;

		public WeaponDecisionOptions weapon = WeaponDecisionOptions.WeaponIs;

		[Hide("weapon", new int[] { 1 })]
		public WeaponID weaponType;

		[Hide("weapon", new int[] { 5, 6, 7 })]
		public ComparerInt comparer;

		[Hide("weapon", new int[] { 5, 6, 7 })]
		public int value;

		public override string DisplayName => "Weapon/Check Weapon";

		public override void PrepareDecision(MAnimalBrain brain, int Index)
		{
			switch (CheckOn)
			{
			case Affected.Self:
				brain.DecisionsVars[Index].mono = brain.Animal.FindComponent<MWeaponManager>();
				break;
			case Affected.Target:
				brain.DecisionsVars[Index].mono = brain.Target.FindComponent<MWeaponManager>();
				break;
			}
		}

		public override bool Decide(MAnimalBrain brain, int index)
		{
			MWeaponManager mWeaponManager = brain.DecisionsVars[index].mono as MWeaponManager;
			if (mWeaponManager == null)
			{
				return false;
			}
			switch (weapon)
			{
			case WeaponDecisionOptions.WeaponEquipped:
				return mWeaponManager.Weapon != null;
			case WeaponDecisionOptions.WeaponIs:
				if (mWeaponManager.Weapon == null)
				{
					return false;
				}
				return mWeaponManager.Weapon.WeaponID == (int)weaponType;
			case WeaponDecisionOptions.IsReloading:
				return mWeaponManager.IsReloading;
			case WeaponDecisionOptions.AmmoInChamber:
				if (mWeaponManager.Weapon != null && mWeaponManager.Weapon is MShootable mShootable2)
				{
					return mShootable2.AmmoInChamber.CompareInt(value, comparer);
				}
				return false;
			case WeaponDecisionOptions.TotalAmmo:
				if (mWeaponManager.Weapon != null && mWeaponManager.Weapon is MShootable mShootable3)
				{
					return mShootable3.TotalAmmo.CompareInt(value, comparer);
				}
				return false;
			case WeaponDecisionOptions.ChamberSize:
				if (mWeaponManager.Weapon != null && mWeaponManager.Weapon is MShootable mShootable)
				{
					return mShootable.ChamberSize.CompareInt(value, comparer);
				}
				return false;
			case WeaponDecisionOptions.IsAiming:
				return mWeaponManager.Aim;
			case WeaponDecisionOptions.IsAttacking:
				return mWeaponManager.IsAttacking;
			default:
				return false;
			}
		}
	}
}
