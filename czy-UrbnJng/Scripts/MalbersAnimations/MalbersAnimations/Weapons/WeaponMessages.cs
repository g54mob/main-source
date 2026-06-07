using System;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	[Serializable]
	public class WeaponMessages
	{
		[HideInInspector]
		public string name;

		public WeaponOption Action;

		[Range(0f, 1f)]
		[Tooltip("Normalized Time. \n[0]: On State Enter\n[1]:On State Exit\n[0-1]: On State Update")]
		public float time;

		[Hide("Action", false, new int[] { 8 })]
		public int value;

		[Hide("Action", false, new int[] { 6 })]
		public bool exit = true;

		[Hide("Action", false, new int[] { 2 })]
		public bool equip = true;

		[Hide("Action", false, new int[] { 11 })]
		public bool aim;

		[Tooltip("Send the message anyway if the animation was interrupted and the time to send it was not reach")]
		public bool sendInterrupted = true;

		public bool MessageSent { get; set; }

		public void Execute(Animator anim, IWeaponManager manager, bool debug)
		{
			switch (Action)
			{
			case WeaponOption.Equip:
				manager.Equip_Weapon();
				break;
			case WeaponOption.Unequip:
				manager.Unequip_Weapon();
				break;
			case WeaponOption.EquipProjectile:
				if (manager.Weapon is MShootable mShootable4)
				{
					if (equip)
					{
						mShootable4.EquipProjectile();
					}
					else
					{
						mShootable4.DestroyProjectileInstance();
					}
				}
				break;
			case WeaponOption.FireProjectile:
				if (manager.Weapon is MShootable { ReleaseByAnimation: not false } mShootable)
				{
					mShootable.ReleaseProjectile();
				}
				break;
			case WeaponOption.Reload:
				if (manager.Weapon is MShootable mShootable3)
				{
					mShootable3.ReloadWeapon();
				}
				break;
			case WeaponOption.FinishReload:
				if (manager.Weapon is MShootable mShootable2)
				{
					mShootable2.FinishReload();
				}
				break;
			case WeaponOption.ExitByAnimation:
				manager.ExitByAnimation(exit);
				break;
			case WeaponOption.CheckAim:
				if (manager.Weapon != null)
				{
					manager.Weapon.CheckAim();
				}
				break;
			case WeaponOption.PlaySound:
				if (manager.Weapon != null)
				{
					manager.Weapon.PlaySound(value);
				}
				break;
			case WeaponOption.UseFreeHand:
				manager.FreeHandUse();
				break;
			case WeaponOption.ReleaseFreeHand:
				manager.FreeHandRelease();
				break;
			case WeaponOption.Aim:
				manager.Aim_Set(aim);
				break;
			}
			if (debug)
			{
				Debug.Log($"[{anim.name}] <B><color=red>**Weapon Message**:</color></B> <color=red>[{Action}]</color>", anim);
			}
			MessageSent = true;
		}
	}
}
