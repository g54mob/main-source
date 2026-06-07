using MalbersAnimations.Weapons;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Weapon Tasks", fileName = "new Weapon Task")]
	public class WeaponTask : MTask
	{
		[Tooltip("Play the mode only when the animal has arrived to the target")]
		public bool near;

		public BrainWeaponActions Actions = BrainWeaponActions.Attack;

		[Hide("Actions", new int[] { 2 })]
		public MWeapon Weapon;

		[Hide("Actions", new int[] { 0 })]
		public HolsterID HolsterID;

		[Hide("Actions", new int[] { 4 })]
		public bool AimValue = true;

		[Hide("Actions", new int[] { 0, 1 })]
		[Tooltip("Ingore Draw and Store weapon animations")]
		public bool IgnoreDrawStore;

		public override string DisplayName => "Weapons/Weapon Tasks";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			MWeaponManager componentInChildren = brain.Animal.GetComponentInChildren<MWeaponManager>();
			brain.TasksVars[index].mono = componentInChildren;
			if (near && !brain.AIControl.HasArrived)
			{
				return;
			}
			if ((bool)componentInChildren)
			{
				switch (Actions)
				{
				case BrainWeaponActions.Equip_Weapon:
					componentInChildren.Equip_External(Weapon);
					break;
				case BrainWeaponActions.Draw_Holster:
					componentInChildren.UnEquip_Fast();
					componentInChildren.IgnoreDraw = IgnoreDrawStore;
					componentInChildren.Holster_Equip(HolsterID);
					break;
				case BrainWeaponActions.Aim:
					componentInChildren.Aim_Set(AimValue);
					break;
				case BrainWeaponActions.Store_Weapon:
					componentInChildren.IgnoreStore = IgnoreDrawStore;
					componentInChildren.Aim_Set(value: false);
					componentInChildren.Store_Weapon();
					break;
				case BrainWeaponActions.Reload:
					componentInChildren.ReloadWeapon();
					break;
				case BrainWeaponActions.Unequip_Weapon:
					componentInChildren.UnEquip();
					brain.TaskDone(index);
					break;
				case BrainWeaponActions.StopAttack:
					if ((bool)componentInChildren.Weapon && componentInChildren.WeaponIsActive)
					{
						componentInChildren.MainAttackReleased();
					}
					break;
				case BrainWeaponActions.Attack:
					break;
				}
			}
			else
			{
				brain.TaskDone(index);
				Debug.Log("No Weapon Manager Found on the Animal", brain.Animal);
			}
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			if (near && !brain.AIControl.HasArrived && Actions != BrainWeaponActions.Attack)
			{
				return;
			}
			MWeaponManager mWeaponManager = brain.TasksVars[index].mono as MWeaponManager;
			if (!mWeaponManager)
			{
				return;
			}
			switch (Actions)
			{
			case BrainWeaponActions.Draw_Holster:
				if (mWeaponManager.DrawWeapon && mWeaponManager.WeaponAction == Weapon_Action.None)
				{
					mWeaponManager.UnEquip_Fast();
					mWeaponManager.IgnoreDraw = IgnoreDrawStore;
					mWeaponManager.Holster_Equip(HolsterID);
				}
				if ((int)mWeaponManager.ActiveHolster == (int)HolsterID && mWeaponManager.WeaponAction == Weapon_Action.Idle)
				{
					brain.TaskDone(index);
				}
				break;
			case BrainWeaponActions.Store_Weapon:
				if (mWeaponManager.WeaponAction == Weapon_Action.None)
				{
					brain.TaskDone(index);
				}
				break;
			case BrainWeaponActions.Aim:
				if ((bool)mWeaponManager.Weapon)
				{
					brain.TaskDone(index);
				}
				break;
			case BrainWeaponActions.Attack:
				if (near && !brain.AIControl.HasArrived)
				{
					mWeaponManager.MainAttackReleased();
					if ((bool)mWeaponManager.Weapon)
					{
						mWeaponManager.Weapon.Input = false;
					}
				}
				else if ((bool)mWeaponManager.Weapon)
				{
					if (mWeaponManager.Weapon is MMelee)
					{
						mWeaponManager.MainAttack();
					}
					else if (!mWeaponManager.Weapon.Input || (mWeaponManager.Weapon as MShootable).releaseProjectile == MShootable.Release_Projectile.OnAttackStart)
					{
						mWeaponManager.MainAttack();
					}
					else
					{
						mWeaponManager.MainAttackReleased();
					}
				}
				break;
			case BrainWeaponActions.Reload:
				if (!mWeaponManager.IsReloading)
				{
					brain.TaskDone(index);
				}
				break;
			case BrainWeaponActions.Equip_Weapon:
			case BrainWeaponActions.Unequip_Weapon:
			case BrainWeaponActions.StopAttack:
				break;
			}
		}

		private void Reset()
		{
			Description = "Use common Methods of the Weapon Manager to play on the AI Character";
		}
	}
}
