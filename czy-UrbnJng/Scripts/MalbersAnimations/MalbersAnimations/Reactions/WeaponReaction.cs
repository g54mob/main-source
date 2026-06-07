using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Weapon Manager/Equip", 0)]
	public class WeaponReaction : MReaction
	{
		public enum WeaponActions
		{
			Equip = 0,
			Unequip = 1,
			EquipFast = 2,
			UnequipFast = 3,
			HolsterClear = 4,
			HolsterClearAll = 5,
			NextHolster = 6,
			PreviousHolster = 7,
			ResetCombat = 8,
			StoreWeapon = 9,
			DrawWeapon = 10
		}

		public WeaponActions Actions;

		[Hide("Actions", new int[] { 0, 2 })]
		public GameObject Weapon;

		[Hide("Actions", new int[] { 4 })]
		public HolsterID Holster;

		protected override bool _TryReact(Component component)
		{
			MWeaponManager mWeaponManager = component as MWeaponManager;
			switch (Actions)
			{
			case WeaponActions.Equip:
				if (mWeaponManager.UseHolsters)
				{
					mWeaponManager.Holster_SetWeapon(Weapon);
				}
				else
				{
					mWeaponManager.Equip_External(Weapon);
				}
				break;
			case WeaponActions.Unequip:
				mWeaponManager.UnEquip();
				break;
			case WeaponActions.EquipFast:
				mWeaponManager.Equip_Fast(Weapon);
				break;
			case WeaponActions.UnequipFast:
				mWeaponManager.UnEquip_Fast();
				break;
			case WeaponActions.HolsterClear:
				mWeaponManager.Holster_Clear(Holster);
				break;
			case WeaponActions.HolsterClearAll:
				mWeaponManager.HolsterClearAll();
				break;
			case WeaponActions.NextHolster:
				mWeaponManager.Holster_Next();
				break;
			case WeaponActions.PreviousHolster:
				mWeaponManager.Holster_Previus();
				break;
			case WeaponActions.ResetCombat:
				mWeaponManager.ResetCombat();
				break;
			case WeaponActions.StoreWeapon:
				mWeaponManager.Store_Weapon();
				break;
			case WeaponActions.DrawWeapon:
				mWeaponManager.Draw_Weapon();
				break;
			}
			return true;
		}
	}
}
