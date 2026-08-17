using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUnlock : BaseInteractable
{
	public UnlockableBase unlock;

	public GameObject fx;

	public RawImage icon;

	private bool done;

	public bool useUnlock = true;

	private new void Start()
	{
		base.Start();
		Texture texture = unlock.GetIcon();
		icon.texture = texture;
	}

	public override bool Interact()
	{
		//IL_0582: Expected I4, but got O
		//IL_00cd: Expected I, but got O
		//IL_00d5: Expected I, but got O
		//IL_00e5: Expected O, but got I
		//IL_01ff: Expected I, but got O
		//IL_020f: Expected O, but got I
		//IL_0312: Expected I, but got O
		//IL_0322: Expected O, but got I
		//IL_0121: Expected O, but got I
		//IL_040e: Expected I, but got O
		//IL_041e: Expected O, but got I
		//IL_024b: Expected O, but got I
		//IL_035e: Expected O, but got I
		//IL_045a: Expected O, but got I
		if (!done)
		{
			bool flag = !useUnlock;
			done = true;
			if (flag)
			{
				goto IL_0096;
			}
			if ((object)unlock != null)
			{
				MyAchievement unlockRequirement = unlock.GetUnlockRequirement();
				if ((object)unlockRequirement != null)
				{
					bool flag2 = MyAchievements.TryUnlock(unlockRequirement.internalName);
					goto IL_0096;
				}
			}
			goto IL_0574;
		}
		return false;
		IL_0574:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_04c7:
		if ((object)fx != null)
		{
			Transform transform = fx.transform;
			if ((object)transform != null)
			{
				transform.parentInternal = null;
				if ((object)fx != null)
				{
					fx.SetActive(value: true);
					GameObject obj = base.gameObject;
					UnityEngine.Object.Destroy(obj);
					return true;
				}
			}
		}
		goto IL_0574;
		IL_0096:
		TomeData tomeData = (TomeData)unlock;
		if ((object)unlock != null)
		{
			nint num = (nint)typeof(WeaponData);
			nint num2 = (nint)tomeData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v9 (Il2CppClass<WeaponData>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v9 (Il2CppClass<WeaponData>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v47+FFFFFFF8+v387 @ rax_v15*8]");
				if (0 == (nint)typeof(WeaponData))
				{
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory = instance.inventory;
						if (instance.inventory != null && (object)DataManager.Instance != null)
						{
							WeaponData weapon = DataManager.Instance.GetWeapon((EWeapon)tomeData.eTome);
							if (inventory.weaponInventory != null)
							{
								inventory.weaponInventory.AddWeapon(weapon, null);
								goto IL_04c7;
							}
						}
					}
					goto IL_0574;
				}
			}
			nint num4 = (nint)typeof(TomeData);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v10 (Il2CppClass<TomeData>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v10 (Il2CppClass<TomeData>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v38+FFFFFFF8+v483 @ rax_v17*8]");
				if (0 == (nint)typeof(TomeData))
				{
					MyPlayer instance2 = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory2 = instance2.inventory;
						if (instance2.inventory != null)
						{
							List<StatModifier> upgradeOffer = ((TomeData)unlock).GetUpgradeOffer(ERarity.New);
							if (inventory2.tomeInventory != null)
							{
								inventory2.tomeInventory.AddTome((TomeData)unlock, upgradeOffer, ERarity.New);
								goto IL_04c7;
							}
						}
					}
					goto IL_0574;
				}
			}
			nint num6 = (nint)typeof(ItemData);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v11 (Il2CppClass<ItemData>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v11 (Il2CppClass<ItemData>)+130]");
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v29+FFFFFFF8+v537 @ rax_v19*8]");
				if (0 == (nint)typeof(ItemData))
				{
					MyPlayer instance3 = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory3 = instance3.inventory;
						if (instance3.inventory != null && inventory3.itemInventory != null)
						{
							ItemInventory itemInventory = inventory3.itemInventory;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdi_v3 (TomeData)+54]");
							itemInventory.AddItem(EItem.Key);
							goto IL_04c7;
						}
					}
					goto IL_0574;
				}
			}
			nint num8 = (nint)typeof(HatData);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v12 (Il2CppClass<HatData>)+130]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v12 (Il2CppClass<HatData>)+130]");
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v5 (Il2CppClass<TomeData>)+C8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v22+FFFFFFF8+v415 @ rax_v21*8]");
				if (0 == (nint)typeof(HatData))
				{
					MyPlayer instance4 = MyPlayer.Instance;
					if ((object)MyPlayer.Instance == null || (object)instance4.playerRenderer == null)
					{
						goto IL_0574;
					}
					instance4.playerRenderer.SetHat((HatData)unlock);
				}
			}
		}
		goto IL_04c7;
	}

	public override string GetInteractString()
	{
		if ((object)unlock != null)
		{
			return unlock.GetName();
		}
		return (string)(object)new NullReferenceException();
	}

	public InteractableUnlock()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
